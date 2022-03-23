public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Username: {Username}, Password: {Password}, Active: {Active}";
    }
}