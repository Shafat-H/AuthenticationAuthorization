using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class User
{
    public long UserId { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Role { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
