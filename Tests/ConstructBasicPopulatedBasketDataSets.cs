namespace Tests;

public static class ConstructBasicBasketDataSets
{
    // https://github.com/microsoft/vstest/issues/4208
    // [DynamicData(nameof(ConstructBasicBasketDataSets.BuildBasicBasketDataSet), typeof(ConstructBasicBasketDataSets), DynamicDataSourceType.Method)]

    public static IEnumerable<object[]> BuildBasicBasketDataSet()
    {
        Basket basket = new();
        basket.PopulateBasket();

        return Enumerable.Repeat(new object[]
        {
            nameof(BuildBasicBasketDataSet),
            basket
        }, 1);
    }

    public static Basket PopulateBasket(this Basket basket)
    {
        ArgumentNullException.ThrowIfNull(basket, nameof(basket));

        BasketItem apple_01 = BasketItemFactory.CreateApple("Apple One");
        BasketItem apple_02 = BasketItemFactory.CreateApple("Apple Two");
        BasketItem apple_03 = BasketItemFactory.CreateApple("Apple Three");

        basket.AddItem(apple_01);
        basket.AddItem(apple_02);
        basket.AddItem(apple_03);

        BasketItem pear_01 = BasketItemFactory.CreatePear("Pear One");
        BasketItem pear_02 = BasketItemFactory.CreatePear("Pear Two");
        BasketItem pear_03 = BasketItemFactory.CreatePear("Pear Three");
        BasketItem pear_04 = BasketItemFactory.CreatePear("Pear Four");

        basket.AddItem(pear_01);
        basket.AddItem(pear_02);
        basket.AddItem(pear_03);
        basket.AddItem(pear_04);

        BasketItem orange_01 = BasketItemFactory.CreateOrange("Orange One");
        BasketItem orange_02 = BasketItemFactory.CreateOrange("Orange Two");
        BasketItem orange_03 = BasketItemFactory.CreateOrange("Orange Three");

        basket.AddItem(orange_01);
        basket.AddItem(orange_02);
        basket.AddItem(orange_03);

        BasketItem mango_01 = BasketItemFactory.CreateMango("Mango One");
        BasketItem mango_02 = BasketItemFactory.CreateMango("Mango Two");
        BasketItem mango_03 = BasketItemFactory.CreateMango("Mango Three");
        BasketItem mango_04 = BasketItemFactory.CreateMango("Mango Four");

        basket.AddItem(mango_01);
        basket.AddItem(mango_02);
        basket.AddItem(mango_03);
        basket.AddItem(mango_04);

        return basket;
    }
}
