using System.ComponentModel;
using ContractResolver.Domain.Models;
using ContractResolver.Infra;

namespace ContractResolver.Domain.Handler;

public interface IAccountHandler
{
    AccountResult GetAccount(int id, string? fields);
}

public class AccountHandler : IAccountHandler
{
    private readonly IAccountRepository _accountRepository;

    public AccountHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public AccountResult GetAccount(int id, string? fields)
    {
        // Recuperar o objeto da base de dados.
        var account = _accountRepository.GetAccountFromDatabase(id);

        if (account == null) return new AccountResult { StatusCode = 404 };

        // Se fields é null ou vazio, então todos os campos serão selecionados
        var fieldList = (string.IsNullOrEmpty(fields)) 
            ? TypeDescriptor.GetProperties(typeof(Account))
                .Cast<PropertyDescriptor>()
                .Select(prop => prop.Name)
            : fields.Split(',').ToList();

        var accountDict = new Dictionary<string, object?>();

        foreach (var field in fieldList)
        {
            var property = TypeDescriptor.GetProperties(typeof(Account)).Find(field, true);

            if (property == null)
            {
                return new AccountResult { StatusCode = 400, ErrorMessage = $"O campo '{field}' não existe" };
            }

            accountDict.Add(field, property.GetValue(account));
        }

        return new AccountResult { StatusCode = 200, Data = accountDict };
    }
}
