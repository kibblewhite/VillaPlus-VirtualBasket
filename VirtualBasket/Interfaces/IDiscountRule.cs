namespace VirtualBasket.Interfaces;

public interface IDiscountRule
{
    /// <summary>
    /// The item(s) that the discount is for, use of HashSet ensures that a Guid is not added more than once
    /// </summary>
    HashSet<Guid> ItemsGuidList { get; init; }

    /// <summary>
    /// Calculates discount amount on the provided basket
    /// </summary>
    /// <param name="basket"></param>
    /// <returns></returns>
    ValueResults<int> GetDiscount(Basket basket);
}
