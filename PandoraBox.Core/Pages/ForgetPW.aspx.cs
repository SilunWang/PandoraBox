using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_ForgetPW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)

  {


        //检查登录状态
        if (Session["userID"] == null || !AppUserManage.isRegister(Session["userID"] as string))
            Response.Redirect("~/Pages/login.aspx");
        //获得密码提示问题
        string userID = Session["userID"] as string;
        TextBox1.Text = AppUserManage.getQuestion(userID);
        TextBox2.Focus();

    }
    
    protected void ForgetPassword_Click1(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        string answer = TextBox2.Text;
        bool correct = AppUserManage.verifyQuestion(userID, answer);
        if (correct)
        {
            //在此处填写找回密码成功后的操作
            //MessageBox b = new MessageBox(Context);
            //b.Show("bbb");
            infoLabel.Text = "密码成功找回！密码已发送至您的邮箱\n三秒后返回登录页面";
            String mystr = userID + "您好！\n" + "您的密码是：" + AppUserManage.getPassword(userID) + "\n欢迎关注潘多拉宝盒";
            EmailManager.SetContents(mystr);
            EmailManager.sendEmailTo(userID);
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>" +
                "<script>var the_timeout; the_timeout = setTimeout(\"Refresh();\",3000); function Refresh(){window.location.href=\"login.aspx\";}</script>");
        }
        else
        {
            //在此处填写找回密码失败后的操作
            infoLabel.Text = "密码提示问题回答错误！";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#dialog\").fadeToggle(1000);});</script>");
        }
    }
}