using System.Net;

namespace RequestSpammer
{
    public class RequestSpammerLogic : IRequestSpammerLogic
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RequestSpammerLogic(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public string SendRequest()
        {
            var httpClient = httpClientFactory.CreateClient();
            string url = "https://localhost:5000/api/Processor/Process";
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(DateTime.Now);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
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
