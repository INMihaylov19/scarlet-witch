using System;
using System.Collections.Generic;

namespace CVBuilder.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte[]? Salt { get; set; }

    public virtual ICollection<PersonalInfo> PersonalInfos { get; set; } = new List<PersonalInfo>();

    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
