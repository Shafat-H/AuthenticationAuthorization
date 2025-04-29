using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class Instructor
{
    public long InstructorId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Department { get; set; }

    public bool IsActive { get; set; }

    public long? UserId { get; set; }
}
