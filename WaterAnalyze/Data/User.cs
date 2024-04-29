using System;
using System.Collections.Generic;

namespace WaterAnalyze.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? RoleId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
