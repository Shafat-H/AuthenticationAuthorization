using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class Student
{
    public long StudentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public bool IsActive { get; set; }

    public long? UserId { get; set; }
}
