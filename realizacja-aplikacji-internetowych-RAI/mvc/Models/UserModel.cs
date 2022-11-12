using mvc.DataStore;

namespace mvc.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        
        public List<User> Friends { get; set; }
    }
}
