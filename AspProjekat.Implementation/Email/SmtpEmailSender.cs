using AspProjekat.Application.Emails;
using System.Net;
using System.Net.Mail;

namespace AspProjekat.Implementation.Email
{
	public class SmtpEmailSender : IEmailSender
	{
		public void Send(SendEmailDto dto)
		{
			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("iceblader1332@gmail.com", "Goblingoblin99!")
			};

			var message = new MailMessage("iceblader1332@gmail.com", dto.SendTo);
			message.Subject = dto.Subject;
			message.Body = dto.Content;
			message.IsBodyHtml = true;
			smtp.Send(message);
		}
	}
}
