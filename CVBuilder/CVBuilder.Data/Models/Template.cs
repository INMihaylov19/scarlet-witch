using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class Template
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;
}
