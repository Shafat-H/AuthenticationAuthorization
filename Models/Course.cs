using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class Course
{
    public long CourseId { get; set; }

    public string CourseName { get; set; }

    public string CourseDescription { get; set; }

    public long Credits { get; set; }

    public bool IsActive { get; set; }
}
