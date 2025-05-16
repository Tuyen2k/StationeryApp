using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.Model
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Thời gian khởi tạo
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedByAccountId { get; set; }
        public string? CreatedByAccountName { get; set; }
        public string? CreatedByAccountEmail { get; set; }


        /// <summary>
        /// Thời gian cập nhật
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedByAccountId { get; set; }
        public string? UpdatedByAccountName { get; set; }
        public string? UpdatedByAccountEmail { get; set; }

        /// <summary>
        /// Thời gian xóa
        /// </summary>
        public DateTime? DeletedAt { get; set; }
        public string? DeletedByAccountId { get; set; }
        public string? DeletedByAccountName { get; set; }
        public string? DeletedByAccountEmail { get; set; }

        /// <summary>
        /// Trạng thái xóa
        /// </summary>
        public bool IsDeleted { get; set; }

        
       

    }
}
