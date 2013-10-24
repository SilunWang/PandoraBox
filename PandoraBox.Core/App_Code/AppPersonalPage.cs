using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace PandoraBox.AppCode
{
    /// <summary>
    /// 用户个人页面
    /// </summary>
    public class AppPersonalPage
    {
        #region 字段

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private List<AppMessage> publishs;
        private List<AppMessage> favorites;
        private string userID;
        private string userImagePath;
        private string userName;
        private AppSortType sortType;
        #endregion

        #region 属性
        /// <summary>
        /// 用户发布的内容
        /// </summary>
        public List<AppMessage> Publishs
        {
            get { return publishs; }
        }
        /// <summary>
        /// 用户收藏的内容
        /// </summary>
        public List<AppMessage> Favorites
        {
            get { return favorites; }
        }

        /// <summary>
        /// 用户的ID
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }

        /// <summary>
        /// 用户的头像
        /// </summary>
        public string UserImagePath
        {
            get { return userImagePath; }
        }

        /// <summary>
        /// 用户的昵称或邮箱
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }

        /// <summary>
        /// 消息的排序方式
        /// </summary>
        public AppSortType SortType
        {
            get { return sortType; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 构造函数，根据用户ID和排序方式从数据库中读取个人发布的内容和收藏的内容
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="type"></param>
        public AppPersonalPage(string userID)
        {
            this.sortType = AppSortType.timeDescending;
            this.userID = userID;
            AppUser user = AppUserManage.getUser(userID);
            this.userImagePath = user.UserImagePath;
            this.userName = user.Name;
            if (this.userName == null || this.userName == "")
                this.userName = user.UserID;

            this.favorites = new List<AppMessage>();
            SqlParameter[] pramsFavorites = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
			};
            DataSet setFavorites = data.RunProcReturn("SELECT * FROM favorites WHERE (userID=@userID)", pramsFavorites, "favorites");
            data.Close();
            for (int i = 0; i < setFavorites.Tables[0].Rows.Count; i++)
            {
                string userIDAdd = setFavorites.Tables[0].Rows[i]["userID"] as string;
                int messageIDAdd = (int)setFavorites.Tables[0].Rows[i]["messageID"];
                AppMessage messageAdd = new AppMessage(userIDAdd, messageIDAdd, "所有");
                messageAdd.CanBeDeleted = true;
                this.favorites.Add(messageAdd);
            }
            AppHomePage.sortByTimeDescending(this.favorites);

            this.publishs = new List<AppMessage>();
            SqlParameter[] pramsPublishs = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@parentID", SqlDbType.Int, 0, -1)
			};
            DataSet setPublishs = data.RunProcReturn("SELECT * FROM message WHERE (userID=@userID) AND (parentID=@parentID)", pramsPublishs, "message");
            data.Close();
            for (int i = 0; i < setPublishs.Tables[0].Rows.Count; i++)
            {
                string userIDAdd = setPublishs.Tables[0].Rows[i]["userID"] as string;
                int messageIDAdd = (int)setPublishs.Tables[0].Rows[i]["messageID"];
                AppMessage messageAdd = new AppMessage(userIDAdd, messageIDAdd, "所有");
                messageAdd.CanBeDeleted = true;
                this.publishs.Add(messageAdd);
            }
            AppHomePage.sortByTimeDescending(this.publishs);

        }

        /// <summary>
        /// 从数据库中删除用户自己发布的内容
        /// </summary>
        /// <param name="messageID"></param>
        public static void deletePublish(int messageID)
        {
            AppMessage.deleteMessage(messageID);
        }

        /// <summary>
        /// 从数据库中删除用户自己收藏的内容
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageID"></param>
        public static void deleteFavorite(string userID, int messageID)
        {
            SqlParameter[] pramsDelete = {
			    data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
			    };
            int result = data.RunProc("delete from favorites where (messageID=@messageID) AND (userID=@userID)", pramsDelete);
            data.Close();
        }


        /// <summary>
        /// 按举报数量排序，会剔除没有被举报的信息
        /// </summary>
        /// <param name="messages"></param>
        public static void sortByReport(List<AppMessage> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j = i + 1; j < messages.Count; j++)
                {
                    if (messages[i].Report < messages[j].Report)
                    {
                        AppMessage tmp = messages[i];
                        messages[i] = messages[j];
                        messages[j] = tmp;
                    }
                }
            }
            for (int i = messages.Count - 1; i >= 0; i--)
                if (messages[i].Report == 0)
                    messages.RemoveAt(i);
        }

        #endregion
    }
}
