using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Context.COMMON_DB;

public partial class CommonDbDevV31Context : DbContext
{
    //private readonly IConfiguration _configuration;
    public CommonDbDevV31Context()
    {
        //_configuration = new ConfigurationBuilder()
        //    .AddUserSecrets("fc917c02-0293-4f3b-8dd7-971a40e52ece", true)
        //    .Build();
    }

    public CommonDbDevV31Context(DbContextOptions<CommonDbDevV31Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Ad> Ads { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<ApiUser> ApiUsers { get; set; }

    public virtual DbSet<AppApiService> AppApiServices { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<AppVersion> AppVersions { get; set; }

    public virtual DbSet<AppVersionDetail> AppVersionDetails { get; set; }

    public virtual DbSet<AppVersionHeader> AppVersionHeaders { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationAccessRequest> ApplicationAccessRequests { get; set; }

    public virtual DbSet<AuthenticationToken> AuthenticationTokens { get; set; }

    public virtual DbSet<Barangay> Barangays { get; set; }

    public virtual DbSet<BuMaintenance> BuMaintenances { get; set; }

    public virtual DbSet<BuMaintenanceStore> BuMaintenanceStores { get; set; }

    public virtual DbSet<BusinessStore> BusinessStores { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<BusinessUnitAdminAccess> BusinessUnitAdminAccesses { get; set; }

    public virtual DbSet<BusinessUnitResource> BusinessUnitResources { get; set; }

    public virtual DbSet<CategoryBusinessUnitStore> CategoryBusinessUnitStores { get; set; }

    public virtual DbSet<CategoryHome> CategoryHomes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<EmployeeLevel> EmployeeLevels { get; set; }

    public virtual DbSet<Highlight> Highlights { get; set; }

    public virtual DbSet<JobLevel> JobLevels { get; set; }

    public virtual DbSet<LegalEntity> LegalEntities { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<NonRrhiCompany> NonRrhiCompanies { get; set; }

    public virtual DbSet<NonRrhiPartner> NonRrhiPartners { get; set; }

    public virtual DbSet<NonRrhiUserProfile> NonRrhiUserProfiles { get; set; }

    public virtual DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }

    public virtual DbSet<PartnerBu> PartnerBus { get; set; }

    public virtual DbSet<PartnerVendor> PartnerVendors { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionLocation> RegionLocations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleModule> RoleModules { get; set; }

    public virtual DbSet<SecretAnswer> SecretAnswers { get; set; }

    public virtual DbSet<SecretQuestion> SecretQuestions { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<UserCoverage> UserCoverages { get; set; }

    public virtual DbSet<UserEmail> UserEmails { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserProfilePicture> UserProfilePictures { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:COMMON_DB"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ad>(entity =>
        {
            entity.ToTable("ads");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBuCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("created_bu_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBuCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("deleted_bu_code");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBuCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("edited_bu_code");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.ToTable("announcements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("date_from");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("date_to");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(20)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(20)
                .HasColumnName("edited_by");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .HasColumnName("image_path");
        });

        modelBuilder.Entity<ApiUser>(entity =>
        {
            entity.ToTable("api_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorizeRole)
                .HasMaxLength(100)
                .HasColumnName("authorize_role");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<AppApiService>(entity =>
        {
            entity.ToTable("app_api_services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiMethod)
                .HasMaxLength(500)
                .HasColumnName("api_method");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.BaseUrl)
                .HasMaxLength(100)
                .HasColumnName("base_url");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.HttpVerb)
                .HasMaxLength(10)
                .HasColumnName("http_verb");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ParameterFormat).HasColumnName("parameter_format");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Application).WithMany(p => p.AppApiServices)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_app_api_services_applications");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("app_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.NumberVisit).HasColumnName("number_visit");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Application).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_applications_app_users");

            entity.HasOne(d => d.User).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_profile_app_users");
        });

        modelBuilder.Entity<AppVersion>(entity =>
        {
            entity.ToTable("app_versions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .HasColumnName("version");
        });

        modelBuilder.Entity<AppVersionDetail>(entity =>
        {
            entity.ToTable("app_version_detail");

            entity.HasIndex(e => new { e.Id, e.HeaderId }, "UK_app_version_detail").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.HeaderId).HasColumnName("header_id");

            entity.HasOne(d => d.Header).WithMany(p => p.AppVersionDetails)
                .HasForeignKey(d => d.HeaderId)
                .HasConstraintName("FK_app_version_detail_app_version_header");
        });

        modelBuilder.Entity<AppVersionHeader>(entity =>
        {
            entity.ToTable("app_version_header");

            entity.HasIndex(e => new { e.Id, e.ApplicationId }, "UK_app_version_header").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppVersion)
                .HasMaxLength(20)
                .HasColumnName("app_version");
            entity.Property(e => e.AppVersionId).HasColumnName("app_version_id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");

            entity.HasOne(d => d.AppVersionNavigation).WithMany(p => p.AppVersionHeaders)
                .HasForeignKey(d => d.AppVersionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_app_version_header_app_versions");

            entity.HasOne(d => d.Application).WithMany(p => p.AppVersionHeaders)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_app_version_header_applications");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.ToTable("applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiServiceId).HasColumnName("api_service_id");
            entity.Property(e => e.AutoRegister)
                .HasDefaultValue(false)
                .HasColumnName("auto_register");
            entity.Property(e => e.CentralIsdApp)
                .HasDefaultValue(false)
                .HasColumnName("central_isd_app");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DbConnectionString)
                .HasMaxLength(200)
                .HasColumnName("db_connection_string");
            entity.Property(e => e.DefaultRoleId).HasColumnName("default_role_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DevDbConn)
                .HasMaxLength(200)
                .HasColumnName("dev_db_conn");
            entity.Property(e => e.DevUrl)
                .HasMaxLength(50)
                .HasColumnName("dev_url");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .HasColumnName("url");
        });

        modelBuilder.Entity<ApplicationAccessRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_non_rrhi_application");

            entity.ToTable("application_access_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ApplicationRequestStatus)
                .HasMaxLength(50)
                .HasColumnName("application_request_status");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationAccessRequests)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_non_rrhi_application_non_rrhi_application");

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationAccessRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_non_rrhi_application_user_profile");
        });

        modelBuilder.Entity<AuthenticationToken>(entity =>
        {
            entity.ToTable("authentication_token");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthToken).HasColumnName("auth_token");
            entity.Property(e => e.DateExpiry)
                .HasColumnType("datetime")
                .HasColumnName("date_expiry");
            entity.Property(e => e.DateExtended)
                .HasColumnType("datetime")
                .HasColumnName("date_extended");
            entity.Property(e => e.DateIssued)
                .HasColumnType("datetime")
                .HasColumnName("date_issued");
            entity.Property(e => e.ExtendedApps)
                .HasMaxLength(50)
                .HasColumnName("extended_apps");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.AuthenticationTokens)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_authentication_token_user_profile");
        });

        modelBuilder.Entity<Barangay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_baranggay");

            entity.ToTable("barangay");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");

            entity.HasOne(d => d.City).WithMany(p => p.Barangays)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_barangay_city");
        });

