using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_MyFriends : System.Web.UI.UserControl
{
    private AppUser user;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Fr_uerName.Text = "用户昵称：" + user.Name;
        this.Fr_email.Text = "用户邮箱：" + user.UserID;
        this.Fr_school.Text = "所在学校：" + user.School;
        this.Fr_department.Text = "所在院系：" + user.Department;
        this.friendsImage.ImageUrl = user.UserImagePath;
    }

    public void initial(AppUser user)
    {
        this.user = user;
    }

    protected void right_button_Click(object sender, ImageClickEventArgs e)
    {
        string me = Session["userID"] as string;
        AppFriendManage.deleteAttention(me, user.UserID);
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("Page_Load");
        mi.Invoke(page, new object[] { null, null });
    }
    protected void friendsImage_Click(object sender, ImageClickEventArgs e)
    {
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("getUserPublic");
        mi.Invoke(page, new object[] { this.user });
    }
}