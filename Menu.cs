namespace Coffee_Shop_POS_Project;

internal struct Menu //Displays the menu of food/drinks and prompting users for it
{
    // Static Fields
    private static Dictionary<string, Dictionary<string, (int, int, int)>> _drinksAvailable = null!;
    private static Dictionary<string, Dictionary<string, (int, int, int)>> _dessertsAvailable = null!;

    // Constructor
    static Menu()
    {
        DrinksAvailable = new Dictionary<string, Dictionary<string, (int, int, int)>>
        {
            ["Traditional Coffee"] = new Dictionary<string, (int, int, int)>
            {
                ["Iced Coffee with Condensed Milk"] = (29_000, 39_000, 45_000),
                ["Iced Black Coffee"] = (29_000, 35_000, 39_000),
                ["Iced White PHIN Coffee & Condensed Milk"] = (29_000, 39_000, 45_000)
            },
            ["PhinDi Coffee"] = new Dictionary<string, (int, int, int)>
            {
                ["Iced Coffee with Almond & Fresh Milk"] = (45_000, 49_000, 55_000),
                ["Iced Coffee with Milk Foam"] = (45_000, 49_000, 55_000),
                ["Iced Coffee with Chocolate"] = (45_000, 49_000, 55_000)
            },
            ["Tea"] = new Dictionary<string, (int, int, int)>
            {
                ["Tea with Lotus Seeds"] = (45_000, 55_000, 65_000),
                ["Tea with Peach Jelly"] = (45_000, 55_000, 65_000),
                ["Peach Tea with Lemongrass"] = (45_000, 55_000, 65_000),
                ["Tea with Lychee Jelly"] = (45_000, 55_000, 65_000),
                ["Green Tea with Red Bean"] = (45_000, 55_000, 65_000)
            }
        };
        ;
        DessertsAvailable = new Dictionary<string, Dictionary<string, (int, int, int)>>
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
                ["Peach Mousse"] = (35_000, 0, 0),
                ["Cocoa Mousse"] = (35_000, 0, 0)
            }
        };
    }

    // Properties
    internal static Dictionary<string, Dictionary<string, (int, int, int)>> DrinksAvailable
    {
        get => _drinksAvailable;
        set => _drinksAvailable = value;
    }

    internal static Dictionary<string, Dictionary<string, (int, int, int)>> DessertsAvailable
    {
        get => _dessertsAvailable;
        set => _dessertsAvailable = value;
    }
}