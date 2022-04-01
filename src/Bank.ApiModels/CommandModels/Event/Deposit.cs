using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ApiModels.CommandModels.Event
{
    public class InsertBalance
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
