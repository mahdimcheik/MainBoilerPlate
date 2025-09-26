using MainBoilerPlate.Models;

namespace MainBoilerPlate.Templates
{
    public class ResetPasswordModel
    {
        public UserApp Receiver { get; set; }
        public string ValidationLink { get; set; }
        public string WebsiteLink { get; set; } 

        public ResetPasswordModel(UserApp receiver, string resetLink, string websiteLink)
        {
            Receiver = receiver;
            ValidationLink = resetLink;
            WebsiteLink = websiteLink;
        }
    }

    public class ConfirmMailModel
    {
        public UserApp Receiver { get; set; }
        public string ConfirmLink { get; set; }
        public string WebsiteLink { get; set; }

        public ConfirmMailModel(UserApp receiver, string confirmLink, string websiteLink)
        {
            Receiver = receiver;
            ConfirmLink = confirmLink;
            WebsiteLink = websiteLink;
        }
    }
}
