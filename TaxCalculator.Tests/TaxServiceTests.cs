using Moq;
using System;
using System.Threading.Tasks;
using TaxCalculator.Application;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Models;
using TaxCalculator.Application.Requests;
using TaxCalculator.Infrastructure.Models;
using Xunit;

namespace TaxCalculator.Tests
{
    public class TaxServiceTests
    {
        private readonly TaxService _sut;
        private readonly Mock<ITaxCalculator> _taxCalculatorMock = new Mock<ITaxCalculator>();

        public TaxServiceTests()
        {
            _sut = new TaxService(_taxCalculatorMock.Object);
        }

        [Fact]
        public async void GetTaxesForLocation_ShouldRetunDecimal_WhenLocationExists()
        {
            // Arange
            var taxRateRequest = new TaxRatesForLocationRequest
            {
                Country = "us",
                State = "fl",
                City = "Merritt Island",
                Street = "Space Commerce Way",
                ZipCode = "32953"
            };

            _taxCalculatorMock.Setup(x => x.GetTaxesForLocation(taxRateRequest))
                .Returns(Task.FromResult(1.25M));

            // Act
            var result = await _sut.GetTaxesForLocation(taxRateRequest);

            // Assert
            Assert.Equal<decimal>(1.25M, result);
        }

        [Fact]
        public async void GetTaxesForOrder_ShouldRetunDecimal_WhenOrderIsValid()
        {
            // Arange
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

            _taxCalculatorMock.Setup(x => x.GetTaxesForOrder(orderTaxRequest))
                .Returns(Task.FromResult(1.25M));

            // Act
            var result = await _sut.GetTaxesForOrder(orderTaxRequest);

            // Assert
            Assert.Equal<decimal>(1.25M, result);
        }

    }
}
