using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.IO;

namespace PandoraBox.AppCode
{
    /// <summary>
    /// 用户对某条状态的回复所对应的类
    /// </summary>
    public class AppResponse
    {
        #region 成员变量

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private int messageID;
        private int parentID;
        private string userImagePath;
        private string userName;
        private string userID;
        private string contents;
        private DateTime time;
        private bool isRead;
        private bool canBeDeleted;
        #endregion

        #region 属性
        /// <summary>
        /// 回复在数据库中的ID
        /// </summary>
        public int MessageID
        {
            get { return messageID; }
        }

        /// <summary>
        /// 回复的原状态在数据库中的ID
        /// </summary>
        public int ParentID
        {
            get { return parentID; }
        }

        /// <summary>
        /// 用户头像所在的文件位置
        /// </summary>
        public string UserImagePath
        {
            get
            {
                if (userImagePath == null || userImagePath == "")
                    return "../CSS/backgrounds/pandora.png";
                else
                    return userImagePath;
            }
        }

        /// <summary>
        /// 用户的昵称或邮箱
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }

        /// <summary>
        /// 回复的文本
        /// </summary>
        public string Contents
        {
            get { return contents; }
        }

        /// <summary>
        /// 回复的时间（字符串形式）
        /// </summary>
        public string TimeString
        {
            get { return time.ToString(); }
        }

        /// <summary>
        /// 回复的时间
        /// </summary>
        public DateTime Time
        {
            get { return time; }
        }

        /// <summary>
        /// 回复是否被读取
        /// </summary>
        public bool IsRead
        {
            get { return isRead; }
        }

        /// <summary>
        /// 回复是否可以被删除
        /// </summary>
        public bool CanBeDeleted
        {
            get { return canBeDeleted; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 从数据库中读取回复的id，构造一个回复对象
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="responseID"></param>
        public AppResponse(string userID, int responseID)
        {
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, responseID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM message WHERE (messageID = @messageID)", prams, "message");
            data.Close();
            //整理信息
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("没有检索到消息");
            DataRow row = set.Tables[0].Rows[0];
            //检查消息是否可以被删除
            this.canBeDeleted = false;
            if (userID != null && userID == (row["userID"] as string))
                canBeDeleted = true;
            if (userID != null && AppUserManage.getUser(userID).Authority == AppUserAuthority.administrator)
                canBeDeleted = true;
            //获取消息内容
            this.contents = row["contents"] as string;
            //判断消息是否已读
            this.isRead = (bool)row["isread"];
            //获取消息的ID
            this.messageID = (int)row["messageID"];
            //获取消息所在的父消息ID
            this.parentID = (int)row["parentID"];
            //获取时间
            this.time = (DateTime)row["time"];
            //获取用户头像
            this.userImagePath = row["userImage"] as string;
            //获取用户姓名
            string userIDGet = row["userID"] as string;
            string userNameGet = AppUserManage.getUser(userIDGet).Name;
            if (userNameGet != null && userNameGet != "")
                this.userName = userNameGet;
            else
                this.userName = userIDGet;
            //获取用户ID
            this.userID = userIDGet;
        }

        /// <summary>
        /// 删除指定id的状态
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool delete(int messageID)
        {
            //删除消息本身
            bool succeed = true;
            SqlParameter[] pramsDelete = {
			    data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
			    };
            int result = data.RunProc("delete from message where messageID=@messageID", pramsDelete);
            data.Close();
            if (result != 0)
                succeed = false;
            //删除子消息
            SqlParameter[] nextPrams = {
                data.MakeInParam("@parentID", SqlDbType.Int, 0, messageID)
                };
            DataSet nextSet = data.RunProcReturn("SELECT messageID FROM message WHERE (parentID = @parentID)", nextPrams, "message");
            data.Close();
            List<int> nextList = new List<int>();
            for (int i = 0; i < nextSet.Tables[0].Rows.Count; i++)
                nextList.Add((int)nextSet.Tables[0].Rows[i]["messageID"]);
            foreach (int nextID in nextList)
                succeed = succeed && delete(nextID);
            return succeed;
        }

        /// <summary>
        /// 得到这条消息的父消息ID
        /// </summary>
        /// <param name="responseID"></param>
        /// <returns></returns>
        public static int getFatherMessageID(int responseID)
        {
            int result = -1;
            AppResponse response = new AppResponse(null, responseID);
            result = response.parentID;
            return result;
        }

        /// <summary>
        /// 得到这条回复的最原始的MessageID
        /// </summary>
        /// <param name="responseID"></param>
        /// <returns></returns>
        public static int getResponseSource(int responseID)
        {
            int father = responseID;
            AppResponse response = null;
            while (father != -1)
            {
                response = new AppResponse(null, father);
                father = response.parentID;
            }
            return response.messageID;
        }
        #endregion
    }
}