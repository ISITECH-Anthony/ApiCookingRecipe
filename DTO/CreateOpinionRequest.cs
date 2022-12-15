namespace ApiScrabble.DTO;

public class CreateOpinionRequest
{
    public int? grade { get; set; }
    public string? comment { get; set; }
    public int? recipe_id { get; set; }
    public int? user_id { get; set; }
}