namespace NicosApp.Core.Interfaces.Identity
{
    public interface ISchemaAcountUrlConfirmEmailService
    {
        string Protocol { get; }
        string Geturl(string idUsiuario, string code);
    }
}
