using System.Collections.Generic;

namespace PetShop.Infrastructure.Security
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Role> Roles { get; set; }
    }
}