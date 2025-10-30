using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testing_general.Models;

public partial class Dish
{
    [Key]
    public long DishId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }
}
