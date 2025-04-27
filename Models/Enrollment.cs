using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class Enrollment
{
    public long EnrollmentId { get; set; }

    public long StudentId { get; set; }

    public long CourseId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public string? Grade { get; set; }

    public bool IsActive { get; set; }
}
