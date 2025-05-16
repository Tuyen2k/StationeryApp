using StationeryManagerLib.Dtos;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IReportServices
    {
        Task<List<ReportProductModel>> GetReportProduct(ReportFilterModel filter);
    }
}
