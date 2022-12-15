namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RecipeStep: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    public int? position { get; set; }

    [Required]
    public string? content { get; set; }

    [Required]
    public int? recipe_id { get; set; }
    public Recipe? recipe { get; set; }

    public ICollection<RecipeStepFood>? recipeStepFoods { get; set; }
}
