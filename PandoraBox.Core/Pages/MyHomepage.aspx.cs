using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_MyHomepage : System.Web.UI.Page
{

    private AppUser user;
    private AppPersonalPage page;

    public void Page_Load(object sender, EventArgs e)
    {
        Session["currentSite"] = "MyHomepage";
        string userID = Session["userID"] as string;
        this.user = AppUserManage.getUser(userID);
        this.page = new AppPersonalPage(user.UserID);
        if (user.Authority == AppUserAuthority.administrator)
        {
            //在这里显示管理员图标
            this.AddTag.Style.Value = "display:normal";
            this.DeleteTag.Style.Value = "display:normal";
            this.confine.Style.Value = "display:normal";
            this.report.Style.Value = "display:normal";
            this.noAuthority.Style.Value = "display:none";
        }
        else
        {
            //在这里显示非管理员图标
            this.AddTag.Style.Value = "display:none";
            this.DeleteTag.Style.Value = "display:none";
            this.confine.Style.Value = "display:none";
            this.report.Style.Value = "display:none";
            this.noAuthority.Style.Value = "display:normal";
        }
        if (!IsPostBack)
            this.MyInformation_Click(null, null);
        else if (Session["subCurrentSite"].ToString() == "information")
            this.MyInformation_Click(null, null);
        else if (Session["subCurrentSite"].ToString() == "collection")
            this.MyCollection_Click(null, null);
        else if (Session["subCurrentSite"].ToString() == "report")
            this.aspReport_Click(null, null);
        else if (Session["subCurrentSite"].ToString() == "confine")
            this.aspConfine_Click(null, null);
    }
    protected void xinxianshi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/HomePage.aspx");
    }
    protected void MyInformation_Click(object sender, ImageClickEventArgs e)
    {
        if (page == null)
            throw new Exception("没有或得页面对象");
        Session["subCurrentSite"] = "information";
        List<AppMessage> load = page.Publishs;
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppMessage msg in load)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(msg.UserID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.myHomePagePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void MyCollection_Click(object sender, ImageClickEventArgs e)
    {
        if (page == null)
            throw new Exception("没有或得页面对象");
        Session["subCurrentSite"] = "collection";
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
        List<AppMessage> load = page.Favorites;
        //加载消息
        foreach (AppMessage msg in load)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(msg.UserID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.myHomePagePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void aspReport_Click(object sender, ImageClickEventArgs e)
    {
        Session["subCurrentSite"] = "report";
        //获取所有被举报的消息
        AppHomePage newpage = new AppHomePage(Session["userID"] as string, "所有", AppSortType.timeDescending);
        List<AppMessage> load = newpage.Messages;
        AppPersonalPage.sortByReport(load);
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
        //加载消息
        foreach (AppMessage msg in load)
        {
            ASP.pages_information_ascx ascx = new ASP.pages_information_ascx();
            ascx.initial(msg.UserID, msg.MessageID, "所有", -1);
            ascx.ID = msg.MessageID.ToString();
            this.myHomePagePanel.ContentTemplateContainer.Controls.Add(ascx);
        }
    }
    protected void aspConfine_Click(object sender, ImageClickEventArgs e)
    {
        Session["subCurrentSite"] = "confine";
        List<AppUser> limitUsers = AppUserManage.getLimitUser();
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
        foreach (AppUser user in limitUsers)
        {
            ASP.pages_deblocking_ascx deblock = new ASP.pages_deblocking_ascx();
            deblock.initial(user);
            deblock.ID = user.UserID;
            this.myHomePagePanel.ContentTemplateContainer.Controls.Add(deblock);
        }
    }

    public void responseTips(string userID, int messageID, int sourceID)
    {
        //清空消息
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        AppPersonalPage page = new AppPersonalPage(Session["userID"] as string);
        List<AppMessage> load = new List<AppMessage>();
        if (Session["currentSite"].ToString() == "MyHomepage" && Session["subCurrentSite"].ToString() == "information")
            load = page.Publishs;
        if (Session["currentSite"].ToString() == "MyHomepage" && Session["subCurrentSite"].ToString() == "collection")
            load = page.Favorites;
        if (Session["currentSite"].ToString() == "MyHomepage" && Session["subCurrentSite"].ToString() == "report")
        {
            AppHomePage newpage = new AppHomePage(Session["userID"] as string, "所有", AppSortType.timeDescending);
            load = newpage.Messages;
            AppPersonalPage.sortByReport(load);
        }
        this.myHomePagePanel.ContentTemplateContainer.Controls.Clear();
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
            this.myHomePagePanel.ContentTemplateContainer.Controls.Add(ascxInformation);
        }
        //this.UpdatePanel.Update();
    }

    protected void gerenzhuye_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("~/Pages/HomePage.aspx");
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
    protected void AddTag_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddTag.aspx");
    }
    protected void DeleteTag_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DeleteTag.aspx");
    }
}