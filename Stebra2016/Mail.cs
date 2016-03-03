using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net.Http;
using System.Net;


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

        //Waiting for SendGrid SMTP

        //try
        //{
        //    //https://sendgrid.com/docs/Integrate/Code_Examples/csharp.html
        //    var myMessage = new SendGrid.SendGridMessage();
        //    myMessage.AddTo("simon.bergqvist.91@gmail.com"); //  info@stebra.se  //to whom to post
        //    myMessage.From = new MailAddress(email, name); //from who
        //    myMessage.Subject = "Stebra Website form"; //subject
        //    myMessage.Text = comments;//body

        //    var transportWeb = new SendGrid.Web(Keys.SendGridKey);
        //    transportWeb.DeliverAsync(myMessage);//it was to slow with wait, dont spam this to much, account going to get locked then.
        //    return "sent";
        //}
        //catch (Exception ex)
        //{
        //    return ex.ToString();
        //}

        MailMessage mail = new MailMessage();
        mail.To.Add("info@stebra.se");
        mail.From = new MailAddress("stebra@website.com");
        mail.Subject = "Message from our Stebra.se";

        mail.Body = comments + "// " + email + "// " + name;

        SmtpClient sc = new SmtpClient("smtp.gmail.com");
        NetworkCredential nc = new NetworkCredential("leifetwalder", "Mailservice");//username doesn't include @gmail.com
        sc.UseDefaultCredentials = false;
        sc.Credentials = nc;
        sc.EnableSsl = true;
        sc.Port = 587;
        try
        {
            sc.Send(mail);
            return "success";
        }
        catch (Exception ex)
        {
            //EventLog.WriteEntry("Error Sending", EventLogEntryType.Error);
            return ex.ToString();
        }


    }
}
