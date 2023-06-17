using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBasics.CarManagement.Dependencies
{
    internal sealed class GetAppSetting : IGetAppSetting
    {
        public Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin)
        {
            return Task.FromResult(new AppSettingDto
            {
                SoldTo = "SoldTo01"
            });
        }
    }

    internal sealed class InsertHistory : IInsertHistory
    {
        private IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> _registrations { get; } = new Dictionary<int, Tuple<CarRegistrationDto, string, string, string>>();

        public InsertHistory(IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> registrations)
        {
            _registrations = registrations;
        }

        public Task<int> InsertHistoryAsync(CarRegistrationDto dbCar, string userName, string transactionStateName = null, string transactionTypeName = null)
        {
            if (!_registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                _registrations.Add(dbCar.RegisteredCarId, Tuple.Create(dbCar, userName, transactionStateName, transactionTypeName));

                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }
    }

    internal sealed class UpdateCar : IUpdateCar
    {
        private IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> _registrations { get; }

        public UpdateCar(IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> registrations)
        {
            _registrations = registrations;
        }

        public Task<bool> UpdateCarAsync(CarRegistrationDto dbCar)
        {
            if (!_registrations.ContainsKey(dbCar.RegisteredCarId))
            {
                return Task.FromResult(false);
            }

            var current = _registrations[dbCar.RegisteredCarId];

            _registrations[dbCar.RegisteredCarId] = Tuple.Create(dbCar, current.Item2, current.Item3, current.Item4);

            return Task.FromResult(true);
        }
    }

    internal sealed class LeasingRegistrationRepository : ILeasingRegistrationRepository
    {
        public IDictionary<int, Tuple<CarRegistrationDto, string, string, string>> Registrations { get; }
    }
}
