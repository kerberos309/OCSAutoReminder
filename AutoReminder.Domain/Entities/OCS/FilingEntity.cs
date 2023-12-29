using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class FilingEntity
    {
        public int Id { get; set; }

        public string? EmployeeNumber { get; set; }

        public string? TrackingNumber { get; set; }

        public string? PersonalEmail { get; set; }

        public string? ContactNumber { get; set; }

        public DateTime? DateSeparation { get; set; }

        public int? ReasonId { get; set; }

        public string? OtherReason { get; set; }

        public string? Comments { get; set; }

        public bool? IsDraft { get; set; }

        public string? Status { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsAvailRetirement { get; set; }

        public string? CreatedBy { get; set; }

        public bool? IsCreatedByOwner { get; set; }

        public string? ReasonCreated { get; set; }

        public string? StatusBeforeRetractionRequest { get; set; }

        public DateTime? DateCheckReceived { get; set; }

        public DateTime? EmployeeDateCheckReceived { get; set; }

        public DateTime? DateApproved { get; set; }

        public int? Ihreminder { get; set; }

        public int? Pareminder { get; set; }

        public int? Empbenreminder { get; set; }

        public int? FormReminder { get; set; }

        public int? R7reminder { get; set; }
    }
}
