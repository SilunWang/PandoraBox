using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_FriendsManagement : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        Session["currentSite"] = "FriendsManagement";
        string userID = Session["userID"] as string;
        if (Session["friSubSite"] == null)
            Session["friSubSite"] = "concern";
        if (!IsPostBack)
            Concern_Click(null, null);
        else if (Session["friSubSite"] as string == "information")
            GetInformation_Click(null, null);
        else if (Session["friSubSite"] as string == "user")
        {
            getUserPublic(Session["lastClickUser"] as AppUser);
        }
        else if (Session["friSubSite"] as string == "concern")
            Concern_Click(null, null);
        else if (Session["friSubSite"] as string == "fans")
            Fans_Click(null, null);
        NumText.Text = AppFriendManage.getFans(userID).Count.ToString() + "粉丝 ღ " + AppFriendManage.getAttentions(userID).Count.ToString() + "关注";
    }
    protected void GetInformation_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        Session["friSubSite"] = "information";
        List<AppMessage> load = AppFriendManage.getAttentionsInfomation(userID);
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppMessage msg in load)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(userID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    public void getUserPublic(AppUser user)
    {
        string myID = Session["userID"] as string;
        Session["friSubSite"] = "user";
        Session["lastClickUser"] = user;
        List<AppMessage> load = AppFriendManage.getUserInfomation(myID, user.UserID);
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppMessage msg in load)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(myID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void Concern_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        Session["friSubSite"] = "concern";
        List<AppUser> load = AppFriendManage.getAttentions(userID);
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppUser user in load)
        {
            ASP.pages_myfriends_ascx ascx = new ASP.pages_myfriends_ascx();
            ascx.initial(user);
            ascx.ID = user.UserID.ToString() + "concern";
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void Fans_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        Session["friSubSite"] = "fans";
        List<AppUser> load = AppFriendManage.getFans(userID);
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppUser user in load)
        {
            ASP.pages_myfans_ascx ascx = new ASP.pages_myfans_ascx();
            ascx.initial(user);
            ascx.ID = user.UserID.ToString() + "fans";
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    public void responseTips(string userID, int messageID, int sourceID)
    {
        //清空消息
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        List<AppMessage> load;
        if (Session["friSubSite"] as string == "information")
            load = AppFriendManage.getAttentionsInfomation(userID);
        else
            load = AppFriendManage.getUserInfomation(userID, ((AppUser)Session["lastClickUser"]).UserID);
        //加载消息
        foreach (AppMessage appMessage in load)
        {
            ASP.pages_information_ascx ascxInformation = new ASP.pages_information_ascx();
            ascxInformation.ID = appMessage.MessageID.ToString();
            if (appMessage.MessageID != sourceID)
                ascxInformation.initial(userID, appMessage.MessageID, "所有", -1);
            else
            {
                //获得他/她回复的是谁并储存消息ID
                Session[appMessage.MessageID.ToString() + "-responseID"] = messageID;
                ascxInformation.initial(userID, appMessage.MessageID, "所有", messageID);
            }
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascxInformation);
        }
    }
    protected void xinxianshi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/HomePage.aspx");
    }
    protected void gerenzhuye_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/MyHomepage.aspx");
    }
    protected void gerenxinxi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/PersonalInformation.aspx");
    }
    protected void huifutixing_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/ResponseInform.aspx");
    }
    protected void haoyouguanli_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/FriendsManagement.aspx");
    }
    //记录用户顶和踩的信息
    public void recordUpAndDown(string userID, int messageID, string s)
    {
        Session[userID + "-ud-" + messageID.ToString()] = s;
    }

    //记录用户举报的信息
    public void recordReport(string userID, int messageID)
    {
        Session[userID + "-report-" + messageID.ToString()] = "report";
    }
}