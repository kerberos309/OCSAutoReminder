using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Context.EAMS;

public partial class EamsDevV31Context : DbContext
{
    //private readonly IConfiguration _configuration;
    public EamsDevV31Context()
    {
        //_configuration = new ConfigurationBuilder()
        //    .AddUserSecrets("fc917c02-0293-4f3b-8dd7-971a40e52ece", true)
        //    .Build();
    }

    public EamsDevV31Context(DbContextOptions<EamsDevV31Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiUser> ApiUsers { get; set; }

    public virtual DbSet<ApproverDelegation> ApproverDelegations { get; set; }

    public virtual DbSet<AttendanceSummary> AttendanceSummaries { get; set; }

    public virtual DbSet<AttendanceSummaryStatus> AttendanceSummaryStatuses { get; set; }

    public virtual DbSet<DailyWorkSchedule> DailyWorkSchedules { get; set; }

    public virtual DbSet<DailyWorkSchedulePersonnelArea> DailyWorkSchedulePersonnelAreas { get; set; }

    public virtual DbSet<DailyWorkScheduleTest> DailyWorkScheduleTests { get; set; }

    public virtual DbSet<DtrRaw> DtrRaws { get; set; }

    public virtual DbSet<EmailNotifService> EmailNotifServices { get; set; }

    public virtual DbSet<ExemptedEmployee> ExemptedEmployees { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<HornNotif> HornNotifs { get; set; }

    public virtual DbSet<HornNotifViewed> HornNotifVieweds { get; set; }

    public virtual DbSet<LeaveHour> LeaveHours { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<LeaveTypePersonnelArea> LeaveTypePersonnelAreas { get; set; }

    public virtual DbSet<LeaveTypeRequirement> LeaveTypeRequirements { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Module> Modules { get; set; }


    public virtual DbSet<PersonnelArea> PersonnelAreas { get; set; }


    public virtual DbSet<TasApplication> TasApplications { get; set; }

    public virtual DbSet<TasApproval> TasApprovals { get; set; }


    public virtual DbSet<TasApprovalRule> TasApprovalRules { get; set; }

    public virtual DbSet<TasEmailNotification> TasEmailNotifications { get; set; }

    public virtual DbSet<TasType> TasTypes { get; set; }

    public virtual DbSet<TempMatrix> TempMatrices { get; set; }

    public virtual DbSet<Timekeeper> Timekeepers { get; set; }

    public virtual DbSet<UserDefaultSchedule> UserDefaultSchedules { get; set; }


    public virtual DbSet<UserDefineApprover> UserDefineApprovers { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }


    public virtual DbSet<UserSchedule> UserSchedules { get; set; }

    public virtual DbSet<UserScheduleDetail> UserScheduleDetails { get; set; }


    public virtual DbSet<WeeklySchedule> WeeklySchedules { get; set; }

    public virtual DbSet<WeeklyScheduleDetail> WeeklyScheduleDetails { get; set; }

    public virtual DbSet<WsApproverDelegation> WsApproverDelegations { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:EAMS"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.Eams).HasColumnName("eams");
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

        modelBuilder.Entity<ApproverDelegation>(entity =>
        {
            entity.ToTable("approver_delegation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DateEmailed)
                .HasColumnType("datetime")
                .HasColumnName("date_emailed");
            entity.Property(e => e.DelegatedEmployeeCode).HasColumnName("delegated_employee_code");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmailNotif).HasColumnName("email_notif");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.DelegatedEmployeeCodeNavigation).WithMany(p => p.ApproverDelegationDelegatedEmployeeCodeNavigations)
                .HasForeignKey(d => d.DelegatedEmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_approver_delegation_user_profile1");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.ApproverDelegationEmployeeCodeNavigations)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_approver_delegation_user_profile");
        });

        modelBuilder.Entity<AttendanceSummary>(entity =>
        {
            entity.ToTable("attendance_summary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasColumnName("remarks");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.AttendanceSummaries)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attendance_summary_user_profile");
        });

        modelBuilder.Entity<AttendanceSummaryStatus>(entity =>
        {
            entity.ToTable("attendance_summary_status");

            entity.HasIndex(e => new { e.Status, e.ApproverCode }, "IX-attendance-summary-status-20221220-131223");

            entity.HasIndex(e => e.ApproverCode, "IX_attendance_summary_status_22_21");

            entity.HasIndex(e => e.AttendanceSummaryId, "ix-attendance-summary-status-attendance_summary_id-20230502-134107");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproverCode).HasColumnName("approver_code");
            entity.Property(e => e.AttendanceSummaryId).HasColumnName("attendance_summary_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            entity.HasOne(d => d.ApproverCodeNavigation).WithMany(p => p.AttendanceSummaryStatusApproverCodeNavigations)
                .HasForeignKey(d => d.ApproverCode)
                .HasConstraintName("FK_attendance_summary_status_user_profile1");

            entity.HasOne(d => d.AttendanceSummary).WithMany(p => p.AttendanceSummaryStatuses)
                .HasForeignKey(d => d.AttendanceSummaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attendance_summary_status_attendance_summary");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.AttendanceSummaryStatusEmployeeCodeNavigations)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attendance_summary_status_user_profile");
        });

        modelBuilder.Entity<DailyWorkSchedule>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("daily_work_schedule");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeGroup)
                .HasMaxLength(50)
                .HasColumnName("time_group");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");
        });

        modelBuilder.Entity<DailyWorkSchedulePersonnelArea>(entity =>
        {
            entity.ToTable("daily_work_schedule_personnel_area");

            entity.HasIndex(e => new { e.PersonnelAreaCode, e.Deleted }, "IX_daily_work_schedule_personnel_area_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DailyWorkScheduleCode)
                .HasMaxLength(10)
                .HasColumnName("daily_work_schedule_code");
            entity.Property(e => e.DailyWorkScheduleId).HasColumnName("daily_work_schedule_id");
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
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(20)
                .HasColumnName("personnel_area_code");

            entity.HasOne(d => d.DailyWorkScheduleCodeNavigation).WithMany(p => p.DailyWorkSchedulePersonnelAreas)
                .HasForeignKey(d => d.DailyWorkScheduleCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_daily_work_schedule_personnel_area_daily_work_schedule");

            entity.HasOne(d => d.PersonnelAreaCodeNavigation).WithMany(p => p.DailyWorkSchedulePersonnelAreas)
                .HasForeignKey(d => d.PersonnelAreaCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_daily_work_schedule_personnel_area_personnel_area");
        });

        modelBuilder.Entity<DailyWorkScheduleTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("daily_work_schedule_test");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedDate).HasColumnName("deleted_date");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("personnel_area_code");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeGroup)
                .HasMaxLength(50)
                .HasColumnName("time_group");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");
        });

