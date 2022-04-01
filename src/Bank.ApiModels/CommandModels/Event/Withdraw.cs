namespace Bank.ApiModels.CommandModels.Event
{
    public class Withdraw
    {
        public class Request
        {
            public int Id { get; set; }
            public decimal Amount { get; set; }
        }

        public class Response : BaseResponse
        {
            public int Id { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
