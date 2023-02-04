namespace VirtualBasket.Extensions;

public static class BasketItemExtensions
{
    public static int CalculateBasketPriceWithoutDiscounts(this Basket basket)
    {
        try
        {
            return basket.Items.Sum(i => i.Price);
        }
        catch (Exception ex)
        {
            // log error message and bubble error up
            Console.WriteLine($"An error occurred in CalculateBasketPriceWithoutDiscounts: {ex}");
            throw;
        }
    }

    public static int CalculateBasketPriceWithDiscounts(this Basket basket)
    {
        int total = basket.CalculateBasketPriceWithoutDiscounts();
        foreach (IDiscountRule discountRule in basket.DiscountRules)
        {
            ValueResults<int> value_results = discountRule.GetDiscount(basket);
            if (value_results.Success is false)
            {
                // log error - depending where this logic sits in the application or service
                //             it could instead bubble the exception up rather than catching and logging
                //             > this information was not provided in the specifications
                continue;
            }

            total -= value_results.Value;
        }

        return total < 0 ? 0 : total;
    }
}