        modelBuilder.Entity<DtrRaw>(entity =>
        {
            entity.ToTable("dtr_raw");

            entity.HasIndex(e => new { e.EmployeeCode, e.DtrDate }, "IX_dtr_raw_empcode_date");

            entity.HasIndex(e => new { e.AccessNumber, e.DtrDate, e.DtrTime }, "Missing_IXNC_dtr_raw_access_number_dtr_date_dtr_time_F3662");

            entity.HasIndex(e => e.EmployeeCode, "Missing_IXNC_dtr_raw_employee_code_2EA21");

            entity.HasIndex(e => new { e.EmployeeCode, e.DtrDate }, "ix-dtr-raw-employee_code-dtr_date-20230502-133553");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessNumber)
                .HasMaxLength(50)
                .HasColumnName("access_number");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DtrDate).HasColumnName("dtr_date");
            entity.Property(e => e.DtrTime).HasColumnName("dtr_time");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.LogFile)
                .HasMaxLength(200)
                .HasColumnName("log_file");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.DtrRaws)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dtr_raw_user_profile");
        });

        modelBuilder.Entity<EmailNotifService>(entity =>
        {
            entity.ToTable("email_notif_service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OnOff).HasColumnName("onOff");
            entity.Property(e => e.SendBefore).HasColumnName("sendBefore");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<ExemptedEmployee>(entity =>
        {
            entity.ToTable("exempted_employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDeleted).HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.ExemptedEmployees)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exempted_employee_user_profile");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.ToTable("holidays");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
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
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Recurring).HasColumnName("recurring");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<HornNotif>(entity =>
        {
            entity.ToTable("horn_notif");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.FifteenthDay).HasColumnName("fifteenth_day");
            entity.Property(e => e.LastDay).HasColumnName("last_day");
            entity.Property(e => e.NotifMsg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notif_msg");
            entity.Property(e => e.NotifTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("notif_title");
        });

        modelBuilder.Entity<HornNotifViewed>(entity =>
        {
            entity.ToTable("horn_notif_viewed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CutoffDate).HasColumnName("cutoff_date");
            entity.Property(e => e.DateViewed)
                .HasColumnType("datetime")
                .HasColumnName("date_viewed");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.HornNotifId).HasColumnName("horn_notif_id");

            entity.HasOne(d => d.HornNotif).WithMany(p => p.HornNotifVieweds)
                .HasForeignKey(d => d.HornNotifId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_horn_notif_viewed_horn_notif");
        });

        modelBuilder.Entity<LeaveHour>(entity =>
        {
            entity.ToTable("leave_hours");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.HalfDayHours).HasColumnName("half_day_hours");
            entity.Property(e => e.LegalEntityCode)
                .HasMaxLength(25)
                .HasColumnName("legal_entity_code");
            entity.Property(e => e.StoreCode)
                .HasMaxLength(25)
                .HasColumnName("store_code");
            entity.Property(e => e.WholeDayHours).HasColumnName("whole_day_hours");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_leave_type_1");

            entity.ToTable("leave_type");

            entity.HasIndex(e => e.Code, "IX_leave_type");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
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
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.InfoType)
                .HasMaxLength(10)
                .HasColumnName("info_type");
            entity.Property(e => e.LeaveQuotaCode)
                .HasMaxLength(5)
                .HasColumnName("leave_quota_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(5)
                .HasColumnName("short_name");
            entity.Property(e => e.SubType)
                .HasMaxLength(10)
                .HasColumnName("sub_type");
        });

        modelBuilder.Entity<LeaveTypePersonnelArea>(entity =>
        {
            entity.ToTable("leave_type_personnel_area");

            entity.HasIndex(e => new { e.LeaveTypeCode, e.PersonnelAreaCode }, "IX_leave_type_personnel_area");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.LeaveTypeCode)
                .HasMaxLength(20)
                .HasColumnName("leave_type_code");
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(20)
                .HasColumnName("personnel_area_code");

            entity.HasOne(d => d.LeaveTypeCodeNavigation).WithMany(p => p.LeaveTypePersonnelAreas)
                .HasForeignKey(d => d.LeaveTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_leave_type_personnel_area_leave_type");

            entity.HasOne(d => d.PersonnelAreaCodeNavigation).WithMany(p => p.LeaveTypePersonnelAreas)
                .HasForeignKey(d => d.PersonnelAreaCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_leave_type_personnel_area_personnel_area");
        });

        modelBuilder.Entity<LeaveTypeRequirement>(entity =>
        {
            entity.ToTable("leave_type_requirements");

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
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(20)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(20)
                .HasColumnName("edited_by");
            entity.Property(e => e.LeaveTypeCode)
                .HasMaxLength(20)
                .HasColumnName("leave_type_code");
            entity.Property(e => e.Requirements).HasColumnName("requirements");

            entity.HasOne(d => d.LeaveTypeCodeNavigation).WithMany(p => p.LeaveTypeRequirements)
                .HasForeignKey(d => d.LeaveTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_leave_type_requirements_leave_type");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_maintenance_1");

            entity.ToTable("maintenance");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.DownloadUrl)
                .HasMaxLength(250)
                .HasColumnName("downloadUrl");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.ForceUpdate).HasColumnName("forceUpdate");
            entity.Property(e => e.IsAndroid).HasColumnName("isAndroid");
            entity.Property(e => e.IsMaintenance).HasColumnName("isMaintenance");
            entity.Property(e => e.IsSupported)
                .HasDefaultValue(true)
                .HasColumnName("isSupported");
            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("modules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
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
            entity.Property(e => e.EamsAppCode)
                .HasMaxLength(10)
                .HasColumnName("eams_app_code");
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
        });

        modelBuilder.Entity<PersonnelArea>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_personnel_area_code");

            entity.ToTable("personnel_area");

            entity.HasIndex(e => e.Code, "IX_personnel_area_[code]");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TasApplication>(entity =>
        {
            entity.ToTable("tas_application");

            entity.HasIndex(e => e.EmployeeNumber, "IXNC_tas_application_employee_number_1E3FC");

            entity.HasIndex(e => new { e.EmployeeNumber, e.DateFrom }, "IXNC_tas_application_employee_number_date_from_24A9C");

            entity.HasIndex(e => new { e.EmployeeNumber, e.DateFrom, e.DateTo }, "IXNC_tas_application_employee_number_date_from_date_to_16B5C");

            entity.HasIndex(e => new { e.EmployeeCode, e.DateFrom, e.DateTo }, "IX_tas_application_empcode_dfrom_dto");

            entity.HasIndex(e => new { e.DateCreated, e.EmployeeCode, e.TasTypeId, e.LeaveTypeCode, e.DateFrom, e.DateTo }, "ix-tas-application-employee_code-20230502-133149").IsDescending(true, false, false, false, false, false);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(15)
                .HasDefaultValueSql("((0))")
                .HasColumnName("application_status");
            entity.Property(e => e.CancelledDate)
                .HasColumnType("datetime")
                .HasColumnName("cancelled_date");
            entity.Property(e => e.CancelledReason)
                .HasMaxLength(1000)
                .HasColumnName("cancelled_reason");
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
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Destination)
                .HasMaxLength(1000)
                .HasColumnName("destination");
            entity.Property(e => e.DwsCode)
                .HasMaxLength(10)
                .HasColumnName("dws_code");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FioInOut).HasColumnName("fio_in_out");
            entity.Property(e => e.FioPreviousDay).HasColumnName("fio_previous_day");
            entity.Property(e => e.HalfdayType)
                .HasMaxLength(5)
                .HasColumnName("halfday_type");
            entity.Property(e => e.LateSubmissionReason)
                .HasMaxLength(1000)
                .HasColumnName("late_submission_reason");
            entity.Property(e => e.LeaveTypeCode)
                .HasMaxLength(20)
                .HasColumnName("leave_type_code");
            entity.Property(e => e.Reason)
                .HasMaxLength(1000)
                .HasColumnName("reason");
            entity.Property(e => e.SapPostingStatus)
                .HasMaxLength(50)
                .HasColumnName("sap_posting_status");
            entity.Property(e => e.TasTypeId).HasColumnName("tas_type_id");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.DwsCodeNavigation).WithMany(p => p.TasApplications)
                .HasForeignKey(d => d.DwsCode)
                .HasConstraintName("FK_tas_application_daily_work_schedule");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.TasApplications)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_application_user_profile");

            entity.HasOne(d => d.LeaveTypeCodeNavigation).WithMany(p => p.TasApplications)
                .HasForeignKey(d => d.LeaveTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_application_leave_type");

            entity.HasOne(d => d.TasType).WithMany(p => p.TasApplications)
                .HasForeignKey(d => d.TasTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_application_tas_type");
        });

        modelBuilder.Entity<TasApproval>(entity =>
        {
            entity.ToTable("tas_approval");

            entity.HasIndex(e => e.TasApplicationId, "IX-tas-approval-tas-application-id-20221215-093613");

            entity.HasIndex(e => e.EmployeeCode, "Missing_IXNC_tas_approval_employee_code_4515D");

            entity.HasIndex(e => new { e.EmployeeCode, e.Status }, "Missing_IXNC_tas_approval_employee_code_status_6987C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovalLevel).HasColumnName("approval_level");
            entity.Property(e => e.ApproverDelegationId).HasColumnName("approver_delegation_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited)
                .HasColumnType("datetime")
                .HasColumnName("date_edited");
            entity.Property(e => e.DelegatedApprover).HasColumnName("delegated_approver");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Reason)
                .HasMaxLength(1000)
                .HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TasApplicationId).HasColumnName("tas_application_id");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.TasApprovals)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_approval_user_profile");

            entity.HasOne(d => d.TasApplication).WithMany(p => p.TasApprovals)
                .HasForeignKey(d => d.TasApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_approval_tas_application");
        });

        modelBuilder.Entity<TasApprovalRule>(entity =>
        {
            entity.ToTable("tas_approval_rule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.ApprovalLevel).HasColumnName("approval_level");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
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
            entity.Property(e => e.LeaveTypeCode)
                .HasMaxLength(20)
                .HasColumnName("leave_type_code");
            entity.Property(e => e.TasTypeId).HasColumnName("tas_type_id");

            entity.HasOne(d => d.LeaveTypeCodeNavigation).WithMany(p => p.TasApprovalRules)
                .HasForeignKey(d => d.LeaveTypeCode)
                .HasConstraintName("FK_tas_approval_rule_leave_type");

            entity.HasOne(d => d.TasType).WithMany(p => p.TasApprovalRules)
                .HasForeignKey(d => d.TasTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_approval_rule_tas_type");
        });

        modelBuilder.Entity<TasEmailNotification>(entity =>
        {
            entity.ToTable("tas_email_notification");

            entity.HasIndex(e => new { e.Deleted, e.Id }, "_dta_index_tas_email_notification_10_1622296839__K11_K1_2_3_4_5_6_7_8_9_10_12_13").IsDescending(false, true);

            entity.HasIndex(e => new { e.EditedBy, e.DateCreated }, "_dta_index_tas_email_notification_10_1622296839__K9_K8D_1_2_3_4_5_6_7_10_11_12_13").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Approvers).HasColumnName("approvers");
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
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.TasEmailNotifications)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tas_email_notification_user_profile");
        });

        modelBuilder.Entity<TasType>(entity =>
        {
            entity.ToTable("tas_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
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
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.InfoType)
                .HasMaxLength(10)
                .HasColumnName("info_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ShortName)
                .HasMaxLength(5)
                .HasColumnName("short_name");
            entity.Property(e => e.SubType)
                .HasMaxLength(10)
                .HasColumnName("sub_type");
        });

        modelBuilder.Entity<TempMatrix>(entity =>
        {
            entity.ToTable("temp_matrix");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("date_from");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("date_to");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(100)
                .HasColumnName("employee_code");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(8)
                .HasColumnName("employee_number");
            entity.Property(e => e.ForEdit).HasColumnName("for_edit");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.WeeklyScheduleCode)
                .HasMaxLength(50)
                .HasColumnName("weekly_schedule_code");
        });

        modelBuilder.Entity<Timekeeper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__timekeep__3213E83FC824B98C");

            entity.ToTable("timekeeper");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.Timekeepers)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__timekeepe__emplo_uprof_code");
        });

        modelBuilder.Entity<UserDefaultSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__work_sch__3213E83F1B97C15E");

            entity.ToTable("user_default_schedule");

            entity.HasIndex(e => e.EmployeeCode, "Missing_IXNC_user_default_schedule_employee_code_D5F2B");

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
            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("date_from");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("date_to");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.IsWeekly).HasColumnName("is_weekly");
            entity.Property(e => e.WeeklyScheduleCode)
                .HasMaxLength(20)
                .HasColumnName("weekly_schedule_code");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.UserDefaultSchedules)
                .HasForeignKey(d => d.EmployeeCode)
                .HasConstraintName("FK__user_defa__emplo__100C566E");

            entity.HasOne(d => d.WeeklyScheduleCodeNavigation).WithMany(p => p.UserDefaultSchedules)
                .HasForeignKey(d => d.WeeklyScheduleCode)
                .HasConstraintName("FK_user_default_schedule_weekly_schedule");
        });

        modelBuilder.Entity<UserDefineApprover>(entity =>
        {
            entity.ToTable("user_define_approver");

            entity.HasIndex(e => new { e.Active, e.Deleted, e.Status }, "Missing_IXNC_user_define_approver_active_deleted_status_BADCA");

            entity.HasIndex(e => new { e.Active, e.Deleted, e.Status, e.EmployeeCode }, "Missing_IXNC_user_define_approver_active_deleted_status_employee_code_BFC0C");

            entity.HasIndex(e => new { e.ApproverEmployeeCode, e.Deleted, e.Status }, "Missing_IXNC_user_define_approver_approver_employee_code_deleted_status_744D6");

            entity.HasIndex(e => new { e.EmployeeCode, e.Active, e.Deleted, e.Status }, "Missing_IXNC_user_define_approver_employee_code_active_deleted_status_48293");

            entity.HasIndex(e => e.Deleted, "ix-user-define-approver-deleted-20230502-134252");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.ApprovalLevel).HasColumnName("approval_level");
            entity.Property(e => e.ApproverEmployeeCode).HasColumnName("approver_employee_code");
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
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("status");

            entity.HasOne(d => d.ApproverEmployeeCodeNavigation).WithMany(p => p.UserDefineApproverApproverEmployeeCodeNavigations)
                .HasForeignKey(d => d.ApproverEmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_define_approver_user_profile_approver");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.UserDefineApproverEmployeeCodeNavigations)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_define_approver_user_profile");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("user_profile");

            entity.HasIndex(e => new { e.DateHired, e.DateRegularized, e.SssNumber, e.PayrollAreaCode, e.StoreCode, e.WorkScheduleRuleCode, e.SharedService, e.LegalEntityCode, e.SapId, e.NonRrhi, e.WsrFrom, e.WsrTo }, "IX-user-profile-date-hired-wsr-to-20221215-101251");

            entity.HasIndex(e => new { e.Id, e.Code, e.EmployeeNumber, e.NonAd, e.UserName, e.FirstName, e.MiddleName, e.LastName, e.Status, e.AccessNumber, e.Signatory, e.ImmediateSupervisor, e.NonSwipe, e.Active, e.CompanyId, e.DepartmentId, e.CreatedBy, e.DateCreated, e.EditedBy, e.DateEdited, e.Deleted, e.DeletedBy, e.DateDeleted, e.BusinessUnitId, e.DivisionId, e.PersonnelAreaCode, e.OrganizationalUnitCode, e.JobLevelCode, e.LocationCode, e.PositionCode, e.Gender, e.Birthday }, "IX-user-profile-id-birthday-20221215-100957");

            entity.HasIndex(e => e.UserName, "IXNC_user_profile_user_name_8011F");

            entity.HasIndex(e => e.BusinessUnitId, "Missing_IXNC_user_profile_business_unit_id_F3260");

            entity.HasIndex(e => e.EmployeeNumber, "Missing_IXNC_user_profile_employee_number_06FF1");

            entity.HasIndex(e => new { e.Id, e.EmployeeNumber }, "UK_user_profile").IsUnique();

            entity.HasIndex(e => e.AccessNumber, "ix-user-profile-access_number-20230502-132805");

            entity.HasIndex(e => new { e.Active, e.BusinessUnitId }, "ix-user-profile-active-business_unit_id-20230502-134956");

            entity.HasIndex(e => new { e.ImmediateSupervisor, e.Active, e.Deleted }, "ix-user-profile-immediate_supervisor-active-deleted-20230502-132655");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
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
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ImmediateSupervisor).HasColumnName("immediate_supervisor");
            entity.Property(e => e.JobLevelCode)
                .HasMaxLength(25)
                .HasColumnName("job_level_code");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LegalEntityCode)
                .HasMaxLength(25)
                .HasColumnName("legal_entity_code");
            entity.Property(e => e.LocationCode)
                .HasMaxLength(25)
                .HasColumnName("location_code");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.NonAd).HasColumnName("non_ad");
            entity.Property(e => e.NonRrhi).HasColumnName("non_rrhi");
            entity.Property(e => e.NonSwipe).HasColumnName("non_swipe");
            entity.Property(e => e.OrganizationalUnitCode)
                .HasMaxLength(25)
                .HasColumnName("organizational_unit_code");
            entity.Property(e => e.PayrollAreaCode)
                .HasMaxLength(25)
                .HasColumnName("payroll_area_code");
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(20)
                .HasColumnName("personnel_area_code");
            entity.Property(e => e.PositionCode)
                .HasMaxLength(25)
                .HasColumnName("position_code");
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
                .HasComment("Cost Center")
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
        });

        modelBuilder.Entity<UserSchedule>(entity =>
        {
            entity.ToTable("user_schedule");

            entity.HasIndex(e => new { e.EmployeeCode, e.DateFrom, e.DateTo }, "IX_user_schedule_empcode_datefr_dateto");

            entity.HasIndex(e => new { e.EmployeeCode, e.Deleted }, "ix-user-schedule-employee_code-deleted-20230502-132904");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archived).HasColumnName("archived");
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
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmailSent).HasColumnName("email_sent");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Remarks)
                .HasMaxLength(300)
                .HasColumnName("remarks");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.UserSchedules)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_schedule_user_profile");
        });

        modelBuilder.Entity<UserScheduleDetail>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("user_schedule_detail");

            entity.HasIndex(e => e.Id, "IX-user-schedule-detail-id-20221215-095148");

            entity.HasIndex(e => new { e.WorkScheduleDate, e.EmployeeCode, e.DwsStatus }, "IX_user_schedule_detai_employee_code");

            entity.HasIndex(e => e.WorkScheduleDate, "IX_user_schedule_detail_date");

            entity.HasIndex(e => new { e.UserScheduleId, e.WorkScheduleDate }, "IX_user_schedule_detail_schedid_date");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.DwsCode)
                .HasMaxLength(10)
                .HasColumnName("dws_code");
            entity.Property(e => e.DwsStatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dws_status");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UserScheduleId).HasColumnName("user_schedule_id");
            entity.Property(e => e.WorkScheduleDate).HasColumnName("work_schedule_date");

            entity.HasOne(d => d.DwsCodeNavigation).WithMany(p => p.UserScheduleDetails)
                .HasForeignKey(d => d.DwsCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_schedule_detail_daily_work_schedule");

            entity.HasOne(d => d.UserSchedule).WithMany(p => p.UserScheduleDetails)
                .HasForeignKey(d => d.UserScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_schedule_detail_user_schedule");
        });

        modelBuilder.Entity<WeeklySchedule>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_weekly_schedule_1");

            entity.ToTable("weekly_schedule");

            entity.HasIndex(e => new { e.PersonnelAreaCode, e.Code }, "IX_weekly_schedule_[personnel_area_code][code]");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateDeleted).HasColumnName("date_deleted");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PersonnelAreaCode)
                .HasMaxLength(20)
                .HasColumnName("personnel_area_code");

            entity.HasOne(d => d.PersonnelAreaCodeNavigation).WithMany(p => p.WeeklySchedules)
                .HasForeignKey(d => d.PersonnelAreaCode)
                .HasConstraintName("FK_weekly_schedule_personnel_area");
        });

        modelBuilder.Entity<WeeklyScheduleDetail>(entity =>
        {
            entity.ToTable("weekly_schedule_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateEdited).HasColumnName("date_edited");
            entity.Property(e => e.DayName)
                .HasMaxLength(10)
                .HasColumnName("day_name");
            entity.Property(e => e.DwsCode)
                .HasMaxLength(10)
                .HasColumnName("dws_code");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.WeeklyScheduleCode)
                .HasMaxLength(20)
                .HasColumnName("weekly_schedule_code");

            entity.HasOne(d => d.DwsCodeNavigation).WithMany(p => p.WeeklyScheduleDetails)
                .HasForeignKey(d => d.DwsCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_weekly_schedule_detail_daily_work_schedule");

            entity.HasOne(d => d.WeeklyScheduleCodeNavigation).WithMany(p => p.WeeklyScheduleDetails)
                .HasForeignKey(d => d.WeeklyScheduleCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_weekly_schedule_detail_weekly_schedule");
        });

        modelBuilder.Entity<WsApproverDelegation>(entity =>
        {
            entity.ToTable("ws_approver_delegation");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.DateEmailed)
                .HasColumnType("datetime")
                .HasColumnName("date_emailed");
            entity.Property(e => e.DelegatedEmployeeCode).HasColumnName("delegated_employee_code");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.EditedBy)
                .HasMaxLength(50)
                .HasColumnName("edited_by");
            entity.Property(e => e.EmailNotif).HasColumnName("email_notif");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
