using StationeryManager.Util;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services.Impl
{
    public class ReportServices : IReportServices
    {
        private readonly HttpClient _httpClient;

        public ReportServices(HttpClient httpClient) { 
            _httpClient = httpClient;
        }

        public async Task<int> CountReportProduct(ReportFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/reports/products/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var count = await result.Content.ReadFromJsonAsync<int>();
                return count;
            }
            return 0;
        }

        public async Task<int> CountReportProduct(ReportFilterModel filter, string staffId)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + $"api/reports/staff/{staffId}/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri); 
            if (result.IsSuccessStatusCode)
            {
                var count = await result.Content.ReadFromJsonAsync<int>();
                return count;
            }
            return 0;
        }

        public async Task<int> CountReportStaff(ReportFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/reports/staff/count", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var count = await result.Content.ReadFromJsonAsync<int>();
                return count;
            }
            return 0;
        }

        public async Task<List<ReportProductModel>> GetReportProduct(ReportFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
                if (filter.Limit != null)
                {
                    parameters.Add("limit", filter.Limit.ToString());
                }
                if (filter.Page != null)
                {
                    parameters.Add("page", filter.Page.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/reports/products", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var products = await result.Content.ReadFromJsonAsync<List<ReportProductModel>>();
                return products ?? [];
            }
            return [];
        }

        public async Task<List<ReportProductModel>> GetReportProduct(ReportFilterModel filter, string staffId)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
                if (filter.Limit != null)
                {
                    parameters.Add("limit", filter.Limit.ToString());
                }
                if (filter.Page != null)
                {
                    parameters.Add("page", filter.Page.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + $"api/reports/staff/{staffId}", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var products = await result.Content.ReadFromJsonAsync<List<ReportProductModel>>();
                return products ?? [];
            }
            return [];
        }

        public async Task<List<ReportStaffModel>> GetReportStaff(ReportFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }

                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
                if (filter.Limit != null)
                {
                    parameters.Add("limit", filter.Limit.ToString());
                }
                if (filter.Page != null)
                {
                    parameters.Add("page", filter.Page.ToString());
                }
            }

            var uriBuilder = await UriHelperUtil.BuildUriAsync(_httpClient.BaseAddress + "api/reports/staff", parameters);

            var result = await _httpClient.GetAsync(uriBuilder.Uri);
            if (result.IsSuccessStatusCode)
            {
                var accounts = await result.Content.ReadFromJsonAsync<List<ReportStaffModel>>();
                return accounts ?? [];
            }
            return [];
        }


        /// <summary>
        /// Get parameters for URI ------------- dùng cách này để render parameter cho uri
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private Dictionary<string, string?> GetParameterForUri(ReportFilterModel filter)
        {
            var parameters = new Dictionary<string, string?>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    parameters.Add("name", filter.Name);
                }
                if (filter.FromTime != null)
                {
                    parameters.Add("fromTime", filter.FromTime.ToString());
                }
                if (filter.ToTime != null)
                {
                    parameters.Add("toTime", filter.ToTime.ToString());
                }
            }
            return parameters;
        }
    }
}
