using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.AutoMapper;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using OA.Domin.Logging;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.COM_ADM
{
    public class COM_ADMService : ICOM_ADMService
    {
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly AppDbContext dbContext;

        public COM_ADMService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.dbContext = dbContext;
        }

       

      
        //public IEnumerable<AdministrationBoard> GetAllAdministrators()
        //{
        //    var Admini_Boards = dbContext.AdministrationBoards.ToList();

        //    var customAdmini_Boards = new List<AdministrationBoard>();

        //    foreach (var Ad_Board in Admini_Boards)
        //        customAdmini_Boards.Add(new AdministrationBoard() { Person = Ad_Board.Person, Id = Ad_Board.Id ,Position=Ad_Board.Position});

        //    return customAdmini_Boards;

        //}
        public IEnumerable<AdministrationBoardVM> ADDCOM(AdministrationBoardVM Commission_admini_VM)
        {
            var Commission_adminiVM = new List<AdministrationBoardVM>();




            return Commission_adminiVM;
        }




    }
}
