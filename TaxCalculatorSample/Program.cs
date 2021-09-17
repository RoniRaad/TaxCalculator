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

                // A test location for the tax api to get info on
                var taxRateRequest = new TaxRatesForLocationRequest
                {
                    Country = "us",
                    State = "fl",
                    City = "Merritt Island",
                    Street = "Space Commerce Way",
                    ZipCode = "32953"
                };

                // A test order tax request
                var orderTaxRequest = new OrderTaxApiRequest
                {
                    FromCountry = "us",
                    FromZipCode = "90002",
                    FromCity = "La Jolla",
                    FromState = "CA",
                    FromStreet = "9500 Gilman Drive",
                    ToCity = "Los Angeles",
                    ToCountry = "US",
                    ToZipCode = "92093",
                    ToStreet = "1335 E 103rd St",
                    ToState = "CA",
                    Amount = "15",
                    Shipping = "1.5",
                    NexusAddresses = new NexusAddress[1]
                    {
                        new NexusAddress
                        {
                            Id = "Main Location",
                            Country = "US",
                            ZipCode = "92093",
                            City = "La Jolla",
                            Street = "9500 Gilman Drive"
                        }
                    },
                    LineItems = new LineItem[1]
                    {
                        new LineItem
                        {
                            Id = "1",
                            Quantity = "1",
                            ProductTaxCode = "20010",
                            UnitPrice = "15",
                            Discount = "0"
                        }
                    }
                };

                var taxRates = await taxService.GetTaxesForLocation(taxRateRequest);
                var taxRateCombinedRate = taxRates.CombinedRate;

                var orderTaxes = await taxService.GetTaxesForOrder(orderTaxRequest);
                var orderTaxAmount = orderTaxes.AmountToCollect;

                // Output the combined tax rate to the console.
                Console.Write($"The combined tax rate for the example location is {taxRateCombinedRate} and the tax for the example order is {orderTaxAmount}");
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