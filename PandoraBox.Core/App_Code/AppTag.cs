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
    /// 与Tag相关的类
    /// </summary>
    public static class AppTag
    {
        private static DataBase data = new DataBase();

        /// <summary>
        /// 得到标签名字
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static string getTagName(int tagID)
        {
            if(tagID == -1)
                return null;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                };
            DataSet set = data.RunProcReturn("SELECT name FROM tag WHERE (tagID = @tagID)", prams, "tag");
            data.Close();
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("标签不存在");
            else
            {
                DataRow row = set.Tables[0].Rows[0];
                return row["name"] as string;
            }
        }

        /// <summary>
        /// 得到标签等级
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static int getTagRank(int tagID)
        {
            if (tagID == -1)
                return -1;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                };
            DataSet set = data.RunProcReturn("SELECT rank FROM tag WHERE (tagID = @tagID)", prams, "tag");
            data.Close();
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("标签不存在");
            else
            {
                DataRow row = set.Tables[0].Rows[0];
                return (byte)row["rank"];
            }
        }

        /// <summary>
        /// 得到标签父亲ID
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static int getTagParentID(int tagID)
        {
            if (tagID == -1)
                return -1;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                };
            DataSet set = data.RunProcReturn("SELECT parentID FROM tag WHERE (tagID = @tagID)", prams, "tag");
            data.Close();
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("标签不存在");
            else
            {
                DataRow row = set.Tables[0].Rows[0];
                return (int)row["parentID"];
            }
        }

        /// <summary>
        /// 得到标签图片的地址
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static string getTagImagePath(int tagID)
        {
            if (tagID == -1)
                return null;
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                };
            DataSet set = data.RunProcReturn("SELECT image FROM tag WHERE (tagID = @tagID)", prams, "tag");
            data.Close();
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("标签不存在");
            else
            {
                DataRow row = set.Tables[0].Rows[0];
                return row["image"] as string;
            }
        }

        /// <summary>
        /// 通过名字得到标签ID
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static int getTagID(string tagName)
        {
            if (tagName == "所有")
                throw new Exception("类别为所有，不存在标签");
            //从数据库中获取信息
            SqlParameter[] prams = {
                data.MakeInParam("@name", SqlDbType.NVarChar, 50, tagName)
                };
            DataSet set = data.RunProcReturn("SELECT tagID FROM tag WHERE (name = @name)", prams, "tag");
            data.Close();
            if (set.Tables[0].Rows.Count == 0)
                throw new Exception("标签不存在");
            else
                return (int)set.Tables[0].Rows[0]["tagID"];
        }

        public static List<string> getNextTags(string currentTag)
        {
            List<string> result = new List<string>();
            DataSet set = null;
            if (currentTag == "所有")
            {
                //从数据库中获取信息
                SqlParameter[] prams = {
                    data.MakeInParam("@parentID", SqlDbType.Int, 0, -1)
                    };
                set = data.RunProcReturn("SELECT name FROM tag WHERE (parentID = @parentID)", prams, "tag");
                data.Close();
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    result.Add(set.Tables[0].Rows[i]["name"] as string);
            }
            else
            {
                int currentTagID = getTagID(currentTag);
                SqlParameter[] prams = {
                    data.MakeInParam("@parentID", SqlDbType.Int, 0, currentTagID)
                    };
                set = data.RunProcReturn("SELECT name FROM tag WHERE (parentID = @parentID)", prams, "tag");
                data.Close();
                for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    result.Add(set.Tables[0].Rows[i]["name"] as string);
            }
            return result;
        }

        public static List<string> getAllTags()
        {
            List<string> result = new List<string>(); ;
            DataSet set = data.RunProcReturn("SELECT name FROM tag", "tag");
            data.Close();
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                result.Add(set.Tables[0].Rows[i]["name"] as string);
            result.Add("所有");
            return result;
        }

        public static bool isExists(string tag)
        {
            List<string> tags = getAllTags();
            if (tags.Contains(tag))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string addTags(string father, string currrent)
        {
            if (isExists(currrent))
                return "待添加标签已经存在";
            if(!isExists(father))
                return "父标签不存在";
            string name = currrent;
            int rank = 1;
            int parentID = -1;
            if (father != "所有")
            {
                rank = getTagRank(getTagID(father)) + 1;
                parentID = getTagID(father);
            }
            if (rank > 4)
                return "标签级数不能超过4";
            SqlParameter[] prams = {
                data.MakeInParam("@name", SqlDbType.NVarChar, 50, name),
                data.MakeInParam("@rank", SqlDbType.TinyInt, 0, rank),
                data.MakeInParam("@parentID", SqlDbType.Int, 0, parentID),
                };
            int result = data.RunProc("INSERT INTO tag (name,rank,parentID) VALUES (@name,@rank,@parentID)", prams);
            data.Close();
            if (result == 0)
            {
                //自动添加课程打分模块
                if(rank == 4 && getTagName(getTagParentID(getTagParentID(getTagID(father)))) == "课程")
                {
                    int ID = getTagID(currrent);
                    SqlParameter[] teacherParms = {
                        data.MakeInParam("@tagID", SqlDbType.Int, 0, ID),
                        data.MakeInParam("@name", SqlDbType.NVarChar, 50, father),
                        data.MakeInParam("@teacher", SqlDbType.NVarChar, 50, currrent),
                        data.MakeInParam("@exam", SqlDbType.NVarChar, 50, "考试")
                        };
                    result = data.RunProc("INSERT INTO course (tagID,name,teacher,exam) VALUES(@tagID,@name,@teacher,@exam)", teacherParms);
                    data.Close();
                }
                if(rank == 4 && getTagName(getTagParentID(getTagParentID(getTagID(father)))) == "饮食")
                {
                    int ID = getTagID(currrent);
                    SqlParameter[] foodParms = {
                        data.MakeInParam("@tagID", SqlDbType.Int, 0, ID),
                        data.MakeInParam("@name", SqlDbType.NVarChar, 50, currrent),
                        };
                    result = data.RunProc("INSERT INTO dish (tagID,name) VALUES(@tagID,@name)", foodParms);
                    data.Close();
                }
            }
            if(result == 0)
                return "添加成功";
            else
                return "添加失败";
        }

        public static string deleteTags(string currrent)
        {
            if (!isExists(currrent))
                return "该标签不存在";
            if (currrent == "所有")
                return "标签\"所有\"不能被删除";
            int tagID = getTagID(currrent);
            List<string> next = getNextTags(currrent);
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, tagID)
                };
            int result = data.RunProc("DELETE FROM tag WHERE (tagID=@tagID)", prams);
            if (result == 0)
            {
                foreach (string s in next)
                {
                    string output = deleteTags(s);
                    if (output != "删除成功")
                        result = 1;
                }
            }
            if (result == 0)
                return "删除成功";
            else
                return "删除失败";
        }
    }
}
