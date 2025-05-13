using System.Net.Http;

namespace StationeryManager.Util
{
    public static class UriHelperUtil
    {
        public static async Task<UriBuilder> BuildUriAsync(string basePath, Dictionary<string, string?> parameters)
        {
            var uriBuilder = new UriBuilder(basePath);
            if(parameters != null && parameters.Count > 0)
            {
                var query = new FormUrlEncodedContent(parameters);
                uriBuilder.Query = await query.ReadAsStringAsync();
            }

            return uriBuilder;
        }
    }
}
