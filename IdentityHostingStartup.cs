using Microsoft.AspNetCore.Hosting;
using ZarvanOrder;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace ZarvanOrder
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}