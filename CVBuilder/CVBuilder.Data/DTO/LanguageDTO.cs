using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.DTO
{
    public class LanguageDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public byte Proficiency { get; set; }
    }
}
