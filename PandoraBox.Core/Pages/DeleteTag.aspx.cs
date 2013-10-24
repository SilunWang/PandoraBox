using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PandoraBox.AppCode;

public partial class Pages_DeleteTag : System.Web.UI.Page
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
        else if (tagTextRepeat.Text == null || tagTextRepeat.Text == "")
            tips = "请输入父标签";
        else if (tagTextRepeat.Text != TagText.Text)
            tips = "两次输入的不一致";
        else
            tips = AppTag.deleteTags(TagText.Text);
        Response.Write("<script>alert(\""+tips+"\")</script>");
    }
}