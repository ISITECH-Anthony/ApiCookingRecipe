namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recipe: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? name { get; set; }

    public int? nb_people { get; set; }

    [Required]
    public int? preparation_time { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? description { get; set; }

    [Required]
    public int? user_id { get; set; }
    public User? user { get; set; }

    public ICollection<RecipeStep>? recipeSteps { get; set; }
    public ICollection<Opinion>? opinions { get; set; }
}
