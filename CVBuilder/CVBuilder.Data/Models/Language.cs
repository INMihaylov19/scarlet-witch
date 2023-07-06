using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Language
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public byte Proficiency { get; set; }

    public Guid ResumeId { get; set; }

    public virtual Resume Resume { get; set; } = null!;
}
