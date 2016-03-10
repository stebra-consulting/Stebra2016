using System;
using System.Net.Mail;
using System.Net.Mime;

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

            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress("info@stebra.se"));

            // From
            mailMsg.From = new MailAddress(email, name);

            // Subject and multipart/alternative Body
            mailMsg.Subject = "new message from www.stebra.se";

            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(comments, null, MediaTypeNames.Text.Plain));

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_77d9c935ae3fb9ff42b3a42be4b9a2fb@azure.com", Keys.SendGridKey);
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
            return "";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return ex.Message.ToString();
        }

    }
}
