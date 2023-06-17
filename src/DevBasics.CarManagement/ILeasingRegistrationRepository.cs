using DevBasics.CarManagement.Dependencies;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    public interface ILeasingRegistrationRepository
    {
         IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; }
    }

    public interface IGetAppSetting
    {
        Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin);
    }

    public interface IInsertHistory
    {
        Task<int> InsertHistoryAsync(CarRegistrationDto dbCar, string userName, string transactionStateName = null, string transactionTypeName = null);
    }

    public interface IUpdateCar
    {
        Task<bool> UpdateCarAsync(CarRegistrationDto dbCar);
    }
}
