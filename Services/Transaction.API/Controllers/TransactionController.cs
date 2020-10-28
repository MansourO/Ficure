using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transaction.API.Models;

namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FCTransaction> GetTransactions()
        {
            return new List<FCTransaction>()
            {
                new FCTransaction()
                {
                    Name = "Test 1",
                    TransactionDate = DateTime.Now
                },
                new FCTransaction()
                {
                    Name = "Test 2",
                    TransactionDate = DateTime.Now.AddDays(3)
                }
            };
        }
    }
}
