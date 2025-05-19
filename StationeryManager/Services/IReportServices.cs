using StationeryManagerLib.Dtos;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IReportServices
    {
        /// <summary>
        /// Get report product
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<ReportProductModel>> GetReportProduct(ReportFilterModel filter);

        /// <summary>
        /// Count report product
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> CountReportProduct(ReportFilterModel filter);

        /// <summary>
        /// Get report product by staffId
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="staffId"></param>
        /// <returns></returns>
        Task<List<ReportProductModel>> GetReportProduct(ReportFilterModel filter, string staffId);

        /// <summary>
        /// Count report product by staffId
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="staffId"></param>
        /// <returns></returns>
        Task<int> CountReportProduct(ReportFilterModel filter, string staffId);

        Task<List<ReportStaffModel>> GetReportStaff(ReportFilterModel filter);
        Task<int> CountReportStaff(ReportFilterModel filter);
    }
}
