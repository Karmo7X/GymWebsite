using System;
using System.Collections.Generic;

namespace systemdesignProject.Models;

public partial class Ourteam
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Img { get; set; } = null!;

    public string Job { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
