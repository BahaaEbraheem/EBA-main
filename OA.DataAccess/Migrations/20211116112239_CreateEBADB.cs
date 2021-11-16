using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.DataAccess.Migrations
{
    public partial class CreateEBADB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adjectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    MinimumAge = table.Column<int>(nullable: true),
                    MaximumAge = table.Column<int>(nullable: true),
                    Degree = table.Column<int>(nullable: true),
                    DegreesLimits = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ArrowTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrowTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RefreshTokn = table.Column<string>(nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(nullable: false),
                    FirstUse = table.Column<bool>(nullable: false),
                    Online = table.Column<bool>(nullable: false),
                    LastPasswordChange = table.Column<DateTime>(nullable: true),
                    ProfilePic = table.Column<string>(nullable: true),
                    ConfirmedAccount = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Extention = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<int>(nullable: false),
                    Reference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipRanking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipRanking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<int>(nullable: true),
                    Title_Ar = table.Column<string>(nullable: true),
                    Title_En = table.Column<string>(nullable: true),
                    PhoneCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Seen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionClaims",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionClaims", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "PTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportableTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportableTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportTextTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTextTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignupRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: true),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignupRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Crowd = table.Column<int>(nullable: true),
                    height_m = table.Column<int>(nullable: true),
                    Width_m = table.Column<int>(nullable: true),
                    Position_Ar = table.Column<string>(nullable: true),
                    Position_En = table.Column<string>(nullable: true),
                    Emirate = table.Column<byte>(nullable: false),
                    lightState = table.Column<byte>(nullable: false),
                    StadiumState = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ArticleCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BlockCategoryId = table.Column<int>(nullable: false),
                    BlockURL = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_BlockCategories_BlockCategoryId",
                        column: x => x.BlockCategoryId,
                        principalTable: "BlockCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DecisionNum = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CommissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decisions_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EventCategoryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionshipTypes_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventCategoryId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCategoryTranslations_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LevelOrder = table.Column<int>(nullable: false),
                    PageUrl = table.Column<string>(nullable: true),
                    ParentMenueId = table.Column<int>(nullable: true),
                    MenuCategoryId = table.Column<int>(nullable: true),
                    MenueCategoryId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menues_MenuCategories_MenueCategoryId",
                        column: x => x.MenueCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menues_Menues_ParentMenueId",
                        column: x => x.ParentMenueId,
                        principalTable: "Menues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    PassporNumber = table.Column<string>(nullable: true),
                    PassporEndDate = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    Employer = table.Column<string>(nullable: true),
                    Fax = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NewCategoryId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewCategoryTranslations_NewCategories_NewCategoryId",
                        column: x => x.NewCategoryId,
                        principalTable: "NewCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NewCategoryId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewCategories_NewCategoryId",
                        column: x => x.NewCategoryId,
                        principalTable: "NewCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    HTMLContent = table.Column<string>(nullable: true),
                    Link1 = table.Column<string>(nullable: true),
                    Link2 = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    FieldsOrder = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ReportableTableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportTemplates_ReportableTables_ReportableTableId",
                        column: x => x.ReportableTableId,
                        principalTable: "ReportableTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVerificationAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VerificationQuestionId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerificationAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVerificationAnswers_VerificationQuestions_VerificationQuestionId",
                        column: x => x.VerificationQuestionId,
                        principalTable: "VerificationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTranslations_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlockTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    BlockId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockTranslations_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTranslations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    AgeCategoryId = table.Column<int>(nullable: true),
                    ChampionshipTypeId = table.Column<int>(nullable: true),
                    ChampionshipRankingId = table.Column<int>(nullable: true),
                    ArrowTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championships_AgeCategories_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championships_ArrowTypes_ArrowTypeId",
                        column: x => x.ArrowTypeId,
                        principalTable: "ArrowTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championships_ChampionshipRanking_ChampionshipRankingId",
                        column: x => x.ChampionshipRankingId,
                        principalTable: "ChampionshipRanking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championships_ChampionshipTypes_ChampionshipTypeId",
                        column: x => x.ChampionshipTypeId,
                        principalTable: "ChampionshipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenueTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    HTMLContent = table.Column<string>(nullable: true),
                    MenueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenueTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenueTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenueTranslations_Menues_MenueId",
                        column: x => x.MenueId,
                        principalTable: "Menues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministrationBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    ElectoralCycle = table.Column<DateTime>(nullable: true),
                    MemberType = table.Column<byte>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrationBoards_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    ActiveType = table.Column<string>(nullable: true),
                    Emirate = table.Column<byte>(nullable: false),
                    ClubBossId = table.Column<int>(nullable: true),
                    ClubManagerId = table.Column<int>(nullable: true),
                    FinancialManagerId = table.Column<int>(nullable: true),
                    ClubType = table.Column<byte>(nullable: false),
                    AdvertisingDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    City_Ar = table.Column<string>(nullable: true),
                    City_En = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: true),
                    MenCategory = table.Column<int>(nullable: true),
                    WomenCategory = table.Column<int>(nullable: true),
                    YoungMenCategory = table.Column<int>(nullable: true),
                    YoungWomenCategory = table.Column<int>(nullable: true),
                    CoachesNumber = table.Column<int>(nullable: true),
                    AdministratorsNumber = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_People_ClubBossId",
                        column: x => x.ClubBossId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clubs_People_ClubManagerId",
                        column: x => x.ClubManagerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clubs_People_FinancialManagerId",
                        column: x => x.FinancialManagerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommissionMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    CommissionId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionMembers_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionMembers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportantAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    AchievementType = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportantAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportantAchievements_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonRequestStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    RequestStateId = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: true),
                    RequestNumber = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRequestStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRequestStates_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRequestStates_RequestStates_RequestStateId",
                        column: x => x.RequestStateId,
                        principalTable: "RequestStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTypes_PTypes_PTypeId",
                        column: x => x.PTypeId,
                        principalTable: "PTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTypes_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    AgeCategoryId = table.Column<int>(nullable: true),
                    AdjectiveId = table.Column<int>(nullable: true),
                    Coach = table.Column<DateTime>(nullable: true),
                    WeaponType = table.Column<string>(nullable: true),
                    WeaponNumber = table.Column<string>(nullable: true),
                    WeaponModel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Adjectives_AdjectiveId",
                        column: x => x.AdjectiveId,
                        principalTable: "Adjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_AgeCategories_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    YearsOfPractice = table.Column<int>(nullable: true),
                    LocalMatches = table.Column<int>(nullable: true),
                    InternationalMatches = table.Column<int>(nullable: true),
                    TrainingSuit = table.Column<string>(nullable: true),
                    SportShirt = table.Column<string>(nullable: true),
                    Sportshoe = table.Column<string>(nullable: true),
                    Height = table.Column<float>(nullable: true),
                    Weight = table.Column<float>(nullable: true),
                    StandardNumber = table.Column<string>(nullable: true),
                    Look = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalData_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    HTMLContent = table.Column<string>(nullable: true),
                    NewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewTranslations_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Header = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ReportTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportHeaders_ReportTemplates_ReportTemplateId",
                        column: x => x.ReportTemplateId,
                        principalTable: "ReportTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    ChampionshipId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionshipRoles_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ClubId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubPersons_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubPersons_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fcilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    IsSpecialty = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fcilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fcilities_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    RegistrationEndDate = table.Column<string>(nullable: true),
                    CoursePosition = table.Column<byte>(nullable: false),
                    TrainingCourseTypeId = table.Column<int>(nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Description_Ar = table.Column<string>(nullable: true),
                    Description_Er = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCourses_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingCourses_TrainingCourseTypes_TrainingCourseTypeId",
                        column: x => x.TrainingCourseTypeId,
                        principalTable: "TrainingCourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    CourseType = table.Column<byte>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Trainers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CourseType = table.Column<byte>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_Trainers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingExperiences_Trainers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionshipClubPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    ChampionshipRoleId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionshipClubPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionshipClubPlayers_ChampionshipRoles_ChampionshipRoleId",
                        column: x => x.ChampionshipRoleId,
                        principalTable: "ChampionshipRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipClubPlayers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionshipClubPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ChampionshipRoleId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    FirstTeamId = table.Column<int>(nullable: true),
                    StadiumId = table.Column<int>(nullable: true),
                    SecondTeamId = table.Column<int>(nullable: true),
                    FirstArbitratorId = table.Column<int>(nullable: true),
                    SecondArbitratorId = table.Column<int>(nullable: true),
                    FirstTeamResult = table.Column<int>(nullable: true),
                    SecondTeamResult = table.Column<int>(nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: true),
                    FromTime = table.Column<TimeSpan>(nullable: true),
                    ToTime = table.Column<TimeSpan>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_ChampionshipRoles_ChampionshipRoleId",
                        column: x => x.ChampionshipRoleId,
                        principalTable: "ChampionshipRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_People_FirstArbitratorId",
                        column: x => x.FirstArbitratorId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_People_SecondArbitratorId",
                        column: x => x.SecondArbitratorId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    Name_En = table.Column<string>(nullable: true),
                    TrainingCourseId = table.Column<int>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    AlbumType = table.Column<byte>(nullable: false),
                    AlbumCategory = table.Column<byte>(nullable: false),
                    Description_Ar = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description_En = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true),
                    Bulit_In = table.Column<bool>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Albums_TrainingCourses_TrainingCourseId",
                        column: x => x.TrainingCourseId,
                        principalTable: "TrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubscriberRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TrainingCourseId = table.Column<int>(nullable: true),
                    RequestStateId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: true),
                    RequestNumber = table.Column<int>(nullable: true),
                    PaymentReceipt = table.Column<string>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubscriberRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubscriberRequests_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSubscriberRequests_RequestStates_RequestStateId",
                        column: x => x.RequestStateId,
                        principalTable: "RequestStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSubscriberRequests_TrainingCourses_TrainingCourseId",
                        column: x => x.TrainingCourseId,
                        principalTable: "TrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    LastModefiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name_Ar = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsYoutube = table.Column<bool>(nullable: true),
                    Description_Ar = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumContent_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationBoards_PersonId",
                table: "AdministrationBoards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumContent_AlbumId",
                table: "AlbumContent",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_LanguageId",
                table: "Albums",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TrainingCourseId",
                table: "Albums",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTranslations_ArticleId",
                table: "ArticleTranslations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTranslations_LanguageId",
                table: "ArticleTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockCategoryId",
                table: "Blocks",
                column: "BlockCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockTranslations_BlockId",
                table: "BlockTranslations",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockTranslations_LanguageId",
                table: "BlockTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipClubPlayers_ChampionshipRoleId",
                table: "ChampionshipClubPlayers",
                column: "ChampionshipRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipClubPlayers_GroupId",
                table: "ChampionshipClubPlayers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipClubPlayers_PlayerId",
                table: "ChampionshipClubPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipRoles_ChampionshipId",
                table: "ChampionshipRoles",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_AgeCategoryId",
                table: "Championships",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_ArrowTypeId",
                table: "Championships",
                column: "ArrowTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_ChampionshipRankingId",
                table: "Championships",
                column: "ChampionshipRankingId");

            migrationBuilder.CreateIndex(
                name: "IX_Championships_ChampionshipTypeId",
                table: "Championships",
                column: "ChampionshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionshipTypes_GameTypeId",
                table: "ChampionshipTypes",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPersons_ClubId",
                table: "ClubPersons",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubPersons_PersonId",
                table: "ClubPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubBossId",
                table: "Clubs",
                column: "ClubBossId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubManagerId",
                table: "Clubs",
                column: "ClubManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_FinancialManagerId",
                table: "Clubs",
                column: "FinancialManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_CommissionId",
                table: "CommissionMembers",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_PersonId",
                table: "CommissionMembers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StaffId",
                table: "Courses",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubscriberRequests_PersonId",
                table: "CourseSubscriberRequests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubscriberRequests_RequestStateId",
                table: "CourseSubscriberRequests",
                column: "RequestStateId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubscriberRequests_TrainingCourseId",
                table: "CourseSubscriberRequests",
                column: "TrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_CommissionId",
                table: "Decisions",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategoryTranslations_EventCategoryId",
                table: "EventCategoryTranslations",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategoryTranslations_LanguageId",
                table: "EventCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCategoryId",
                table: "Events",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTranslations_EventId",
                table: "EventTranslations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTranslations_LanguageId",
                table: "EventTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Fcilities_ClubId",
                table: "Fcilities",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportantAchievements_PersonId",
                table: "ImportantAchievements",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_StaffId",
                table: "Lecturers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionshipRoleId",
                table: "Matches",
                column: "ChampionshipRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstArbitratorId",
                table: "Matches",
                column: "FirstArbitratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstTeamId",
                table: "Matches",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GroupId",
                table: "Matches",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondArbitratorId",
                table: "Matches",
                column: "SecondArbitratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondTeamId",
                table: "Matches",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Menues_MenueCategoryId",
                table: "Menues",
                column: "MenueCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Menues_ParentMenueId",
                table: "Menues",
                column: "ParentMenueId");

            migrationBuilder.CreateIndex(
                name: "IX_MenueTranslations_LanguageId",
                table: "MenueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MenueTranslations_MenueId",
                table: "MenueTranslations",
                column: "MenueId");

            migrationBuilder.CreateIndex(
                name: "IX_NewCategoryTranslations_LanguageId",
                table: "NewCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewCategoryTranslations_NewCategoryId",
                table: "NewCategoryTranslations",
                column: "NewCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewCategoryId",
                table: "News",
                column: "NewCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewTranslations_LanguageId",
                table: "NewTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewTranslations_NewId",
                table: "NewTranslations",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_LanguageId",
                table: "PageTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId",
                table: "PageTranslations",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_People_NationalityId",
                table: "People",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequestStates_PersonId",
                table: "PersonRequestStates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequestStates_RequestStateId",
                table: "PersonRequestStates",
                column: "RequestStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_PTypeId",
                table: "PersonTypes",
                column: "PTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_PersonId",
                table: "PersonTypes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AdjectiveId",
                table: "Players",
                column: "AdjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AgeCategoryId",
                table: "Players",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonId",
                table: "Players",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportHeaders_ReportTemplateId",
                table: "ReportHeaders",
                column: "ReportTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTemplates_ReportableTableId",
                table: "ReportTemplates",
                column: "ReportableTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalData_PersonId",
                table: "TechnicalData",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_PersonId",
                table: "Trainers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourses_PersonTypeId",
                table: "TrainingCourses",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCourses_TrainingCourseTypeId",
                table: "TrainingCourses",
                column: "TrainingCourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExperiences_StaffId",
                table: "TrainingExperiences",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerificationAnswers_VerificationQuestionId",
                table: "UserVerificationAnswers",
                column: "VerificationQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrationBoards");

            migrationBuilder.DropTable(
                name: "AlbumContent");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "ArticleTranslations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "BlockTranslations");

            migrationBuilder.DropTable(
                name: "ChampionshipClubPlayers");

            migrationBuilder.DropTable(
                name: "ClubPersons");

            migrationBuilder.DropTable(
                name: "CommissionMembers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseSubscriberRequests");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "EventCategoryTranslations");

            migrationBuilder.DropTable(
                name: "EventTranslations");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "Fcilities");

            migrationBuilder.DropTable(
                name: "ImportantAchievements");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MenueTranslations");

            migrationBuilder.DropTable(
                name: "NewCategoryTranslations");

            migrationBuilder.DropTable(
                name: "NewTranslations");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PageTranslations");

            migrationBuilder.DropTable(
                name: "PermissionClaims");

            migrationBuilder.DropTable(
                name: "PersonRequestStates");

            migrationBuilder.DropTable(
                name: "ReportHeaders");

            migrationBuilder.DropTable(
                name: "ReportTextTemplates");

            migrationBuilder.DropTable(
                name: "SignupRequests");

            migrationBuilder.DropTable(
                name: "TechnicalData");

            migrationBuilder.DropTable(
                name: "TrainingExperiences");

            migrationBuilder.DropTable(
                name: "UserVerificationAnswers");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ChampionshipRoles");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Menues");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "RequestStates");

            migrationBuilder.DropTable(
                name: "ReportTemplates");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "VerificationQuestions");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "TrainingCourses");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "BlockCategories");

            migrationBuilder.DropTable(
                name: "Adjectives");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "NewCategories");

            migrationBuilder.DropTable(
                name: "ReportableTables");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "TrainingCourseTypes");

            migrationBuilder.DropTable(
                name: "AgeCategories");

            migrationBuilder.DropTable(
                name: "ArrowTypes");

            migrationBuilder.DropTable(
                name: "ChampionshipRanking");

            migrationBuilder.DropTable(
                name: "ChampionshipTypes");

            migrationBuilder.DropTable(
                name: "PTypes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
