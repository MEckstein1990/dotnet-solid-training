using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.CarTyps
{
    public class Ford : ICarType
    {
        public string GenerateRegistrationNumber(string endCustomerRegistrationReference,out string registrationRegistrationId)
        {
            registrationRegistrationId = DateTime.Now.Ticks.ToString();
            return string.IsNullOrWhiteSpace(endCustomerRegistrationReference) ? registrationRegistrationId : endCustomerRegistrationReference;
        }
    }
}
