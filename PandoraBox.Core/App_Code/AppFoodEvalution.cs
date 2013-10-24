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
    /// 对食物的评价类
    /// </summary>
    public class AppFoodEvalution
    {
        #region 字段

        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        private int tagID;
        private string name;
        private string where;
        private double reputation;
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
        /// 食物评价，0分到10分，对应5颗星
        /// </summary>
        public float ReputationInt
        {
            get { return (int)(reputation * 2 + 0.5); }
        }

        /// <summary>
        /// 食物评价，打1颗星到5颗星的人数
        /// </summary>
        public int[] ReputationDetail
        {
            get { return reputationDetail; }
        }

        /// <summary>
        /// 位置
        /// </summary>
        public string Where
        {
            get { return where; }
        }

        /// <summary>
        /// 食品名称
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 通过当前页面位置的ID读取食品评价信息
        /// </summary>
        /// <param name="currentTagID"></param>
        public AppFoodEvalution(int currentTagID)
        {
            if (currentTagID == -1)
                throw new Exception("当前标签不存在ID");
            if (AppTag.getTagRank(currentTagID) != 4)
                throw new Exception("当前标签的级别不正确");
            SqlParameter[] prams = {
                data.MakeInParam("@tagID", SqlDbType.Int, 0, currentTagID),
                };
            DataSet set = data.RunProcReturn("SELECT * FROM dish WHERE (tagID = @tagID)", prams, "dish");
            data.Close();
            if (set.Tables[0].Rows.Count <= 0)
                throw new Exception("没有找到该食品");
            DataRow row = set.Tables[0].Rows[0];
            this.name = row["name"] as string;
            this.where =  AppTag.getTagName(AppTag.getTagParentID(AppTag.getTagID(this.name)));
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
        }

        /// <summary>
        /// 给食物打分
        /// </summary>
        /// <param name="foodID"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static bool addReputation(int foodID, int score)
        {
            bool succeed = false;
            AppFoodEvalution eva = new AppFoodEvalution(foodID);
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
                data.MakeInParam("@tagID", SqlDbType.Int, 0, foodID),
                data.MakeInParam("@reputation", SqlDbType.Float, 0, (double)reputation),
                data.MakeInParam("@reputation1", SqlDbType.Int, 0, eva.reputationDetail[1]),
                data.MakeInParam("@reputation2", SqlDbType.Int, 0, eva.reputationDetail[2]),
                data.MakeInParam("@reputation3", SqlDbType.Int, 0, eva.reputationDetail[3]),
                data.MakeInParam("@reputation4", SqlDbType.Int, 0, eva.reputationDetail[4]),
                data.MakeInParam("@reputation5", SqlDbType.Int, 0, eva.reputationDetail[5])
			    };
            //检查执行是否成功
            int result = data.RunProc("update dish set reputation=@reputation,reputation1=@reputation1,reputation2=@reputation2,reputation3=@reputation3,reputation4=@reputation4,reputation5=@reputation5 where tagID=@tagID", prams);
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
