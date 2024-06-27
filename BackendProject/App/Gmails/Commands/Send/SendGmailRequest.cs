namespace BackendProject.App.Gmails.Commands.Send;

public class SendGmailRequest
{
    public string Subject { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Body { get; set; }
}