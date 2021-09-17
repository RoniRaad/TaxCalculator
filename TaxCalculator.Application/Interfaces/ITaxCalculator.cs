using TaxCalculator.Application.Models;
using System.Threading.Tasks;
using TaxCalculator.Application.Requests;

namespace TaxCalculator.Application.Interfaces
{
    public interface ITaxCalculator
    {
        Task<decimal> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest);
        Task<decimal> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest);
    }
}