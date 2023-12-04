using Newtonsoft.Json;
using RequestSpammer.Models.Dtos;
using System.Net;
using System.Text.Json.Serialization;

namespace RequestSpammer
{
    public class RequestSpammerLogic : IRequestSpammerLogic
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RequestSpammerLogic(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public ProcessResponseDto SendRequest()
        {
            var httpClient = httpClientFactory.CreateClient();
            string url = "https://localhost:5000/api/Processor/Process"; //http://localhost:8080/api/Processor/Process this one is for tyk
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    
                    ProcessRequestDto processRequestDto = new ProcessRequestDto()
                    {
                        RequestSent = DateTime.Now
                    };
                    string json = JsonConvert.SerializeObject(processRequestDto);


                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ProcessResponseDto response = JsonConvert.DeserializeObject<ProcessResponseDto>(result);
                    return response;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Something went wrong: {e.Message}");
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
