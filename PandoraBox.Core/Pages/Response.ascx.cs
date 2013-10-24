using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_Response : System.Web.UI.UserControl
{
    /// <summary>
    /// 保存一个回复类的引用
    /// </summary>
    private AppResponse response = null;
    /// <summary>
    /// 当前用户的ID
    /// </summary>
    private string userID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (response != null)
        {
            Label3.Text = response.UserName + ":" + response.Contents;
            if (response.UserImagePath != null && response.UserImagePath != "")
                Image1.ImageUrl = response.UserImagePath;
            else
                Image1.ImageUrl = "../CSS/backgrounds/pandora.png";
            Label2.Text = response.TimeString;
        }
    }

    public void initial(string userID, int responseID)
    {
        this.userID = userID;
        this.response = new AppResponse(userID, responseID);
    }

    protected void asp_responseButton_Click(object sender, ImageClickEventArgs e)
    {
        int messageID = response.MessageID;
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("responseTips");
        mi.Invoke(page, new object[] { this.userID, messageID, AppResponse.getResponseSource(messageID) });
    }
}