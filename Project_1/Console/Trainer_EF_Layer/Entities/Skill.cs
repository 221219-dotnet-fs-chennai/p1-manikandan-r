using System;
using System.Collections.Generic;

namespace Trainer_EF_Layer.Entities;

public partial class Skill
{
    public string UserId { get; set; } = null!;

    public string Skill1 { get; set; } = null!;

    public string Skill2 { get; set; } = null!;

    public string? Skill3 { get; set; }

    public virtual TrainerDetail User { get; set; } = null!;
}
