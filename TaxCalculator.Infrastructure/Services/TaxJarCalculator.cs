﻿using TaxCalculator.Application.Extensions;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Application.Models.ApiResponses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaxCalculator.Infrastructure.Services
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private readonly HttpClient _httpClient;
        private readonly TaxApiSettings _settings;
        private readonly ILogger<TaxJarCalculator> _logger;
        public TaxJarCalculator(ILogger<TaxJarCalculator> logger, HttpClient httpClient, IOptions<TaxApiSettings> settings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = settings.Value;

            if (string.IsNullOrEmpty(_settings?.Key))
            {
                throw new Exception("Error: Tax calculator settings is missing its API Key.");
            }

            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", _settings.Key);


        }
        public async Task<Tax> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest)
        {
            try
            {
                _logger.LogInformation($"Attempting to get taxes for order to {orderTaxApiRequest.ToCity}");

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.IgnoreNullValues = true;

                var json = JsonSerializer.Serialize(orderTaxApiRequest, options);
                var jsonToSend = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");
                
                HttpResponseMessage response = await _httpClient.PostAsync($"{_settings.Url}/v2/taxes", jsonToSend);
                response.EnsureSuccessStatusCode();

                _logger.LogInformation($"Successfully got taxes for order to {orderTaxApiRequest.ToCity}!");

                string responseBody = await response.Content.ReadAsStringAsync();
                var taxData = JsonSerializer.Deserialize<OrderTaxApiResponse>(responseBody);

                return taxData.Tax;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("\nAn error occured");
                _logger.LogError(e.Message);
                _logger.LogError(e.InnerException.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task<TaxRate> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest)
        {
            try
            {
                _logger.LogInformation($"Attempting to get tax information for location in zipcode {taxRatesForLocationRequest.ZipCode} and state {taxRatesForLocationRequest.State}");

                HttpResponseMessage response = await _httpClient.GetAsync($"{_settings.Url}/v2/rates/?{taxRatesForLocationRequest.ObjToGetString()}");
                response.EnsureSuccessStatusCode();
                _logger.LogInformation($"Successfully got tax information for location in zipcode {taxRatesForLocationRequest.ZipCode} and state {taxRatesForLocationRequest.State}");


                string responseBody = await response.Content.ReadAsStringAsync();
                var taxData = JsonSerializer.Deserialize<TaxRatesForLocationResponse>(responseBody);

                return taxData.TaxRate;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError("\nAn error occured");
                _logger.LogError(e.Message);
                _logger.LogError(e.InnerException.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}
