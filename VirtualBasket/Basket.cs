namespace VirtualBasket;

public sealed class Basket
{
    public IReadOnlyList<BasketItem> Items => _items.ToImmutableList();
    private readonly IList<BasketItem> _items;

    public IReadOnlyList<IDiscountRule> DiscountRules => _discountRules.ToImmutableList();
    private readonly IList<IDiscountRule> _discountRules;

    public Basket()
    {
        _items = new List<BasketItem>();
        _discountRules = new List<IDiscountRule>();
    }

    public void AddItem(BasketItem item)
    {
        if (item.Price < 0)
        {
            return;
        }

        // note: Exception handling is missing/not-required as this Add() method is not linked to a database or persistent storage
        _items.Add(item);
    }

    public void AddDiscountRule(IDiscountRule discountRule) => _discountRules.Add(discountRule);
}