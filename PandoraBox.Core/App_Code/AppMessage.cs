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
    /// 消息类
    /// </summary>
    public class AppMessage
    {

        #region 字段

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private int messageID;
        private int parentMessageID;
        private string userImagePath;
        private string userName;
        private string userID;
        private string contents;
        private List<string> tags;
        private DateTime time;
        private bool canBeDeleted;
        private List<AppResponse> responses;
        private int up;
        private int down;
        private int report;
        private string enclosure;
        private string imagePath;
        #endregion

        #region 属性
        /// <summary>
        /// 消息在数据库中的id
        /// </summary>
        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }

        /// <summary>
        /// 这条消息的父消息ID
        /// </summary>
        public int ParentMessageID
        {
            get { return parentMessageID; }
        }

        /// <summary>
        /// 用户头像的文件位置
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
            set { userImagePath = value; }
        }

        /// <summary>
        /// 用户的昵称或邮箱
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 用户的ID
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }

        /// <summary>
        /// 用户发布的内容
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        /// <summary>
        /// 用户发布内容的标签（字符串形式）
        /// </summary>
        public string LastTag
        {
            get
            {
                string result = "";
                if (tags.Count > 0)
                    result += tags[tags.Count - 1];
                return result;
            }
        }

        /// <summary>
        /// 用户发布内容的标签
        /// </summary>
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        /// <summary>
        /// 用户发布消息的时间（字符串形式）
        /// </summary>
        public string TimeString
        {
            get { return time.ToString(); }
        }

        /// <summary>
        /// 用户发布消息的时间
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// 这条消息是否可以被删除
        /// </summary>
        public bool CanBeDeleted
        {
            get { return canBeDeleted; }
            set { canBeDeleted = value; }
        }

        /// <summary>
        /// 消息的回复集合
        /// </summary>
        public List<AppResponse> Responses
        {
            get { return responses; }
            set { responses = value; }
        }

        /// <summary>
        /// 顶这条消息的人数
        /// </summary>
        public int Up
        {
            get { return up; }
            set { up = value; }
        }

        /// <summary>
        /// 踩这条消息的人数
        /// </summary>
        public int Down
        {
            get { return down; }
            set { down = value; }
        }

        /// <summary>
        /// 举报这条消息的人数
        /// </summary>
        public int Report
        {
            get { return report; }
            set { report = value; }
        }

        /// <summary>
        /// 这条消息的附件位置
        /// </summary>
        public string Enclosure
        {
            get { return enclosure; }
            set { enclosure = value; }
        }

        /// <summary>
        /// 这条消息附属的图片位置
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 通过id，从数据库中构造这个状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageID"></param>
        /// <param name="currentTag"></param>
        public AppMessage(string userID, int messageID, string currentTag)
        {
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
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
            //获取踩的个数
            this.down = (int)row["down"];
            //获取附件位置
            this.enclosure = row["enclosure"] as string;
            //获取图片路径
            this.imagePath = row["image"] as string;
            //获取消息的ID
            this.messageID = (int)row["messageID"];
            //获取父消息ID
            this.parentMessageID = (int)row["parentID"];
            //获取举报个数
            this.report = (int)row["report"];
            //获取所有的回复
            {
                this.responses = new List<AppResponse>();
                getResponseRecurrence(this.messageID, this.responses);
                sortByTimeAscending(this.responses);
            }
            //获取消息标签
            {
                this.tags = new List<string>();
                int currentTagRank = 0;
                //如果数据库中存放的tagID是-1，则返回空
                string tag1 = AppTag.getTagName((int)row["tag1ID"]);
                string tag2 = AppTag.getTagName((int)row["tag2ID"]);
                string tag3 = AppTag.getTagName((int)row["tag3ID"]);
                string tag4 = AppTag.getTagName((int)row["tag4ID"]);
                if (currentTag != "所有")
                    currentTagRank = AppTag.getTagRank(AppTag.getTagID(currentTag));
                if (currentTagRank <= 0)
                    tags.Add("所有");
                if (currentTagRank <= 1 && tag1 != null && tag1 != "")
                    tags.Add(tag1);
                if (currentTagRank <= 2 && tag2 != null && tag2 != "")
                    tags.Add(tag2);
                if (currentTagRank <= 3 && tag3 != null && tag3 != "")
                    tags.Add(tag3);
                if (currentTagRank <= 4 && tag4 != null && tag4 != "")
                    tags.Add(tag4);
            }
            //获取时间
            this.time = (DateTime)row["time"];
            //获取顶的个数
            this.up = (int)row["up"];
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
        /// 按时间倒序排序
        /// </summary>
        /// <param name="response"></param>
        public void sortByTimeAscending(List<AppResponse> response)
        {
            for (int i = 0; i < response.Count; i++)
            {
                for (int j = i + 1; j < response.Count; j++)
                {
                    if (response[i].Time > response[j].Time)
                    {
                        AppResponse tmp = response[i];
                        response[i] = response[j];
                        response[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 比较两个字符串大小
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int compare(string a, string b)
        {
            if (a == b)
                return 0;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                if (a[i] < b[i])
                    return -1;
                if (a[i] > b[i])
                    return 1;
            }
            if (a.Length < b.Length)
                return -1;
            if (a.Length > b.Length)
                return 1;
            return 0;
        }

        /// <summary>
        /// 递归的获取一条消息的回复
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="responses"></param>
        private void getResponseRecurrence(int parentID, List<AppResponse> responses)
        {
            SqlParameter[] prams = {
                    data.MakeInParam("@parentID", SqlDbType.Int, 0, parentID)
                    };
            DataSet set = data.RunProcReturn("SELECT messageID FROM message WHERE (parentID = @parentID)", prams, "message");
            data.Close();
            List<int> next = new List<int>();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                next.Add((int)row["messageID"]);
                responses.Add(new AppResponse(this.userID, (int)row["messageID"]));
            }
            //继续递归
            foreach (int ID in next)
                getResponseRecurrence(ID, responses);
        }

        /// <summary>
        /// 增加顶
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool plusUp(int messageID)
        {
            bool succeed = false;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM message WHERE (messageID = @messageID)", prams, "message");
            data.Close();
            //得到当前顶的个数
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("当前状态不存在");
            int currentUp = (int)set.Tables[0].Rows[0]["up"];
            currentUp++;
            //更新个数
            SqlParameter[] pramsUpdate = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@up", SqlDbType.Int, 0, currentUp)
                };
            int result = data.RunProc("update message set up=@up where messageID=@messageID", pramsUpdate);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 增加踩
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool plusDown(int messageID)
        {
            bool succeed = false;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM message WHERE (messageID = @messageID)", prams, "message");
            data.Close();
            //得到当前踩的个数
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("当前状态不存在");
            int currentDown = (int)set.Tables[0].Rows[0]["down"];
            currentDown++;
            //更新个数
            SqlParameter[] pramsUpdate = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@down", SqlDbType.Int, 0, currentDown)
                };
            int result = data.RunProc("update message set down=@down where messageID=@messageID", pramsUpdate);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 增加举报
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool plusReport(int messageID)
        {
            bool succeed = false;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM message WHERE (messageID = @messageID)", prams, "message");
            data.Close();
            //得到当前举报的个数
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("当前状态不存在");
            int currentReport = (int)set.Tables[0].Rows[0]["report"];
            currentReport++;
            //更新个数
            SqlParameter[] pramsUpdate = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@report", SqlDbType.Int, 0, currentReport)
                };
            int result = data.RunProc("update message set report=@report where messageID=@messageID", pramsUpdate);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 举报个数清0
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool clearReport(int messageID)
        {
            bool succeed = false;
            //更新个数
            SqlParameter[] pramsUpdate = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@report", SqlDbType.Int, 0, 0)
                };
            int result = data.RunProc("update message set report=@report where messageID=@messageID", pramsUpdate);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 收藏该状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageID"></param>
        public static bool collect(string userID, int messageID)
        {
            SqlParameter[] check = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM favorites WHERE (userID=@userID) AND (messageID=@messageID)", check, "favorites");
            if (set.Tables[0].Rows.Count != 0)
                return true;
            bool succeed = false;
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID)
                };
            int result = data.RunProc("INSERT INTO favorites (userID,messageID) VALUES (@userID,@messageID)", prams);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="messageID"></param>
        /// <returns></returns>
        public static bool deleteCollect(int messageID, string userID)
        {
            bool succeed = false;
            SqlParameter[] prams = {
                data.MakeInParam("@messageID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
                };
            int result = data.RunProc("delete from favorites where (messageID=@messageID) AND (userID=@userID)", prams);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 回复该状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageID"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static bool response(string userID, int messageID, string contents)
        {
            bool succeed = false;
            AppUser user = AppUserManage.getUser(userID);
            //找到这条消息相关的内容
            AppMessage tmp = new AppMessage(null, messageID, "所有");
            bool isRead = false;
            if (tmp.userID == userID)
            {
                //说明消息的主人是发送回复的主人
                isRead = true;
            }
            //获取时间
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //插入到数据库
            SqlParameter[] prams = {
                data.MakeInParam("@parentID", SqlDbType.Int, 0, messageID),
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@userimage", SqlDbType.NVarChar, 50, user.UserImagePath),
                data.MakeInParam("@isread", SqlDbType.Bit, 0, isRead),
                data.MakeInParam("@contents", SqlDbType.NVarChar, 200, contents),
                data.MakeInParam("@time", SqlDbType.DateTime, 0, time)
            };
            int result = data.RunProc("INSERT INTO message (parentID,userID,userimage,isread,contents,time) VALUES(@parentID,@userID,@userimage,@isread,@contents,@time)", prams);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 删除这条状态
        /// </summary>
        /// <param name="messageID"></param>
        public static bool deleteMessage(int messageID)
        {
            bool succeed = false;
            //删除消息和删除回复原理是一样的
            succeed = AppResponse.delete(messageID);
            return succeed;
        }

        #endregion
    }
}