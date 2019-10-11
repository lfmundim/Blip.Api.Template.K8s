using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Blip.Api.Template
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    #pragma warning disable RCS1102 // Make class static.
    public class Program
    #pragma warning restore RCS1102 // Make class static.
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
