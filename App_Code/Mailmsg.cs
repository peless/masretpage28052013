using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Web.UI;

/// <summary>
/// Summary description for Mail
/// </summary>
public class Mailmsg
{



    public Mailmsg()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public void Send(string Body,string subject)
    {
        try
        {

        SmtpClient smtpClient = new SmtpClient();
        NetworkCredential basicCredential = new NetworkCredential("nephromorsys", "Orr190557");
        MailMessage message = new MailMessage();
        MailAddress fromAddress = new MailAddress("nephromorsys@gmail.com");

        //smtpClient.Credentials = new NetworkCredential("nephromorsys", "Orr190557"); 
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = basicCredential;
        smtpClient.Port = 25;
        smtpClient.EnableSsl = true;

        message.From = fromAddress;
        message.Subject = subject;
        //Set IsBodyHtml to true means you can send HTML email.
        message.IsBodyHtml = true;
        message.Body = "<h1> " + Body +"</h1>";
        message.To.Add("orr.peless@gmail.com");
        //message.To.Add("ranigal@gmail.com");
        //message.To.Add("bigm86@gmail.com");

            smtpClient.Send(message);
        }
        catch (Exception ex)
        {
            //Error, could not send the message
            //Response.Write(ex.Message);
            throw ex;
        }
    }

    public string RenderControl(Control ctrl)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ctrl.RenderControl(hw);
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        
        

}