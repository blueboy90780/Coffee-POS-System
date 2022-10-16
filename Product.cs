namespace Coffee_Shop_POS_Project;

// The product that customer's actually chooses
internal struct Product
{
    // Fields
    private DrinkSizes? Size { get; }
    private string ItemName { get; }
    private int Price { get; set; }

    // Constructor
    internal Product(DrinkSizes? size, string itemName, int price)
    {
        this.Size = size;
        this.ItemName = itemName;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"{ItemName} ({Size}) = {Price}";
    }

}