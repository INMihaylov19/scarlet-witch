using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data.DTO
{
    public class WorkExperienceDTO
    {
        public Guid Id { get; set; }

        public string Company { get; set; } = null!;

        public string Position { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; } = null!;
    }
}
