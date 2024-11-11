using System;
using System.Collections.Generic;

namespace Olimpiaaa.Models;

public partial class Player
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int Weight { get; set; }

    public int Height { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual ICollection<Data> Data { get; set; } = new List<Data>();
}
