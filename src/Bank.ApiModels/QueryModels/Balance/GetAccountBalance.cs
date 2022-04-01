using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ApiModels.QueryModels.Balance
{
    public class GetAccountBalance
    {
        public class Request
        {
            public int Id { get; set; }
        }

        public class Response : BaseResponse
        {
            public int Id { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
