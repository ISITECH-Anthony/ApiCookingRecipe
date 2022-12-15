namespace ApiScrabble.DTO;

public class UpsertUserRequest
{
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? username { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
}