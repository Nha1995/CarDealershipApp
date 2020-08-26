using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Models
{
    public class CarVm : CarBaseModel
    {
        public ClientBaseModel Client { get; set; }
    }
}
