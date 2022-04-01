namespace Bank.ApiModels.CommandModels.Event
{
    public class CreateAccount
    {
        public class Request
        {
            public int Id { get; set; }
            public decimal InitialBalance { get; set; }
        }

        public class Response : BaseResponse
        {
            public int Id { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
