using System;
using System.Collections.Generic;

namespace HectorCoffeShop.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LasName { get; set; }

    public string? Gender { get; set; }
}
