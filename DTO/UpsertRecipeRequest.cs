namespace ApiScrabble.DTO;

public class UpsertRecipeRequest
{
    public string? name { get; set; }
    public int? nb_people { get; set; }
    public int? preparation_time { get; set; }
    public string? description { get; set; }
}