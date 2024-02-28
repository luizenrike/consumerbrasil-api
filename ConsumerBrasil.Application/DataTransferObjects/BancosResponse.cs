using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerBrasil.Application.DataTransferObjects
{
    public class BancosResponse
    {
        public string Ispb { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public string FullName { get; set; }
    }
}
