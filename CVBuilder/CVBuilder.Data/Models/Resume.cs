using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Resume
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime LastModified { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
