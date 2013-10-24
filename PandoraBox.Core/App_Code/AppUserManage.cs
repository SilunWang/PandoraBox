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
    /// 用户的个人信息类
    /// </summary>
    public class AppUser
    {

        #region 字段
        private string userID;
        private string password;
        private string passwordQuestion;
        private string passwordAnswer;
        private AppUserAuthority authority;
        private string name;
        private AppUserGender gender;
        private string school;
        private string department;
        private string userImagePath;
        private string limitTime;
        #endregion

        #region 属性
        /// <summary>
        /// 用户的ID
        /// </summary>
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// 用户的密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 用户的密码提示问题
        /// </summary>
        public string PasswordQuestion
        {
            get { return passwordQuestion; }
            set { passwordQuestion = value; }
        }

        /// <summary>
        /// 用户的密码提示答案
        /// </summary>
        public string PasswordAnswer
        {
            get { return passwordAnswer; }
            set { passwordAnswer = value; }
        }

        /// <summary>
        /// 用户的权限
        /// </summary>
        public AppUserAuthority Authority
        {
            get { return authority; }
            set { authority = value; }
        }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 用户的性别
        /// </summary>
        public AppUserGender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// 用户的学校
        /// </summary>
        public string School
        {
            get { return school; }
            set { school = value; }
        }

        /// <summary>
        /// 用户的专业
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        /// <summary>
        /// 用户头像所在路径
        /// </summary>
        public string UserImagePath
        {
            get 
            {
                if (userImagePath == null || userImagePath == "" )
                    return "../CSS/backgrounds/pandora.png";
                else 
                    return userImagePath; 
            }
            set { userImagePath = value; }
        }

        /// <summary>
        /// 用户开始被封的时间
        /// </summary>
        public string LimitTime
        {
            get { return limitTime; }
            set { limitTime = value; }
        }

        #endregion
    }

    /// <summary>
    /// 用户注册，登录，信息维护
    /// </summary>
    public class AppUserManage
    {
    
        /// <summary>
        /// 数据库对象
        /// </summary>
        private static DataBase data = new DataBase();

        /// <summary>
        /// 给一个用户名，返回一个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AppUser getUser(string userID)
        {
            AppUser result = null;
            //获取用户信息的数据集
            SqlParameter[] pramslog = {
            data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
			};
            SqlParameter[] pramsinfo = {
            data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
			};
            DataSet logSet = data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID)", pramslog, "userlog");
            DataSet infoSet = data.RunProcReturn("SELECT * FROM userinfo WHERE (userID = @userID)", pramsinfo, "userinfo");
            //检查是否取得信息
            if (logSet.Tables[0].Rows.Count > 0 && infoSet.Tables[0].Rows.Count > 0)
            {
                result = new AppUser();
                //获取用户id
                result.UserID = userID;
                //获取用户权限
                int userAuthorityInt = (int)logSet.Tables[0].Rows[0]["authority"];
                if (userAuthorityInt == 0)
                    result.Authority = AppUserAuthority.normal;
                else if (userAuthorityInt > 0)
                    result.Authority = AppUserAuthority.administrator;
                else
                {
                    DateTime limitTime = (DateTime)logSet.Tables[0].Rows[0]["limitTime"];
                    if (limitTime.AddDays(10) > DateTime.Now)
                    {
                        result.LimitTime = limitTime.ToShortDateString();
                        result.Authority = AppUserAuthority.limited;
                    }
                    else
                    {
                        result.Authority = AppUserAuthority.normal;
                        authorityUpdate(result.UserID, AppUserAuthority.normal);
                    }
                }
                //获取用户专业
                result.Department = infoSet.Tables[0].Rows[0]["department"].ToString();
                //获取用户性别
                string genderString = infoSet.Tables[0].Rows[0]["gender"].ToString();
                if (genderString == "男")
                    result.Gender = AppUserGender.male;
                else
                    result.Gender = AppUserGender.female;
                //获取用户昵称
                result.Name = infoSet.Tables[0].Rows[0]["name"].ToString();
                //获取用户密码
                result.Password = logSet.Tables[0].Rows[0]["password"].ToString();
                //获取用户密码提示答案
                result.PasswordAnswer = logSet.Tables[0].Rows[0]["answer"].ToString();
                //获取用户密码提示问题
                result.PasswordQuestion = logSet.Tables[0].Rows[0]["question"].ToString();
                //获取用户所在的学校
                result.School = infoSet.Tables[0].Rows[0]["school"].ToString();
                //获取用户头像地址
                result.UserImagePath = infoSet.Tables[0].Rows[0]["image"].ToString();
            }
            data.Close();
            return result;
        }

        /// <summary>
        /// 得到所有被封禁的用户
        /// </summary>
        /// <returns></returns>
        public static List<AppUser> getLimitUser()
        {
            List<AppUser> result = new List<AppUser>();
            SqlParameter[] prams = {
                data.MakeInParam("@authority", SqlDbType.Int, 0, -1)
			    };
            DataSet set = data.RunProcReturn("SELECT userID FROM userlog WHERE authority=@authority", prams, "userlog");
            data.Close();
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                result.Add(AppUserManage.getUser(set.Tables[0].Rows[i]["userID"] as string));
            return result;
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static void Logout(string userID)
        {
            //修改数据库中用户的登录状态为未登录
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@login", SqlDbType.Bit, 0, false)
                };
            data.RunProc("update userlog set login=@login where userID=@userID", prams);
            data.Close();
        }

        /// <summary>
        /// 管理员更改用户的权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public static bool authorityUpdate(string userID, AppUserAuthority authority)
        {
            bool succeed = false;
            //将权限转化为数字
            int authorityInt = 0;
            if (authority == AppUserAuthority.administrator)
                authorityInt = 1;
            else if (authority == AppUserAuthority.limited)
                authorityInt = -1;
            //更新数据库
            try
            {
                //获取时间
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //获得参数
                SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@authority", SqlDbType.Int, 0, authorityInt),
                data.MakeInParam("@limittime", SqlDbType.DateTime, 0, time)
			    };
                //检查执行是否成功
                int result = 0;
                if (authorityInt != -1)
                    result = data.RunProc("update userlog set authority=@authority,limittime=NULL where userID=@userID", prams);
                else
                    result = data.RunProc("update userlog set authority=@authority,limittime=@limittime where userID=@userID", prams);
                if (result != 0)
                    succeed = false;
                else
                    succeed = true;
            }
            catch (Exception)
            {
                succeed = false;
            }
            finally
            {
                data.Close();
            }
            return succeed;
        }

        /// <summary>
        /// 修改个人账户
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <returns></returns>
        public static bool userLogUpdate(string userID, 
            string password, string passwordQuestion, string passwordAnswer)
        {
            bool succeed = false;
            try
            {
                SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@password", SqlDbType.NVarChar, 50, password),
                data.MakeInParam("@question", SqlDbType.NVarChar, 50, passwordQuestion),
                data.MakeInParam("@answer", SqlDbType.NVarChar, 50, passwordAnswer)
			    };
                //检查执行是否成功
                int result = data.RunProc("update userlog set password=@password,question=@question,answer=@answer where userID=@userID", prams);
                if (result != 0)
                    succeed = false;
                else
                    succeed = true;
            }
            catch (Exception)
            {
                succeed = false;
            }
            finally
            {
                data.Close();
            }
            return succeed;
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="school"></param>
        /// <param name="department"></param>
        /// <param name="userImagePath"></param>
        /// <returns></returns>
        public static bool userInfoUpdate(string userID, string name,
            AppUserGender gender, string school, string department, string userImagePath)
        {
            bool succeed = false;
            string genderString;
            if (gender == AppUserGender.male)
                genderString = "男";
            else
                genderString = "女";
            try
            {
                SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@name", SqlDbType.NVarChar, 50, name),
                data.MakeInParam("@gender", SqlDbType.NVarChar, 50, genderString),
                data.MakeInParam("@school", SqlDbType.NVarChar, 50, school),
                data.MakeInParam("@department", SqlDbType.NVarChar, 50, department),
                data.MakeInParam("@image", SqlDbType.NVarChar, 50, userImagePath)
			    };
                //检查执行是否成功
                int result = data.RunProc("update userinfo set name=@name,gender=@gender,school=@school," +
                "department=@department,image=@image where userID=@userID", prams);
                if (result != 0)
                    succeed = false;
                else
                    succeed = true;
            }
            catch (Exception e)
            {
                succeed = false;
            }
            finally
            {
                data.Close();
            }
            return succeed;
        }

        /// <summary>
        /// 验证密码是否输入正确
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="passwordInput"></param>
        /// <returns></returns>
        public static bool verifyPassword(string userID, string passwordInput)
        {
            bool correct = false;
            SqlParameter[] prams = {
            data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
            data.MakeInParam("@password", SqlDbType.NVarChar, 50, passwordInput)
			};
            DataSet result =  data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID) AND (password = @password)", prams, "userlog");
            if (result.Tables[0].Rows.Count > 0)
                correct = true;
            else
                correct = false;
            data.Close();
            return correct;
        }

        /// <summary>
        /// 检查用户是否已经登录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool isLogin(string userID)
        {
            bool result = false;
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@login", SqlDbType.Bit, 0, true)
                };
            DataSet set = data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID) AND (login = @login)", prams, "userlog");
            if (set.Tables[0].Rows.Count > 0)
                result = true;
            else
                result = false;
            data.Close();
            return result;
        }

        public static string getPassword(string userID)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
			};
            DataSet result = data.RunProcReturn("SELECT * FROM userlog WHERE userID = @userID", prams, "userlog");
            return result.Tables[0].Rows[0]["password"].ToString();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="passwordInput"></param>
        /// <returns></returns>
        public static bool login(string userID, string passwordInput)
        {
            bool result = verifyPassword(userID, passwordInput);
            if (result == true)
            {
                //修改数据库中用户的登录状态为已经登录
                SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@login", SqlDbType.Bit, 0, true)
                };
                data.RunProc("update userlog set login=@login where userID=@userID", prams);
            }
            data.Close();
            return result;
        }

        public static bool register(string userID, string password, string question, string answer)
        {
            bool succeed = false;
            //一些对注册信息的判断
            if (isRegister(userID))
                return false;
            if (userID == "" || password == "" || question == "" || answer == "")
                return false;
            //注册，向数据库写入数据
            try
            {
                SqlParameter[] pramslog = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                data.MakeInParam("@password", SqlDbType.NVarChar, 50, password),
                data.MakeInParam("@question", SqlDbType.NVarChar, 50, question),
                data.MakeInParam("@answer", SqlDbType.NVarChar, 50, answer),
                data.MakeInParam("@authority", SqlDbType.Int, 0, 0),
                data.MakeInParam("@login", SqlDbType.Bit, 0, true)
                };
                SqlParameter[] pramsinfo = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID)
                };
                int resultlog = data.RunProc("INSERT INTO userlog (userID,password,question,answer,authority,login) VALUES(@userID,@password,@question,@answer,@authority,@login)", pramslog);
                int resultinfo = data.RunProc("INSERT INTO userinfo (userID) VALUES (@userID)", pramsinfo);
                //检查注册是否成功
                if (resultlog == 0 && resultinfo == 0)
                    succeed = true;
                else
                    succeed = false;
            }
            catch (Exception)
            {
                succeed = false;
            }
            finally
            {
                data.Close();
            }
            return succeed;
        }

        public static bool isRegister(string userID)
        {
            bool result = false;
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                };
            DataSet set = data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID)", prams, "userlog");
            if (set.Tables[0].Rows.Count > 0)
                result = true;
            else
                result = false;
            data.Close();
            return result;
        }

        /// <summary>
        /// 获取密码提示问题
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string getQuestion(string userID)
        {
            string result = null;
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                };
            DataSet set = data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID)", prams, "userlog");
            if (set.Tables[0].Rows.Count > 0)
                result = set.Tables[0].Rows[0]["question"] as string;
            else
                throw new Exception("用户不存在");
            data.Close();
            return result;
        }

        public static bool verifyQuestion(string userID, string answer)
        {
            string standard = null;
            SqlParameter[] prams = {
                data.MakeInParam("@userID", SqlDbType.NVarChar, 50, userID),
                };
            DataSet set = data.RunProcReturn("SELECT * FROM userlog WHERE (userID = @userID)", prams, "userlog");
            if (set.Tables[0].Rows.Count > 0)
                standard = set.Tables[0].Rows[0]["answer"] as string;
            else
                throw new Exception("用户不存在");
            data.Close();
            return (answer == standard);
        }
    }
}
