using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ServerSite.Areas.Identity.IdentityHostingStartup))]
namespace ServerSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}