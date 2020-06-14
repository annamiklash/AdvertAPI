using System.Collections;
using System.Collections.Generic;

namespace AdvertAPI.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Salt { get; set; }
        public virtual IEnumerable<Campaign> Campaign { get; set; }
        public  AccessToken AccessToken { get; set; }
        public  RefreshToken RefreshToken { get; set; }
    }
}