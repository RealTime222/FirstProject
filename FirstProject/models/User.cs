using System;
using System.Collections.Generic;

namespace FirstProject.models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Password { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
