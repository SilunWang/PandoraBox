using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class Pages_Enclosure : System.Web.UI.UserControl
{
    string m_text;
    static string m_filePath;
    public void initial(string text)
    {
        this.m_text = text;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        EnclosureText.Text = m_text;
        EnclosureText.NavigateUrl = m_text;
    }
    [WebMethod]
    public static void commit(string filePath)
    {
        m_filePath = filePath;
    }
}