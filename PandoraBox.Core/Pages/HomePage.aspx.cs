using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using PandoraBox.AppCode;

public partial class Pages_HomePage : System.Web.UI.Page
{
    protected string PageTitle = "Welcome To PandoraBox";
    AppHomePage appPage = null;
    private string m_filePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        //检查登录状态
        if (Session["isLogin"] == null || (bool)Session["isLogin"] != true)
            Response.Redirect("~/Pages/login.aspx");
        PageTitle = "Welcome ! " + Session["userID"].ToString();
        if (Session["sortType"] == null)
            Session["sortType"] = AppSortType.timeDescending;
        Session["currentSite"] = "HomePage";

        this.SearchInputBox.Attributes.Add("onkeydown", "BtnClick(this);");

        //审核用户权限
        if (AppUserManage.getUser(Session["userID"] as string).Authority == AppUserAuthority.limited)
        {
            TextBox1.Text = "对不起，您的账号暂被封禁";
            TextBox1.Enabled = false;
            PublishButton.Enabled = false;
            UploadPicture.Enabled = false;
        }

        //刷新时，如果搜索框为空，则取消搜索结果
        if (SearchInputBox.Text == null || SearchInputBox.Text == "")
        {
            if ((AppSortType)Session["sortType"] != AppSortType.hot)
                Session["sortType"] = AppSortType.timeDescending;
            ImageButton1.ImageUrl = "~/CSS/HomePage/sort/sort_hot.png";
            SearchInputBox.Text = "";
        }
        this.updateInformationUI();
        this.HeadImg.ImageUrl = AppUserManage.getUser(Session["userID"].ToString()).UserImagePath;
        //更新页面其它信息
        TagText.Text = "当  前 : " + addSpace(Session["currentTag"] as string);
        TagText.Font.Size = getFontSize(Session["currentTag"] as string);
        //下一级标签显示的起始位置
        if (Session["nextTagStart"] == null)
            Session["nextTagStart"] = 0;
        List<string> nextTags = AppTag.getNextTags(Session["currentTag"] as string);
        //显示标签
        if (nextTags.Count > (int)Session["nextTagStart"])
        {
            DirectorText1.Text = addSpace(nextTags[(int)Session["nextTagStart"]]);
            DirectorText1.Font.Size = getFontSize(nextTags[(int)Session["nextTagStart"]]);
            Director1.Enabled = true;
        }
        else
        {
            DirectorText1.Text = "";
            Director1.Enabled = false;
        }
        if (nextTags.Count > (int)Session["nextTagStart"] + 1)
        {
            DirectorText2.Text = addSpace(nextTags[(int)Session["nextTagStart"] + 1]);
            DirectorText2.Font.Size = getFontSize(nextTags[(int)Session["nextTagStart"] + 1]);
            Director2.Enabled = true;
        }
        else
        {
            DirectorText2.Text = "";
            Director2.Enabled = false;
        }
        if (nextTags.Count > (int)Session["nextTagStart"] + 2)
        {
            DirectorText3.Text = addSpace(nextTags[(int)Session["nextTagStart"] + 2]);
            DirectorText3.Font.Size = getFontSize(nextTags[(int)Session["nextTagStart"] + 2]);
            Director3.Enabled = true;
        }
        else
        {
            DirectorText3.Text = "";
            Director3.Enabled = false;
        }
        if (nextTags.Count > (int)Session["nextTagStart"] + 3)
        {
            DirectorText4.Text = addSpace(nextTags[(int)Session["nextTagStart"] + 3]);
            DirectorText4.Font.Size = getFontSize(nextTags[(int)Session["nextTagStart"] + 3]);
            Director4.Enabled = true;
        }
        else
        {
            DirectorText4.Text = "";
            Director4.Enabled = false;
        }
        if (Session["currentTag"] as string == "所有")
            ReturnButton.Enabled = false;
        else
            ReturnButton.Enabled = true;
        //两个按钮的开启与关闭
        if ((int)Session["nextTagStart"] == 0)
            LeftButton.Enabled = false;
        else
            LeftButton.Enabled = true;
        if ((int)Session["nextTagStart"] + 3 >= nextTags.Count - 1)
            RightButton.Enabled = false;
        else
            RightButton.Enabled = true;
        //显示评价模块
        ////
        ///this.outLoad.Style.Value = "display:none";
        /////
        appPage = new AppHomePage(Session["userID"] as string, Session["currentTag"] as string, (AppSortType)Session["sortType"]);
        this.assessment1Panel.ContentTemplateContainer.Controls.Clear();
        if(appPage.TeacherEva != null)
        {
            ASP.pages_assessment_ascx ascxTeacher= new ASP.pages_assessment_ascx();
            ascxTeacher.initial(appPage.TeacherEva, Session["userID"] as string);
            ascxTeacher.ID = AppTag.getTagID(Session["currentTag"] as string).ToString() + "teacherEva";
            this.assessment1Panel.ContentTemplateContainer.Controls.Add(ascxTeacher);
        }
        else if (appPage.FoodEva != null)
        {
            ASP.pages_assessmentfood_ascx ascxFood = new ASP.pages_assessmentfood_ascx();
            ascxFood.initial(appPage.FoodEva, Session["userID"] as string);
            ascxFood.ID = AppTag.getTagID(Session["currentTag"] as string).ToString() + "foodEva";
            this.assessment1Panel.ContentTemplateContainer.Controls.Add(ascxFood);
        }
        this.assessment1Panel.Update();       
    }

    /// <summary>
    /// 得到字号
    /// </summary>
    /// <param name="currentTag"></param>
    /// <returns></returns>
    private int getFontSize(string currentTag)
    {
        if (currentTag.Length <= 4)
            return 14;
        else if (currentTag.Length == 5)
            return 12;
        else if (currentTag.Length == 6)
            return 11;
        else if (currentTag.Length == 7)
            return 9;
        else
            return 8;
    }

    /// <summary>
    /// 两个字之间加入一个空格
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private string addSpace(string s)
    {
        if (s == null || s == "")
            return "";
        string result = s[0].ToString();
        for (int i = 1; i < s.Length; i++)
        {
            result += "  ";
            result += s[i].ToString();
        }
        return result;
    }

    private string deleteSpace(string s)
    {
        string result = "";
        for (int i = 0; i < s.Length; i++)
            if (s[i] != ' ')
                result += s[i].ToString();
        return result;
    }

    protected void LogOut_Click(object sender, ImageClickEventArgs e)
    {
        AppUserManage.Logout(Session["userID"] as string);
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("~/Pages/login.aspx");
    }
    protected void HeadBorder_Click(object sender, ImageClickEventArgs e)
    {
    }
    /// <summary>
    /// 更新消息框
    /// </summary>
    public void updatePublishUI()
    {
        this.publishPanel.Update();
    }

    /// <summary>
    /// 重新加载消息
    /// </summary>
    public void updateInformationUI()
    {
        if ((AppSortType)Session["sortType"] == AppSortType.relevance && SearchInputBox.Text != null && SearchInputBox.Text != "")
        {
            SearchButton_Click(null, null);
            return;
        }
        //重新获得页面
        string userID = Session["userID"] as string;
        string currentTag = Session["currentTag"] as string;
        if (Session["sortType"] == null)
            appPage = new AppHomePage(userID, currentTag, AppSortType.timeDescending);
        else
            appPage = new AppHomePage(userID, currentTag, (AppSortType)Session["sortType"]);
        //清空消息
        this.messagePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        List<AppMessage> load = getCurrentPageInfo(appPage.Messages);
        //加载消息
        foreach (AppMessage appMessage in load)
        {
            ASP.pages_information_ascx ascxInformation = new ASP.pages_information_ascx();
            ascxInformation.ID = appMessage.MessageID.ToString();
            ascxInformation.initial(userID, appMessage.MessageID, currentTag, -1);
            this.messagePanel.ContentTemplateContainer.Controls.Add(ascxInformation);
        }
        this.messagePanel.Update();
    }

    public void responseTips(string userID, int messageID, int sourceID)
    {
        //重新获得页面
        string currentTag = Session["currentTag"] as string;
        if (Session["sortType"] == null)
            appPage = new AppHomePage(userID, currentTag, AppSortType.timeDescending);
        else
            appPage = new AppHomePage(userID, currentTag, (AppSortType)Session["sortType"]);
        //清空消息
        this.messagePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        List<AppMessage> load = getCurrentPageInfo(appPage.Messages);
        //加载消息
        foreach (AppMessage appMessage in load)
        {
            ASP.pages_information_ascx ascxInformation = new ASP.pages_information_ascx();
            ascxInformation.ID = appMessage.MessageID.ToString();
            if (appMessage.MessageID != sourceID)
                ascxInformation.initial(userID, appMessage.MessageID, currentTag, -1);
            else
            {
                //获得他/她回复的是谁并储存消息ID
                Session[appMessage.MessageID.ToString() + "-responseID"] = messageID;
                ascxInformation.initial(userID, appMessage.MessageID, currentTag, messageID);
            }
            this.messagePanel.ContentTemplateContainer.Controls.Add(ascxInformation);
        }
        this.messagePanel.Update();
       
    }

    public void changeImage()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "changeImg",
           "<script src=\"../JS/imgFit.js\"></script><script>window.onload = function () { Init(); }</script>");
    }
    public void displayChat()
    {
       // ClientScript.RegisterStartupScript(this.GetType(), "displayChat",
           //"<script>$(document).ready(function () { $(\"#dialog\").show(); });</script>");
    }

    protected void Director1_Click(object sender, ImageClickEventArgs e)
    {
        if (DirectorText1.Text != null && DirectorText1.Text != "")
        {
            Session["pageNumber"] = 1;
            Session["nextTagStart"] = 0;
            Session["currentTag"] = deleteSpace(DirectorText1.Text);
            this.Page_Load(null, null);
        }
    }
    protected void Director2_Click(object sender, ImageClickEventArgs e)
    {
        if (DirectorText2.Text != null && DirectorText2.Text != "")
        {
            Session["pageNumber"] = 1;
            Session["nextTagStart"] = 0;
            Session["currentTag"] = deleteSpace(DirectorText2.Text);
            this.Page_Load(null, null);
        }
    }
    protected void Director3_Click(object sender, ImageClickEventArgs e)
    {
        if (DirectorText3.Text != null && DirectorText3.Text != "")
        {
            Session["pageNumber"] = 1;
            Session["nextTagStart"] = 0;
            Session["currentTag"] = deleteSpace(DirectorText3.Text);
            this.Page_Load(null, null);
        }
    }
    protected void Director4_Click(object sender, ImageClickEventArgs e)
    {
        if (DirectorText4.Text != null && DirectorText4.Text != "")
        {
            Session["pageNumber"] = 1;
            Session["nextTagStart"] = 0;
            Session["currentTag"] = deleteSpace(DirectorText4.Text);
            this.Page_Load(null, null);
        }
    }
    protected void ReturnButton_Click(object sender, ImageClickEventArgs e)
    {
        Session["pageNumber"] = 1;
        Session["nextTagStart"] = 0;
        string current = Session["currentTag"] as string;
        if (AppTag.getTagRank(AppTag.getTagID(current)) == 1)
            Session["currentTag"] = "所有";
        else
        {
            string back = AppTag.getTagName(AppTag.getTagParentID(AppTag.getTagID(current)));
            Session["currentTag"] = back;
        }
        this.Page_Load(null, null);
    }
    protected void LeftButton_Click(object sender, ImageClickEventArgs e)
    {
        Session["nextTagStart"] = (int)Session["nextTagStart"] - 1;
        this.Page_Load(null, null);
    }
    protected void RightButton_Click(object sender, ImageClickEventArgs e)
    {
        Session["nextTagStart"] = (int)Session["nextTagStart"] + 1;
        this.Page_Load(null, null);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["pageNumber"] = 1;
        if (ImageButton1.ImageUrl == "~/CSS/HomePage/sort/sort_relation.png")
            Session["sortType"] = AppSortType.relevance;
        else
            Session["sortType"] = AppSortType.hot;
        updateInformationUI();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session["pageNumber"] = 1;
        Session["sortType"] = AppSortType.timeDescending;
        updateInformationUI();
    }
    protected void SearchButton_Click(object sender, ImageClickEventArgs e)
    {
        if (SearchInputBox.Text == null || SearchInputBox.Text == "")
            return;
        Session["pageNumber"] = 1;
        //如果搜索的是标签，则进入标签页面
        List<string> tags = AppTag.getAllTags();
        if (tags.Contains(SearchInputBox.Text))
        {
            Session["currentTag"] = SearchInputBox.Text;
            Page_Load(null, null);
            return;
        }
        //重新获得页面，先按照时间排序
        string userID = Session["userID"] as string;
        string currentTag = Session["currentTag"] as string;
        appPage = new AppHomePage(userID, currentTag, AppSortType.timeDescending);
        //取得页面结果，按相关度排序
        List<AppMessage> resultMessage = appPage.Messages;
        appPage.sortByRelevance(resultMessage, SearchInputBox.Text);
        //替换排序按钮
        Session["sortType"] = AppSortType.relevance;
        ImageButton1.ImageUrl = "~/CSS/HomePage/sort/sort_relation.png";
        //清空消息
        this.messagePanel.ContentTemplateContainer.Controls.Clear();
        //得到当前页面需要加载的Message
        List<AppMessage> load = getCurrentPageInfo(resultMessage);
        //加载消息
        foreach (AppMessage appMessage in load)
        {
            ASP.pages_information_ascx ascxInformation = new ASP.pages_information_ascx();
            ascxInformation.ID = appMessage.MessageID.ToString();
            ascxInformation.initial(userID, appMessage.MessageID, currentTag, -1);
            this.messagePanel.ContentTemplateContainer.Controls.Add(ascxInformation);
        }
        this.messagePanel.Update();
    }

    private List<AppMessage> getCurrentPageInfo(List<AppMessage> messages)
    {
        if (Session["pageNumber"] == null)
            Session["pageNumber"] = 1;
        int page = (int)Session["pageNumber"];
        //设定上一页和下一页
        if (page <= 1)
        {
            Last.Enabled = false;
            Last.ImageUrl = "~/CSS/HomePage/Information/begin.png";
        }
        else
        {
            Last.Enabled = true;
            Last.ImageUrl = "~/CSS/HomePage/Information/last.png";
        }
        if (messages.Count <= page * 10)
        {
            Next.Enabled = false;
            Next.ImageUrl = "~/CSS/HomePage/Information/end.png";
        }
        else
        {
            Next.Enabled = true;
            Next.ImageUrl = "~/CSS/HomePage/Information/next.png";
        }
        List<AppMessage> result = new List<AppMessage>();
        for (int i = (page - 1) * 10; i < page * 10 && i < messages.Count; i++)
            result.Add(messages[i]);
        return result;
    }
    protected void Last_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["pageNumber"] != null && (int)Session["pageNumber"] > 1)
            Session["pageNumber"] = (int)Session["pageNumber"] - 1;
        updateInformationUI();
    }
    protected void Next_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["pageNumber"] != null && (int)Session["pageNumber"] * 10 < this.appPage.Messages.Count)
            Session["pageNumber"] = (int)Session["pageNumber"] + 1;
        updateInformationUI();
    }
    protected void haoyouguanli_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/FriendsManagement.aspx");
    }
    protected void huifutixing_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/ResponseInform.aspx");
    }
    protected void gerenxinxi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/UserInfo.aspx");
    }
    protected void xinxianshi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/HomePage.aspx");
    }
    protected void gerenzhuye_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/MyHomePage.aspx");
    }
    protected void gerenxinxi_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/PersonalInformation.aspx");
    }
    

    protected void PublishButton_Click(object sender, ImageClickEventArgs e)
    {
        m_filePath = this.hd.Attributes["value"];
        string userID = Session["userID"] as string;
        string contents = TextBox1.Text;
        if ((contents == null || contents == "")&&(m_filePath==null || m_filePath == ""))
        {
            ScriptManager.RegisterStartupScript(publishPanel, publishPanel.GetType(), "", "alert('发布内容不能为空！');", true);   
            return;
        }
        string currentTag = Session["currentTag"] as string;
        string path = m_filePath;
        if (path == null)
            path = "";
        string[] split = path.Split(new char[] { '.' });
        string expansion = split[split.Length - 1];
        string imagePath = "";
        if (expansion == "jpg" || expansion == "bmp" || expansion == "png" || expansion == "gif" || expansion == "JPG")
        {
            imagePath = "UploadFile\\" + path;
            contents += "(Image)";
        }
        string enclosurePath = "";
        if (path != null && path != "")
        {
            enclosurePath = "UploadFile\\" + path;
            contents += "(Enclosure)";
        }
        bool succeed = AppHomePage.publishMessage(userID, contents, currentTag, imagePath, enclosurePath);
        TextBox1.Text = "";
        m_filePath = ""; 
        updateInformationUI();
        updatePublishUI();
        Response.Redirect(Request.Url.ToString()); 
    }
    protected void ChatRoom_Click(object sender, ImageClickEventArgs e)
    {
        Session["room" + "userID"] = Session["userID"].ToString();
        Response.Redirect("ChatRoom.aspx", false);
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

    /// <summary>
    /// 教师打分的第1个打分
    /// </summary>
    /// <param name="tagID"></param>
    /// <param name="userID"></param>
    public void recordTeacherScore1(int tagID, string userID, int score)
    {
        Session[tagID.ToString() + "-teva1-" + userID] = score.ToString();
    }

    /// <summary>
    /// 教师打分的第2个打分
    /// </summary>
    /// <param name="tagID"></param>
    /// <param name="userID"></param>
    public void recordTeacherScore2(int tagID, string userID, int score)
    {
        Session[tagID.ToString() + "-teva2-" + userID] = score.ToString();
    }

    /// <summary>
    /// 食品打分
    /// </summary>
    /// <param name="tagID"></param>
    /// <param name="userID"></param>
    public void recordFoodScore(int tagID, string userID, int score)
    {
        Session[tagID.ToString() + "-feva-" + userID] = score.ToString();
    }
}