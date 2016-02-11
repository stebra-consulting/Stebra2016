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
            myMessage.AddTo("simon.bergqvist.91@gmail.com"); //  info@stebra.se  //to whom to post
            myMessage.From = new MailAddress(email, name); //from who
            myMessage.Subject = "Stebra Website form"; //subject
            myMessage.Text = comments;//body

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
