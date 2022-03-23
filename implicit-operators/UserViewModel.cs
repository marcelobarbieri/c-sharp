public class UserViewModel
{
    public UserViewModel(string userName)
        => UserName = userName;

    public string UserName { get; }

    public static implicit operator UserViewModel(User user)
        => new UserViewModel(user.Username);

    public override string ToString()
    {
        return $"UserName: {UserName}";
    }
}