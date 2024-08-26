namespace api.Entities;

public class Application
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Resume { get; set; }
    public DateTime DateApplied { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; }
}