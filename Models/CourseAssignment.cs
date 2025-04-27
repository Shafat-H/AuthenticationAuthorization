using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class CourseAssignment
{
    public long AssignmentId { get; set; }

    public long InstructorId { get; set; }

    public long CourseId { get; set; }

    public long ClassroomId { get; set; }

    public DateTime AssignmentDate { get; set; }

    public bool IsActive { get; set; }
}
