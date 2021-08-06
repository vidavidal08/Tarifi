using NicosApp.Core.Common;
using System;

namespace NicosApp.Core.Entidades
{
    public class EmailMessage : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
