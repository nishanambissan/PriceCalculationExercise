namespace PriceCalculator;

public class Basket
{
    public List<BasketProduct> Items { get; set; } = new List<BasketProduct>();

    private decimal TotalCost { get; set; }

    public decimal CalculateTotal()
    {
        TotalCost = new PricingCalculator().Calculate(Items);
        return TotalCost;
    }
}

//TODO : If I had more time, I would store discount rules collection and apply strategy pattern to apply each kind of discount
//Due to lack of time, it is now calculated directly as a simple solution in the PriceCalculator

/* something of this sort, different kinds of discount
 
public class PercentageDiscount : IDiscount
{
    //<'code = butter', quantity = 2, discountedProductcode = 'milk', discountPercentage '0.5' -> for 2 butters, milk is discounted at 50% 
    private string code;
    private int quantity;
    private string discountedProductcode;
    private decimal discountPercentage;

    decimal Apply(basket)
    {
        //apply this discount and update the total on the basket to the discounted price
    }
}

public class MultibuyDiscount : IDiscount
{
    //<'code = milk', quantity = 3, discountPercentage '1' -> for 3 milks, 100% discount on 4th 
    private string code;
    private int quantity;
    private string discountedProductcode;
    private decimal discountPercentage;

    decimal Apply(basket)
    {        
        //apply this discount and update the total on the basket to the discounted price
    }
}

*/