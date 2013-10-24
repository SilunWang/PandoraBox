using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Web.Security;

public partial class Pages_ChangePW : System.Web.UI.Page
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
        TextBox4.Text = user.PasswordQuestion;
        TextBox5.Text = user.PasswordAnswer;
        TextBox1.Focus();
    }
    protected override void OnPreRender(EventArgs args)
    {
        base.OnPreRender(args);
        TextBox1.Attributes["value"] = TextBox1.Text;
        TextBox2.Attributes["value"] = TextBox2.Text;
        TextBox3.Attributes["value"] = TextBox3.Text;
    }
    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        //验证原始密码
        if (TextBox1.Text == "")
        {
            infoLabel.Text = "请输入原密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Focus();
            return;
        }
        else if (!AppUserManage.verifyPassword(userID, TextBox1.Text))
        {
            infoLabel.Text = "原密码输入不正确";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        //对新密码的判断
        else if (TextBox2.Text == "")
        {
            infoLabel.Text = "请输入新密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Focus();
            return;
        }
        else if (TextBox3.Text == "")
        {
            infoLabel.Text = "请再次输入新密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox3.Focus();
            return;
        }
        else if (!TextBox3.Text.Equals(TextBox2.Text))
        {
            infoLabel.Text = "两次密码输入不一致";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox2.Focus();
            return;
        }
        //对密码提示问题和答案的判断
        else if (TextBox4.Text == "")
        {
            infoLabel.Text = "请输入密码提示问题";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox4.Focus();
            return;
        }
        else if (TextBox5.Text == "")
        {
            infoLabel.Text = "请输入密码提示问题答案";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox5.Focus();
            return;
        }
        bool succeed = AppUserManage.userLogUpdate(userID, TextBox2.Text, TextBox4.Text, TextBox5.Text);
        if (succeed)
        {
            infoLabel.Text = "修改密码成功";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            AppUserManage.Logout(Session["userID"] as string);
            Session["userID"] = null;
            Session["isLogin"] = false;
            Session["currentTag"] = null;
            FormsAuthentication.SignOut();
            Response.Write("<script>var the_timeout; the_timeout = setTimeout(\"Refresh();\",3000); function Refresh(){window.location.href=\"login.aspx\";}</script>");
        }
        else
        {
            infoLabel.Text = "修改密码失败 服务器错误";
            ClientScript.RegisterStartupScript(this.GetType(), "warning", 
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
        }
    }
   
}