using NicosApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicosApp.Core.Entidades
{
    public class EmailMessage : BaseEntity<Guid>
    {

        public string Email { get; set; }


        public string Subject { get; set; }


        public string Body { get; set; }




    }
}
