using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Api.Infrastructure
{
    public static class ProblemDetailsConfiguration
    {
        public static ProblemDetailsOptions ProblemDetailsMapConfiguration(this ProblemDetailsOptions config)
        {
            config.Map<NotFoundException>((context, ex) =>
                new ProblemDetails
                {
                    Title = "Not Found Entity",
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message
                }
            );

            config.Map<CustomerConfigurationException>((context, ex) =>
                new ProblemDetails
                {
                    Title = "Customer Wrong Configuration",
                    Status = StatusCodes.Status412PreconditionFailed,
                    Detail = ex.Message
                }
            );

            return config;
        }
    }
}
