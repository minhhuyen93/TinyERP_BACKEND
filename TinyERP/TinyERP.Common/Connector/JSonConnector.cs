using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TinyERP.Common.Data;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Connector
{
    internal class JSonConnector : IConnector
    {
        private HttpClient http;
        public JSonConnector()
        {
            this.http = new HttpClient();
        }
        public async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = this.http.GetAsync(url).Result;
            return await this.ConvertResponseToResult<T>(response);
        }

        public async Task<T> Post<T>(string url, object requestObject)
        {
            StringContent dataConvert = this.ConvertObjectToDataContent(requestObject);
            var result = this.http.PostAsync(url, dataConvert).Result;
            return await this.ConvertResponseToResult<T>(result); ;
        }
        private StringContent ConvertObjectToDataContent(object request)
        {
            string jsonObject = JsonConvert.SerializeObject(request);
            return new StringContent(jsonObject, Encoding.UTF8, "application/json");
        }
        private async Task<T> ConvertResponseToResult<T>(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ValidationException("common.genericError.requestWasNotFound");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            ResponseData<T> responseData = JsonConvert.DeserializeObject<ResponseData<T>>(result);
            if (responseData.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ValidationException(responseData.Errors);
            }
            return responseData.Data;
        }
    }
}
