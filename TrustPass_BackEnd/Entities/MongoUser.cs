namespace Entities;

public class MongoUser
{
    public long id { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public string? email { get; set; }
    public string? sso { get; set; }
}