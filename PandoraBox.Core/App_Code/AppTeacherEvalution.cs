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
    /// 对教师的评价类
    /// </summary>
    public class AppTeacherEvalution
    {

        #region 字段
        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private int tagID;
        private string courseName;
        private string englishCourseName;
        private string teacherName;
        private bool isExam;
        private float difficulty;
        private float reputation;
        private int[] difficultyDetail;
        private int[] reputationDetail;
        #endregion

        #region 属性
        /// <summary>
        /// 评价的ID号
        /// </summary>
        public int TagID
        {
            get { return tagID; }
        }

        /// <summary>
        /// 课程的中文名字
        /// </summary>
        public string CourseName
        {
            get { return courseName; }
        }

        /// <summary>
        /// 课程的英文名字
        /// </summary>
        public string EnglishCourseName
        {
            get { return englishCourseName; }
        }

        /// <summary>
        /// 课程的教师名字
        /// </summary>
        public string TeacherName
        {
            get { return teacherName; }
        }

        /// <summary>
        /// 是否考试
        /// </summary>
        public bool IsExam
        {
            get { return isExam; }
        }

        /// <summary>
        /// 课程难度，0分到10分，对应5颗星
        /// </summary>
        public int DifficultyInt
        {
            get { return (int)(difficulty * 2 + 0.5); }
        }

        /// <summary>
        /// 老师声誉，0分到10分，对应5颗星
        /// </summary>
        public float ReputationInt
        {
            get { return (int)(reputation * 2 + 0.5); }
        }

        /// <summary>
        /// 课程难度，打1颗星到5颗星的人数
        /// </summary>
        public int[] DifficultyDetail
        {
            get { return difficultyDetail; }
        }

        /// <summary>
        /// 教师声誉，打1颗星到5颗星的人数
        /// </summary>
        public int[] ReputationDetail
        {
            get { return reputationDetail; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 通过当前页面位置的ID读取教师评价信息
        /// </summary>
        /// <param name="currentTagID"></param>
        public AppTeacherEvalution(int currentTagID)
        {
            if (currentTagID == -1)
                throw new Exception("当前标签不存在ID");
            if (AppTag.getTagRank(currentTagID) != 4)
                throw new Exception("当前标签的级别不正确");
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, currentTagID),
                };
            DataSet set = data.RunProcReturn("SELECT * FROM course WHERE (tagID = @tagID)", prams, "course");
            data.Close();
            if (set.Tables[0].Rows.Count <= 0)
                throw new Exception("没有找到该课程");
            DataRow row = set.Tables[0].Rows[0];
            this.courseName = row["name"] as string;
            this.difficulty = (float)((Double)row["difficulty"]);
            if (this.difficulty <= float.Epsilon)
                this.difficulty = 3;
            this.difficultyDetail = new int[6];
            this.difficultyDetail[0] = 0;
            this.difficultyDetail[1] = (int)row["difficulty1"];
            this.difficultyDetail[2] = (int)row["difficulty2"];
            this.difficultyDetail[3] = (int)row["difficulty3"];
            this.difficultyDetail[4] = (int)row["difficulty4"];
            this.difficultyDetail[5] = (int)row["difficulty5"];
            this.englishCourseName = row["englishname"] as string;
            if (row["exam"].ToString().Contains("考察"))
                this.isExam = false;
            else
                this.isExam = true;
            this.reputation = (float)((Double)row["reputation"]);
            if (this.reputation <= float.Epsilon)
                this.reputation = 3;
            this.reputationDetail = new int[6];
            this.reputationDetail[0] = 0;
            this.reputationDetail[1] = (int)row["reputation1"];
            this.reputationDetail[2] = (int)row["reputation2"];
            this.reputationDetail[3] = (int)row["reputation3"];
            this.reputationDetail[4] = (int)row["reputation4"];
            this.reputationDetail[5] = (int)row["reputation5"];
            this.tagID = currentTagID;
            this.teacherName = row["teacher"] as string;
        }

        /// <summary>
        /// 给难度打分
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static bool addDifficulty(int courseID, int score)
        {
            bool succeed = false;
            AppTeacherEvalution eva = new AppTeacherEvalution(courseID);
            int totalScore = 0;
            int totalEva = 0;
            for (int i = 1; i < eva.difficultyDetail.Length; i++)
            {
                totalScore += eva.difficultyDetail[i] * i;
                totalEva += eva.difficultyDetail[i];
            }
            totalEva++;
            eva.difficultyDetail[score]++;
            totalScore += score;
            float difficulty = (float)totalScore / (float)totalEva;
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, courseID),
                data.MakeInParam("@difficulty", SqlDbType.Float, 0, (double)difficulty),
                data.MakeInParam("@difficulty1", SqlDbType.Int, 0, eva.difficultyDetail[1]),
                data.MakeInParam("@difficulty2", SqlDbType.Int, 0, eva.difficultyDetail[2]),
                data.MakeInParam("@difficulty3", SqlDbType.Int, 0, eva.difficultyDetail[3]),
                data.MakeInParam("@difficulty4", SqlDbType.Int, 0, eva.difficultyDetail[4]),
                data.MakeInParam("@difficulty5", SqlDbType.Int, 0, eva.difficultyDetail[5])
			    };
            //检查执行是否成功
            int result = data.RunProc("update course set difficulty=@difficulty,difficulty1=@difficulty1,difficulty2=@difficulty2,difficulty3=@difficulty3,difficulty4=@difficulty4,difficulty5=@difficulty5 where tagID=@tagID", prams);
            data.Close();
            if (result != 0)
                succeed = false;
            else
                succeed = true;
            return succeed;
        }

        /// <summary>
        /// 给教师水平打分
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static bool addReputation(int courseID, int score)
        {
            bool succeed = false;
            AppTeacherEvalution eva = new AppTeacherEvalution(courseID);
            int totalScore = 0;
            int totalEva = 0;
            for (int i = 1; i < eva.reputationDetail.Length; i++)
            {
                totalScore += eva.reputationDetail[i] * i;
                totalEva += eva.reputationDetail[i];
            }
            totalEva++;
            eva.reputationDetail[score]++;
            totalScore += score;
            float reputation = (float)totalScore / (float)totalEva;
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, courseID),
                data.MakeInParam("@reputation", SqlDbType.Float, 0, (double)reputation),
                data.MakeInParam("@reputation1", SqlDbType.Int, 0, eva.reputationDetail[1]),
                data.MakeInParam("@reputation2", SqlDbType.Int, 0, eva.reputationDetail[2]),
                data.MakeInParam("@reputation3", SqlDbType.Int, 0, eva.reputationDetail[3]),
                data.MakeInParam("@reputation4", SqlDbType.Int, 0, eva.reputationDetail[4]),
                data.MakeInParam("@reputation5", SqlDbType.Int, 0, eva.reputationDetail[5])
			    };
            //检查执行是否成功
            int result = data.RunProc("update course set reputation=@reputation,reputation1=@reputation1,reputation2=@reputation2,reputation3=@reputation3,reputation4=@reputation4,reputation5=@reputation5 where tagID=@tagID", prams);
            data.Close();
            if (result != 0)
                succeed = false;
            else
                succeed = true;
            return succeed;
        }
        #endregion
    }
}