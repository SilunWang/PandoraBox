using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_AddTag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ReturnButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/MyHomepage.aspx");
    }
    protected void SubmitButton_Click(object sender, ImageClickEventArgs e)
    {
        string tips = "";
        if (TagText.Text == null || TagText.Text == "")
            tips = "请输入要添加的标签";
        else if (ParentLabelText.Text == null || ParentLabelText.Text == "")
            tips = "请输入父标签";
        else
            tips = AppTag.addTags(ParentLabelText.Text, TagText.Text);
        Response.Write("<script>alert(\""+tips + "\")</script>");
    }
}