using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Users
{
    public class User : BaseEntity
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<string> Roles { get; private set; }
        public bool IsActivated { get; private set; }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
            
            Roles = new List<string>();
        }
        
    }
}