using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.DTO
{
    public class EducationDTO
    {
        public Guid Id { get; set; }

        public string Institute { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public string FieldOfStudy { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
