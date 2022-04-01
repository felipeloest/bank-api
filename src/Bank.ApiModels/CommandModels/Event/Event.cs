using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ApiModels.CommandModels.Event
{
    public class Event
    {
        public decimal Amount { get; set; }
        public int Destination { get; set; }
    }
}
