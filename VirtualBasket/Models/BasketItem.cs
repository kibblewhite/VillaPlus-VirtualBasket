namespace VirtualBasket.Models;

public sealed class BasketItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required int Price { get; init; }

    public static BasketItem Create(string name, int price) => Create(Guid.NewGuid(), name, price);
    public static BasketItem Create(Guid id, string name, int price) => new()
    {
        Id = id,
        Name = name,
        Price = price < 0 ? 0 : price
    };
}
