using PriceCalculator;

namespace PriceCalculatorTests;

public class PricingCalculatorTests
{
    [Theory]
    [InlineData(1, 1, 1, "2.95")]
    [InlineData(2, 3, 4, "9.05")]
    public void ShouldCalculateBasketTotalNoDiscountsApplicable(int quantity1, int quantity2, int quantity3, string expectedTotal)
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", quantity1, 0.8m));
        basket.Items.Add(new BasketProduct("milk", "Milk", quantity2, 1.15m));
        basket.Items.Add(new BasketProduct("bread", "Bread", quantity3, 1.0m));
        
        var totalCost = basket.CalculateTotal();

        //had to do this because inlinedata would throw error otherwise [CS0182] 
        Assert.Equal(decimal.Parse(expectedTotal), totalCost);
    }
    
    [Fact]
    public void ShouldCalculateBasketTotal_Bread_50Percent_Discounted_For2Butters()
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", 2, 0.8m));
        basket.Items.Add(new BasketProduct("bread", "Bread", 2, 1.0m));
        
        var totalCost = basket.CalculateTotal();
        Assert.Equal(3.10m, totalCost);
    }
}