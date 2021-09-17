using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Requests;

namespace TaxCalculator.Application
{
    public class TaxService
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public async Task<decimal> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest)
        {
            return await _taxCalculator.GetTaxesForOrder(orderTaxApiRequest);
        }

        public async Task<decimal> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest)
        {
            return await _taxCalculator.GetTaxesForLocation(taxRatesForLocationRequest); 
        }
    }
}
