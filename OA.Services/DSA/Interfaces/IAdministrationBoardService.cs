using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.DSA.Interfaces
{
    public interface IAdministrationBoardService
    {
        Task<Response<string>> AdministrationBoardCreate(AdministrationBoardVM administrationboardvm);

        //        Task<Response<string>> RegisterBeneficary(RegisterBeneficiaryVM registerBeneficiary);

        //        Task<Response<string>> RegisterDonator(RegisterDonatorVM registerDonator);

        //        Response<string> CreateDonationRequest(DonationRequestVM donationRequest, string userId);

        //        Response<string> CreateDonationOffer(DonationOfferVM donationOffer, string UserId);

        //        Response<IEnumerable<DonationRequest>> GetDonationRequests();

        //        Response<string> UpdateDonationOffer(DonationOffer donationOffer);

    }
}
