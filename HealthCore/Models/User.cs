using System;
using System.Collections.Generic;

namespace HealthCore.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }
}
