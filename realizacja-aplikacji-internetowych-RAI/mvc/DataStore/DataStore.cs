namespace mvc.DataStore
{
    public class Database
    {
        private Database() {
            _userJa.Friends.Add(_userKtos);
            _userJa.Friends.Add(_userKtosInny);
            _users.Add(_userKtos);
            _users.Add(_userJa);
            _users.Add(_userKtosInny);
        }
        private static Database _instance;
        
        private User _userJa = new User { Username = "ja" };
        private User _userKtos = new User { Username = "ktos" };
        private User _userKtosInny = new User { Username = "ktos inny" };
        private List<User> _users = new();

        public static Database GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }
            return _instance;
        }

        public List<User> GetFriendsOfUser(string username)
        {
            var user = _users.FirstOrDefault(user => user.Username == username);
            return user != null ? user.Friends : new();
        }

        public void RemoveFriendOfUser(string username, string usernameToRemove)
        {
            var user = _users.FirstOrDefault(user => user.Username == username);
            var friend = _users.FirstOrDefault(user => user.Username == usernameToRemove);
            if (user != null && friend != null)
            {
                user.Friends.Remove(friend);
            }
        }
        public void AddFriendOfUser(string username, string usernameToAdd)
        {
            var user = _users.FirstOrDefault(user => user.Username == username);
            var friend = _users.FirstOrDefault(user => user.Username == usernameToAdd);
            if (user != null && friend != null)
            {
                if (user.Friends.Contains(friend))
                {
                    return;
                }
                user.Friends.Add(friend);
            }
        }

        public List<User> GetUsers()
        {
            return _users;
        }
        
        public void AddUser(string username)
        {
            var user = _users.FirstOrDefault(user => user.Username == username);
            if (user != null)
            {
                return;
            }
            _users.Add(new User { Username = username });
        }
        public void RemoveUser(string username)
        {
            foreach (var user in _users)
            {
                var friend = user.Friends.FirstOrDefault(friend => friend.Username == username);
                if (friend != null)
                {
                    user.Friends.Remove(friend);
                }
            }

            var userTemp = _users.FirstOrDefault(user => user.Username == username);
            if (userTemp != null)
            {
                _users.Remove(userTemp);
            }
        }
    }
}