        modelBuilder.Entity<BuMaintenance>(entity =>
        {
            entity.ToTable("bu_maintenance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuCode)
                .HasMaxLength(50)
                .HasColumnName("bu_code");
            entity.Property(e => e.BuId).HasColumnName("bu_id");
            entity.Property(e => e.BySchedule).HasColumnName("by_schedule");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDeleted).HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.DatetimeFrom)
                .HasColumnType("datetime")
                .HasColumnName("datetime_from");
            entity.Property(e => e.DatetimeTo)
                .HasColumnType("datetime")
                .HasColumnName("datetime_to");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DownloadUrl)
                .HasMaxLength(250)
                .HasColumnName("download_url");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.ForceUpdate).HasColumnName("force_update");
            entity.Property(e => e.IsAndroid).HasColumnName("is_android");
            entity.Property(e => e.IsIos).HasColumnName("is_ios");
            entity.Property(e => e.IsSupported).HasColumnName("is_supported");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");
            entity.Property(e => e.WithStore).HasColumnName("with_store");
        });

        modelBuilder.Entity<BuMaintenanceStore>(entity =>
        {
            entity.ToTable("bu_maintenance_store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuMaintenanceId).HasColumnName("bu_maintenance_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.BuMaintenance).WithMany(p => p.BuMaintenanceStores)
                .HasForeignKey(d => d.BuMaintenanceId)
                .HasConstraintName("FK_bu_maintenance_store_bu_maintenance");
        });

        modelBuilder.Entity<BusinessStore>(entity =>
        {
            entity.ToTable("business_store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .HasColumnName("account_number");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(10)
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("date_edited");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.JdaCstcod)
                .HasMaxLength(10)
                .HasColumnName("jda_cstcod");
            entity.Property(e => e.MappingCodeDetail)
                .HasMaxLength(50)
                .HasColumnName("mapping_code_detail");
            entity.Property(e => e.MappingCodeHeader)
                .HasMaxLength(50)
                .HasColumnName("mapping_code_header");
            entity.Property(e => e.PaymentDateFormat)
                .HasMaxLength(50)
                .HasColumnName("payment_date_format");
            entity.Property(e => e.PaymentDelimeter)
                .HasMaxLength(10)
                .HasColumnName("payment_delimeter");
            entity.Property(e => e.PaymentPassword)
                .HasMaxLength(50)
                .HasColumnName("payment_password");
            entity.Property(e => e.PaymentPath)
                .HasMaxLength(100)
                .HasColumnName("payment_path");
            entity.Property(e => e.PaymentStoredProcedure)
                .HasMaxLength(50)
                .HasColumnName("payment_stored_procedure");
            entity.Property(e => e.PaymentUserName)
                .HasMaxLength(50)
                .HasColumnName("payment_user_name");
            entity.Property(e => e.PrefixAssignment)
                .HasMaxLength(30)
                .HasColumnName("prefix_assignment");
            entity.Property(e => e.PrefixReclass)
                .HasMaxLength(30)
                .HasColumnName("prefix_reclass");
            entity.Property(e => e.PrefixRecon)
                .HasMaxLength(30)
                .HasColumnName("prefix_recon");
            entity.Property(e => e.SalesDateFormat)
                .HasMaxLength(50)
                .HasColumnName("sales_date_format");
            entity.Property(e => e.SalesDelimeter)
                .HasMaxLength(10)
                .HasColumnName("sales_delimeter");
            entity.Property(e => e.SalesFileFormat)
                .HasMaxLength(20)
                .HasColumnName("sales_file_format");
            entity.Property(e => e.SalesPassword)
                .HasMaxLength(50)
                .HasColumnName("sales_password");
            entity.Property(e => e.SalesPath)
                .HasMaxLength(100)
                .HasColumnName("sales_path");
            entity.Property(e => e.SalesStoredProcedure)
                .HasMaxLength(50)
                .HasColumnName("sales_stored_procedure");
            entity.Property(e => e.SalesUserName)
                .HasMaxLength(50)
                .HasColumnName("sales_user_name");
            entity.Property(e => e.SearchTerm)
                .HasMaxLength(20)
                .HasColumnName("search_term");
            entity.Property(e => e.StoreCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("store_code");
            entity.Property(e => e.StoreName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("store_name");
            entity.Property(e => e.Tender)
                .HasMaxLength(10)
                .HasColumnName("tender");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.BusinessStores)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_business_store_business_units");
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.ToTable("business_units");

            entity.HasIndex(e => e.Id, "IX-business-units-20221227-133007");

            entity.HasIndex(e => new { e.Id, e.Code }, "UK_business_units").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.JdaCloneDb)
                .HasMaxLength(200)
                .HasColumnName("jda_clone_db");
            entity.Property(e => e.JdaCloneDbDev)
                .HasMaxLength(100)
                .HasColumnName("jda_clone_db_dev");
            entity.Property(e => e.JdaCloneDbName)
                .HasMaxLength(200)
                .HasColumnName("jda_clone_db_name");
            entity.Property(e => e.JdaIpAddress)
                .HasMaxLength(20)
                .HasColumnName("jda_ip_address");
            entity.Property(e => e.JdaLibrary)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("jda_library");
            entity.Property(e => e.JdaLinkedServerCatalog)
                .HasMaxLength(20)
                .HasColumnName("jda_linked_server_catalog");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RbeeDb)
                .HasMaxLength(200)
                .HasColumnName("rbee_db");
            entity.Property(e => e.RbeeDbName)
                .HasMaxLength(200)
                .HasColumnName("rbee_db_name");
            entity.Property(e => e.SapBucode)
                .HasMaxLength(10)
                .HasColumnName("sap_bucode");
            entity.Property(e => e.SapProfitCenter)
                .HasMaxLength(20)
                .HasColumnName("sap_profit_center");
            entity.Property(e => e.SapTitle)
                .HasMaxLength(20)
                .HasColumnName("sap_title");
            entity.Property(e => e.ShortName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("short_name");
            entity.Property(e => e.VoucherLimits).HasColumnName("voucher_limits");
        });

        modelBuilder.Entity<BusinessUnitAdminAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_business_it_admin");

            entity.ToTable("business_unit_admin_access");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Application).WithMany(p => p.BusinessUnitAdminAccesses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_business_it_access_applications");

            entity.HasOne(d => d.User).WithMany(p => p.BusinessUnitAdminAccesses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_business_it_access_user_profile");
        });

        modelBuilder.Entity<BusinessUnitResource>(entity =>
        {
            entity.ToTable("business_unit_resources");

            entity.HasIndex(e => new { e.Id, e.BusinessUnitId, e.DivisionId }, "UK_business_unit_resources").IsUnique();

            entity.HasIndex(e => e.Id, "UQ__business__3213E83EA9A2563D").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BannerSmall).HasColumnName("banner_small");
            entity.Property(e => e.BannerSmallFilename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("banner_small_filename");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.BusinessUnitResources)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_business_unit_resources_business_units");

            entity.HasOne(d => d.Division).WithMany(p => p.BusinessUnitResources)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_business_unit_resources_divisions");
        });

        modelBuilder.Entity<CategoryBusinessUnitStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_category_business_unit");

            entity.ToTable("category_business_unit_store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.HomeCategoryId).HasColumnName("home_category_id");
            entity.Property(e => e.StoreCode).HasColumnName("store_code");
        });

        modelBuilder.Entity<CategoryHome>(entity =>
        {
            entity.ToTable("category_home");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AltText).HasColumnName("alt_text");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.ForcedDisplay).HasColumnName("forced_display");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .HasColumnName("name");
            entity.Property(e => e.Priority).HasColumnName("priority");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_city_region");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_companies_1");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("address");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.Companies)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_companies_business_units");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_departments_1");

            entity.ToTable("departments");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Shared).HasColumnName("shared");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("divisions");

            entity.HasIndex(e => new { e.Id, e.BusinessUnitId }, "UK_divisions").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.BusinessUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_divisions_business_units");
        });

        modelBuilder.Entity<EmployeeLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId);

            entity.ToTable("employee_level");

            entity.Property(e => e.LevelId)
                .ValueGeneratedNever()
                .HasColumnName("level_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Swipe).HasColumnName("swipe");
        });

        modelBuilder.Entity<Highlight>(entity =>
        {
            entity.ToTable("highlights");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<JobLevel>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("job_level");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<LegalEntity>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("legal_entity");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("location");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("modules");

            entity.HasIndex(e => new { e.Id, e.ApplicationId }, "UK_modules").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .HasColumnName("controller");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .HasColumnName("group_name");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(100)
                .HasColumnName("subtitle");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");

            entity.HasOne(d => d.Application).WithMany(p => p.Modules)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_modules_applications");
        });

        modelBuilder.Entity<NonRrhiCompany>(entity =>
        {
            entity.ToTable("non_rrhi_companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.NonRrhiCompanies)
                .HasForeignKey(d => d.BusinessUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_non_rrhi_companies_business_units");
        });

        modelBuilder.Entity<NonRrhiPartner>(entity =>
        {
            entity.HasKey(e => e.EmployeeNumber).HasName("PK_non_rrhi_partner_1");

            entity.ToTable("non_rrhi_partner");

            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_number");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<NonRrhiUserProfile>(entity =>
        {
            entity.ToTable("non_rrhi_user_profile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.JobGradeLevel)
                .HasMaxLength(50)
                .HasColumnName("job_grade_level");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.NonRrhiCompanyId).HasColumnName("non_rrhi_company_id");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.RrhiWide).HasColumnName("rrhi_wide");
            entity.Property(e => e.SharedServices).HasColumnName("shared_services");
            entity.Property(e => e.Signatory)
                .HasMaxLength(50)
                .HasColumnName("signatory");
            entity.Property(e => e.SssNumber)
                .HasMaxLength(50)
                .HasColumnName("sss_number");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.NonRrhiCompany).WithMany(p => p.NonRrhiUserProfiles)
                .HasForeignKey(d => d.NonRrhiCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_non_rrhi_user_profile_non_rrhi_companies");
        });

        modelBuilder.Entity<OrganizationalUnit>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("organizational_unit");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<PartnerBu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_partner_bu_1");

            entity.ToTable("partner_bu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuId).HasColumnName("bu_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.PartnerEmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("partner_employee_number");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Bu).WithMany(p => p.PartnerBus)
                .HasForeignKey(d => d.BuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partner_bu_business_units");

            entity.HasOne(d => d.PartnerEmployeeNumberNavigation).WithMany(p => p.PartnerBus)
                .HasForeignKey(d => d.PartnerEmployeeNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_partner_bu_non_rrhi_partner");
        });

        modelBuilder.Entity<PartnerVendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_partner_vendor_1");

            entity.ToTable("partner_vendor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuId).HasColumnName("bu_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.VendorDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vendor_description");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.Bu).WithMany(p => p.PartnerVendors)
                .HasForeignKey(d => d.BuId)
                .HasConstraintName("FK_partner_vendor_partner_bu");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("position");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.ToTable("province");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(25)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(25)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deleted_date");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(25)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_province_region");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("region");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.RegionLocationId).HasColumnName("region_location_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
        });

        modelBuilder.Entity<RegionLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_island");

            entity.ToTable("region_location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Application).WithMany(p => p.Roles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_roles_applications");
        });

        modelBuilder.Entity<RoleModule>(entity =>
        {
            entity.ToTable("role_modules");

            entity.HasIndex(e => new { e.Id, e.RoleId, e.ModuleId }, "UK_role_modules").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Module).WithMany(p => p.RoleModules)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_role_modules_modules");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleModules)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_role_modules_roles");
        });

        modelBuilder.Entity<SecretAnswer>(entity =>
        {
            entity.ToTable("secret_answer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.SecretQuestionId).HasColumnName("secret_question_id");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.SecretQuestion).WithMany(p => p.SecretAnswers)
                .HasForeignKey(d => d.SecretQuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_secret_answer_secret_question");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.SecretAnswers)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("FK_secret_answer_user_profile");
        });

        modelBuilder.Entity<SecretQuestion>(entity =>
        {
            entity.ToTable("secret_question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Question)
                .HasMaxLength(200)
                .HasColumnName("question");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.BusinessUnitId, e.CompanyCode, e.Number });

            entity.ToTable("stores");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("company_code");
            entity.Property(e => e.Number)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("number");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("address_2");
            entity.Property(e => e.Address3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("address_3");
            entity.Property(e => e.Afct)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("afct");
            entity.Property(e => e.Apyn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("apyn");
            entity.Property(e => e.Aryn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("aryn");
            entity.Property(e => e.Ayes)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ayes");
            entity.Property(e => e.BankAccount)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("bank_account");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("city");
            entity.Property(e => e.Clcn)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("clcn");
            entity.Property(e => e.Cmp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cmp");
            entity.Property(e => e.Cntr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cntr");
            entity.Property(e => e.CompanyNumber)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("company_number");
            entity.Property(e => e.CostingMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("costing_method");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("country_code");
            entity.Property(e => e.CountryId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("country_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateClosed)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("date_closed");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DateOpened)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("date_opened");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.DistrictNumber)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("district_number");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("fax_number");
            entity.Property(e => e.Glyn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("glyn");
            entity.Property(e => e.Hdo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("hdo");
            entity.Property(e => e.HomeCurrency)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("home_currency");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("language_code");
            entity.Property(e => e.LastMerchantCount)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("last_merchant_count");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("manager_name");
            entity.Property(e => e.ModelStoreCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("model_store_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OpenSunday)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("open_sunday");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("phone_number");
            entity.Property(e => e.Poll)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("poll");
            entity.Property(e => e.Pon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("pon");
            entity.Property(e => e.PrintQueue)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("print_queue");
            entity.Property(e => e.Prms)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("prms");
            entity.Property(e => e.ProvinceStateCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("province_state_code");
            entity.Property(e => e.RegionNumber)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("region_number");
            entity.Property(e => e.ReplenishmentZone)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("replenishment_zone");
            entity.Property(e => e.Retail)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("retail");
            entity.Property(e => e.SalesAuditClerk)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("sales_audit_clerk");
            entity.Property(e => e.Scen)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("scen");
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("short_name");
            entity.Property(e => e.TaxCurrency)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("tax_currency");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("type");
            entity.Property(e => e.WarehouseNumber)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("warehouse_number");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("zip_code");
            entity.Property(e => e.ZoneNumber)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("zone_number");
        });

        modelBuilder.Entity<UserCoverage>(entity =>
        {
            entity.ToTable("user_coverage");

            entity.HasIndex(e => new { e.Id, e.UserProfileId, e.ApplicationId, e.BusinessUnitId, e.DivisionId }, "UK_user_coverage").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Application).WithMany(p => p.UserCoverages)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_coverage_applications");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.UserCoverages)
                .HasForeignKey(d => d.BusinessUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_coverage_business_units");

            entity.HasOne(d => d.Division).WithMany(p => p.UserCoverages)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_user_coverage_divisions");

            entity.HasOne(d => d.Role).WithMany(p => p.UserCoverages)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_coverage_roles");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserCoverages)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("FK_user_coverage_user_profile");
        });

        modelBuilder.Entity<UserEmail>(entity =>
        {
            entity.ToTable("user_emails");

            entity.HasIndex(e => new { e.Id, e.UserProfileId }, "UK_user_emails").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.EmailAddress)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.Primary).HasColumnName("primary");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserEmails)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("FK_user_emails_user_profile");
        });

        modelBuilder.Entity<UserNotification>(entity =>
        {
            entity.ToTable("user_notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Message)
                .HasMaxLength(300)
                .HasColumnName("message");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.ReadStatus).HasColumnName("read_status");
            entity.Property(e => e.RedirectUrl)
                .HasMaxLength(200)
                .HasColumnName("redirect_url");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Application).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_notification_applications");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserNotifications)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_notification_user_profile");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_profile_id");

            entity.ToTable("user_profile");

            entity.HasIndex(e => new { e.EmployeeNumber, e.Active }, "IX_user_profile_empnumber_active");

            entity.HasIndex(e => new { e.Signatory, e.RegistrationStatus }, "IX_user_profile_signatory_regstatus");

            entity.HasIndex(e => new { e.UserName, e.Active }, "IX_user_profile_username_active");

            entity.HasIndex(e => new { e.Id, e.EmployeeNumber }, "UK_user_profile").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessNumber)
                .HasMaxLength(50)
                .HasColumnName("access_number");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DateHired)
                .HasColumnType("datetime")
                .HasColumnName("date_hired");
            entity.Property(e => e.DateRegularized)
                .HasColumnType("datetime")
                .HasColumnName("date_regularized");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("deleted_by");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.JobLevelCode)
                .HasMaxLength(25)
                .HasColumnName("job_level_code");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LegalEntityCode)
                .HasMaxLength(25)
                .HasColumnName("legal_entity_code");
            entity.Property(e => e.LocationCode)
                .HasMaxLength(25)
                .HasColumnName("location_code");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.NonAd).HasColumnName("non_ad");
            entity.Property(e => e.NonRrhi).HasColumnName("non_rrhi");
            entity.Property(e => e.NonSwipe).HasColumnName("non_swipe");
            entity.Property(e => e.OrganizationalUnitCode)
                .HasMaxLength(25)
                .HasColumnName("organizational_unit_code");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PayrollAreaCode)
                .HasMaxLength(25)
                .HasColumnName("payroll_area_code");
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(25)
                .HasColumnName("personnel_area_code");
            entity.Property(e => e.PositionCode)
                .HasMaxLength(25)
                .HasColumnName("position_code");
            entity.Property(e => e.RegistrationStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("registration_status");
            entity.Property(e => e.SapId)
                .HasMaxLength(50)
                .HasColumnName("sap_id");
            entity.Property(e => e.SharedService).HasColumnName("shared_service");
            entity.Property(e => e.Signatory)
                .HasMaxLength(50)
                .HasColumnName("signatory");
            entity.Property(e => e.SssNumber)
                .HasMaxLength(50)
                .HasColumnName("sss_number");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StoreCode)
                .HasMaxLength(25)
                .HasColumnName("store_code");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.WorkScheduleRuleCode)
                .HasMaxLength(25)
                .HasColumnName("work_schedule_rule_code");
            entity.Property(e => e.WsrFrom)
                .HasColumnType("datetime")
                .HasColumnName("wsr_from");
            entity.Property(e => e.WsrTo)
                .HasColumnType("datetime")
                .HasColumnName("wsr_to");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_user_profile_business_units");

            entity.HasOne(d => d.Company).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_user_profile_companies");

            entity.HasOne(d => d.Department).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_user_profile_departments");

            entity.HasOne(d => d.Division).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_user_profile_divisions");

            entity.HasOne(d => d.JobLevelCodeNavigation).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.JobLevelCode)
                .HasConstraintName("FK_user_profile_job_level");

            entity.HasOne(d => d.LegalEntityCodeNavigation).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.LegalEntityCode)
                .HasConstraintName("FK_user_profile_new_legal_entity");

            entity.HasOne(d => d.LocationCodeNavigation).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.LocationCode)
                .HasConstraintName("FK_user_profile_location");

            entity.HasOne(d => d.OrganizationalUnitCodeNavigation).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.OrganizationalUnitCode)
                .HasConstraintName("FK_user_profile_organizational_unit");

            entity.HasOne(d => d.PositionCodeNavigation).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.PositionCode)
                .HasConstraintName("FK_user_profile_position");
        });

        modelBuilder.Entity<UserProfilePicture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_avatar");

            entity.ToTable("user_profile_picture");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
            entity.Property(e => e.Type)
                .HasMaxLength(5)
                .HasColumnName("type");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserProfilePictures)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("FK_profile_picture_user_profile");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
