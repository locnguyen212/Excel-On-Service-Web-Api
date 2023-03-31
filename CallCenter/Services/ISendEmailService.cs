using CallCenter.Utils.UtilModels;

namespace CallCenter.Services
{
    public interface ISendEmailService
    {
        public void SendEmail(EmailModel emailModel);
    }
}
