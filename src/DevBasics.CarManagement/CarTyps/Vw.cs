using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.CarTyps
{
    internal class Vw : ICarType
    {
        public string GenerateRegistrationNumber(string endCustomerRegistrationReference,out string registrationRegistrationId)
        {
            Guid guid = Guid.NewGuid();
            registrationRegistrationId = guid.ToString();
            return guid.ToString();
        }
    }
}
