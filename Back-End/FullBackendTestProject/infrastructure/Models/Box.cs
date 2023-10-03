namespace infrastructure.DataModels;

public class Box
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfCreation { get; set; }
    public string Category { get; set; }
}