namespace mvc.DataStore
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public List<User> Friends { get; set; } = new List<User>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
