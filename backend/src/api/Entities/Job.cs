namespace api.Entities;

public class Job
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime UpdatedAt { get; set; }
}