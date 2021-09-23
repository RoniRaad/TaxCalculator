using TaxCalculator.Core.Models;
using System.Threading.Tasks;
using TaxCalculator.Core.Requests;

namespace TaxCalculator.Core.Interfaces
{
    public interface ITaxCalculator
    {
        Task<decimal> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest);
        Task<decimal> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest);
    }
}