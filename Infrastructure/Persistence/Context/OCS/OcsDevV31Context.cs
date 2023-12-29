using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context.OCS;

public partial class OcsDevV31Context : DbContext
{
    //private readonly IConfiguration _configuration;
    public OcsDevV31Context()
    {
        //_configuration = new ConfigurationBuilder()
        //    .AddUserSecrets("fc917c02-0293-4f3b-8dd7-971a40e52ece", true)
        //    .Build();
    }

    public OcsDevV31Context(DbContextOptions<OcsDevV31Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<AuditTrail> AuditTrails { get; set; }

    public virtual DbSet<ClearanceAccountabilitiesEmail> ClearanceAccountabilitiesEmails { get; set; }

    public virtual DbSet<ClearanceAccountabilitiesPerBu> ClearanceAccountabilitiesPerBus { get; set; }

    public virtual DbSet<ClearanceAccountability> ClearanceAccountabilities { get; set; }

    public virtual DbSet<ClearanceAttachment> ClearanceAttachments { get; set; }

    public virtual DbSet<ClearanceFormStatus> ClearanceFormStatuses { get; set; }

    public virtual DbSet<ClearanceFormSubstatus> ClearanceFormSubstatuses { get; set; }

    public virtual DbSet<ClearanceHeader> ClearanceHeaders { get; set; }

    public virtual DbSet<ClearanceHold> ClearanceHolds { get; set; }

    public virtual DbSet<ClearanceTrail> ClearanceTrails { get; set; }

    public virtual DbSet<ClearanceValue> ClearanceValues { get; set; }

    public virtual DbSet<DebuggerLog> DebuggerLogs { get; set; }

    public virtual DbSet<EmailNotification> EmailNotifications { get; set; }

    public virtual DbSet<Filing> Filings { get; set; }

    public virtual DbSet<MaintenanceBuAssignment> MaintenanceBuAssignments { get; set; }

    public virtual DbSet<MaintenanceDelegation> MaintenanceDelegations { get; set; }

    public virtual DbSet<MaintenanceEmploymentStatus> MaintenanceEmploymentStatuses { get; set; }

    public virtual DbSet<MaintenanceNotificationSetting> MaintenanceNotificationSettings { get; set; }

    public virtual DbSet<MaintenancePosition> MaintenancePositions { get; set; }

    public virtual DbSet<MaintenanceReason> MaintenanceReasons { get; set; }

    public virtual DbSet<MaintenanceResignationStatus> MaintenanceResignationStatuses { get; set; }

    public virtual DbSet<MatrixAccess> MatrixAccesses { get; set; }

    public virtual DbSet<MatrixEmployeeAccess> MatrixEmployeeAccesses { get; set; }

    public virtual DbSet<MatrixEntity> MatrixEntities { get; set; }

    public virtual DbSet<MatrixForm> MatrixForms { get; set; }

    public virtual DbSet<MatrixFormApproval> MatrixFormApprovals { get; set; }

    public virtual DbSet<MatrixHeader> MatrixHeaders { get; set; }

    public virtual DbSet<MatrixSetup> MatrixSetups { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<SystemLog> SystemLogs { get; set; }

    public virtual DbSet<UploadFile> UploadFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["OCS"].ToString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.ToTable("announcement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnnouncementContent)
                .HasColumnType("text")
                .HasColumnName("announcement_content");
            entity.Property(e => e.BannerPath)
                .HasMaxLength(250)
                .HasColumnName("banner_path");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsPosted).HasColumnName("is_posted");
            entity.Property(e => e.IsPreview).HasColumnName("is_preview");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblAuditTrail");

            entity.ToTable("audit_trail");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.EmployeeNumber).HasMaxLength(50);
            entity.Property(e => e.LoginName).HasMaxLength(500);
        });

        modelBuilder.Entity<ClearanceAccountabilitiesEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_clearance_emails");

            entity.ToTable("clearance_accountabilities_emails");

            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.BuId).HasColumnName("bu_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<ClearanceAccountabilitiesPerBu>(entity =>
        {
            entity.ToTable("clearance_accountabilities_per_bu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccNo).HasColumnName("acc_no");
            entity.Property(e => e.BusinessUnitId).HasColumnName("business_unit_id");
            entity.Property(e => e.ClearanceAccountabilitiesId).HasColumnName("clearance_accountabilities_id");
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
            entity.Property(e => e.FormId).HasColumnName("form_id");

            entity.HasOne(d => d.ClearanceAccountabilities).WithMany(p => p.ClearanceAccountabilitiesPerBus)
                .HasForeignKey(d => d.ClearanceAccountabilitiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clearance_accountabilities_clearance_accountabilities_per_table");
        });

        modelBuilder.Entity<ClearanceAccountability>(entity =>
        {
            entity.ToTable("clearance_accountabilities");

            entity.Property(e => e.AccName)
                .IsUnicode(false)
                .HasColumnName("acc_name");
            entity.Property(e => e.AccNo).HasColumnName("acc_no");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FormId).HasColumnName("form_id");
        });

        modelBuilder.Entity<ClearanceAttachment>(entity =>
        {
            entity.ToTable("clearance_attachment");

            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.PkId).HasColumnName("pk_Id");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<ClearanceFormStatus>(entity =>
        {
            entity.ToTable("clearance_form_status");

            entity.HasIndex(e => new { e.FormStatus, e.FormId, e.EmployeeNumber, e.TrackingNumber }, "IX_clearance_form_status-20231215-173329");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                .HasColumnName("approved_by");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.AutoApproveCount).HasColumnName("auto_approve_count");
            entity.Property(e => e.AutoApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("auto_approve_date");
            entity.Property(e => e.BuValue).HasColumnName("bu_value");
            entity.Property(e => e.DepartmentValue)
                .HasMaxLength(50)
                .HasColumnName("department_value");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.EnableForward).HasColumnName("enable_forward");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.FormStatus)
                .HasMaxLength(50)
                .HasColumnName("form_status");
            entity.Property(e => e.ForwardBy)
                .HasMaxLength(50)
                .HasColumnName("forward_by");
            entity.Property(e => e.ForwardDate)
                .HasColumnType("datetime")
                .HasColumnName("forward_date");
            entity.Property(e => e.ForwardTo)
                .HasMaxLength(50)
                .HasColumnName("forward_to");
            entity.Property(e => e.IsAutoApprove).HasColumnName("is_auto_approve");
            entity.Property(e => e.JoblevelValue).HasColumnName("joblevel_value");
            entity.Property(e => e.LeadTimeCount).HasColumnName("lead_time_count");
            entity.Property(e => e.LeadTimeDate)
                .HasColumnType("datetime")
                .HasColumnName("lead_time_date");
            entity.Property(e => e.PositionValue).HasColumnName("position_value");
            entity.Property(e => e.Reminder).HasColumnName("reminder");
            entity.Property(e => e.RevertDate)
                .HasColumnType("datetime")
                .HasColumnName("revert_date");
            entity.Property(e => e.RevertReason)
                .HasMaxLength(4000)
                .HasColumnName("revert_reason");
            entity.Property(e => e.StatusValue).HasColumnName("status_value");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<ClearanceFormSubstatus>(entity =>
        {
            entity.ToTable("clearance_form_substatus");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                .HasColumnName("approved_by");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.DepartmentValue)
                .HasMaxLength(50)
                .HasColumnName("department_value");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.FormStatus)
                .HasMaxLength(10)
                .HasColumnName("form_status");
            entity.Property(e => e.ForwardBy)
                .HasMaxLength(50)
                .HasColumnName("forward_by");
            entity.Property(e => e.ForwardDate)
                .HasColumnType("datetime")
                .HasColumnName("forward_date");
            entity.Property(e => e.ForwardTo)
                .HasMaxLength(50)
                .HasColumnName("forward_to");
            entity.Property(e => e.HoldBy)
                .HasMaxLength(50)
                .HasColumnName("hold_by");
            entity.Property(e => e.HoldDate)
                .HasColumnType("datetime")
                .HasColumnName("hold_date");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<ClearanceHeader>(entity =>
        {
            entity.ToTable("clearance_header");

            entity.Property(e => e.ClearanceStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("clearance_status");
            entity.Property(e => e.DateCompleted)
                .HasColumnType("datetime")
                .HasColumnName("date_completed");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEmail)
                .HasColumnType("datetime")
                .HasColumnName("date_email");
            entity.Property(e => e.DateReceived)
                .HasColumnType("datetime")
                .HasColumnName("date_received");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FaFlagging).HasColumnName("fa_flagging");
            entity.Property(e => e.LastWorkDay)
                .HasColumnType("datetime")
                .HasColumnName("last_work_day");
            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
            entity.Property(e => e.PkId).HasColumnName("pk_Id");
            entity.Property(e => e.ReleasedBy)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("released_by");
            entity.Property(e => e.ResignationEffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("resignation_effective_date");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<ClearanceHold>(entity =>
        {
            entity.ToTable("clearance_hold");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClearanceStatus)
                .HasMaxLength(50)
                .HasColumnName("clearance_status");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.HoldBy)
                .HasMaxLength(10)
                .HasColumnName("hold_by");
            entity.Property(e => e.HoldDate)
                .HasColumnType("datetime")
                .HasColumnName("hold_date");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
            entity.Property(e => e.UnholdBy)
                .HasMaxLength(10)
                .HasColumnName("unhold_by");
            entity.Property(e => e.UnholdDate)
                .HasColumnType("datetime")
                .HasColumnName("unhold_date");
        });

        modelBuilder.Entity<ClearanceTrail>(entity =>
        {
            entity.ToTable("clearance_trail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClearanceStatus)
                .HasMaxLength(50)
                .HasColumnName("clearance_status");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<ClearanceValue>(entity =>
        {
            entity.ToTable("clearance_value");

            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.Deactivated).HasColumnName("deactivated");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.ForAddition)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("for_addition");
            entity.Property(e => e.ForDeduction)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("for_deduction");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.NotApplicable).HasColumnName("not_applicable");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.PasswordReset).HasColumnName("password_reset");
            entity.Property(e => e.RemainingBalance).HasColumnName("remaining_balance");
            entity.Property(e => e.Remarks)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
            entity.Property(e => e.TurnOver).HasColumnName("turn_over");
        });

        modelBuilder.Entity<DebuggerLog>(entity =>
        {
            entity.ToTable("debugger_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.FromAction)
                .HasMaxLength(50)
                .HasColumnName("from_action");
            entity.Property(e => e.FromClass)
                .HasMaxLength(50)
                .HasColumnName("from_class");
            entity.Property(e => e.Message).HasColumnName("message");
        });

        modelBuilder.Entity<EmailNotification>(entity =>
        {
            entity.ToTable("email_notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.EmailData)
                .HasMaxLength(1000)
                .HasColumnName("email_data");
            entity.Property(e => e.EmailFrom)
                .HasMaxLength(100)
                .HasColumnName("email_from");
            entity.Property(e => e.EmailSubject)
                .HasMaxLength(1000)
                .HasColumnName("email_subject");
            entity.Property(e => e.EmailTemplate)
                .HasMaxLength(1000)
                .HasColumnName("email_template");
            entity.Property(e => e.EmailTo)
                .HasMaxLength(1000)
                .HasColumnName("email_to");
            entity.Property(e => e.IsSent).HasColumnName("is_sent");
        });

        modelBuilder.Entity<Filing>(entity =>
        {
            entity.ToTable("filing");

            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateApproved).HasColumnType("datetime");
            entity.Property(e => e.DateCheckReceived).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateSeparation).HasColumnType("datetime");
            entity.Property(e => e.Empbenreminder).HasColumnName("EMPBENReminder");
            entity.Property(e => e.EmployeeDateCheckReceived).HasColumnType("datetime");
            entity.Property(e => e.EmployeeNumber).HasMaxLength(50);
            entity.Property(e => e.Ihreminder).HasColumnName("IHReminder");
            entity.Property(e => e.OtherReason).IsUnicode(false);
            entity.Property(e => e.Pareminder).HasColumnName("PAReminder");
            entity.Property(e => e.PersonalEmail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.R7reminder).HasColumnName("R7Reminder");
            entity.Property(e => e.ReasonCreated).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatusBeforeRetractionRequest)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaintenanceBuAssignment>(entity =>
        {
            entity.ToTable("maintenance_bu_assignment");

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
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .HasColumnName("deleted_by");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<MaintenanceDelegation>(entity =>
        {
            entity.ToTable("maintenance_delegation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BuId).HasColumnName("bu_id");
            entity.Property(e => e.DateDelegated)
                .HasColumnType("datetime")
                .HasColumnName("date_delegated");
            entity.Property(e => e.DelegatedBy)
                .HasMaxLength(50)
                .HasColumnName("delegated_by");
            entity.Property(e => e.DelegatedTo)
                .HasMaxLength(50)
                .HasColumnName("delegated_to");
            entity.Property(e => e.DelegatedUntil)
                .HasColumnType("datetime")
                .HasColumnName("delegated_until");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<MaintenanceEmploymentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_employement_status");

            entity.ToTable("maintenance_employment_status");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.EmploymentStatus)
                .HasMaxLength(50)
                .HasColumnName("employment_status");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(50)
                .HasColumnName("status_code");
        });

        modelBuilder.Entity<MaintenanceNotificationSetting>(entity =>
        {
            entity.ToTable("maintenance_notification_settings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaintenancePosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_position");

            entity.ToTable("maintenance_position");

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
        });

        modelBuilder.Entity<MaintenanceReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblReason");

            entity.ToTable("maintenance_reason");

            entity.Property(e => e.FldDateCreated)
                .HasColumnType("datetime")
                .HasColumnName("fldDateCreated");
            entity.Property(e => e.FldIsActive).HasColumnName("fldIsActive");
            entity.Property(e => e.FldIsDeleted).HasColumnName("fldIsDeleted");
            entity.Property(e => e.FldIsOthers).HasColumnName("fldIsOthers");
            entity.Property(e => e.FldReason)
                .IsUnicode(false)
                .HasColumnName("fldReason");
        });

        modelBuilder.Entity<MaintenanceResignationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_resignation_status");

            entity.ToTable("maintenance_resignation_status");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MatrixAccess>(entity =>
        {
            entity.ToTable("matrix_access");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutoApproval).HasColumnName("auto_approval");
            entity.Property(e => e.AutoApprove).HasColumnName("auto_approve");
            entity.Property(e => e.AutoNotification).HasColumnName("auto_notification");
            entity.Property(e => e.AutoRelease).HasColumnName("auto_release");
            entity.Property(e => e.AutoReleasedLeadTime).HasColumnName("auto_released_lead_time");
            entity.Property(e => e.EmailOption).HasColumnName("email_option");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.IdName)
                .HasMaxLength(150)
                .HasColumnName("id_name");
            entity.Property(e => e.IdValue).HasColumnName("id_value");
            entity.Property(e => e.InOrder)
                .HasDefaultValue(0)
                .HasColumnName("in_order");
            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
            entity.Property(e => e.ProcessingLeadTime).HasColumnName("processing_lead_time");
            entity.Property(e => e.ReminderLeadTime).HasColumnName("reminder_lead_time");
        });

        modelBuilder.Entity<MatrixEmployeeAccess>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("matrix_employee_access");

            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(150)
                .HasColumnName("employee_number");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
        });

        modelBuilder.Entity<MatrixEntity>(entity =>
        {
            entity.HasKey(e => e.EntityId).HasName("PK_maxtrix_entity");

            entity.ToTable("matrix_entity");

            entity.Property(e => e.EntityId).HasColumnName("entity_Id");
            entity.Property(e => e.EntityCategory)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("entity_Category");
            entity.Property(e => e.EntityConfig).HasColumnName("entity_Config");
            entity.Property(e => e.EntityDesc)
                .HasColumnType("text")
                .HasColumnName("entity_Desc");
            entity.Property(e => e.EntityName)
                .HasMaxLength(1000)
                .HasColumnName("entity_Name");
        });

        modelBuilder.Entity<MatrixForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("matrix_form");

            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FormVersion).HasColumnName("form_version");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
        });

        modelBuilder.Entity<MatrixFormApproval>(entity =>
        {
            entity.HasKey(e => e.ApprovalId);

            entity.ToTable("matrix_form_approval");

            entity.Property(e => e.ApprovalId).HasColumnName("approval_id");
            entity.Property(e => e.ApprovalLevel).HasColumnName("approval_level");
            entity.Property(e => e.DepartmentValue)
                .HasMaxLength(50)
                .HasColumnName("department_value");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.InOrder)
                .HasDefaultValue(0)
                .HasColumnName("in_order");
            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
        });

        modelBuilder.Entity<MatrixHeader>(entity =>
        {
            entity.HasKey(e => e.MatrixId).HasName("PK_matrix_header_1");

            entity.ToTable("matrix_header");

            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
            entity.Property(e => e.ActivationDate)
                .HasColumnType("datetime")
                .HasColumnName("activation_date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasColumnName("created_by");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.EffectivityFrom)
                .HasColumnType("datetime")
                .HasColumnName("effectivity_from");
            entity.Property(e => e.EffectivityTo)
                .HasColumnType("datetime")
                .HasColumnName("effectivity_to");
            entity.Property(e => e.FormVersion).HasColumnName("form_version");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastEditedBy)
                .HasMaxLength(150)
                .HasColumnName("last_edited_by");
            entity.Property(e => e.LastEditedDate)
                .HasColumnType("datetime")
                .HasColumnName("last_edited_date");
            entity.Property(e => e.PkId).HasColumnName("pk_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .HasColumnName("status");
        });

        modelBuilder.Entity<MatrixSetup>(entity =>
        {
            entity.ToTable("matrix_setup");

            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.MatrixId).HasColumnName("matrix_id");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("notification");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.EmailRecipient)
                .HasMaxLength(50)
                .HasColumnName("email_recipient");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .HasColumnName("employee_number");
            entity.Property(e => e.IsNew).HasColumnName("is_new");
            entity.Property(e => e.Module)
                .HasMaxLength(50)
                .HasColumnName("module");
            entity.Property(e => e.Recipient)
                .HasMaxLength(50)
                .HasColumnName("recipient");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.Requestor)
                .HasMaxLength(50)
                .HasColumnName("requestor");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .HasColumnName("tracking_number");
        });

        modelBuilder.Entity<SystemLog>(entity =>
        {
            entity.ToTable("system_logs");

            entity.Property(e => e.Data).IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InnerException).IsUnicode(false);
            entity.Property(e => e.LoggedUsername)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.Method).IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StackTrace).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<UploadFile>(entity =>
        {
            entity.ToTable("upload_files");

            entity.Property(e => e.AttachPkId).HasColumnName("Attach_PkId");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.EmployeeNumber).HasMaxLength(50);
            entity.Property(e => e.FileName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Module)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
