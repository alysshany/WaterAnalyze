using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class Account
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
