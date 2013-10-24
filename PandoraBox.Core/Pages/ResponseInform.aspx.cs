using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_ResponseInform : System.Web.UI.Page
{
    private AppNotice notice;

    public void Page_Load(object sender, EventArgs e)
    {
        //检查登录状态
        if (Session["isLogin"] == null || (bool)Session["isLogin"] != true)
            Response.Redirect("~/Pages/login.aspx");
        Session["currentSite"] = "ResponseInform";
        String userID = Session["userID"] as string;
        Session["currentSite"] = "ResponseInform";
        notice = new AppNotice(userID);
        Renum.Text = AppNotice.noticeNumber(userID).ToString() + "个未读回复";
        NewResponse_Click(null, null);
    }
    protected void NewResponse_Click(object sender, ImageClickEventArgs e)
    {
        List<AppMessage> msgs = notice.Messages;
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        foreach(AppMessage msg in msgs)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(msg.UserID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.UpdatePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void HaveChecked_Click(object sender, ImageClickEventArgs e)
    {
        string userID = Session["userID"] as string;
        foreach (AppMessage msg in notice.Messages)
            AppNotice.deleteNotice(msg.MessageID, userID);
        this.Page_Load(null, null);
    }
    protected void MyResponse_Click(object sender, ImageClickEventArgs e)
    {

    }

    public void responseTips(string userID, int messageID, int sourceID)
    {
        //清空消息
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        AppNotice notice = new AppNotice(Session["userID"] as string);
        List<AppMessage> load = notice.Messages;
        this.UpdatePanel.ContentTemplateContainer.Controls.Clear();
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
        //this.UpdatePanel.Update();
    }
    protected void huifutixing_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void gerenzhuye_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MyHomepage.aspx");
    }
    protected void xinxianshi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
    protected void gerenxinxi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PersonalInformation.aspx");
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