using System;
using System.Collections.Generic;

namespace Trainer_EF_Layer.Entities;

public partial class TrainerDetail
{
    public string UserId { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual Company? Company { get; set; }

    public virtual Education? Education { get; set; }

    public virtual Skill? Skill { get; set; }
}
