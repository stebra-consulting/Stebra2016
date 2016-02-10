using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net.Http;

/// <summary>
/// Summary description for Mail
/// </summary>
public class Mail
{
    public static string String()
    {
        return "Hello world";
    }
    public static string Send(string name, string email, string comments)
    {
       
        try
        {
            //https://sendgrid.com/docs/Integrate/Code_Examples/csharp.html
            var myMessage = new SendGrid.SendGridMessage();
            myMessage.AddTo("simon.bergqvist.91@gmail.com");  //to whom to post
            myMessage.From = new MailAddress("test@email.com", "Test My"); //from who
            myMessage.Subject = "Sending with SendGrid is Fun Test"; //subject
            myMessage.Text = "and easy to do anywhere, even with C#";//body

            var transportWeb = new SendGrid.Web(Keys.SendGridKey);
            transportWeb.DeliverAsync(myMessage);//it was to slow with wait, dont spam this to much, account going to get locked then.
            return "sent";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }


    }
}
//MailMessage mail = new MailMessage();
//SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

//mail.From = new MailAddress("felix.freye@gmail.com");
//mail.To.Add("info@stebra.se");
//mail.Subject = "Meddelade från stebra.se";
//mail.Body = comments + " FROM " + email;

//SmtpServer.Port = 587;
//SmtpServer.Credentials = new System.Net.NetworkCredential("felix.freye@gmail.com", "XXX");
//SmtpServer.EnableSsl = true;

//SmtpServer.Send(mail);