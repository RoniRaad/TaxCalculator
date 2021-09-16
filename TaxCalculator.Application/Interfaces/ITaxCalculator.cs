using TaxCalculator.Application.Models;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Interfaces
{
    public interface ITaxCalculator
    {
        Task<TaxRate> GetTaxesForLocation(TaxRatesForLocationRequest taxRatesForLocationRequest);
        Task<Tax> GetTaxesForOrder(OrderTaxApiRequest orderTaxApiRequest);
    }
}