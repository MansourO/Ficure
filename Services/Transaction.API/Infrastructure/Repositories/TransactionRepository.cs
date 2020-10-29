using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.API.Model;

namespace Transaction.API.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        public IEnumerable<UserTransaction> GetTransactions(Guid UserId);
    }

    public class MockTransactionRepository : ITransactionRepository
    {
        public IEnumerable<UserTransaction> GetTransactions(Guid UserId)
        {
            //TODO: Refactor into service layer
            var userId = new Guid("79e814c5-31e8-4a91-8c97-8c57cfccbc33");
            var userId2 = new Guid("c75fdddf-183b-493b-a77f-d0cb7817ec2e");

            var mockTransactions =  new List<UserTransaction>()
            {
                new UserTransaction()
                {
                    UserId = userId,
                    Name = "Test 1",
                    Amount = -10m
                },
                new UserTransaction()
                {
                    UserId = userId,
                    Name = "Test 2",
                    Amount = 25m
                },
                 new UserTransaction()
                {
                    UserId = userId2,
                    Name = "Test 2",
                    Amount = 25m
                }
            };

            return mockTransactions.Where(x => x.UserId == UserId).ToList();
        }
    }
}
