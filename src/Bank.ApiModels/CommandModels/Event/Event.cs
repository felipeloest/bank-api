using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ApiModels.CommandModels.Event
{
    public class Event
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int Destination { get; set; }
        public int Origin { get; set; }
    }

    public enum EventTypes
    {
        [Description("deposit")]
        Deposit,

        [Description("withdraw")]
        Withdraw,

        [Description("transfer")]
        Transfer,
    }
}
