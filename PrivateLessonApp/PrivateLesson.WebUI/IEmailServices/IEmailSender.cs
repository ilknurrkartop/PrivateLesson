namespace PrivateLesson.WebUI.IEmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
