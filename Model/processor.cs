using System.Net.Http.Headers;

namespace First_Jason_Project.Model
{
    public class processor
    {
        public static async Task<Model> LoadInformation()
        {
            string url = "https://api.kucoin.com/api/v1/market/stats?symbol=BTC-USDT";
            using (HttpResponseMessage response = await Port.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    resultdata result = await response.Content.ReadAsAsync<resultdata>();
                    return result.data;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
