using LibraryManagementSystem.Managers;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public string Password { get; set; }

    public Random generateUserId = new Random();

    public User()
    {
        Name = "";
        Email = "";
        PhoneNumber = "";
        Password = "";
        // randomly generates an 8 digit user id for user
        UserId = generateUserId.Next(10000000, 99999999);
    }
}

public class UserAccount
{
    private User user;

    public UserAccount()
    {
        user = new User();
    }

    public UserAccount UserName(string name)
    {
        user.Name = name;
        return this;
    }
    public UserAccount UserEmail(string email)
    {
        user.Email = email;
        return this;
    }
    public UserAccount UserPhone(string phone)
    {
        user.PhoneNumber = phone;
        return this;
    }
    public UserAccount UserUserId()
    {
        return this;
    }
    public UserAccount UserPassword(string password)
    {
        user.Password = password;
        return this;
    }

    public User UserCreate()
    {
        return user;
    }
}