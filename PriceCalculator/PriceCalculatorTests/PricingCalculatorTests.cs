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
        basket.Items.Add(new BasketProduct("butter", "Butter", (quantity1, 0.8m)));
        basket.Items.Add(new BasketProduct("milk", "Milk", (quantity2, 1.15m)));
        basket.Items.Add(new BasketProduct("bread", "Bread", (quantity3, 1.0m)));
        
        var totalCost = basket.CalculateTotal();

        //had to do this because inline data would throw error otherwise [CS0182] 
        Assert.Equal(decimal.Parse(expectedTotal), totalCost);
    }
    
    [Theory]
    [InlineData(2, 0, 2, "3.10")]
    [InlineData(6, 0, 1, "5.30")]
    [InlineData(4, 0, 2, "4.20")]
    public void ShouldCalculateBasketTotal_Apply_Discount(int quantity1, int quantity2, int quantity3, string expectedTotal)
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", (quantity1, 0.8m)));
        basket.Items.Add(new BasketProduct("milk", "Milk", (quantity2, 1.15m)));
        basket.Items.Add(new BasketProduct("bread", "Bread", (quantity3, 1.0m)));
        
        var totalCost = basket.CalculateTotal();
        Assert.Equal(decimal.Parse(expectedTotal), totalCost);
    }
    
    [Theory]
    [InlineData(0, 4, 0, "3.45")]
    public void ShouldCalculateBasketTotal_Apply_Discount_Milk(int quantity1, int quantity2, int quantity3, string expectedTotal)
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", (quantity1, 0.8m)));
        basket.Items.Add(new BasketProduct("milk", "Milk", (quantity2, 1.15m)));
        basket.Items.Add(new BasketProduct("bread", "Bread", (quantity3, 1.0m)));
        
        var totalCost = basket.CalculateTotal();
        Assert.Equal(decimal.Parse(expectedTotal), totalCost);
    }
    
    [Theory]
    [InlineData(2, 8, 1, "9.00")]
    public void ShouldCalculateBasketTotal_Apply_All_Discount_Rules_Apply(int quantity1, int quantity2, int quantity3, string expectedTotal)
    {
        var basket = new Basket();
        basket.Items.Add(new BasketProduct("butter", "Butter", (quantity1, 0.8m)));
        basket.Items.Add(new BasketProduct("milk", "Milk", (quantity2, 1.15m)));
        basket.Items.Add(new BasketProduct("bread", "Bread", (quantity3, 1.0m)));
        
        var totalCost = basket.CalculateTotal();
        Assert.Equal(decimal.Parse(expectedTotal), totalCost);
    }
}