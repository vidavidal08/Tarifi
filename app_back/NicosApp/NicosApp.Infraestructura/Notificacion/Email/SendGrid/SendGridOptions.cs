namespace NicosApp.Infraestructura.Notificacion.Email.SendGrid
{
    public class SendGridOptions
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
