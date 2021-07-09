using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using NicosApp.Core.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.API.Services
{
    public class SchemaAcountUrlConfirmEmailService : ISchemaAcountUrlConfirmEmailService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        private readonly LinkGenerator _generator;



        public SchemaAcountUrlConfirmEmailService(IHttpContextAccessor httpContextAccessor,
                                                  LinkGenerator generator)
        {
            _httpContextAccessor = httpContextAccessor;
            _generator = generator;
        }

        public string Protocol => _httpContextAccessor.HttpContext?.Request?.Scheme;



        public string Geturl(string idUsiuario, string token)
        {
            var callbackLink = _generator.GetUriByAction(_httpContextAccessor.HttpContext,
                action: "ConfirmarEmail",
                values: new { userId = idUsiuario, token = token });


            return callbackLink;
        }



    }
}
