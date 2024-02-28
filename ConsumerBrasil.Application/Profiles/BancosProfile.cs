using AutoMapper;
using ConsumerBrasil.Application.DataTransferObjects;
using ConsumerBrasil.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBrasil.Application.Profiles
{
    public class BancosProfile : Profile
    {

        public BancosProfile()
        {
            SetupOutBound();
        }
        private void SetupOutBound()
        {
            CreateMap<BancosResponseViewModel, BancosResponse>();
        }
    }
}
