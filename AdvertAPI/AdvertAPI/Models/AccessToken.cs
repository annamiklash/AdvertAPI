using System;

namespace AdvertAPI.Models
{
    public class AccessToken
    {
        public int IdAccessToken { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public DateTime IssueDateTime { get; set; }
        
        public int IdClient { get; set; }
        public virtual Client Client { get; set; }
    }
}