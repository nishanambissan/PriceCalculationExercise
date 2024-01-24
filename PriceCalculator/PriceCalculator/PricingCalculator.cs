namespace PriceCalculator;

public class PricingCalculator
{
    public decimal Calculate(List<BasketProduct> basketProducts)
    {
        var cost = ApplyDiscounts(basketProducts);
        
        foreach (var item in basketProducts)
        {
            cost += item.AtFullPrice.quantity * item.AtFullPrice.price;
            cost += item.AtDiscountedPrice.quantity * item.AtDiscountedPrice.price;
        }

        return cost;
    }

    public decimal ApplyDiscounts(List<BasketProduct> basketProducts)
    {
        var cost = 0m;
        
        foreach (var item in basketProducts)
        {
            //due to lack of time, have to embed it here, I would use different strategies and store the discounts rules separate
            if (item.Code == "bread")
            {
                var numberOfButters = basketProducts.First(i => i.Code == "butter").AtFullPrice.quantity;
                var numberOfBreads = basketProducts.First(i => i.Code == "bread").AtFullPrice.quantity;
                
                if (numberOfButters / 2 >= numberOfBreads)
                {
                    //all can be discounted 
                    var numberOfItemsAtDiscountedPrice = numberOfBreads;
                    item.AtDiscountedPrice = (numberOfItemsAtDiscountedPrice, 0.5m * item.AtFullPrice.price);
                    item.AtFullPrice = (0, item.AtFullPrice.price);
                }
                else
                {
                    //else group in bunches of two, and what remains are discounted
                    var numberOfItemsAtDiscountedPrice = numberOfBreads - (numberOfButters /2);
                    item.AtDiscountedPrice = (numberOfItemsAtDiscountedPrice, 0.5m * item.AtFullPrice.price);
                    item.AtFullPrice = ((numberOfBreads - numberOfItemsAtDiscountedPrice), item.AtFullPrice.price);
                }
            }

            if (item.Code == "milk")
            {
                var numberOfMilks = basketProducts.First(i => i.Code == "milk").AtFullPrice.quantity;
                
                var numberOfItemsAtDiscountedPrice = numberOfMilks/3;
                var numberOfMilksAtFullPrice = numberOfMilks - numberOfItemsAtDiscountedPrice;
                
                item.AtDiscountedPrice = (numberOfItemsAtDiscountedPrice, 0); //free - 100% discount on 4th one
                item.AtFullPrice = (numberOfMilksAtFullPrice, item.AtFullPrice.price); //rest at full price
            }
        }
        return cost;
    }
}