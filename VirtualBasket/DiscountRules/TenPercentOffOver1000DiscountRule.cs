namespace VirtualBasket.DiscountRules;

/// <summary>
/// Provide 10 percent off selected items, when the total of those selected items total to more than 1000
/// </summary>
/// <remarks>This code is not implemented but demostrates that more discount rules can be added to this example</remarks>
internal class TenPercentOffOver1000DiscountRule : IDiscountRule
{
    /// <summary>
    /// The threshold value before this discount is applied
    /// </summary>
    private const int _value = 1000;
    public required HashSet<Guid> ItemsGuidList { get; init; }

    public TenPercentOffOver1000DiscountRule(HashSet<Guid> itemsGuidList) => ItemsGuidList = itemsGuidList;

    public ValueResults<int> GetDiscount(Basket basket)
    {
        // note: `basket.DiscountRules` is accessible, therefore optional logic can be added to prevent discount clashes
        int totalPrice = 0;

        try
        {
            totalPrice += basket.Items.Where(x => ItemsGuidList.Contains(x.Id) is true).Sum(i => i.Price);
        }
        catch (Exception ex)
        {
            return ValueResults<int>.Failed(ex.HResult, ex.Message);
        }

        return ValueResults<int>.Passed(totalPrice >= _value
            ? Convert.ToInt32(totalPrice * 0.1) // Roughly, apply 10% discount
            : 0);
    }
}
