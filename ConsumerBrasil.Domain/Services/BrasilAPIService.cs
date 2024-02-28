using ConsumerBrasil.Domain.DataTransferObjects;
using ConsumerBrasil.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerBrasil.Domain.Services
{
    public class BrasilAPIService : IBrasilAPIService
    {
        private const string _banksUrl = "https://brasilapi.com.br/api/banks/v1";
        private const string KEY_BANK = "BANK_CACHE";

        private readonly IMemoryCache _memoryCache;
        public BrasilAPIService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<BancosResponseViewModel>> GetAllBancosAsync()
        {
            
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_banksUrl);
                var data = await response.Content.ReadAsStringAsync();
                var banks = JsonSerializer.Deserialize<List<BancosResponseViewModel>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return banks;
            }

        }

        public async Task<IEnumerable<BancosResponseViewModel>> GetAllBancosCacheAsync()
        {
            if(_memoryCache.TryGetValue(KEY_BANK, out List<BancosResponseViewModel> banks))
            {
                return banks;
            }

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_banksUrl);
                var data = await response.Content.ReadAsStringAsync();
                banks = JsonSerializer.Deserialize<List<BancosResponseViewModel>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var optionsCache = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1200),
                    SlidingExpiration = TimeSpan.FromSeconds(600)

                };
                _memoryCache.Set(KEY_BANK, banks, optionsCache);

                return banks;
            }

        }
    }
}
