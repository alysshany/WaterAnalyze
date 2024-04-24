using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Task
{
    public int Id { get; set; }

    public string? Info { get; set; }

    public bool? IsDone { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
