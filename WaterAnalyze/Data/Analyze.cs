using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Analyze
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public double? AcidityIndex { get; set; }

    public double? Hardness { get; set; }

    public double? Сhlorine { get; set; }

    public double? Bicarbonate { get; set; }

    public double? Sulfate { get; set; }

    public double? Calcium { get; set; }

    public double? Magnesium { get; set; }

    public double? Iron { get; set; }

    public double? Oil { get; set; }

    public double? CommonMinerals { get; set; }

    public DateTime? DateOfSelection { get; set; }

    public int? SampleId { get; set; }

    public int? UserId { get; set; }

    public int? SourceId { get; set; }

    public virtual Sample? Sample { get; set; }

    public virtual Source? Source { get; set; }

    public virtual User? User { get; set; }
}
