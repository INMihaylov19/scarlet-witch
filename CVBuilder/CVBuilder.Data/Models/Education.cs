using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Education
{
    public Guid Id { get; set; }

    public string Institute { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public string FieldOfStudy { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ResumeId { get; set; }

    public virtual Resume Resume { get; set; } = null!;
}
