using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Sample
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();
}
