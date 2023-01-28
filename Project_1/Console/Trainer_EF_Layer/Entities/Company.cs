using System;
using System.Collections.Generic;

namespace Trainer_EF_Layer.Entities;

public partial class Company
{
    public string UserId { get; set; } = null!;

    public string? CompanyName { get; set; }

    public string? Field { get; set; }

    public string? OverallExperience { get; set; }

    public virtual TrainerDetail User { get; set; } = null!;
}
