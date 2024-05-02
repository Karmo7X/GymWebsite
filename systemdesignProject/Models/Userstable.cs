using System;
using System.Collections.Generic;

namespace systemdesignProject.Models;

public partial class Userstable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
