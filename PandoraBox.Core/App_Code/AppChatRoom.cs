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
    /// 聊天记录
    /// </summary>
    public class AppChatItem
    {
        #region 字段
        private int tagID;
        private string userID;
        private string userName;
        private string contents;
        private DateTime time;
        private static AppDataBase data = new AppDataBase();
        
        #endregion

        #region 属性
        public int TagID
        {
            get { return tagID; }
            set { tagID = value; }
        }
        /// <summary>
        /// 用户的昵称或邮箱
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }
        /// <summary>
        /// 发布的内容
        /// </summary>
        public string Contents
        {
            get { return contents; }
        }
        /// <summary>
        /// 发布的时间
        /// </summary>
        public DateTime Time
        {
            get { return time; }
        }

        /// <summary>
        /// 发布的时间（字符串形式）
        /// </summary>
        public string TimeString
        {
            get { return time.ToString(); }
        }

        #endregion

        #region 方法
        public AppChatItem(int tagID, string userID, string contents)
        {
            AppUser user = AppUserManage.getUser(userID);
            if (user.Name != null && user.Name != "")
                this.userName = user.Name;
            else
                this.userName = userID;
            this.tagID = tagID;
            this.userID = userID;
            this.contents = contents;
        }

        public bool insertDialog()
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID),
                data.MakeInParam("@userID", SqlDbType.NVarChar  ,50, userID),
                data.MakeInParam("@contents", SqlDbType.NVarChar, 400, contents),
                data.MakeInParam("@time", SqlDbType.DateTime, 0, time)
                };
            int result = data.RunProc("INSERT INTO chatroom (tagID,userID,contents,time) VALUES(@tagID,@userID,@contents,@time)", prams);
            data.Close();
            if (result == 0)
                return true;
            else
                return false;
        }
        #endregion
    }

    
    /// <summary>
    /// 聊天室类
    /// </summary>
    public class AppChatRoom
    {
        private static AppDataBase data = new AppDataBase();
        //public 
    }
}