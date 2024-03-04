using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class SamplingFrequency
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public virtual ICollection<Source> Sources { get; set; } = new List<Source>();
}
