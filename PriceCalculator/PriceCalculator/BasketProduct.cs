namespace PriceCalculator;

public class BasketProduct
{
    public BasketProduct(string code, string name, int quantity, decimal unitPrice)
    {
        Code = code;
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

