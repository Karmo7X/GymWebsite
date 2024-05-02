using System;
using System.Collections.Generic;

namespace systemdesignProject.Models;

public partial class Planstable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int Userid { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
