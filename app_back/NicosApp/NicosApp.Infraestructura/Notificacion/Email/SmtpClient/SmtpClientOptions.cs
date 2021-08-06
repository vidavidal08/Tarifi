namespace NicosApp.Infraestructura.Notificacion.Email.SmtpClient
{
    public class SmtpClientOptions
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? EnableTsl { get; set; }
    }
}
