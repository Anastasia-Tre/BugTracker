namespace BugTracker.DataModel;

public class User<TKey>
{
    public TKey Id { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
