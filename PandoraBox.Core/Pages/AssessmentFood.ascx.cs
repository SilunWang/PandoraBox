using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_AssessmentFood : System.Web.UI.UserControl
{
    private AppFoodEvalution eva;
    private string userID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (eva == null)
            return;
        if (eva.Where != null && eva.Where != "")
            Cantin.Text = "地点：" + eva.Where;
        Food_name.Text = "名称：" + eva.Name;
        //食品评价的星星
        if (eva.ReputationInt == 0)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 1)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_5.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 2)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 3)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_5.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 4)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 5)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_5.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 6)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 7)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_5.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 8)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (eva.ReputationInt == 9)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_5.png";
        }
        if (eva.ReputationInt == 10)
        {
            this.food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        }

        //初始化您的打分
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] as string == "1")
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] as string == "2")
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] as string == "3")
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] as string == "4")
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_0.png";
        }
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] as string == "5")
        {
            this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
            this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        }
    }

    public void initial(AppFoodEvalution eva, string userID)
    {
        this.eva = eva;
        this.userID = userID;
    }
    protected void your_food_grade_star_1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
            AppFoodEvalution.addReputation(eva.TagID, 1);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_feva(this.eva.TagID, Session["user"] as string, 1);

        AppFoodEvalution.addReputation(eva.TagID, 1);
        this.eva = new AppFoodEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
    }
    protected void your_food_grade_star_2_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
            AppFoodEvalution.addReputation(eva.TagID, 2);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_feva(this.eva.TagID, Session["user"] as string, 2);

        this.eva = new AppFoodEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
    }
    protected void your_food_grade_star_3_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
            AppFoodEvalution.addReputation(eva.TagID, 3);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_feva(this.eva.TagID, Session["user"] as string, 3);

        this.eva = new AppFoodEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
    }
    protected void your_food_grade_star_4_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
            AppFoodEvalution.addReputation(eva.TagID, 4);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_feva(this.eva.TagID, Session["user"] as string, 4);

        this.eva = new AppFoodEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
    }
    protected void your_food_grade_star_5_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[this.eva.TagID.ToString() + "-feva-" + (Session["user"] as string)] == null)
            AppFoodEvalution.addReputation(eva.TagID, 5);
        else
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('您已经打过分了！');", true);
            return;
        }
        invoke_feva(this.eva.TagID, Session["user"] as string, 5);

        this.eva = new AppFoodEvalution(eva.TagID);
        Page_Load(null, null);
        this.your_food_grade_star_1.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_2.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_3.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_4.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
        this.your_food_grade_star_5.ImageUrl = "~/CSS/HomePage/Assessment/large_star_1.png";
    }

    private void invoke_feva(int tagID, string userID, int score)
    {
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordFoodScore");
        mi.Invoke(page, new object[] { tagID, userID, score });
    }
}