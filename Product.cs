namespace Coffee_Shop_POS_Project;

// The product that customer's actually chooses
internal struct Product
{
    // Fields
    private string StringSize { get; }
    private string ItemName { get; }
    private int Price { get; set; }
    private string Category { get; set; } // The category of drink or food this product belongs to

    // Constructor
    internal Product(DrinkSizes? size, string itemName, int price, string category)
    {
        this.StringSize = $" ({size})" ?? "";
        this.ItemName = itemName;
        this.Price = price;
        this.Category = category;
    }

    public override string ToString()
    {
        return $"{ItemName}{StringSize} = {Price}";
    }

}