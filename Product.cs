namespace Coffee_Shop_POS_Project;

// The product that customer's actually chooses
internal struct Product
{
    // Fields
    internal string StringSize { get; }
    internal string ItemName { get; }
    internal int Price { get; set; }
    internal string Category { get; set; } // The category of drink or food this product belongs to

    // Constructor
    internal Product(DrinkSizes size, string itemName, int price, string category)
    {
        this.ItemName = itemName;
        this.Price = price;
        this.Category = category;
        
        // Deciding on DrinkSize
        if (size == DrinkSizes.Null) StringSize = "";
        else StringSize = $" ({size})";
    }

    public override string ToString()
    {
        return $"{ItemName}{StringSize} = {Price}";
    }
}