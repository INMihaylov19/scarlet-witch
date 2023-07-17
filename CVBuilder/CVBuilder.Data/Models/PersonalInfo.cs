using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class PersonalInfo
{
    public Guid Id { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
