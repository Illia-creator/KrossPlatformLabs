using Lab6.Api.Dal;
using Lab6.Api.Entities;
using Lab6.Api.Entities.Dtos;
using Lab6.Api.Entities.Relations;
using Lab6.Api.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Services
{
    public class LabService
    {
        private readonly LabDbContext _context;
        private readonly LabDbInitializer _dbInitializer;
        private readonly IPasswordManager _passwordManager;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly IHttpContextStorage _contextStorage;


        public LabService(
            LabDbContext context,
            LabDbInitializer dbInitializer, 
            IPasswordManager passwordManager,
            IJwtTokenProvider jwtTokenProvider, 
            IHttpContextStorage contextStorage)
        {
            _context = context;
            _dbInitializer = dbInitializer;
            _passwordManager = passwordManager;
            _jwtTokenProvider = jwtTokenProvider;
            _contextStorage = contextStorage;
        }

        public async Task<List<MedicationResponse>> GetMedicationResponse()
        {
            IQueryable<Medication> _medications = _context.Medications;
            IQueryable<GenericMedication> _genericMedications = _context.GenericMedications;
            IQueryable<GenericToBrandNameCorrespondence> _genericToBrandNameCorrespondences = _context.GenericToBrandNameCorrespondences;
            IQueryable<BrandNameMedication> _brandNameMedications = _context.BrandNameMedications;

            return await (from medication in _medications
                          join genericMedication in _genericMedications
                            on medication.Id equals genericMedication.MedicationId
                          join genericToBrandNameCorrespondence in _genericToBrandNameCorrespondences
                            on genericMedication.Id equals genericToBrandNameCorrespondence.GenericMedicationId
                          join brandNameMedication in _brandNameMedications
                             on genericToBrandNameCorrespondence.BrandNameMedicationId equals brandNameMedication.Id
                          select new MedicationResponse
                          (medication.Id,
                          medication.MedicationName,
                          medication.MedicationDescription,
                          medication.MedicationCost,
                          brandNameMedication.BrandMedicationName,
                          brandNameMedication.BrandMedicationCost,
                          brandNameMedication.BrandMedicationDescription)).ToListAsync();
        }
        public async Task<List<MedicationResponse>> GetCustomersByFiltersAsync(MedicationRequest request)
        {
            var medications = await GetMedicationResponse();

            if (!string.IsNullOrEmpty(request.SearchColumn) && !string.IsNullOrEmpty(request.SearchValue))
                medications = medications.Where(medication => FilterCustomerByRequest(medication, request)).ToList();

            return medications;
        }

        private bool FilterCustomerByRequest(MedicationResponse medication, MedicationRequest request)
        {
            var propertyValue = medication.GetType().GetProperty(request.SearchColumn)?.GetValue(medication, null)?.ToString();
            return propertyValue != null && propertyValue.Contains(request.SearchValue, StringComparison.OrdinalIgnoreCase);
        }

        public async Task Login(LoginRequest request, CancellationToken cancellationToken)
        {
            Customer? customer;

            if (!string.IsNullOrEmpty(request.UserFirstName))
                customer = await _context.Customers
                    .FirstOrDefaultAsync(
                        x => x.CustomerFirstName == request.UserFirstName && x.CustomerLastName == request.UserLastName,
                        cancellationToken
                    );
            else
                customer = await _context.Customers
                        .FirstOrDefaultAsync(
                    x => x.CustomerFirstName == request.UserFirstName 
                    && x.CustomerLastName == request.UserLastName,
                    cancellationToken: cancellationToken);


            if (customer is null) throw new ArgumentNullException(nameof(customer));

            bool isValidPassword = _passwordManager.Validate(request.Password, customer.CustomerPassword);

            if (!isValidPassword) throw new ArgumentException(nameof(request.Password));

            var jwt = _jwtTokenProvider.CreateToken(
               customer.Id,
                customer.CustomerLastName
            );

            var authResponse = new AuthResponse(
               customer.Id,
               customer.CustomerLastName,
               jwt.AccessToken,
               jwt.Expires
            );

          // return authResponse;
            _contextStorage.Set(authResponse, "auth_data");
        }

        public async Task Register(RegisterCustomerRequest request, CancellationToken cancellationToken)
        {
            var adress = _context.Addresses.Where(x => x.Line1NumberBuilding == request.Line1NumberBuilding).FirstOrDefault();
            var password = _passwordManager.Secure(request.CustomerPassword).ToString();
            var customer = _context.Customers.Add(new Customer(
                Guid.NewGuid().ToString(),
                adress.Id.ToString(),
                request.CustomerFirstName,
                request.CustomerLastName, 
                request.CustomerPhone, 
                request.DateOriginalyJoined, 
                request.CreditCardNumber,
                request.DateCardExpiry, 
                request.OtherCustomerDetails,
                password
            ));
            

            await _context.SaveChangesAsync(cancellationToken);

            var jwt = _jwtTokenProvider.CreateToken(
              customer.Entity.Id,
              customer.Entity.CustomerLastName
            );

            var authResponse = new AuthResponse(
               customer.Entity.Id,
               customer.Entity.CustomerLastName,
               jwt.AccessToken,
               jwt.Expires
            );

            _contextStorage.Set(authResponse, "auth_data");
        }

    }
}
