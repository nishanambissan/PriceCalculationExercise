using PriceCalculator;

namespace PriceCalculatorTests;

public class PricingCalculatorTests
{
    [Fact]
    public void ShouldCalculateBasketTotalNoDiscountsApplicable()
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", 1, 0.8m));
        basket.Items.Add(new BasketProduct("milk", "Milk", 1, 1.15m));
        basket.Items.Add(new BasketProduct("bread", "Bread", 1, 1.0m));
        
        var totalCost = basket.CalculateTotal();
        Assert.Equal(2.95m, totalCost);
    }
}