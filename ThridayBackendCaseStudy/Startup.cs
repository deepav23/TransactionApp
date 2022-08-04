using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThridayDatabase;

[assembly: FunctionsStartup(typeof(ThridayBackendCaseStudy.Startup))]
namespace ThridayBackendCaseStudy
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IDBAccess>((s) => {
                return new DBAccess();
            });
        }
    }
}
