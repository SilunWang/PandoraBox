using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

public class EmailManager
{
    static string From = "badjoker@163.com";
    static string Contents = "This is the content";

    public void setSender(string sender)
    {
        From = sender;
    }
    public string getSender()
    {
        return From;
    }
    public static void SetContents(string contents)
    {
        Contents = contents;
    }

    public static void sendEmailTo(string Receiver)
    {
        MailMessage message = new MailMessage(From, Receiver, "PandoraBox", Contents);
        SmtpClient client = new SmtpClient();
        client.Send(message);
    }
}
