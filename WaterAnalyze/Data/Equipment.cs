using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Equipment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? UserId { get; set; }

    public string? DocumentNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual User? User { get; set; }
}
