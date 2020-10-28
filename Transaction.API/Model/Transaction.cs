using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transaction.API.Model
{
    public class UserTransaction
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
