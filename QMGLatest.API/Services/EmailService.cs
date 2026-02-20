using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendOtpAsync(string toEmail, string otp)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
            return;

        var fromEmail = _config["EmailSettings:FromEmail"];
        var password = _config["EmailSettings:Password"];
        var host = _config["EmailSettings:SmtpHost"];
        var port = int.Parse(_config["EmailSettings:Port"]);

        var message = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = "Your Login OTP",
            Body = $"Your OTP is: {otp}\nValid for 5 minutes.",
            IsBodyHtml = false
        };

        message.To.Add(toEmail);

        using var smtp = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        await smtp.SendMailAsync(message);
    }
}
