namespace PriceCalculator;

public class PricingCalculator
{
    public decimal Calculate(List<BasketProduct> basketProducts)
    {
        var cost = ApplyDiscounts(basketProducts);
        return cost;
    }

    public decimal ApplyDiscounts(List<BasketProduct> basketProducts)
    {
        var cost = 0m;
        
        foreach (var item in basketProducts)
        {
            cost += item.Quantity * item.UnitPrice;
        }
        
        return cost;
    }
}