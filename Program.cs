using Coffee_Shop_POS_Project;
using static System.Console;

Product chosenProduct = GetCustomerDrinks();
Console.WriteLine(chosenProduct);

Product GetCustomerDrinks()
{
    // Local Variables
    var drinksAvailable = Menu.DrinksAvailable;
    string drinksDisplay;
    
    // Prompt user for Drink Category
    drinksDisplay = "";
    for (int i = 0; i < drinksAvailable.Length; i++) drinksDisplay += $"\n{i} : {drinksAvailable[i]}";
    WriteLine("Drink Type:" + drinksDisplay);
    int drinkCategory = Convert.ToInt32(ReadLine());
    
    // Prompt user for specific drinks
    drinksDisplay = "";
    for (int i = 0; i < drinksAvailable[drinkCategory].Length; i++) drinksDisplay += $"\n{i} : {drinksAvailable[drinkCategory][i].ItemName}";
    WriteLine($"{drinksAvailable[drinkCategory]} :" + drinksDisplay);
    int drinkNumber = Convert.ToInt32(ReadLine());

    // Prompt user for size of drink 
    WriteLine("Size of Drink: ");
    int sizeInput = Convert.ToInt32(ReadLine());
    var drinkSize = sizeInput switch // Select size enum based on userInput
    {
        0 => DrinkSizes.Small,
        1 => DrinkSizes.Medium,
        2 => DrinkSizes.Large,
        _ => throw new ArgumentOutOfRangeException()
    };
    
    // Returning the final Product Object
    string drinkName = drinksAvailable[drinkCategory][drinkNumber].ItemName;
    int drinkPrice = drinksAvailable[drinkCategory][drinkNumber].Price[(int) drinkSize];
    return new Product(drinkSize, drinkName, drinkPrice);
}

Product GetCustomerFood()
{
    // Local Variables
    var foodAvailable = Menu.FoodAvailable;
    string foodDisplay;
    int foodCategory;
    int foodNumber;
    
    // Prompt user for Drink Category
    foodDisplay = "";
    for (int i = 0; i < foodAvailable.Length; i++) foodDisplay += $"\n{i} : {foodAvailable[i]}";
    WriteLine("Drink Type:" + foodDisplay);
    foodCategory = Convert.ToInt32(ReadLine());
    
    // Prompt user for specific drinks
    foodDisplay = "";
    for (int i = 0; i < foodAvailable[foodCategory].Length; i++) foodDisplay += $"\n{i} : {foodAvailable[foodCategory][i]}";
    WriteLine("Drink Type:" + foodDisplay);
    foodNumber = Convert.ToInt32(ReadLine());
    
    // Returning the final Product Object
    string drinkName = foodAvailable[foodCategory][foodNumber].ItemName;
    int drinkPrice = foodAvailable[foodCategory][foodNumber].Price;
    return new Product(null, drinkName, drinkPrice);
}