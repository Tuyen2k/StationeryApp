using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.Dtos
{
    public class ReportProductModel
    {
        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Sku { get; set; } = string.Empty;  
        public string? ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// số lượng
        /// </summary>
        public double QuantityImport { get; set; } = 0;
        public double QuantityExport { get; set; } = 0;

        /// <summary>
        /// Tổng tiền đã nhập
        /// </summary>
        public double TotalImport { get; set; } = 0;

        /// <summary>
        /// Tổng tiền đã xuất - Doanh thu = số lượng xuất * giá bán
        /// </summary>
        public double TotalExport { get; set; } = 0;

        /// <summary>
        /// Tổng lợi nhuận = (Giá bán [Lấy trong phiếu xuất] - Giá nhập [Lấy sản phẩm]) * Số lượng xuất
        /// </summary>
        public double Profit { get; set; } = 0;
    }
}
