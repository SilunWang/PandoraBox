using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PandoraBox.AppCode;

public partial class Pages_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "warning",
                    "<script>scscms_alert(\"Allen\");</script>");
        if (IsPostBack)
            return;
        TextBox1.Focus();
    }
    protected override void OnPreRender(EventArgs args)
    {
        base.OnPreRender(args);
        TextBox2.Attributes["value"] = TextBox2.Text;
        TextBox3.Attributes["value"] = TextBox3.Text;
    }
    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        //获取注册信息
        string userID = TextBox1.Text;
        string password = TextBox2.Text;
        string repeat = TextBox3.Text;
        string question = TextBox4.Text;
        string answer = TextBox5.Text;
        if (userID == "")
        {
            infoLabel.Text = "请输入您的邮箱";
            ClientScript.RegisterStartupScript(this.GetType(), "warning2", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Focus();
            return;
        }
        else if (!userID.Contains("@") || (!userID.Contains(".com") && !userID.Contains(".cn") && !userID.Contains(".edu") && !userID.Contains(".org")))
        {
            infoLabel.Text = "您输入的邮箱不合法，请重新输入";
            ClientScript.RegisterStartupScript(this.GetType(), "warning3", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        else if (password == "")
        {
            infoLabel.Text = "请输入您的密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning4", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Focus();
            return;
        }
        else if (repeat == "")
        {
            infoLabel.Text = "请再次输入您的密码";
            ClientScript.RegisterStartupScript(this.GetType(), "warning5", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox3.Focus();
            return;
        }
        else if (!password.Equals(repeat))
        {
            infoLabel.Text = "两次密码输入不一致";
            ClientScript.RegisterStartupScript(this.GetType(), "warning6", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox2.Focus();
            return;
        }
        else if (question == "")
        {
            infoLabel.Text = "请输入密码提示问题";
            ClientScript.RegisterStartupScript(this.GetType(), "warning8", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox4.Focus();
            return;
        }
        else if (answer == "")
        {
            infoLabel.Text = "请输入密码提示答案";
            ClientScript.RegisterStartupScript(this.GetType(), "warning876", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox5.Focus();
            return;
        }
        else if (AppUserManage.isRegister(userID))
        {
            infoLabel.Text = "该邮箱已经被注册";
            ClientScript.RegisterStartupScript(this.GetType(), "warning76", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        else if (String.Compare(Session["code"].ToString(), TextBox6.Text, true) != 0)
        {
            infoLabel.Text = "验证码错误";
            ClientScript.RegisterStartupScript(this.GetType(), "warning777", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
            TextBox6.Text = "";
            TextBox6.Focus();
            return;
        }
        //注册
        bool succeed = AppUserManage.register(userID, password, question, answer);
        if (succeed)
        {
            Session["userID"] = TextBox1.Text;
            Session["isLogin"] = true;
            Session["currentTag"] = "所有";
            FormsAuthentication.SetAuthCookie(userID, false);
            Response.Redirect("~/Pages/PersonalInformation.aspx");
        }
        else
        {
            infoLabel.Text = "与服务器通讯出现问题，注册失败";
            ClientScript.RegisterStartupScript(this.GetType(), "warning888", "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
        }
    }
    
}