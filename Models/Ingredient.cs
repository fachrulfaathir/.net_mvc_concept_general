using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testing_general.Models;

public partial class Ingredient
{
    [Key]
    public long IngredientId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }
}
