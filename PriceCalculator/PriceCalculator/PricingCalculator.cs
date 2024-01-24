namespace PriceCalculator;

public class PricingCalculator
{
    //ideally this would be coming in via DI
    public PricingCalculator()
    {
    }

    public decimal Calculate(List<BasketProduct> basketProducts)
    {
        ApplyDiscounts();
        return 0;
    }

    public void ApplyDiscounts()
    {
        
    }
}