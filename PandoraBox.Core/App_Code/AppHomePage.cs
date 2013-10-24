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
    /// 主页类
    /// </summary>
    public class AppHomePage
    {
        #region 字段

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();
        /// <summary>
        /// 默认传送20条消息
        /// </summary>
        private const int MESSAGE_NUM = 20;
        private string userID;
        private string userImagePath;
        private string userName;
        private string currentTag;
        private AppEvaluationType evaType;
        private AppSortType sortType;
        private AppFoodEvalution foodEva;
        private AppTeacherEvalution teacherEva;
        #endregion

        #region 属性
        /// <summary>
        /// 所有消息的列表
        /// </summary>
        public List<AppMessage> Messages
        {
            get
            {
                //获得这一类别下的所有消息ID
                DataSet set;
                List<AppMessage> result = new List<AppMessage>();
                if (currentTag == "所有")
                {
                    set = data.RunProcReturn("SELECT messageID,parentID FROM message", "message");
                    data.Close();
                }
                else
                {
                    int tagID = AppTag.getTagID(currentTag);
                    SqlParameter[] prams = {
                        data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                        };
                    set = data.RunProcReturn("SELECT messageID,parentID FROM message WHERE (tag1ID = @tagID) OR (tag2ID = @tagID) OR (tag3ID = @tagID) OR (tag4ID = @tagID)", prams, "message");
                    data.Close();
                }
                //将Message加入到列表
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                {
                    int messageIDGet = (int)set.Tables[0].Rows[i]["messageID"];
                    int parentIDGet = (int)set.Tables[0].Rows[i]["parentID"];
                    if (parentIDGet == -1)
                        result.Add(new AppMessage(userID, messageIDGet, currentTag));
                }
                //排序
                if (this.sortType == AppSortType.timeDescending)
                    sortByTimeDescending(result);
                if (this.sortType == AppSortType.timeAscending)
                    sortByTimeAscending(result);
                if (this.sortType == AppSortType.hot)
                    sortByHot(result);
                return result;
            }
        }

        /// <summary>
        /// 给教师打分的对象引用
        /// </summary>
        public AppTeacherEvalution TeacherEva
        {
            get { return teacherEva; }
        }

        /// <summary>
        /// 给食品打分的对象引用
        /// </summary>
        public AppFoodEvalution FoodEva
        {
            get { return foodEva; }
        }

        /// <summary>
        /// 下一级位置列表
        /// </summary>
        public List<string> NextTags
        {
            get
            {
                //根据当前位置，从数据库中读出下一个可能的位置并返回
                List<string> result = new List<string>();
                if (currentTag == "所有")
                {
                    //取得所有1级标签
                    SqlParameter[] prams = {
                        data.MakeInParam("@rank", SqlDbType.TinyInt, 0, 1)
                        };
                    DataSet set = data.RunProcReturn("SELECT name FROM tag WHERE (rank = @rank)", prams, "tag");
                    data.Close();
                    //处理dataSet
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                        result.Add(set.Tables[0].Rows[i]["name"] as string);
                }
                else
                {
                    //取得下一级标签
                    int parentID = AppTag.getTagID(currentTag);
                    SqlParameter[] prams = {
                        data.MakeInParam("@parentID", SqlDbType.Int, 0, parentID)
                        };
                    DataSet set = data.RunProcReturn("SELECT name FROM tag WHERE (parentID = @parentID)", prams, "tag");
                    data.Close();
                    //处理dataSet
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                        result.Add(set.Tables[0].Rows[i]["name"] as string);
                }
                return result;
            }
        }

        /// <summary>
        /// 排序的方法
        /// </summary>
        public AppSortType SortType
        {
            get { return sortType; }
        }

        /// <summary>
        /// 评价的种类
        /// </summary>
        public AppEvaluationType EvaType
        {
            get { return evaType; }
        }

        /// <summary>
        /// 用户当前所在位置的ID
        /// </summary>
        public int CurrentTagID
        {
            get
            {
                if (currentTag == "所有")
                    throw new Exception("标签\"所有\"没有ID");
                else
                    return AppTag.getTagID(currentTag);
            }
        }

        /// <summary>
        /// 用户当前所在的位置
        /// </summary>
        public string CurrentTag
        {
            get { return currentTag; }
        }

        /// <summary>
        /// 用户昵称或邮箱
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }

        /// <summary>
        /// 用户头像所在位置
        /// </summary>
        public string UserImagePath
        {
            get { return userImagePath; }
        }

        /// <summary>
        /// 用户的ID
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }

        #endregion

        #region 方法
        
        /// <summary>
        /// 根据用户ID，用户当前所在的位置和排序方式显示页面
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="currentTag"></param>
        /// <param name="sortType"></param>
        public AppHomePage(string userID, string currentTag, AppSortType sortType)
        {
            this.currentTag = currentTag;
            this.evaType = AppEvaluationType.none;
            if (currentTag == "所有")
            {
                ;
            }
            else if (AppTag.getTagRank(AppTag.getTagID(currentTag)) < 4)
            {
                ;
            }
            else
            {
                //获得4级标签的ID
                int currentTagID = AppTag.getTagID(currentTag);
                //获得3级标签的ID
                int rank3ID = AppTag.getTagParentID(currentTagID);
                //获得2级标签的ID
                int rank2ID = AppTag.getTagParentID(rank3ID);
                //获得1级标签的ID
                int rank1ID = AppTag.getTagParentID(rank2ID);
                if (AppTag.getTagName(rank1ID) == "课程")
                    this.evaType = AppEvaluationType.teacher;
                if (AppTag.getTagName(rank1ID) == "饮食")
                    this.evaType = AppEvaluationType.food;
            }
            if (this.evaType == AppEvaluationType.food)
            {
                this.foodEva = new AppFoodEvalution(CurrentTagID);
            }
            if (this.evaType == AppEvaluationType.teacher)
            {
                this.teacherEva = new AppTeacherEvalution(CurrentTagID);
            }
            this.sortType = sortType;
            this.userID = userID;
            AppUser user = AppUserManage.getUser(userID);
            this.userImagePath = user.UserImagePath;
            if (user.Name != null && user.Name != "")
                this.userName = user.Name;
            else
                this.userName = user.UserID;
        }

        /// <summary>
        /// 根据当前位置得到上一层的位置
        /// </summary>
        /// <param name="currentTag"></param>
        /// <returns></returns>
        public static string getParentTag(string currentTag)
        {
            if (currentTag == "所有")
                return null;
            if (AppTag.getTagRank(AppTag.getTagID(currentTag)) == 1)
                return "所有";
            return AppTag.getTagName(AppTag.getTagParentID(AppTag.getTagID(currentTag)));
        }

        /// <summary>
        /// 用户发布一条消息，返回消息是否发布成功
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="contents"></param>
        /// <param name="currentTag"></param>
        /// <param name="imagePath"></param>
        /// <param name="enclosurePath"></param>
        /// <returns></returns>
        public static bool publishMessage(string userID, string contents, string currentTag, string imagePath, string enclosurePath)
        {
            bool succeed = false;
            AppUser user = AppUserManage.getUser(userID);
            //获得四级标签的内容
            int tag1ID = -1;
            int tag2ID = -1;
            int tag3ID = -1;
            int tag4ID = -1;
            if (currentTag == "所有")
            {
            }
            else if (AppTag.getTagRank(AppTag.getTagID(currentTag)) == 1)
            {
                tag1ID = AppTag.getTagID(currentTag);
            }
            else if (AppTag.getTagRank(AppTag.getTagID(currentTag)) == 2)
            {
                tag2ID = AppTag.getTagID(currentTag);
                tag1ID = AppTag.getTagParentID(tag2ID);
            }
            else if (AppTag.getTagRank(AppTag.getTagID(currentTag)) == 3)
            {
                tag3ID = AppTag.getTagID(currentTag);
                tag2ID = AppTag.getTagParentID(tag3ID);
                tag1ID = AppTag.getTagParentID(tag2ID);
            }
            else if (AppTag.getTagRank(AppTag.getTagID(currentTag)) == 4)
            {
                tag4ID = AppTag.getTagID(currentTag);
                tag3ID = AppTag.getTagParentID(tag4ID);
                tag2ID = AppTag.getTagParentID(tag3ID);
                tag1ID = AppTag.getTagParentID(tag2ID);
            }
            if (imagePath == null)
                imagePath = "";
            if (enclosurePath == null)
                enclosurePath = "";
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@userimage", SqlDbType.NVarChar, 50, user.UserImagePath),
                data.MakeInParam("@isread", SqlDbType.Bit, 0, true),
                data.MakeInParam("@contents", SqlDbType.NVarChar, 200, contents),
                data.MakeInParam("@tag1ID", SqlDbType.Int, 0, tag1ID),
                data.MakeInParam("@tag2ID", SqlDbType.Int, 0, tag2ID),
                data.MakeInParam("@tag3ID", SqlDbType.Int, 0, tag3ID),
                data.MakeInParam("@tag4ID", SqlDbType.Int, 0, tag4ID),
                data.MakeInParam("@image", SqlDbType.NVarChar, 150, imagePath),
                data.MakeInParam("@enclosure", SqlDbType.NVarChar, 150, enclosurePath),
                data.MakeInParam("@time",SqlDbType.DateTime, 0, time)
                };
            int result = data.RunProc("INSERT INTO message (userID,userimage,isread,contents,tag1ID,tag2ID,tag3ID,tag4ID,image,enclosure,time) VALUES(@userID,@userimage,@isread,@contents,@tag1ID,@tag2ID,@tag3ID,@tag4ID,@image,@enclosure,@time)", prams);
            data.Close();
            if (result == 0)
                succeed = true;
            return succeed;
        }


        /// <summary>
        /// 按时间倒序排序
        /// </summary>
        /// <param name="messages"></param>
        public static void sortByTimeDescending(List<AppMessage> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j = i + 1; j < messages.Count; j++)
                {
                    if (messages[i].Time < messages[j].Time)
                    {
                        AppMessage tmp = messages[i];
                        messages[i] = messages[j];
                        messages[j] = tmp;
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
        private static int compare(string a, string b)
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
        /// 按时间正序排序
        /// </summary>
        /// <param name="messages"></param>
        public static void sortByTimeAscending(List<AppMessage> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j = i + 1; j < messages.Count; j++)
                {
                    if (messages[i].Time > messages[j].Time)
                    {
                        AppMessage tmp = messages[i];
                        messages[i] = messages[j];
                        messages[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 按热度排序
        /// </summary>
        /// <param name="messages"></param>
        public static void sortByHot(List<AppMessage> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                for (int j = i + 1; j < messages.Count; j++)
                {
                    if (messages[i].Up + messages[i].Responses.Count < messages[j].Up + messages[j].Responses.Count)
                    {
                        AppMessage tmp = messages[i];
                        messages[i] = messages[j];
                        messages[j] = tmp;
                    }
                    else if ((messages[i].Up + messages[i].Responses.Count == messages[j].Up + messages[j].Responses.Count)
                        && compare(messages[i].TimeString, messages[j].TimeString) < 0)
                    {
                        AppMessage tmp = messages[i];
                        messages[i] = messages[j];
                        messages[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// 按相关度排序。注意：会删除不相关的内容
        /// </summary>
        /// <param name="message"></param>
        /// <param name="keyWord"></param>
        public void sortByRelevance(List<AppMessage> messages, string keyWord)
        {
            //检索
            List<AppMessage> result = new List<AppMessage>();
            List<int> number = new List<int>();
            foreach(AppMessage message in messages)
            {
                if(message.Contents.Contains(keyWord))
                {
                    result.Add(message);
                    number.Add(getfrequency(message.Contents, keyWord));
                }
            }
            //排序
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (number[i] < number[j])
                    {
                        int Itmp = number[i];
                        number[i] = number[j];
                        number[j] = Itmp;
                        AppMessage Mtmp = result[i];
                        result[i] = result[j];
                        result[j] = Mtmp;
                    }
                    else if(number[i] == number[j]
                        && compare(result[i].TimeString, result[j].TimeString) < 0)
                    {
                        int Itmp = number[i];
                        number[i] = number[j];
                        number[j] = Itmp;
                        AppMessage Mtmp = result[i];
                        result[i] = result[j];
                        result[j] = Mtmp;
                    }
                }
            }
            //重新赋值
            messages.Clear();
            foreach (AppMessage message in result)
                messages.Add(message);
        }

        private static int getfrequency(string contents, string keyword)
        {
            return contents.Split(new string[] { keyword }, StringSplitOptions.None).Length;
        }

        #endregion
    }
}