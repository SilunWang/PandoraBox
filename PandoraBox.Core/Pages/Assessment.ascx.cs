using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_Assessment : System.Web.UI.UserControl
{

    private AppTeacherEvalution eva;
    private string userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (eva == null)
            return;
        if (eva.EnglishCourseName != null && eva.EnglishCourseName != "")
            Course.Text = "课程名：" + eva.CourseName + "(" + eva.EnglishCourseName + ")";
        else
            Course.Text = "课程名：" + eva.CourseName;
        CourseTeacher.Text = "教师：" + eva.TeacherName;
        if (eva.IsExam == false)
            CourseIsExam.Text = "考核方式：考察";
        else
            CourseIsExam.Text = "考核方式：考试";
        //课程教师评价的星星
        if (eva.ReputationInt == 0)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 1)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 2)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 3)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 4)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 5)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 6)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 7)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 8)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.ReputationInt == 9)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
        }
        if (eva.ReputationInt == 10)
        {
            this.grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        }

        //课程难度的评价
        if (eva.DifficultyInt == 0)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 1)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 2)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 3)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 4)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 5)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 6)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 7)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 8)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (eva.DifficultyInt == 9)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_5.png";
        }
        if (eva.DifficultyInt == 10)
        {
            this.difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        }
        //初始化您的打分
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] as string == "1")
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] as string == "2")
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] as string == "3")
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] as string == "4")
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] as string == "5")
        {
            this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        }


        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] as string == "1")
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] as string == "2")
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] as string == "3")
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] as string == "4")
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] as string == "5")
        {
            this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
            this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        }
    }

    public void initial(AppTeacherEvalution eva, string userID)
    {
        this.eva = eva;
        this.userID = userID;
    }

    protected void your_grade_star_1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addReputation(eva.TagID, 1);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva1(this.eva.TagID, Session["user"] as string, 1);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_grade_star_2_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addReputation(eva.TagID, 2);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva1(this.eva.TagID, Session["user"] as string, 2);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_grade_star_3_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addReputation(eva.TagID, 3);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva1(this.eva.TagID, Session["user"] as string, 3);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_grade_star_4_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addReputation(eva.TagID, 4);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva1(this.eva.TagID, Session["user"] as string, 4);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_grade_star_5_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva1-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addReputation(eva.TagID, 5);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva1(this.eva.TagID, Session["user"] as string, 5);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_difficulty_star_1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addDifficulty(eva.TagID, 1);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva2(this.eva.TagID, Session["user"] as string, 1);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_difficulty_star_2_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addDifficulty(eva.TagID, 2);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva2(this.eva.TagID, Session["user"] as string, 2);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_difficulty_star_3_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addDifficulty(eva.TagID, 3);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva2(this.eva.TagID, Session["user"] as string, 3);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_difficulty_star_4_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addDifficulty(eva.TagID, 4);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva2(this.eva.TagID, Session["user"] as string, 4);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }
    protected void your_difficulty_star_5_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-teva2-" + (Session["user"] as string)] == null)
            AppTeacherEvalution.addDifficulty(eva.TagID, 5);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel, UpdatePanel.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_teva2(this.eva.TagID, Session["user"] as string, 5);

        this.eva = new AppTeacherEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_difficulty_star_1.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_2.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_3.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_4.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
        this.your_difficulty_star_5.ImageUrl = "~/CSS/HomePage/Assessment/big_star_1.png";
    }

    private void invoke_teva1(int tagID, string userID, int score)
    {
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordTeacherScore1");
        mi.Invoke(page, new object[]{tagID, userID, score});
    }

    private void invoke_teva2(int tagID, string userID, int score)
    {
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordTeacherScore2");
        mi.Invoke(page, new object[] { tagID, userID, score });
    }
}