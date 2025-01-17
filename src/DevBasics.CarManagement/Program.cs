﻿using AutoMapper;
using DevBasics.CarManagement.CarMangement;
using DevBasics.CarManagement.CarTyps;
using DevBasics.CarManagement.Dependencies;
using DevBasics.CarManagement.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    internal sealed class Program
    {
        internal static async Task Main()
        {
            var model = new CarRegistrationModel();
            var configuration = new MapperConfiguration(cnfgrtn => model.CreateMappings(cnfgrtn));
            var mapper = configuration.CreateMapper();

            var bulkRegistrationServiceMock = new BulkRegistrationServiceMock();
            var leasingRegistrationRepository = new LeasingRegistrationRepository();
            var updateCar = new UpdateCar(new Dictionary<int, Tuple<CarRegistrationDto,string, string, string>>());
            var insertHistory = new InsertHistory(new Dictionary<int, Tuple<CarRegistrationDto, string, string, string>>());
            var localization = new LocalizationHolder();
            var carRegistrationRepositoryMock = new CarRegistrationRepository(
                leasingRegistrationRepository,
                bulkRegistrationServiceMock,
                mapper,
                updateCar);

            var service = new CarManagementService(
                mapper,
                new CarManagementSettings(),
                new HttpHeaderSettings(),
                new KowoLeasingApiClientMock(),
                new TransactionStateServiceMock(),
                bulkRegistrationServiceMock,
                new RegistrationDetailServiceMock(),
                leasingRegistrationRepository,
                carRegistrationRepositoryMock,
                insertHistory,
                localization,
                updateCar);

            var result = await service.RegisterCarsAsync(
                new RegisterCarsModel
                {
                    CompanyId = "Company",
                    CustomerId = "Customer",
                    VendorId = "Vendor",
                    Cars = new List<CarRegistrationModel>
                    {
                        new CarRegistrationModel
                        {
                            CompanyId = "Company",
                            CustomerId = "Customer",
                            VehicleIdentificationNumber = Guid.NewGuid().ToString(),
                            DeliveryDate = DateTime.Now.AddDays(14).Date,
                            ErpDeliveryNumber = Guid.NewGuid().ToString(),
                            CarType = new Vw()
                        }
                    }
                },
                false,
                new Claims()); ;
        }
    }
}
