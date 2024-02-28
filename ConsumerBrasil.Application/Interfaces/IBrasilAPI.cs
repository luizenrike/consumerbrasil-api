using ConsumerBrasil.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBrasil.Application.Interfaces
{
    public interface IBrasilAPI
    {
        public Task<IEnumerable<BancosResponse>> GetAllBancos();
        public Task<IEnumerable<BancosResponse>> GetBancosCache();
    }
}
