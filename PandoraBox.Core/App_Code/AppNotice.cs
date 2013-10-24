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
    /// 用户未读消息提醒页面
    /// </summary>
    public class AppNotice
    {
        #region 字段

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private List<AppMessage> messages;
        private string userID;
        private string userImagePath;
        private string userName;
        #endregion

        #region 属性
        /// <summary>
        /// 未读消息
        /// </summary>
        public List<AppMessage> Messages
        {
            get { return messages; }
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
        /// 用户的昵称或姓名
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 根据用户ID读取这个用户未读消息
        /// </summary>
        /// <param name="userID"></param>
        public AppNotice(string userID)
        {
            this.messages = new List<AppMessage>();
            //获取用户发送的消息
            SqlParameter[] publishPrams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
                };
            DataSet publishSet = data.RunProcReturn("SELECT messageID FROM message WHERE (userID = @userID)", publishPrams, "message");
            List<int> messagePublish = new List<int>();
            for(int i = 0; i < publishSet.Tables[0].Rows.Count; i++)
                messagePublish.Add((int)publishSet.Tables[0].Rows[i]["messageID"]);
            //获取用户未读的消息的ID
            List<int> messageUnread = new List<int>();
            foreach(int publishID in messagePublish)
            {
                SqlParameter[] unreadPrams = {
                    data.MakeInParam("@parentID", SqlDbType.Int, 0, publishID),
                    data.MakeInParam("@isread", SqlDbType.Bit, 0, false)
                };
                DataSet unreadSet = data.RunProcReturn("SELECT messageID FROM message WHERE (parentID = @parentID) AND (isread = @isread)", unreadPrams, "message");
                for (int i = 0; i < unreadSet.Tables[0].Rows.Count; i++)
                    messageUnread.Add((int)unreadSet.Tables[0].Rows[i]["messageID"]);
            }
            data.Close();
            //查找这些消息的源头
            List<int> messageSource = new List<int>();
            foreach (int unreadID in messageUnread)
            {
                int parentID = unreadID;
                AppMessage message = null;
                while (parentID != -1)
                {
                    message = new AppMessage(null, parentID, "所有");
                    parentID = message.ParentMessageID;
                }
                if (messageSource.Contains(message.MessageID))
                    continue;
                else
                    messageSource.Add(message.MessageID);
            }
            //将这些消息加载到List中
            foreach(int sourceID in messageSource)
                this.messages.Add(new AppMessage(null, sourceID, "所有"));
            //获取用户个人信息
            AppUser user = AppUserManage.getUser(userID);
            this.userID = user.UserID;
            this.userImagePath = user.UserImagePath;
            if (user.Name != null && user.Name != "")
                this.userName = user.Name;
            else
                this.userName = user.UserID;
        }

        /// <summary>
        /// 该用户未读的消息数目
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static int noticeNumber(string userID)
        {
            //获取用户发送的消息
            SqlParameter[] publishPrams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
                };
            DataSet publishSet = data.RunProcReturn("SELECT messageID FROM message WHERE (userID = @userID)", publishPrams, "message");
            List<int> messagePublish = new List<int>();
            for (int i = 0; i < publishSet.Tables[0].Rows.Count; i++)
                messagePublish.Add((int)publishSet.Tables[0].Rows[i]["messageID"]);
            //获取用户未读的消息的ID
            List<int> messageUnread = new List<int>();
            foreach (int publishID in messagePublish)
            {
                SqlParameter[] unreadPrams = {
                    data.MakeInParam("@parentID", SqlDbType.Int, 0, publishID),
                    data.MakeInParam("@isread", SqlDbType.Bit, 0, false)
                };
                DataSet unreadSet = data.RunProcReturn("SELECT messageID FROM message WHERE (parentID = @parentID) AND (isread = @isread)", unreadPrams, "message");
                for (int i = 0; i < unreadSet.Tables[0].Rows.Count; i++)
                    messageUnread.Add((int)unreadSet.Tables[0].Rows[i]["messageID"]);
            }
            data.Close();
            return messageUnread.Count;
        }

        /// <summary>
        /// 将消息标记为已读
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool deleteNotice(int messageID, string userID)
        {
            bool succeed = true;
            //将这条消息标记为已读
            SqlParameter[] thisPrams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@isread", SqlDbType.Bit, 0, true),
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
                };
            int result = data.RunProc("update message set isread=@isread where (messageID=@messageID) AND (userID<>@userID)", thisPrams);
            if (result != 0)
                succeed = false;
            //将这条消息的子消息都标记为已读
            SqlParameter[] nextPrams = {
                data.MakeInParam("@parentID", SqlDbType.Int, 0, messageID)
                };
            DataSet nextSet = data.RunProcReturn("SELECT messageID FROM message WHERE (parentID = @parentID)", nextPrams, "message");
            List<int> nextList = new List<int>();
            for (int i = 0; i < nextSet.Tables[0].Rows.Count; i++)
                nextList.Add((int)nextSet.Tables[0].Rows[i]["messageID"]);
            foreach (int nextID in nextList)
                succeed = succeed && deleteNotice(nextID, userID);
            return succeed;
        }
        #endregion
    }
}
