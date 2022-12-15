namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

public class User: BaseEntity
{
    [Key]
    public int? id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? firstname { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? lastname { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? username { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string? email { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? password { get; set; }
    // public string? password { 
    //     get {
    //         return this.password;
    //     }
    //     set {
    //         this.password = BCrypt.HashPassword(value);
    //     }
    // }

    public ICollection<Recipe>? recipes { get; set; }
    public ICollection<Opinion>? opinions { get; set; }
}
