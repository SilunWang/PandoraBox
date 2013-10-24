using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;
using System.Reflection;

public partial class Pages_deBlocking : System.Web.UI.UserControl
{
    private AppUser limituser;

    protected void Page_Load(object sender, EventArgs e)
    {
        User.Text = "被封用户ID:" + limituser.UserID;
        Time.Text = "被封时间:" + limituser.LimitTime;
    }

    public void initial(AppUser user)
    {
        this.limituser = user;
    }
    protected void OutButton_Click(object sender, ImageClickEventArgs e)
    {
        AppUserManage.authorityUpdate(limituser.UserID, AppUserAuthority.normal);
        System.Web.UI.Page page = this.Page;
        Type pageType = page.GetType();
        MethodInfo mi = pageType.GetMethod("Page_Load");
        mi.Invoke(page, new object[] { null, null });
    }
}