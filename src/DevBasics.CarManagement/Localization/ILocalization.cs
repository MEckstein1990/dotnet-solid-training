using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.Localization
{
    public interface ILocalization
    {
        public IDictionary<string, string> LanguageCodes { get; set; }
        public IDictionary<string, int> TimeZones { get; set; }
    }
}
