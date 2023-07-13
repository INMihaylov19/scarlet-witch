using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.DTO
{
    public class PersonalInfoDTO
    {
        public Guid Id { get; set; }

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}
