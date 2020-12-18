using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebUIBlazor.Services.Abstract;

namespace WebUIBlazor.Helpers
{
    public class BackendHandler : HttpClientHandler
    {
        [Inject]
        private IAuthenticationService _userService { get; set; }      
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var path = request.RequestUri.AbsolutePath;
            var method = request.Method;
            if (path == "/users/authenticate" && method == HttpMethod.Post)
            {
                return await ok(_userService.User+"");
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
            async Task<HttpResponseMessage> ok(object body)
            {
                return await jsonResponse(HttpStatusCode.OK, body);
            }
            async Task<HttpResponseMessage> jsonResponse(HttpStatusCode statusCode, object content)
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(_userService.User + "")
                };

                // delay to simulate real api call
                await Task.Delay(500);

                return response;
            }

          
        }
    }
}
