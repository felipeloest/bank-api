using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ApiModels.QueryModels
{
    public class FindAccount
    {
        public const string Route = "balance";
        public class Request
        {
            public Guid Id { get; set; }
        }

        public class Response
        { }

        public class ResponseDto
        {
            public Guid Id { get; set; }
        }
    }

}
