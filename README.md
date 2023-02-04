# Villa Plus Virtual Basket

### Overview

The provided code is a C# implementation of a shopping basket application. The application has several classes that work together to provide a functioning shopping basket.

1.  `BuyTwoGetOneFreeDiscountRule`: This class is a implementation of the IDiscountRule interface, it implements the GetDiscount method, this class is a discount rule that when applied to the basket, it will give one free item for every two items of the same type that are in the basket. The class has a constructor which takes a `HashSet<Guid>` as a parameter which represents the items that will be included in the discount rule.

2.  `TenPercentOffOver1000DiscountRule`: This class is also a implementation of the IDiscountRule interface, it implements the GetDiscount method, this class is a discount rule that when applied to the basket, it will give 10% discount for items that have a total price of more than 1000. The class has a constructor which takes a `HashSet<Guid>` as a parameter which represents the items that will be included in the discount rule.

3.  `BasketItemExtensions`: This class has two extension methods that can be used to calculate the price of the basket, one is `CalculateBasketPriceWithoutDiscounts` which returns the total price of all the items in the basket without applying any discounts and the other is `CalculateBasketPriceWithDiscounts` which returns the total price of all the items in the basket after applying all the discounts.

4.  `IDiscountRule`: This is an interface that requires classes that implement it to have a property `ItemsGuidList` of type `HashSet<Guid>` and a method `GetDiscount(Basket basket)` which takes a Basket object as a parameter and returns an integer representing the discount to be applied.

5.  `Basket`: This is the main class of the application, it represents the shopping basket. It has several properties and methods, some of them are:

    -   `Items`: a readonly property that returns a list of all the items in the basket
    -   `DiscountRules`: a readonly property that returns a list of all the discount rules that have been applied to the basket
    -   `RemoveItem(Guid itemId)`: a method that removes an item from the basket, given its id
    -   `GetItems(IEnumerable<Guid> items_guid_list)`: a method that returns all the items in the basket that match the items passed in the parameter
    -   `AddItem(BasketItem item)`: a method that adds an item to the basket
    -   `AddDiscountRule(IDiscountRule discountRule)`: a method that adds a discount rule to the basket.

6.  `BasketItem`: This is a class that represents an item in the basket, it has three properties: `Id` of type `Guid`, `Name` of type `string` and `Price` of type `int`. It also has a static method `Create(string name, int price)` which can be used to create a new instance of the class.

### Outline

Implement a C# code to calculate the total price of items in a basket, taking into account discount rules. The code should support a "buy two, get one free" deal for certain items or combinations of items. For example, if the deal applies to apples and oranges, buying two apples and one orange would require payment for only two items.

The implementation should be:
- Maintainable and of production quality
- A fully working pricing solution

Please note:
- This task does not require implementing a shopping basket, e-commerce website, or console application
- Aim to spend approximately two hours working on the solution.


### Guidelines

- Adequate error handling in place
- Effective unit testing to validate code functionality with a single well-defined assertion
- Organized project structure to ensure maintainability
- Implementation of SOLID design principles
- Class-based modular code organisation, for example, one class per file
- Clear and concise concept definition
- Simplified logical structure for effective solution support (unconvoluted logic when it is being read by a human)
- Well-defined code/class structure
- Reusable functional components for an improved solution, demonstrating method extensions in functional programming style
- Code with meaningful naming conventions
- Emphasis on only the essential features provided to facilitate an improved understanding of the solution
- Robust unit test suite with comprehensive coverage
- Accurate promotion logic calculation
- Deals are structured and coded with the potential to be extended (multiple deals can be applied)


## IMPORTANT

### Why integer and not decimals: Using a fixed-point integer format for representing currency amounts, rather than a decimal format.

This is because fixed-point integers can represent exact values with no rounding errors, whereas decimals can introduce rounding errors, particularly when dealing with large numbers of decimal places.
Additionally, fixed-point integers are generally easier to work with and more efficient for calculations, since they do not require floating-point arithmetic.

```csharp
decimal num1 = 0.1M;
decimal num2 = 0.2M;
decimal sum = num1 + num2;
Console.WriteLine(sum); // Output: 0.3

decimal num3 = 0.6M;
decimal num4 = 0.2M;
decimal sum2 = num3 + num4;
Console.WriteLine(sum2); // Output: 0.8

decimal num5 = 0.6M;
decimal num6 = 0.2M;
decimal sum3 = num5 + num6;
Console.WriteLine(sum3 == 0.8M); // Output: False
```

In this example, the variable sum is assigned the value of num1 plus num2, which should be 0.3. However, when you add num3 and num4 and assign the result to sum2, it is not equal to 0.8. The output of sum3 == 0.8M is false. This is because the actual value of sum3 is 0.8000000000000003 which is not equal to 0.8. The problem is that the decimal type has a limited precision, and the value of 0.6 cannot be exactly represented using a finite number of bits. Therefore, when 0.6 is represented using the decimal type, it is an approximation of the true value. This approximation leads to the rounding error when it is added to another value.

Another example of a rounding error can occur when dividing one number by another. For example, dividing 1 by 3 gives a result of 0.3333333333333333. However, this result is not exact and is a close approximation. When this value is then rounded to 2 decimal places, the result will be 0.33, which is not the exact value of the division, but a rounded approximation.

### After thoughts...

Seems the company has some issues, and contrasting reviews on glassdoor was not very promising either
- https://www.google.co.uk/search?hl=en&q=Villa+Plus&meta=#lrd=0x48763f26689a76c7:0xdd8e3b7d716d5c7e,1
