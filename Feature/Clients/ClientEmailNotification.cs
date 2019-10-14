namespace Feature.Clients
{
    public class ClientEmailNotification
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public ClientEmailNotification(string from, string to, string subject, string message)
        {
            this.From = from;
            this.To = to;
            this.Subject = subject;
            this.Message = message;
        }
    }
}
