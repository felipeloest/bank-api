namespace Bank.ApiModels.CommandModels.Event
{
    public class Event
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int Destination { get; set; }
        public int Origin { get; set; }
    }
}
