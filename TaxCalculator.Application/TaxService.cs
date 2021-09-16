using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Application
{
    public class TaxService
    {
        private readonly ILogger<TaxService> _logger;
        private readonly ITaxCalculator _taxCalculator;
        public TaxService(ILogger<TaxService> logger, ITaxCalculator taxCalculator)
        {
            logger = _logger;
            _taxCalculator = taxCalculator;
        }
        public async Task<Tax> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest)
        {
            return await _taxCalculator.GetTaxesForOrder(orderTaxApiRequest);
        }

        public async Task<TaxRate> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest)
        {
            return await _taxCalculator.GetTaxesForLocation(taxRatesForLocationRequest); 
        }
    }
}
