using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Certificate
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int ResumeId { get; set; }

    public virtual Resume Resume { get; set; } = null!;
}
