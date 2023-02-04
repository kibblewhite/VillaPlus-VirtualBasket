namespace VirtualBasket.DiscountRules;

public class BuyTwoGetOneFreeDiscountRule : IDiscountRule
{
    public HashSet<Guid> ItemsGuidList { get; init; }

    public BuyTwoGetOneFreeDiscountRule(HashSet<Guid> itemsGuidList) => ItemsGuidList = itemsGuidList;

    public ValueResults<int> GetDiscount(Basket basket)
    {
        int itemCount = 0;
        int discountedValue = 0;
        List <BasketItem> discountedValueItems = new();

        try
        {
            itemCount = basket.Items.Count(i => ItemsGuidList.Contains(i.Id) is true);
            int freeItems = itemCount / 3;

            // In these two lines, items ordered by their cheapest value is subtracted, instead of matching by batches of matched item
            IOrderedEnumerable<BasketItem> itemsOrderedByCheapest = basket.Items.OrderBy(x => x.Price);
            IEnumerable<BasketItem> discountedItems = itemsOrderedByCheapest.Take(freeItems);
            discountedValueItems.AddRange(discountedItems);
            discountedValue = discountedValueItems.Sum(x => x.Price);
        }
        catch (Exception ex)
        {
            return ValueResults<int>.Failed(ex.HResult, ex.Message);
        }

        return ValueResults<int>.Passed(discountedValue < 0 ? 0 : discountedValue);
    }
}