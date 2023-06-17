using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.CarTyps
{
    public interface ICarType
    {
        string GenerateRegistrationNumber(string endCustomerRegistrationReference,out string registrationRegistrationId);
    }
}
