namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Opinion: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    public int? grade { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string? comment { get; set; }

    [Required]
    public int? recipe_id { get; set; }
    public Recipe? recipe { get; set; }

    [Required]
    public int? user_id { get; set; }
    public User? user { get; set; }
}
