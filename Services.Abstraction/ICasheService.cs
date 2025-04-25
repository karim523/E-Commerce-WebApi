namespace Services.Abstraction
{
    public interface ICasheService
    {
        Task<string?> GetCasheValueAsync(string key);

        Task SetCasheValueAsync(string key, string value, TimeSpan duration);
    }
}
