using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transaction.API.Infrastructure.Repositories;
using Transaction.API.Model;

namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionController : ControllerBase
    {
        private readonly ILogger<UserTransactionController> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public UserTransactionController(ILogger<UserTransactionController> logger, 
                                         ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }


        [HttpGet("GetTransactions")]
        public IEnumerable<UserTransaction> GetTransactions([FromQuery] Guid UserId)
        {
            return _transactionRepository.GetTransactions(UserId);
        }
    }
}
