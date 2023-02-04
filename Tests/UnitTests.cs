namespace Tests;

[TestClass]
public class UnitTests
{
    [TestInitialize]
    public void TestInitialize() { }

    [TestMethod]
    public void BasicTest()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();
        basket.PopulateBasket();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            BasketItemFactory.AppleGUID, BasketItemFactory.PearGUID
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);
        basket.AddDiscountRule(discountRule);

        // Act
        int priceWithDiscounts = basket.CalculateBasketPriceWithDiscounts();

        // Assert
        Assert.AreEqual(890, priceWithDiscounts);
    }

    [TestMethod]
    public void BasicTestWithoutDiscounts()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();
        basket.PopulateBasket();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            BasketItemFactory.AppleGUID, BasketItemFactory.PearGUID
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);
        basket.AddDiscountRule(discountRule);

        // Act
        int priceWithoutDiscounts = basket.CalculateBasketPriceWithoutDiscounts();

        // Assert
        Assert.AreEqual(950, priceWithoutDiscounts);
    }

    [TestMethod]
    public void BasicTestWithNoItems()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            BasketItemFactory.AppleGUID, BasketItemFactory.PearGUID
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);
        basket.AddDiscountRule(discountRule);

        // Act
        int priceWithoutDiscounts = basket.CalculateBasketPriceWithDiscounts();

        // Assert
        Assert.AreEqual(0, priceWithoutDiscounts);
    }

    [TestMethod]
    public void BasicTestWithNoMatchedDiscountItems()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();
        basket.PopulateBasket();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            Guid.Empty
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);
        basket.AddDiscountRule(discountRule);

        // Act
        int priceWithoutDiscounts = basket.CalculateBasketPriceWithDiscounts();

        // Assert
        Assert.AreEqual(950, priceWithoutDiscounts);
    }

    [TestMethod]
    public void BuyTwoGetOneFreeDiscountRuleTest()
    {
        // AAA: (Arrange-Act-Assert)
        int discountValue = 0;
        Basket basket = new();
        basket.PopulateBasket();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            BasketItemFactory.AppleGUID, BasketItemFactory.PearGUID
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);

        // Act
        ValueResults<int> value_result = discountRule.GetDiscount(basket);
        if (value_result.Success is true)
        {
            discountValue = value_result.Value;
        }

        // Assert
        Assert.AreEqual(60, discountValue);
    }

    [TestMethod]
    public void SimpleAddItemTest()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();

        // Arrange
        string pear_name = "Awesome Pear";
        BasketItem pear = BasketItemFactory.CreatePear(pear_name);

        // Act
        basket.AddItem(pear);
        BasketItem retrieved_pear = basket.Items.Single(x => x.Name == pear_name);

        // Assert
        Assert.AreEqual(pear, retrieved_pear);
    }

    [TestMethod]
    public void SimpleCheckDiscountRuleAddedTest()
    {
        // AAA: (Arrange-Act-Assert)
        Basket basket = new();
        basket.PopulateBasket();

        // Arrange
        HashSet<Guid> itemsGuidList = new()
        {
            BasketItemFactory.AppleGUID, BasketItemFactory.PearGUID
        };

        IDiscountRule discountRule = new BuyTwoGetOneFreeDiscountRule(itemsGuidList);
        basket.AddDiscountRule(discountRule);

        // Act
        IDiscountRule only_added_discount_rule = basket.DiscountRules.Single();

        // Assert
        Assert.AreEqual(discountRule, only_added_discount_rule);
    }

    [TestMethod]
    public void SimpleBasketItemCreationTest()
    {
        // AAA: (Arrange-Act-Assert)
        Guid basketItemGuid = Guid.NewGuid();
        int price = 1000;
        string item_name = "Test Item";

        // Arrange
        BasketItem item = BasketItem.Create(basketItemGuid, item_name, price);

        // Act
        bool matched_item = item.MatchProperties(basketItemGuid, price, item_name);

        // Assert
        Assert.IsTrue(matched_item);
    }
}
