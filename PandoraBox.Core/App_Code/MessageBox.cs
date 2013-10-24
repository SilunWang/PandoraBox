using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// MessageBox 的摘要说明
/// </summary>

namespace MB
{
    public enum MsgType
    {
        Ok, Warn, Error
    }
    public class MessageBox : System.Web.UI.Page
    {
        
        public void show(string info, HttpContext context)
        {
            ClientScript.RegisterStartupScript(context.GetType(), "warning",
                    "<script>scscms_alert(" + info + ");</script>");
        }
        public void show(string info, MsgType type, HttpContext context)
        {
            switch (type)
            {
                case MsgType.Ok:
                    ClientScript.RegisterStartupScript(context.GetType(), "warning",
                    "<script>scscms_alert(" + info + ", \"ok\");</script>");
                    break;
                case MsgType.Warn:
                    ClientScript.RegisterStartupScript(context.GetType(), "warning",
                    "<script>scscms_alert(" + info + ", \"warn\");</script>");
                    break;
                case MsgType.Error:
                    ClientScript.RegisterStartupScript(context.GetType(), "warning",
                    "<script>scscms_alert(" + info + ", \"error\");</script>");
                    break;
                default:
                    break;
            }
        }

    }
}
