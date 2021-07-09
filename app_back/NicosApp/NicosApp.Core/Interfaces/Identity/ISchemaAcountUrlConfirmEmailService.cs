using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Interfaces.Identity
{
    public interface ISchemaAcountUrlConfirmEmailService
    {

        string Protocol { get; }
        string Geturl(string idUsiuario, string code);
    }

}
