namespace Coffee_Shop_POS_Project;

// TODO: Implement this solution: https://learn.microsoft.com/en-us/dotnet/csharp/iterators

internal static class Menu
{
    // Entire class simply consist of fields and getter methods. No other behavioural methods

    #region Drinks
    // Traditional Coffee
    private static readonly Drinks IcedCoffeeWithCondensedMilk = new Drinks("Iced Coffee with Condensed Milk", new int[]{29_000, 39_000, 45_000});
    private static readonly Drinks IcedBlackCoffee = new Drinks("Iced Black Coffee", new int[]{29_000, 39_000, 45_000});
    private static readonly Drinks IcedWhitePhinCoffee = new Drinks("Iced White Phin Coffee & Condensed Milk", new int[]{29_000, 39_000, 45_000});
    
    // PhinDi Coffee
    private static readonly Drinks IcedCoffeeWithAlmond = new Drinks("Iced Coffee with Almond & Fresh Milk", new int[]{45_000, 49_000, 55_000});
    private static readonly Drinks IcedCoffeeWithMilk = new Drinks("Iced Coffee with Milk Foam", new int[]{45_000, 49_000, 55_000});
    private static readonly Drinks IcedCoffeeWithChocolate = new Drinks("Iced Coffee with Chocolate", new int[]{45_000, 49_000, 55_000});
    
    // Teas 
    private static readonly Drinks TeaWithLotusSeeds = new Drinks("Tea with Lotus Seeds", new int[]{45_000, 55_000, 65_000});
    private static readonly Drinks TeaWithPeachJelly = new Drinks("Tea with Peach Jelly", new int[]{45_000, 55_000, 65_000});
    private static readonly Drinks PeachTeaWithLemonGrass = new Drinks("Peach Tea with Lemon Grass", new int[]{45_000, 55_000, 65_000});
    private static readonly Drinks TeaWithLycheeJelly = new Drinks("Tea with Lychee Jelly", new int[]{45_000, 55_000, 65_000});
    #endregion

    #region Food
    // Pastries
    private static readonly Food BananaCake = new Food("Banana Cake", 29_000);
    private static readonly Food PassionFruitCheeseCake = new Food("Passion Fruit Cheese Cake", 29_000);
    private static readonly Food CoffeeCheeseCake = new Food("Coffee Cheese Cake", 29_000);
    private static readonly Food TiramisuCake = new Food("Tiramisu Cake", 35_000);
    
    // BreakSticks
    private static readonly Food Pate = new Food("Pate", 19_000);
    private static readonly Food ChickenAndCheese = new Food("Chicken & Cheese", 19_000);
    #endregion

    #region Drink Groups
    private static readonly DrinksGroup TraditionalCoffee = new DrinksGroup("Traditional Coffee", new List<Drinks>() {IcedCoffeeWithCondensedMilk, IcedBlackCoffee, IcedWhitePhinCoffee});
    private static readonly DrinksGroup PhinDi = new DrinksGroup("PhinDi Coffee", new List<Drinks>() {IcedCoffeeWithAlmond, IcedCoffeeWithMilk, IcedCoffeeWithChocolate});
    private static readonly DrinksGroup Teas = new DrinksGroup("Teas", new List<Drinks>() {TeaWithLotusSeeds, TeaWithPeachJelly, PeachTeaWithLemonGrass, TeaWithLycheeJelly});
    #endregion
    
    #region Food Groups
    private static readonly FoodGroup Pastries = new FoodGroup("Pastries", new List<Food>() {BananaCake, PassionFruitCheeseCake, CoffeeCheeseCake, TiramisuCake});
    private static readonly FoodGroup BreadSticks = new FoodGroup("BreadSticks", new List<Food>() {Pate, ChickenAndCheese});
    #endregion

    #region Product Categories (Exposed to other Classes)
    internal static DrinksCategory DrinksAvailable { get; } = new("Drinks", new List<DrinksGroup>() {TraditionalCoffee, PhinDi, Teas});
    internal static FoodCategory FoodAvailable { get; } = new("Food", new List<FoodGroup>() {Pastries, BreadSticks});
    #endregion

    #region Records
    internal record Drinks(string ItemName, int[] Price);
    internal record Food(string ItemName, int Price);
    internal record DrinksGroup(string GroupName, List<Drinks> DrinksCollection); // Accepts Drinks as a collection to allow users to add their own drink group when needed
    internal record FoodGroup(string GroupName, List<Food> FoodCollection);
    internal record DrinksCategory(string ProductType, List<DrinksGroup> GroupsCollection);
    internal record FoodCategory(string ProductType, List<FoodGroup> GroupsCollection);
    #endregion
}