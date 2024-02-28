using AutoMapper;
using BenchmarkDotNet.Attributes;
using ConsumerBrasil.Application.DataTransferObjects;
using ConsumerBrasil.Application.Interfaces;
using ConsumerBrasil.Domain.Interfaces;
using System.Diagnostics;

namespace ConsumerBrasil.Application.Services
{
    [MemoryDiagnoser]
    public class BrasilAPIService : IBrasilAPI
    {
        private readonly IBrasilAPIService _apiService;
        private readonly IMapper _mapper;
        public BrasilAPIService(IBrasilAPIService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }
        [Benchmark]
        public async Task<IEnumerable<BancosResponse>> GetAllBancos()
        {
            var banks = await _apiService.GetAllBancosAsync();
            var response = _mapper.Map<List<BancosResponse>>(banks);
            return response;


        }
        [Benchmark]
        public async Task<IEnumerable<BancosResponse>> GetBancosCache()
        {
            var banks = await _apiService.GetAllBancosAsync();
            var response = _mapper.Map<List<BancosResponse>>(banks);
            return response;
        }
    }
}
