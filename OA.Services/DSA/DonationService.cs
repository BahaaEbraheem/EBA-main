//using OA.DataAccess;
//using OA.Domin.Administration;
//using OA.Domin.AutoMapper;
//using OA.Domin.DSA;
//using OA.Domin.DSA.ViewModels;
//using OA.Domin.Responces;
//using OA.Services.Administration;
//using OA.Services.DSA.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OA.Services.DSA
//{
//    public class DonationService : IDonationService
//    {
//        private readonly AppDbContext Context;
//        private readonly IAdministrationService AdministrationService;
//        public DonationService(AppDbContext context, IAdministrationService administrationService)
//        {
//            Context = context;
//            AdministrationService = administrationService;
//        }

//        public async Task<Response<string>> RegisterBeneficary(RegisterBeneficiaryVM registerBeneficiary)
//        {
//            //Add Beneficiary with assosiated user

//            var response = new Response<string>();

//            var role = Context.Roles.FirstOrDefault(r => r.Name == "Beneficiary");
//            if (role == null)
//            {
//                response.HasErrors = true;
//                response.AddValidationError("Role", "Beneficiary Role Not Found");
//                return response;
//            }


//            var user = new CustomUser { UserName = registerBeneficiary.UserName, Password = registerBeneficiary.Password, Email = $"{registerBeneficiary.UserName}@app.com", Roles = new List<CustomRole> { new CustomRole { Name = role.Name, Id = role.Id } } };
//            var userResult = await AdministrationService.AddUserAsync(user);
//            if (userResult.HasErrors)
//            {
//                response.HasErrors = true;
//                response.ValidationErrors = userResult.ValidationErrors;
//                return response;
//            }

//            string userId = userResult.Result.Id;
//            if (registerBeneficiary.Type == "Per")
//            {
//                registerBeneficiary.Beneficiary.UserId = userId;
//                Context.Beneficiaries.Add(registerBeneficiary.Beneficiary);

//            }
//            else if (registerBeneficiary.Type == "Corp")
//            {
//                registerBeneficiary.CorporateBeneficiary.UserId = userId;
//                Context.CorporateBeneficiaries.Add(registerBeneficiary.CorporateBeneficiary);
//            }

//            var r = Context.SaveChanges();
//            response.HasErrors = (r == 0);

//            return response;
//        }

//        public async Task<Response<string>> RegisterDonator(RegisterDonatorVM registerDonator)
//        {
//            var response = new Response<string>();

//            var role = Context.Roles.FirstOrDefault(r => r.Name == "Donator");
//            if (role == null)
//            {
//                response.HasErrors = true;
//                response.AddValidationError("Role", "Donator Role Not Found");
//                return response;
//            }

//            var user = new CustomUser { UserName = registerDonator.DonatorUserName, Password = registerDonator.DonatorPassword, Email = $"{registerDonator.DonatorUserName}@app.com", Roles = new List<CustomRole> { new CustomRole { Name = role.Name, Id = role.Id } } };
//            var userResult = await AdministrationService.AddUserAsync(user);
//            if (userResult.HasErrors)
//            {
//                response.HasErrors = true;
//                response.ValidationErrors = userResult.ValidationErrors;
//                return response;
//            }

//            string userId = userResult.Result.Id;

//            if (registerDonator.Type == "Per")
//            {
//                registerDonator.PersonDonator.UserId = userId;
//                Context.PersonDonators.Add(registerDonator.PersonDonator);

//            }
//            else if (registerDonator.Type == "Corp")
//            {
//                registerDonator.CorporateDonator.UserId = userId;
//                Context.CorporateDonators.Add(registerDonator.CorporateDonator);
//            }

//            var r = Context.SaveChanges();
//            response.HasErrors = (r == 0);

//            return response;
//        }

//        public Response<string> CreateDonationOffer(DonationOfferVM donationOfferVM, string userId)
//        {
//            var donationOffer = Mapping.Mapper.Map<DonationOffer>(donationOfferVM);
            
//            if (donationOffer.DonatorType == "Per")
//                donationOffer.PersonDonatorId = Context.PersonDonators.FirstOrDefault(d => d.UserId == userId)?.Id;
//            else if (donationOffer.DonatorType == "Corp")
//                donationOffer.CorporateDonatorId = Context.CorporateDonators.FirstOrDefault(d => d.UserId == userId)?.Id;

//            Response<string> response = new Response<string>();
//            if (donationOffer.PersonDonatorId == null && donationOffer.CorporateDonatorId == null)
//            {
//                response.HasErrors = true;
//                response.AddValidationError("Donator", "Donator User not found");
//                return response;
//            }

//            Context.DonationOffers.Add(donationOffer);
//            var r = Context.SaveChanges();
//            response.HasErrors = (r == 0);

//            return response;
//        }

//        public Response<string> CreateDonationRequest(DonationRequestVM donationRequestVM, string userId)
//        {
//            var donationRequest = Mapping.Mapper.Map<DonationRequest>(donationRequestVM);

//            if (donationRequest.BeneficiaryType == "Per")
//                donationRequest.BeneficiaryId = Context.Beneficiaries.FirstOrDefault(b => b.UserId == userId)?.Id;
//            else if (donationRequest.BeneficiaryType == "Corp")
//                donationRequest.CorpBeneficiaryId = Context.CorporateBeneficiaries.FirstOrDefault(b => b.UserId == userId)?.Id;

//            //Upload Attachments

//            Response<string> response = new Response<string>();
//            if (donationRequest.BeneficiaryId == null && donationRequest.CorpBeneficiaryId == null)
//            {
//                response.HasErrors = true;
//                response.AddValidationError("Beneficiary", "Beneficary User not found");
//                return response;
//            }

//            Context.DonationRequests.Add(donationRequest);
//            var r = Context.SaveChanges();
//            response.HasErrors = (r == 0);

//            return response;
//        }

//        public Response<IEnumerable<DonationRequest>> GetDonationRequests()
//        {
//            var responce = new Response<IEnumerable<DonationRequest>>();

//            responce.Result = Context.DonationRequests.Where(d => d.IsAccepted && !d.IsAssigned).ToList();

//            return responce;
//        }

//        public Response<string> UpdateDonationOffer(DonationOffer donationOffer)
//        {
//            var response = new Response<string>();

//            var donationRequest = Context.DonationRequests.Find(donationOffer.DonationRequestId);
//            donationRequest.IsAssigned = true;

//            var eDonationOffer = Context.DonationOffers.Find(donationOffer.Id);

//            if (!eDonationOffer.IsAccepted && donationOffer.IsAccepted)
//            {
//                var donation = new Donation();
//                donation.Amount = donationRequest.Amount;
//                donation.DonationType = donationRequest.DonationType?.Name;
//                donation.Date = DateTime.Now;
//                donation.BeneficiaryId = donationRequest.BeneficiaryId;
//                donation.CorporateBeneficiaryId = donationRequest.CorpBeneficiaryId;
//                donation.PersonDonatorId = donationOffer.PersonDonatorId;
//                donation.CorporateDonatorId = donationOffer.CorporateDonatorId;
//                Context.Donations.Add(donation);
//            }

//            eDonationOffer.IsAccepted = donationOffer.IsAccepted;
//            eDonationOffer.Notes = donationOffer.Notes;

//            var r = Context.SaveChanges();
//            response.HasErrors = (r == 0);

//            return response;
//        }
//    }
//}
