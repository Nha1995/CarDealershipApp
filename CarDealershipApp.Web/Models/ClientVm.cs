using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Models
{
    public class ClientVm : ClientBaseModel
    {  
        public List<CarBaseModel> Cars { get; set; }
    }
}
