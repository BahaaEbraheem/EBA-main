//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OA.DataAccess;
//using OA.Domin.Administration;
//using OA.Domin.DSA;
//using OA.Domin.DSA.ViewModels;
//using OA.Domin.Responces;
//using OA.Services.Administration;
//using OA.Services.DSA.Interfaces;
//using OA_API.Extentions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA_API.Controllers.DSA
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExternalDonationsController : ControllerBase
//    {
//        private readonly IDonationService DonationService;
//        public ExternalDonationsController(IDonationService donationService)
//        {
//            DonationService = donationService;
//        }

//        [HttpPost("RegisterBeneficiary")]
//        public async Task<IActionResult> RegisterBeneficiary(RegisterBeneficiaryVM registerBeneficiary)
//        {
//            var result = await DonationService.RegisterBeneficary(registerBeneficiary);

//            return Ok(result);
//        }

//        [HttpPost("RegisterDonator")]
//        public async Task<IActionResult> RegisterDonator(RegisterDonatorVM registerDonator)
//        {
//            var result = await DonationService.RegisterDonator(registerDonator);

//            return Ok(result);
//        }

//        [HttpPost("CreateDonationRequest")]
//        [Authorize(Policy = "beneficiary-position")]
//        public IActionResult CreateDonationRequest(DonationRequestVM donationRequest)
//        {
//            var userId = HttpContext.User.GetUserId();
//            var result = DonationService.CreateDonationRequest(donationRequest, userId);

//            return Ok(result);
//        }

//        [HttpPost("CreateDonationOffer")]
//        [Authorize(Policy = "donator-position")]
//        public IActionResult CreateDonationOffer(DonationOfferVM donationOffer)
//        {
//            var userId = HttpContext.User.GetUserId();
//            var result = DonationService.CreateDonationOffer(donationOffer, userId);

//            return Ok(result);
//        }

//        [HttpGet("GetDonationRequests")]
//        [Authorize(Policy = "donator-position")]
//        public IActionResult GetDonationRequests()
//        {
//            var result = DonationService.GetDonationRequests();

//            return Ok(result);
//        }



//    }
//}
