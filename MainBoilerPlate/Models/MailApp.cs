namespace MainBoilerPlate.Models
{
    public class MailApp
    {
        public string? MailTo { get; set; }
        public string? MailSubject { get; set; }
        public string? MailBody { get; set; }
        public string? MailFrom { get; set; }
        public bool SendCopy { get; set; } = false;
        public UserApp? Sender { get; set; }
        public UserApp? Receiver { get; set; }

    }
}
