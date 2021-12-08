using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using OA.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OA.Domin;
using OA.Domin.Reporting;
using OA.Domin.Logging;
using OA.Domin.Settings;
using OA.Domin.Notifications;
using OA.Domin.Administration;
using OA.DataAccess.Auditing;
using OA.Domin.Auditing;
using OA.Domin.Reporting.TemplateReporting;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
//using OA.Domin.DSA.Indexes;

namespace OA.DataAccess
{
    public partial class AppDbContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            httpContextAccessor = this.GetInfrastructure().GetRequiredService<IHttpContextAccessor>();
        }

        //Reporting
        public DbSet<ReportableTable> ReportableTables { get; set; }
        public DbSet<ReportTemplate> ReportTemplates { get; set; }
        public DbSet<ReportHeader> ReportHeaders { get; set; }
        public DbSet<ReportTextTemplate> ReportTextTemplates { get; set; }

        //Exception Log
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        //App Settings
        public DbSet<AppSetting> AppSettings { get; set; }

        //Notification
        public DbSet<Notification> Notifications { get; set; }

        //Administration
        public DbSet<SignupRequest> SignupRequests { get; set; }
        public DbSet<PermissionClaim> PermissionClaims { get; set; }
        public DbSet<VerificationQuestion> VerificationQuestions { get; set; }
        public DbSet<UserVerificationAnswer> UserVerificationAnswers { get; set; }

        //Auditing 
        public DbSet<Audit> Audits { get; set; }

               
        //APP DB SETS
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BlockCategory> BlockCategories { get; set; }
        public DbSet<BlockTranslation> BlockTranslations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventCategoryTranslation> EventCategoryTranslations { get; set; }
        public DbSet<EventTranslation> EventTranslations { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<NewCategory> NewCategories { get; set; }
        public DbSet<NewCategoryTranslation> NewCategoryTranslations { get; set; }
        public DbSet<NewTranslation> NewTranslations { get; set; }
        public DbSet<MenueCategory> MenuCategories { get; set; }
        public DbSet<Menue> Menues { get; set; }
        public DbSet<MenueTranslation> MenueTranslations { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageTranslation> PageTranslations { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleTranslation> ArticleTranslations { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<AdministrationBoard> AdministrationBoards { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipClubPlayer> ChampionshipClubPlayers { get; set; }
        public DbSet<ChampionshipRole> ChampionshipRoles { get; set; }
        public DbSet<ChampionshipType> ChampionshipTypes { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubPerson> ClubPersons { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<CommissionMembers> CommissionMembers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubscriberRequest> CourseSubscriberRequests { get; set; }
        public DbSet<Decision> Decisions { get; set; }
        public DbSet<Fcility> Fcilities { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ImportantAchievement> ImportantAchievements { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonRequestState> PersonRequestStates { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<AlbumContent> AlbumContent { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PType> PTypes { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        //public DbSet<SubsecriberRequest> SubsecriberRequests { get; set; }
        public DbSet<TechnicalData> TechnicalData { get; set; }
        public DbSet<Staff> Trainers { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<TrainingExperience> TrainingExperiences { get; set; }
        //APP Indexes

        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Adjective> Adjectives { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<ArrowType> ArrowTypes { get; set; }
        public DbSet<ChampionshipRanking> ChampionshipsRanking { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TrainingCourseType> TrainingCourseTypes { get; set; }

        //Testing functionality
        //public DbSet<WeatherForecast> WeatherForecasts { get; set; }


    }
}
