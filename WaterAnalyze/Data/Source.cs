using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Source
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public TimeSpan? TravelTime { get; set; }

    public int? DirectionId { get; set; }

    public int? SourceTypeId { get; set; }

    public int? SamplingFrequencyId { get; set; }

    public string? CoordinatesX { get; set; }

    public string? CoordinatesY { get; set; }

    public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();

    public virtual Direction? Direction { get; set; }

    public virtual SamplingFrequency? SamplingFrequency { get; set; }

    public virtual SourceType? SourceType { get; set; }
}
