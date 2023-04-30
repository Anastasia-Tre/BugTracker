namespace BugTracker.DataModel;

public class User<TKey>
{
    public TKey Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Title { get; set; }
    public string Bio { get; set; }

    public Project<TKey> Projects { get; set; }
    public Task<TKey> Tasks { get; set; }
}
