using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_Information : System.Web.UI.UserControl
{
    /// <summary>
    /// 一个message信息的引用
    /// </summary>
    private AppMessage message = null;
    /// <summary>
    /// 当前用户ID的引用
    /// </summary>
    private string userID = null;
    /// <summary>
    /// 当前标签的引用
    /// </summary>
    private string currentTag = null;
    /// <summary>
    /// 回复框的初始值
    /// </summary>
    private string inputBoxInitial = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteButton.Attributes["OnClick"] = "return confirm('您确定要删除吗?')";
        ToReport.Attributes["OnClick"] = "return confirm('您确定要举报该状态吗?')";
        ToConfine.Attributes["OnClick"] = "return confirm('您确定要将他禁言吗?')";
        if (message != null)
        {

            if (Session["currentSite"] as string == "MyHomepage" && Session["subCurrentSite"] as string == "report")
                this.ApproveButton.Visible = true;
            else
                this.ApproveButton.Visible = false;

            this.TextContent.Text = message.UserName + ":" + message.Contents;
            this.InformationTime.Text = message.TimeString;
            this.DeleteButton.Visible = message.CanBeDeleted;
            AppUser user = AppUserManage.getUser(userID);
            this.YourImage.ImageUrl = user.UserImagePath;
            if (message.UserImagePath != null && message.UserImagePath != "")
                this.Image1.ImageUrl = message.UserImagePath;
            else
                this.Image1.ImageUrl = "../CSS/backgrounds/pandora.png";
            if (message.ImagePath != null && message.ImagePath != "")
                this.Picture.ImageUrl = message.ImagePath;
            else
                this.Picture.ImageUrl = message.ImagePath;
            if (message.Enclosure != null && message.Enclosure != "")
            {
                ASP.pages_enclosure_ascx myEnclosure = new ASP.pages_enclosure_ascx();
                myEnclosure.initial(message.Enclosure);
                myEnclosure.ID = Convert.ToString(message.MessageID);
                this.Myattachment.Controls.Add(myEnclosure);
            }
            this.NumOfDown.Text = message.Down.ToString();
            this.NumOfUp.Text = message.Up.ToString();
            this.InputBox.Text = inputBoxInitial;
            updateResponseUI();

            //设定控件是否显示

            //如果输入框不为空，则显示
            if (this.inputBoxInitial != null && this.inputBoxInitial != "")
            {
                TempInput.Visible = false;
                Expand.ImageUrl = "~/CSS/HomePage/Information/retract.png";
            }
            //如果在回复提醒页面，则显示
            if (!IsPostBack && Session["currentSite"] as string == "ResponseInform")
            {
                TempInput.Visible = false;
                Expand.ImageUrl = "~/CSS/HomePage/Information/retract.png";
            }
            else if (!IsPostBack && Session["currentSite"] as string == "MyHomepage")
            {
                TempInput.Visible = true;
                Expand.ImageUrl = "~/CSS/HomePage/Information/expand.png";
            }
            //设定加关注按钮的图案
            string me = Session["userID"] as string;
            if (me == message.UserID)
            {
                ImageButton1.ImageUrl = "~/CSS/HomePage/Information/Me.png";
                ImageButton1.Enabled = false;
            }
            else if (AppFriendManage.isAttention(me, message.UserID))
            {
                ImageButton1.ImageUrl = "~/CSS/HomePage/Information/haveConcerned.png";
                ImageButton1.Enabled = false;
            }
            else
            {
                ImageButton1.ImageUrl = "~/CSS/HomePage/Information/addConcern.png";
                ImageButton1.Enabled = true;
            }

            if (Expand.ImageUrl == "~/CSS/HomePage/Information/expand.png")
                this.responsePanel.Visible = false;
            else
                this.responsePanel.Visible = true;
            if (AppUserManage.getUser(this.userID).Authority != AppUserAuthority.administrator)
                ToConfine.Visible = false;
            else
                ToConfine.Visible = true;
            if (TempInput.Visible == true)
                this.a.Visible = false;
            else
                this.a.Visible = true;
        }
    }

    public void initial(string userID, int messageID, string currentTag, int responseID)
    {
        this.message = new AppMessage(userID, messageID, currentTag);
        this.userID = userID;
        this.currentTag = currentTag;
        if (responseID != -1)
        {
            AppResponse response = new AppResponse(null, responseID);
            string whom = response.UserName;
            this.inputBoxInitial = "（回复" + whom + "）";
        }
        else
        {
            this.inputBoxInitial = "";
        }
    }

    public void DeleteButton_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["currentSite"].ToString() == "HomePage")
        {
            bool succeed = AppMessage.deleteMessage(this.message.MessageID);
            if (succeed)
            {
                System.Web.UI.Page page = this.Page;
                Type pageType = page.GetType();
                MethodInfo mi = pageType.GetMethod("updateInformationUI");
                mi.Invoke(page, null);
            }
        }
        else if (Session["currentSite"].ToString() == "ResponseInform")
        {
            AppNotice.deleteNotice(this.message.MessageID, Session["userID"] as string);
            System.Web.UI.Page page = this.Page;
            Type pageType = page.GetType();
            MethodInfo mi = pageType.GetMethod("Page_Load");
            mi.Invoke(page, new object[] { null, null });
        }
        else if (Session["currentSite"].ToString() == "MyHomepage")
        {
            bool succeed = false;
            if (Session["subCurrentSite"].ToString() == "information")
                succeed = AppMessage.deleteMessage(this.message.MessageID);
            else if (Session["subCurrentSite"].ToString() == "collection")
                succeed = AppMessage.deleteCollect(this.message.MessageID, Session["userID"] as string);
            else if (Session["subCurrentSite"].ToString() == "report")
                succeed = AppMessage.deleteMessage(this.message.MessageID);
            if (succeed)
            {
                System.Web.UI.Page page = this.Page;
                Type pageType = page.GetType();
                MethodInfo mi = pageType.GetMethod("Page_Load");
                mi.Invoke(page, new object[] { null, null });
            }
        }
        else if (Session["currentSite"].ToString() == "FriendsManagement")
        {
            if (Session["friSubSite"] as string == "information" || Session["friSubSite"] as string == "user")
            {
                bool succeed = AppMessage.deleteMessage(this.message.MessageID);
                if (succeed)
                {
                    System.Web.UI.Page page = this.Page;
                    Type pageType = page.GetType();
                    MethodInfo mi = pageType.GetMethod("Page_Load");
                    mi.Invoke(page, new object[] { null, null });
                }
            }
        }
    }

    /// <summary>
    /// 重新加载回复
    /// </summary>
    private void updateResponseUI()
    {
        //清空回复
        this.responsePanel.ContentTemplateContainer.Controls.Clear();
        //加载回复
        foreach (AppResponse appResponse in message.Responses)
        {
            ASP.pages_response_ascx ascxResponse = new ASP.pages_response_ascx();
            ascxResponse.initial(this.userID, appResponse.MessageID);
            ascxResponse.ID = appResponse.MessageID.ToString();
            this.responsePanel.ContentTemplateContainer.Controls.Add(ascxResponse);
        }
        this.responsePanel.Update();
    }
    protected void PublishResponse_Click(object sender, ImageClickEventArgs e)
    {
        string contents = this.InputBox.Text;
        if (contents == null || contents == "")
        {
            ScriptManager.RegisterStartupScript(responseButtonPanel, responseButtonPanel.GetType(), "", "alert('发布内容不能为空！');", true);   
            return;
        }
        string userID = Session["userID"] as string;
        string currentTag = Session["currentTag"] as string;
        if (Session[message.MessageID.ToString() + "-responseID"] == null || (int)(Session[message.MessageID.ToString() + "-responseID"]) == -1)
        {
            //写入到数据库
            AppMessage.response(userID, message.MessageID, contents);
        }
        else
        {
            //判断是否回复的是他
            AppResponse response = new AppResponse(null, (int)(Session[message.MessageID.ToString() + "-responseID"]));
            string whom = response.UserName;
            string check = "（回复" + whom + "）";
            //如果仍然回复的是他
            if (contents.Contains(check))
                AppMessage.response(userID, (int)(Session[message.MessageID.ToString() + "-responseID"]), contents);
            else
                AppMessage.response(userID, message.MessageID, contents);
            Session[message.MessageID.ToString() + "-responseID"] = null;
        }
        //读取最新回复
        this.message = new AppMessage(userID, message.MessageID, currentTag);
        this.InputBox.Text = null;
        updateResponseUI();
    }
    protected void Expand_Click(object sender, ImageClickEventArgs e)
    {
        if (Expand.ImageUrl == "~/CSS/HomePage/Information/expand.png")
        {
            this.responsePanel.Visible = true;
            Expand.ImageUrl = "~/CSS/HomePage/Information/retract.png";
        }
        else
        {
            this.responsePanel.Visible = false;
            Expand.ImageUrl = "~/CSS/HomePage/Information/expand.png";
        }
    }
    protected void TempInput_Click(object sender, ImageClickEventArgs e)
    {
        //显示回复
        if (Expand.ImageUrl == "~/CSS/HomePage/Information/expand.png")
        {
            this.responsePanel.Visible = true;
            Expand.ImageUrl = "~/CSS/HomePage/Information/retract.png";
        }
        a.Visible = true;
        TempInput.Visible = false;
        InputBox.Focus();
    }
    protected void ToConfine_Click(object sender, ImageClickEventArgs e)
    {
        string userID = this.message.UserID;
        AppUserManage.authorityUpdate(userID, AppUserAuthority.limited);
    }
    protected void ToReport_Click(object sender, ImageClickEventArgs e)
    {
        string s = Session[userID + "-report-" + message.MessageID.ToString()] as string;
        if(s == null || s == "")
            AppMessage.plusReport(this.message.MessageID);
        else
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('您已经举报过了！');", true);
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordReport");
        mi.Invoke(page, new object[] { this.userID, this.message.MessageID});
    }
    protected void ToUp_Click(object sender, ImageClickEventArgs e)
    {
        string s = Session[userID + "-ud-" + message.MessageID.ToString()] as string;
        if (s == null || s == "")
        {
            AppMessage.plusUp(this.message.MessageID);
            NumOfUp.Text = (Int32.Parse(NumOfUp.Text) + 1).ToString();
            this.upAndDownPanel.Update();
        }
        else if (s == "up")
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('您已经顶过了！');", true);
        else if (s == "down")
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('您已经踩过了！');", true); 
        //反射到主页，记录用户已经顶过了
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordUpAndDown");
        mi.Invoke(page, new object[] {this. userID, this.message.MessageID, "up" });
    }
    protected void ToDown_Click(object sender, ImageClickEventArgs e)
    {
        string s = Session[userID + "-ud-" + message.MessageID.ToString()] as string;
        if (s == null || s == "")
        {
            AppMessage.plusDown(this.message.MessageID);
            NumOfDown.Text = (Int32.Parse(NumOfDown.Text) + 1).ToString();
            this.upAndDownPanel.Update();
        }
        else if (s == "up")
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('您已经顶过了！');", true);
        else if (s == "down")
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('您已经踩过了！');", true);
        //反射到主页，记录用户已经踩过了
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("recordUpAndDown");
        mi.Invoke(page, new object[] { this.userID, this.message.MessageID, "down" });
    }
    protected void ToCollect_Click(object sender, ImageClickEventArgs e)
    {
        if(AppMessage.collect(this.userID, this.message.MessageID))
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('收藏成功！');", true);   
        else
            ScriptManager.RegisterStartupScript(upAndDownPanel, upAndDownPanel.GetType(), "", "alert('出现错误，收藏失败！');", true);   
    }

    //点击infomation上加关注按钮
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string me = Session["userID"] as string;
        if (me == message.UserID || AppFriendManage.isAttention(me, message.UserID))
            return;
        AppFriendManage.addAttention(me, message.UserID);
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("updateInformationUI");
        mi.Invoke(page, null);
    }
    protected void ApproveButton_Click(object sender, ImageClickEventArgs e)
    {
        bool succeed = AppMessage.clearReport(message.MessageID);
        if (succeed)
        {
            System.Web.UI.Page page = this.Page;
            Type pageType = page.GetType();
            MethodInfo mi = pageType.GetMethod("Page_Load");
            mi.Invoke(page, new object[] { null, null });
        }
    }
}


    