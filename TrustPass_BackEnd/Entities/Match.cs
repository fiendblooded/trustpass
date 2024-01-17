using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("matches")]
public class Match
{
    public long Id { get; set; }
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public string Where { get; set; }
    public DateTime When { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public List<User> Users { get; } = new();
    // public List<Ticket> Tickets { get; } = new();
}