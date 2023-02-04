namespace Tests;

public static class BasketItemFactory
{
    public static readonly Guid AppleGUID = Guid.Parse("38ef8f1b-4a52-4e29-bcf1-3f43aff44441");
    public static readonly int ApplePrice = 30;

    public static readonly Guid PearGUID = Guid.Parse("ec30a95b-0c58-46d6-8c3f-f7bbea818782");
    public static readonly int PearPrice = 40;

    public static readonly Guid OrangeGUID = Guid.Parse("649564c7-dedc-43ba-8228-1776fe4bf79d");
    public static readonly int OrangePrice = 60;

    public static readonly Guid MangoGUID = Guid.Parse("637c585e-f5e9-4745-b521-04610020b370");
    public static readonly int MangoPrice = 130;

    public static BasketItem CreateApple(string name) => BasketItem.Create(AppleGUID, name, ApplePrice);
    public static BasketItem CreatePear(string name) => BasketItem.Create(PearGUID, name, PearPrice);
    public static BasketItem CreateOrange(string name) => BasketItem.Create(OrangeGUID, name, OrangePrice);
    public static BasketItem CreateMango(string name) => BasketItem.Create(MangoGUID, name, MangoPrice);
}
