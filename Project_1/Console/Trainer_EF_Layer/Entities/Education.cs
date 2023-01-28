using System;
using System.Collections.Generic;

namespace Trainer_EF_Layer.Entities;

public partial class Education
{
    public string UserId { get; set; } = null!;

    public string UgCollage { get; set; } = null!;

    public string UgStream { get; set; } = null!;

    public string UgPercentage { get; set; } = null!;

    public string UgYear { get; set; } = null!;

    public string? PgCollage { get; set; }

    public string? PgStream { get; set; }

    public string? PgPercentage { get; set; }

    public string? PgYear { get; set; }

    public virtual TrainerDetail User { get; set; } = null!;
}
