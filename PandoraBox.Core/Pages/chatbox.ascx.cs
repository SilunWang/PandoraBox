using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
public partial class Pages_chatbox : System.Web.UI.UserControl
{
    string user1Name = "";
    string user2Name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["chat"+"user1ID"] = "123";
        Session["chat" + "user2ID"] = "badjoker@163.com";
        if (Session["chat" + "user1ID"] == null || Session["chat" + "user2ID"] == null)
            Response.Redirect("~/HomePage.aspx");
        else
        {
            user1Name = AppUserManage.getUser(Session["chat" + "user1ID"].ToString()).Name;
            user2Name = AppUserManage.getUser(Session["chat" + "user2ID"].ToString()).Name;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Session["user1ID" + "user2ID" + "dialog"] != null)
            DialogText.Text = Session["user1ID" + "user2ID" + "dialog"].ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string time =  DateTime.Now.ToString();
        Session["user1ID" + "user2ID" + "dialog"] += time + "\n";
        Session["user1ID" + "user2ID" + "dialog"] += user1Name + "：" + ResponseText.Text + "\n";
        AppDialog dialog = new AppDialog(Session["chat" + "user1ID"].ToString(), 
            Session["chat" + "user2ID"].ToString(), ResponseText.Text);
        dialog.insertDialog();
        AppDialog dialog2 = new AppDialog(Session["chat" + "user2ID"].ToString(), 
            Session["chat" + "user1ID"].ToString(), ResponseText.Text);
        dialog2.insertDialog();
        ResponseText.Text = "";
        this.UpdatePanel2.Update();
    }
}