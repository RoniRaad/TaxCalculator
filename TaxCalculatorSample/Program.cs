using TaxCalculator.Application;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace TaxCalculatorSample
{
    class Program
    {
        private static IHost _host;
        public async static Task Main(string[] args)
        {
            using (_host = CreateHostBuilder(args).Build())
            {
                _host.Start();
                TaxService taxService = _host.Services.GetRequiredService<TaxService>();
                var request = new TaxRatesForLocationRequest
                {
                    Country = "us",
                    State = "fl",
                    City = "Merritt Island",
                    Street = "Space Commerce Way",
                    ZipCode = "32953"
                };
                var taxRates = await taxService.GetTaxesForLocation(request);
                var cityRate = taxRates.CityRate;

                Console.Write(cityRate);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<TaxService>();
                services.AddTransient<ITaxCalculator, TaxJarCalculator>();
                services.AddLogging();
                services.AddHttpClient();
                services.Configure<TaxApiSettings>(context.Configuration.GetSection("TaxApi"));
            });

    }
}