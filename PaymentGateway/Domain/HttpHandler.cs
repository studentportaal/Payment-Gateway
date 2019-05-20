using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Domain
{
    public class HttpHandler : PageModel
    {
        private HttpClient client = new HttpClient();

        public async Task SetTopOfTheDay(object content, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:9000/joboffer/topofday");
            //var json = JsonConvert.SerializeObject(content);
            var stringcontent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            request.Content = stringcontent;
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        }
    }
}
