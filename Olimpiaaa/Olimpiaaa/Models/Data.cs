using System;
using System.Collections.Generic;

namespace Olimpiaaa.Models;

public partial class Data
{
    public Guid Id { get; set; }

    public string Country { get; set; } = null!;

    public string County { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public Guid PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;
}
