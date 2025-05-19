using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.Dtos
{
    public class ReportStaffModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Tổng số lượng bán
        /// </summary>
        public double QuantitySale { get; set; }

        /// <summary>
        /// Tổng doanh thu
        /// </summary>
        public double Revenue { get; set; }

        /// <summary>
        /// Tổng lợi nhuận
        /// </summary>
        public double Profit { get; set; }
    }
}
