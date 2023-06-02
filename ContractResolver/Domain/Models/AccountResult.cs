namespace ContractResolver.Domain.Models;

public class AccountResult
{
    public int StatusCode { get; set; }
    public IDictionary<string, object?> Data { get; set; }
    public string ErrorMessage { get; set; }
}