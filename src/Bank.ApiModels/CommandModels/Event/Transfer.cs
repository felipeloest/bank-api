namespace Bank.ApiModels.CommandModels.Event
{
    public class Transfer
    {
        public class Request
        {
            public int SourceId { get; set; }
            public decimal Amount { get; set; }

            public int TargetId { get; set; }
        }

        public class Response : BaseResponse
        {
            public int SourceId { get; set; }
            public decimal SourceBalance { get; set; }

            public int TargetId { get; set; }
            public decimal TargetBalance { get; set; }
        }
    }
}
