using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.CarMangement
{
    public interface ICarManagementSettings
    {
        IDictionary<int, string> ApiEndpoints { get; set; }
        IDictionary<string, string> HttpHeaders { get; set; }
    }
}
