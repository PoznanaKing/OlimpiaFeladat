using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]

    public virtual Player Player { get; set; } = null!;
}
