using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PandoraBox.AppCode;
using MB;
public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "warning1",
                "<script>$(document).ready(function(){$(\"#loginPart\").slideDown(1500);});</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "warningshow",
                "<script>$(document).ready(function(){$(\"#loginPart\").show();});</script>");
        }
       TextBox1.Focus();
    }

    protected void Go_Click(object sender, ImageClickEventArgs e)
    {
        string userID = TextBox1.Text;
        string passwordInput = TextBox2.Text;
        //判断是否为空
        if (TextBox1.Text == "")
        {
            infoLabel.Text = "请输入您的邮箱";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Focus();
            return;
        }
        //判断用户名是否存在
        else if (!AppUserManage.isRegister(userID))
        {
            infoLabel.Text = "该邮箱还未注册";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        //判断密码是否为空
        else if (TextBox2.Text == "")
        {
            infoLabel.Text = "请输入您的密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Focus();
            return;
        }
        //向数据库登录
        bool result = AppUserManage.login(userID, passwordInput);
        //检查登录结果
        if (result == true)
        {
            //登录成功的操作
            Session["userID"] = TextBox1.Text;
            Session["isLogin"] = true;
            Session["currentTag"] = "所有";
            FormsAuthentication.SetAuthCookie(userID, false);
            Response.Redirect("~/Pages/HomePage.aspx");
        }
        else
        {
            //登录失败后的提示
            infoLabel.Text = "输入的密码不正确";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Text = "";
            TextBox2.Focus();
            return;
        }
    }

    protected void RegisterButton_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Write("<script>alert();</script>");
        Response.Redirect("~/Pages/Register.aspx");
        //Response.Redirect("~/Pages/ChatRoom.aspx?userID=badjoker&tagID=123");
    }

    protected void ForgetPassword_Click(object sender, ImageClickEventArgs e)
    {
        string userID = TextBox1.Text;
        if (userID == "")
        {
            //判断是否为空
            infoLabel.Text = "Forget？请先输入邮箱";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Focus();
            return;
        }
        else if (!AppUserManage.isRegister(userID))
        {
            //判断是否被注册
            TextBox1.Text = "该邮箱还未注册";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        else
        {
            //进入忘记密码页面
            Session["userID"] = TextBox1.Text;
            Response.Redirect("~/Pages/ForgetPW.aspx");
        }
    }
}