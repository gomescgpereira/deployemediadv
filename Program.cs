using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace devmedia
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
           // var config = new ConfigurationBuilder().AddCommandLine(args).Build(); 
            CreateWebHostBuilder(args).Build().Run();
        }
 
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build())
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
