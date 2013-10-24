using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_MyConcern : System.Web.UI.UserControl
{
    AppUser user;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Co_uerName.Text = "用户昵称：" + user.Name;
        Co_email.Text = "用户邮箱：" + user.UserID;
        Co_school.Text = "所在学校：" + user.School;
        Co_department.Text = "所在院系：" + user.Department;
        this.friendsImage.ImageUrl = user.UserImagePath;
        //根据是否是好友决定允不允许加关注
        string me = Session["userID"] as string;
        if (me == user.UserID || AppFriendManage.isAttention(me, user.UserID))
        {
            AddConcern.ImageUrl = "~/CSS/HomePage/Friends/haveConcerned.png";
            AddConcern.Enabled = false;
        }
        else
        {
            AddConcern.ImageUrl = "~/CSS/HomePage/Friends/concern.png";
            AddConcern.Enabled = true;
        }
    }

    public void initial(AppUser user)
    {
        this.user = user;
    }

    protected void AddConcern_Click(object sender, ImageClickEventArgs e)
    {
        string me = Session["userID"] as string;
        if(me != user.UserID && !AppFriendManage.isAttention(me, user.UserID))
            AppFriendManage.addAttention(me, user.UserID);
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