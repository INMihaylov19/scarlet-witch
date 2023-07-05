using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Skill
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
