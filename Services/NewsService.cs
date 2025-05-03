using BlazorApp1.Data.Models;
using Supabase;
namespace BlazorApp1.Services
{
    public class NewsService
    {
        private readonly Client _client;

        public NewsService(Client client)
        {
            _client = client;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            var result = await _client.From<News>().Get();
            return result.Models;
        }
    }
}