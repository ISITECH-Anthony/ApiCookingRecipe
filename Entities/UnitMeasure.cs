namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UnitMeasure: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    public string? name { get; set; }

    [Required]
    public string? abreviation { get; set; }

    public ICollection<RecipeStepFood>? recipeStepFoods { get; set; }
}
