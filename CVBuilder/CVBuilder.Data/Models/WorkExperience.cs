using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class WorkExperience
{
    public Guid Id { get; set; }

    public string Company { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Description { get; set; } = null!;

    //public Guid ResumeId { get; set; }

    //public virtual Resume Resume { get; set; } = null!;
}
