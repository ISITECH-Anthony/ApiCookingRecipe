namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RecipeStepFood: BaseEntity
{
    public float? quantity { get; set; }

    // foreign key (nullable)
    public int? unit_measure_id { get; set; }
    public UnitMeasure? unit_measure { get; set; }

    [Required]
    public int? recipe_step_id { get; set; }
    public RecipeStep? recipe_step { get; set; }

    [Required]
    public int? food_id { get; set; }
    public Food? food { get; set; }
}
