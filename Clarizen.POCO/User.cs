namespace Clarizen.POCO
{
    public class User
    {
        public string id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public User(string id, string firstName, string lastName, string email, string userName)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = userName;
        }

        public User(string firstName, string lastName, string email, string userName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = userName;
        }

        public User()
        {

        }
    }
}
