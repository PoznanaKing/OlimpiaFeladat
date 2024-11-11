using System;
using System.Collections.Generic;

namespace Olimpiaaa.Models;

public partial class Data
{
    public string Id { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string County { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
