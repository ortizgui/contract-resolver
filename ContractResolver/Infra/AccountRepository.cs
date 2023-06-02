using ContractResolver.Domain.Models;

namespace ContractResolver.Infra;

public interface IAccountRepository
{
    Account GetAccountFromDatabase(int id);
}

public class AccountRepository : IAccountRepository
{
    public Account GetAccountFromDatabase(int id)
    {
        return new Account { Id = id, Status = "Active", Number = "12345" };
    }
}