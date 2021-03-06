using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OA.WASM.Services;
using OA.Domain;
using OA.WASM.Services.Auth;
using System.Net;
using OA.WASM.Services.JsonConverter;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using System.Globalization;
using System.Threading;
using Microsoft.JSInterop;
using OA.Domin;
using BlazorDownloadFile;
using OA.WASM.Services.Reporting;
using OA.WASM.Services.ErrorHandler.Extention;
using OA.WASM.Services.Administration;
using OA.WASM.Services.Upload;
using OA.WASM.Services.Settings;
using OA.Domin.Settings;
using OA.Domin.Logging;
using System.Runtime.InteropServices.ComTypes;
using OA.WASM.Services.Logging;
using OA.WASM.Services.Notifications;
using OA.WASM.Services.Auditing;
using OA.WASM.Services.Auth.Extention;
using OA.Domin.DSA;
using OA.WASM.Services.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Services.DSA.Indexes;
using OA.Domin.DSA.ViewModels;
using OA.WASM.Services.COM_ADM;
//using OA.Domin.DSA.Indexes;
//using OA.WASM.Services.DSA.Indexes;

namespace OA.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient 
                { 
                    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value) 
                }
                .EnableIntercept(sp)
            );

            builder.Services.AddLocalization();
           
            builder.Services.AddHttpClientInterceptor();
            
            builder.Services.AddSingleton<IJsonConverter, JsonConverter>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddOptions();

            //builder.Services.AddAuthorizationCore();
            builder.Services.AddPolicyBasedAuthorization();

            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            builder.Services.AddScoped<LocalAuthenticationStateProvider>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<RefreshTokenService>();

            builder.Services.AddScoped<HttpInterceptorService>();

            builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);
            

            //Services ErrorHandler Extention
            builder.Services.AddStateManagement();

        
            builder.Services.AddScoped<IAdministrationService, AdministrationService>();
            builder.Services.AddScoped<IReportingService, ReportingService>();
            builder.Services.AddScoped<IUploadService, UploadService>();
            builder.Services.AddScoped<IAppSettingsService, AppSettingsService>();
            builder.Services.AddScoped<INotificationServices, NotificationService>();
            builder.Services.AddScoped<IAuditsService, AuditsService>();
            builder.Services.AddScoped<ServiceBase<ExceptionLog>, ExceptionLogService>();


            //Services
            builder.Services.AddScoped<ServiceBase<Block>, BlocksService>();
            builder.Services.AddScoped<ServiceBase<BlockCategory>, BlockCategoriesService>();
            builder.Services.AddScoped<ServiceBase<BlockTranslation>, BlockTranslationsService>();

            builder.Services.AddScoped<ServiceBase<Event>, EventsService>();
            builder.Services.AddScoped<ServiceBase<EventTranslation>, EventTranslationsService>();
            builder.Services.AddScoped<ServiceBase<EventCategory>, EventCategoriesService>();
            builder.Services.AddScoped<ServiceBase<EventCategoryTranslation>, EventCategoryTranslationsService>();

            builder.Services.AddScoped<ServiceBase<New>, NewsService>();
            builder.Services.AddScoped<ServiceBase<NewTranslation>, NewTranslationsService>();
            builder.Services.AddScoped<ServiceBase<NewCategory>, NewCategoriesService>();
            builder.Services.AddScoped<ServiceBase<NewCategoryTranslation>, NewCategoryTranslationsService>();

            builder.Services.AddScoped<ServiceBase<Page>, PagesService>();
            builder.Services.AddScoped<ServiceBase<PageTranslation>, PageTranslationsService>();
            builder.Services.AddScoped<ServiceBase<Menue>, MenuesService>();
            builder.Services.AddScoped<ServiceBase<MenueCategory>, MenuCategoriesService>();
            builder.Services.AddScoped<ServiceBase<MenueTranslation>, MenueTranslationsService>();
            builder.Services.AddScoped<ServiceBase<Article>, ArticlesService>();
            builder.Services.AddScoped<ServiceBase<ArticleCategory>, ArticleCategoriesService>();
            builder.Services.AddScoped<ServiceBase<ArticleTranslation>, ArticleTranslationsService>();
            builder.Services.AddScoped<ServiceBase<Attachment>, AttachmentsServices>();
            builder.Services.AddScoped<AttachmentsServices>();


            //Indexes
            builder.Services.AddScoped<ServiceBase<Language>, LanguegesService>();
            builder.Services.AddScoped<ServiceBase<Nationality>, NationalitiesService>();
            builder.Services.AddScoped<ServiceBase<Adjective>, AdjectivesService>();
            builder.Services.AddScoped<ServiceBase<ChampionshipRanking>, ChampionshipRankingService>();
            builder.Services.AddScoped<ServiceBase<ArrowType>, ArrowTypesService>();
            builder.Services.AddScoped<ServiceBase<TrainingCourseType>, TrainingCourseTypesService>();
            builder.Services.AddScoped<ServiceBase<AgeCategory>, AgeCategoriesService>();


            builder.Services.AddScoped<ServiceBase<AdministrationBoard>, AdministrationBoardsService>();
            builder.Services.AddScoped<ServiceBase<Person>, PeopleService>();
            builder.Services.AddScoped<ServiceBase<PType>, PTypesService>();
            builder.Services.AddScoped<ServiceBase<PersonType>, PersonTypesService>();
            builder.Services.AddScoped<ServiceBase<Commission>, CommissionsService>();
            builder.Services.AddScoped<ServiceBase<CommissionMember>, CommissionMembersService>();
            builder.Services.AddScoped<ServiceBase<Decision>, DecisionsService>();
            builder.Services.AddScoped<ServiceBase<Player>, PlayersService>();


            builder.Services.AddScoped<ICOM_ADMService, COM_ADMService>();





            var host = builder.Build();

            var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();
            var cult = await localStorageService.GetItemAsync<string>("Culture");
            if (!string.IsNullOrEmpty(cult))
            {
                var culture = CultureInfo.CreateSpecificCulture(cult);

                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                if(cult == "ar-SY")
                {
                    var Jsrt = host.Services.GetRequiredService<IJSRuntime>();
                    await Jsrt.InvokeVoidAsync("AddClass", "body", "rtl");
                }

                var httpClient = host.Services.GetRequiredService<HttpClient>();
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(cult));

                //Thread.CurrentThread.CurrentCulture = culture;
                //Thread.CurrentThread.CurrentUICulture = culture;
            }

            await host.RunAsync();
        }

    }
}
