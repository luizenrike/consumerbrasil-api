using ConsumerBrasil.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBrasil.Domain.Interfaces
{
    public interface IBrasilAPIService
    {
        public Task<IEnumerable<BancosResponseViewModel>> GetAllBancosAsync();
        public Task<IEnumerable<BancosResponseViewModel>> GetAllBancosCacheAsync();
    }
}
