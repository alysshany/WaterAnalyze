﻿using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();

    public virtual Role? Role { get; set; }
}
