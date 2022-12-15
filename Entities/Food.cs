namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Food: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? name { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? description { get; set; }

    public ICollection<RecipeStepFood>? recipeStepFoods { get; set; }
}
