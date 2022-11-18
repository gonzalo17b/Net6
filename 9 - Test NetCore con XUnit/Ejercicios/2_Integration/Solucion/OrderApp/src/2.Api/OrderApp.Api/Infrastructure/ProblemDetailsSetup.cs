using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace OrderApp.Api.Infrastructure
{
    public class ProblemDetailsOptionsCustomSetup : IConfigureOptions<ProblemDetailsOptions>
    {
        public ProblemDetailsOptionsCustomSetup(
            IWebHostEnvironment environment,
            IOptions<ApiBehaviorOptions> apiOptions)
        {
            this.Environment = environment;
            this.ApiOptions = apiOptions.Value;
        }

        private IWebHostEnvironment Environment { get; }
        private ApiBehaviorOptions ApiOptions { get; }

        public void Configure(ProblemDetailsOptions options)
        {
            options.IncludeExceptionDetails = (ctx, ex) => this.Environment.IsDevelopment();

            options.MapStatusCode = this.MapStatusCode;

            options
                .ProblemDetailsMapConfiguration();
        }

        private ProblemDetails MapStatusCode(HttpContext context)
        {
            if (!this.ApiOptions.SuppressMapClientErrors &&
                 this.ApiOptions.ClientErrorMapping.TryGetValue(context.Response.StatusCode, out var errorData))
            {
                return new ProblemDetails
                {
                    Status = context.Response.StatusCode,
                    Title = errorData.Title,
                    Type = errorData.Link
                };
            }
            else
            {
                // use Hellang.Middleware.ProblemDetails mapping
                return new StatusCodeProblemDetails(context.Response.StatusCode);
            }
        }
    }
}
