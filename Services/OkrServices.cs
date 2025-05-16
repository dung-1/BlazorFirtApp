using BlazorApp1.Data.Models;
using Supabase;

namespace BlazorApp1.Services
{
    public class OkrServices
    {
        private readonly Client _client;

        public OkrServices(Client client)
        {
            _client = client;
        }

        public async Task<List<Taget>> GetAllOkrsAsync()
        {
            var result = await _client.From<Taget>().Get();
            return result.Models;
        }

        public async Task AddOkrsAsync(Taget news)
        {
            var response = await _client.From<Taget>().Insert(news);
            if (response.Models == null || response.Models.Count == 0)
            {
                throw new Exception("Failed to add news to Supabase.");
            }
        }


        public async Task UpdateOkrsAsync(Taget news)
        {
            await _client.From<Taget>().Update(news);
        }

        //public async Task DeleteOkrsAsync(Guid id)
        //{
        //    await _client.From<Taget>().Where(x => x.Id == id).Delete();
        //}

    }
}
