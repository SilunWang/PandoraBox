using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //检查是否是回调
        if (IsPostBack)
            return;
        //检查登录状态
        if (Session["isLogin"] == null || (bool)Session["isLogin"] != true)
            Response.Redirect("~/Pages/login.aspx");
        //获得当前用户信息
        string userID = Session["userID"] as string;
        AppUser user = AppUserManage.getUser(userID);
        NameText.Text = user.Name;
        if (user.Gender == AppUserGender.male)
            GenderDropBox.SelectedIndex = 0;
        else
            GenderDropBox.SelectedIndex = 1;
        SchoolText.Text = user.School;
        DepartText.Text = user.Department;
    }
    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        AppUserGender gender;
        if (GenderDropBox.SelectedIndex == 0)
            gender = AppUserGender.male;
        else
            gender = AppUserGender.female;
        bool succeed = AppUserManage.userInfoUpdate(userID, NameText.Text, gender, SchoolText.Text, DepartText.Text, "");
        if (succeed)
        {
            infoLabel.Text = "修改成功！三秒后跳转";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>"
            +"<script>var the_timeout; the_timeout = setTimeout(\"Refresh();\",3000); function Refresh(){window.location.href=\"HomePage.aspx\";}</script>");

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "warning3",
                "<script>alert(\"修改失败\");</script>");
            return;
        }
    }
    protected void PasswordButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/ChangePW.aspx");
    }
}