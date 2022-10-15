using System.Collections;

namespace Coffee_Shop_POS_Project;

internal sealed class Menu //Displays the menu of food/drinks and prompting users for it
{
    // Static Fields
    private static Dictionary<string, Dictionary<string, (int, int, int)>> _drinksAvailable;
    private static Dictionary<string, Dictionary<string, (int, int, int)>> _dessertsAvailable;
    
    // Constructor
    public Menu()
    {
        InstantiateDrinks();
        InstantiateDesserts();
    }
    
    // Getter Methods (Properties)
    internal static Dictionary<string, Dictionary<string, (int, int, int)>> DrinksAvailable => _drinksAvailable;
    internal static Dictionary<string, Dictionary<string, (int, int, int)>> DessertsAvailable => _dessertsAvailable;

    // Other Methods
    static void InstantiateDrinks()
    {
        _drinksAvailable = new Dictionary<string, Dictionary<string, Tuple<int, int, int>>> 
        {
            ["Traditional Coffee"] = new Dictionary<string, Tuple<int, int, int>>
            {
                ["Iced Coffee with Condensed Milk"] = new Tuple<int, int, int>(29_000, 39_000, 45_000),
                ["Iced Black Coffee"] = new Tuple<int, int, int>(29_000, 35_000, 39_000),
                ["Iced White PHIN Coffee & Condensed Milk"] = new Tuple<int, int, int>(29_000, 39_000, 45_000)
            },
            ["PhinDi Coffee"] = new Dictionary<string, Tuple<int, int, int>>
            {
                ["Iced Coffee with Almond & Fresh Milk"] = new Tuple<int, int, int>(45_000, 49_000, 55_000),
                ["Iced Coffee with Milk Foam"] = new Tuple<int, int, int>(45_000, 49_000, 55_000),
                ["Iced Coffee with Chocolate"] = new Tuple<int, int, int>(45_000, 49_000, 55_000)
            },
            ["Tea"] = new Dictionary<string, Tuple<int, int, int>>
            {
                ["Tea with Lotus Seeds"] = new Tuple<int, int, int>(45_000, 55_000, 65_000),
                ["Tea with Peach Jelly"] = new Tuple<int, int, int>(45_000, 55_000, 65_000),
                ["Peach Tea with Lemongrass"] = new Tuple<int, int, int>(45_000, 55_000, 65_000),
                ["Tea with Lychee Jelly"] = new Tuple<int, int, int>(45_000, 55_000, 65_000),
                ["Green Tea with Red Bean"] = new Tuple<int, int, int>(45_000, 55_000, 65_000)
            }
        };
    }
    static void InstantiateDesserts()
    {
        _dessertsAvailable = new Dictionary<string, Dictionary<string, (int, int, int)>>
        {
            ["Cakes"] = new Dictionary<string, (int, int, int)>
            {
                ["Banana Cake"] = (29_000, 0, 0),
                ["Passion Fruit Cheese Cake"] = (29_000, 0, 0),
                ["Coffee Cheese Cake"] = (29_000, 0, 0),
                ["Tiramisu Cake"] = (35_000, 0, 0)
            },
            ["Mousse"] = new Dictionary<string, (int, int, int)>
            {
                ["Peach Mousse"] = (35_000,0,0),
                ["Cocoa Mousse"] = (35_000,0,0)
            }
        };
    }
}
