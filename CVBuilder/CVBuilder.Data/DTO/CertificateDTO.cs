using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.DTO
{
    public class CertificateDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Organization { get; set; } = null!;

        public DateTime IssueDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
