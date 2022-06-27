using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Canki.Web.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
#if DEBUG
                            .UseIISIntegration()
#endif
                    .UseUrls("http://localhost:4000")
                    .UseStartup<Startup>()
                    .Build();
                host.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
