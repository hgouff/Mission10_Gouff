using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission10_Gouff.Models;

public partial class Bowler
{
    //make BowlerID the primary Key
    //Question mark to allow null values
    [Key]
    [Required]
    public int BowlerID { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

    public int? TeamID { get; set; }

    public Team? Team { get; set; }
}