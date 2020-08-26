using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Models
{
    public class CreateContractModel
    {
        public string CarNumber { get; set; }
        public string PasspotId { get; set; }
        public bool isCredit { get; set; }
        public double? FirstPayment { get; set; }
        public double? CreditTerm { get; set; }
    }
}
