namespace PriceCalculator;

public class BasketProduct
{
    public BasketProduct(string code, string name, (int quantity, decimal price) atFullPrice)
    {
        Code = code;
        Name = name;
        AtFullPrice = atFullPrice;
    }
    public string Code { get; set; }
    public string Name { get; set; }
    public (int quantity, decimal price) AtFullPrice { get; set; }
    public (int quantity, decimal price) AtDiscountedPrice { get; set; }
}

