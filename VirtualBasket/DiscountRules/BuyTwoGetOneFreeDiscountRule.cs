namespace VirtualBasket.DiscountRules;

public class BuyTwoGetOneFreeDiscountRule : IDiscountRule
{
    public HashSet<Guid> ItemsGuidList { get; init; }

    public BuyTwoGetOneFreeDiscountRule(HashSet<Guid> itemsGuidList) => ItemsGuidList = itemsGuidList;

    public ValueResults<int> GetDiscount(Basket basket)
    {
        int itemCount = basket.Items.Count(i => ItemsGuidList.Contains(i.Id) is true);
        int freeItems = itemCount / 3;

        // In these two lines, items ordered by their cheapest value is subtracted, instead of matching by batches of matched item
        List<BasketItem> discountedValueItems = new();
        try
        {
            IOrderedEnumerable<BasketItem> itemsOrderedByCheapest = basket.Items.OrderBy(x => x.Price);
            IEnumerable<BasketItem> discountedItems = itemsOrderedByCheapest.Take(freeItems);
            discountedValueItems.AddRange(discountedItems);
        }
        catch (Exception ex)
        {
            return ValueResults<int>.Failed(ex.HResult, ex.Message);
        }

        int discountedValue = discountedValueItems.Sum(x => x.Price);
        return ValueResults<int>.Passed(discountedValue < 0 ? 0 : discountedValue);
    }
}