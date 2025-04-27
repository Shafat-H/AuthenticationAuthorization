using System;
using System.Collections.Generic;

namespace AuthenticationAuthorization.Models;

public partial class Classroom
{
    public long ClassroomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? Building { get; set; }

    public long Capacity { get; set; }

    public bool IsActive { get; set; }
}
