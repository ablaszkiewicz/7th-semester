namespace tsp_shared
{
    [Serializable]
    public class MyMessage
    {
        public string Text { get; set; }

        public Cycle Cycle { get; set; }
    }
}