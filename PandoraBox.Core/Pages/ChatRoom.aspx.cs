using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_ChatRoom : System.Web.UI.Page
{
    string roomTag = null;
    string userName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        ResponseTB.Attributes.Add("onkeydown", "SubmitKeyClick('Button2');");
        Session["room" + "tagID"] = "1";
        if (Session["room" + "tagID"] == null || Session["room" + "userID"] == null)
            Response.Redirect("~/HomePage.aspx");
        else
        {
            roomTag = Session["room" + "tagID"].ToString() + "room";
            userName = AppUserManage.getUser(Session["room" + "userID"].ToString()).Name;
        }
        if (!IsPostBack)
        {
            if (Application[roomTag + "userList"] == null)
            {
                Application[roomTag + "userList"] = new List<string>();
            }
            (Application[roomTag + "userList"] as List<string>).Add(Session["room" + "userID"].ToString());
            List<string> a = (List<string>)Application[roomTag + "userList"];
            ListBox1.DataSource = a;
            ListBox1.DataBind();
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        (Application[roomTag + "userList"] as List<string>).Remove(Session["room" + "userID"].ToString());
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string time = DateTime.Now.ToString();
        string user = AppUserManage.getUser(Session["room" + "userID"].ToString()).Name;
        Application[Session["room" + "tagID"].ToString() + "room"] += time + '\n';
        Application[Session["room" + "tagID"].ToString() + "room"] += user + "：" + ResponseTB.Text + "\n";
        AppChatItem chatitem = new AppChatItem(
            Int32.Parse(Session["room" + "tagID"].ToString()), Session["room" + "userID"].ToString(), ResponseTB.Text);
        chatitem.insertDialog();
        ResponseTB.Text = "";
        this.UpdatePanel2.Update();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Session["room" + "tagID"] != null && Application[Session["room" + "tagID"].ToString() + "room"] != null)
            PublicTextBox.Text = Application[Session["room" + "tagID"].ToString() + "room"].ToString();
    }
}