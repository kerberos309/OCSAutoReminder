using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OCS
{
    public class AnnouncementEntity
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? BannerPath { get; set; }
        public string? AnnouncementContent { get; set; }
        public bool IsPreview { get; set; }
        public bool IsActive { get; set; }
        public bool IsPosted { get; set; }
    }
}
