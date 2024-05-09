namespace API_Assignment_Day2.Models
{
    public class DummyUserData
    {
        public static List<User> Users = new List<User>
        {
            new User { UserName = "admin", Password = "1", Role = "admin" },
            new User { UserName = "user", Password = "1", Role = "user" }
        };
    }
}
