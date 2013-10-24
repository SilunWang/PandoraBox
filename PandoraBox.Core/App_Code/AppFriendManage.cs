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
    /// 好友管理类
    /// </summary>
    public static class AppFriendManage
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        /// <summary>
        /// user1关注user2
        /// </summary>
        /// <param name="user1ID"></param>
        /// <param name="user2ID"></param>
        /// <returns></returns>
        public static bool addAttention(string user1ID, string user2ID)
        {
            bool succeed = true;
            SqlParameter[] prams = {
                data.MakeInParam("@user1ID", SqlDbType.NVarChar, 50, user1ID),
                data.MakeInParam("@user2ID", SqlDbType.NVarChar, 50, user2ID)
                };
            int result = data.RunProc("INSERT INTO friends (user1ID,user2ID) VALUES (@user1ID,@user2ID)", prams);
            data.Close();
            if (result == 0)
                succeed = true;
            else
                succeed = false;
            return succeed;
        }

        /// <summary>
        /// 检查user1是否关注user2
        /// </summary>
        /// <param name="user1ID"></param>
        /// <param name="user2ID"></param>
        /// <returns></returns>
        public static bool isAttention(string user1ID, string user2ID)
        {
            SqlParameter[] prams = {
                data.MakeInParam("@user1ID", SqlDbType.NVarChar, 50, user1ID),
                data.MakeInParam("@user2ID", SqlDbType.NVarChar, 50, user2ID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM friends WHERE (user1ID=@user1ID) AND (user2ID=@user2ID)", prams, "friends");
            data.Close();

            if (set.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// user1不再关注user2
        /// </summary>
        /// <param name="user1ID"></param>
        /// <param name="user2ID"></param>
        /// <returns></returns>
        public static bool deleteAttention(string user1ID, string user2ID)
        {
            bool succeed = true;
            SqlParameter[] prams = {
                data.MakeInParam("@user1ID", SqlDbType.NVarChar, 50, user1ID),
                data.MakeInParam("@user2ID", SqlDbType.NVarChar, 50, user2ID)
                };
            int result = data.RunProc("DELETE FROM friends WHERE (user1ID=@user1ID) AND (user2ID=@user2ID)", prams);
            if (result == 0)
                succeed = true;
            else
                succeed = false;
            data.Close();
            return succeed;
        }

        /// <summary>
        /// 得到关注它的人
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<AppUser> getFans(string userID)
        {
            List<AppUser> result = new List<AppUser>();
            SqlParameter[] prams = {
                data.MakeInParam("@user2ID", SqlDbType.NVarChar, 50, userID)
                };
            DataSet set = data.RunProcReturn("SELECT user1ID FROM friends WHERE (user2ID=@user2ID)", prams, "friends");
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                result.Add(AppUserManage.getUser(set.Tables[0].Rows[i]["user1ID"] as string));
            data.Close();
            return result;
        }

        /// <summary>
        /// 得到它关注的人
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<AppUser> getAttentions(string userID)
        {
            List<AppUser> result = new List<AppUser>();
            SqlParameter[] prams = {
                data.MakeInParam("@user1ID", SqlDbType.NVarChar, 50, userID)
                };
            DataSet set = data.RunProcReturn("SELECT user2ID FROM friends WHERE (user1ID=@user1ID)", prams, "friends");
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                result.Add(AppUserManage.getUser(set.Tables[0].Rows[i]["user2ID"] as string));
            data.Close();
            return result;
        }

        /// <summary>
        /// 得到他关注的人的消息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<AppMessage> getAttentionsInfomation(string userID)
        {
            List<AppMessage> result = new List<AppMessage>();
            //得到这个人的关注
            List<AppUser> friends = getAttentions(userID);
            foreach (AppUser user in friends)
            {
                List<AppMessage> tmp = getUserInfomation(userID, user.UserID);
                result.AddRange(tmp);
            }
            AppHomePage.sortByTimeDescending(result);
            return result;
        }

        /// <summary>
        /// 得到一个人发的所有消息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<AppMessage> getUserInfomation(string myID, string userID)
        {
            List<AppMessage> result = new List<AppMessage>();
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@parentID", SqlDbType.Int, 0, -1)
                };
            DataSet set = data.RunProcReturn("SELECT messageID FROM message WHERE (userID=@userID) AND (parentID=@parentID)", prams, "message");
            data.Close();
            for(int i = 0; i < set.Tables[0].Rows.Count; i++)
                result.Add(new AppMessage(myID, (int)set.Tables[0].Rows[i]["messageID"], "所有"));
            return result;
        }
    }
}
