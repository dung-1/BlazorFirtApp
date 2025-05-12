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

        public async Task AddNewsAsync(News news)
        {
            var response = await _client.From<News>().Insert(news);
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new Exception("Failed to add news to Supabase.");
            }
        }


        public async Task UpdateNewsAsync(News news)
        {
            await _client.From<News>().Update(news);
        }

        public async Task DeleteNewsAsync(Guid id)
        {
            await _client.From<News>().Where(x => x.Id == id).Delete();
        }

    }
}