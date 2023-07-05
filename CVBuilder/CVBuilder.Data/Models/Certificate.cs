using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ResumeId { get; set; }
    }
}
