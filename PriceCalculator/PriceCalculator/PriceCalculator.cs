namespace PriceCalculator;

public class PriceCalculator
{
    private Basket Basket { get; set; }
    
    //ideally this would be coming in via DI
    public PriceCalculator(Basket basket)
    {
        Basket = basket;
    }

    public decimal CalculateTotal()
    {
        return 0;
    }

    public void ApplyDiscounts()
    {
        
    }
}