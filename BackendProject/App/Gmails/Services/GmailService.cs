using System.Net;
using System.Net.Mail;
using BackendProject.App.Gmails.Commands.Send;
using BackendProject.App.Gmails.Services.IServices;
using BackendProject.Shared;

namespace BackendProject.App.Gmails.Services;

public class GmailService : IGmailService
{
    public async Task<ServiceResponse> SendGmail(SendGmailRequest request)
    {
        const string fromMail = "raminabd444@gmail.com";
        const string fromPassword = "mpxtbsgovlrcijkt";

        var message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = request.Subject;
        message.To.Add(new MailAddress("raminabd444@gmail.com"));
        message.IsBodyHtml = true;
        
        var emailBody =  request.Body;
        emailBody += "<br><br> From: " + request.FirstName + " " + request.LastName + " <br>";
        
        message.Body = emailBody;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);
        return ServiceResponse.SucceededInstance();
    }
}