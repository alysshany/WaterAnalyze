using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class SourceType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Source> Sources { get; set; } = new List<Source>();
}
