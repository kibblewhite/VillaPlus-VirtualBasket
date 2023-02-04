namespace Tests;

public static class BasketItemExtensions
{
    public static bool MatchProperties(this BasketItem item, Guid basketItemGuid, int price, string item_name)
        => item.Id.Equals(basketItemGuid) is true && item.Price.Equals(price) is true && item.Name.Equals(item_name) is true;
}
