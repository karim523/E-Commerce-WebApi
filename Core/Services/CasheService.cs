namespace Services
{
    public class CasheService(ICasheRepository casheRepository) : ICasheService
    {
        public async Task<string?> GetCasheValueAsync(string key)
            => await casheRepository.GetAsync(key);

        public async Task SetCasheValueAsync(string key, string value, TimeSpan duration)
            => await casheRepository.SetAsync(key, value, duration);

    }
}
