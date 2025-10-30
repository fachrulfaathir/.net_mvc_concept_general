using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testing_general.Models;

[Keyless]
public partial class DishIngredient
{
    public long DishId { get; set; }

    public long? IngredientId { get; set; }

    [ForeignKey("DishId")]
    public virtual Dish Dish { get; set; } = null!;

    [ForeignKey("IngredientId")]
    public virtual Ingredient? Ingredient { get; set; }
}
