namespace ApiScrabble.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
}