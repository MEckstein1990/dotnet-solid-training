using DevBasics.CarManagement.CarMangement;
using DevBasics.CarManagement.Dependencies;
using DevBasics.CarManagement.Localization;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DevBasics.CarManagement
{
    public class BaseService
    {
        public ICarManagementSettings Settings { get; set; }
        public ILocalization Localization { get; set; }

        public HttpHeaderSettings HttpHeader { get; set; }

        public IKowoLeasingApiClient ApiClient { get; set; }

        public IBulkRegistrationService BulkRegistrationService { get; set; }

        public ITransactionStateService TransactionStateService { get; set; }

        public IRegistrationDetailService RegistrationDetailService { get; set; }

        public ILeasingRegistrationRepository LeasingRegistrationRepository { get; set; }

        public ICarRegistrationRepository CarLeasingRepository { get; set; }
        public IGetAppSetting GetAppSetting { get; set; }

        public BaseService(
            ICarManagementSettings settings,
            HttpHeaderSettings httpHeader,
            IKowoLeasingApiClient apiClient,
            IBulkRegistrationService bulkRegistrationService = null,
            ITransactionStateService transactionStateService = null,
            IRegistrationDetailService registrationDetailService = null,
            ILeasingRegistrationRepository leasingRegistrationRepository = null,
            ICarRegistrationRepository carLeasingRepository = null,
            IGetAppSetting getAppSetting = null,
            ILocalization localization = null)
        {
            // Mandatory
            Settings = settings;
            HttpHeader = httpHeader;
            ApiClient = apiClient;

            // Optional Services
            BulkRegistrationService = bulkRegistrationService;
            TransactionStateService = transactionStateService;
            RegistrationDetailService = registrationDetailService;

            // Optional Repositories
            LeasingRegistrationRepository = leasingRegistrationRepository;
            CarLeasingRepository = carLeasingRepository;

            GetAppSetting = getAppSetting;
            Localization = localization;
        }

        public async Task<RequestContext> InitializeRequestContextAsync()
        {
            Console.WriteLine("Trying to initialize request context...");

            try
            {
                AppSettingDto settingResult = await GetAppSetting.GetAppSettingAsync(HttpHeader.SalesOrgIdentifier, HttpHeader.WebAppType);

                if (settingResult == null)
                {
                    throw new Exception("Error while retrieving settings from database");
                }

                RequestContext requestContext = new RequestContext()
                {
                    ShipTo = settingResult.SoldTo,
                    LanguageCode = Localization.LanguageCodes["English"],
                    TimeZone = "Europe/Berlin"
                };

                Console.WriteLine($"Initializing request context successful. Data (serialized as JSON): {JsonConvert.SerializeObject(requestContext)}");

                return requestContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Initializing request context failed: {ex}");
                return null;
            }
        }
    }
}
