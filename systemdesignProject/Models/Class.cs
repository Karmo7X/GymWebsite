using System;
using System.Collections.Generic;

namespace systemdesignProject.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Trainerid { get; set; }

    public TimeOnly Time { get; set; }

    public string day { get; set; }

    public int Planid { get; set; }

    public int Userid { get; set; }

    public string? Img { get; set; }

    public virtual Planstable Plan { get; set; } = null!;

    public virtual Ourteam Trainer { get; set; } = null!;

    public virtual Userstable User { get; set; } = null!;
}
