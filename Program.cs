namespace Coffee_Shop_POS_Project;

class Program
{
    public static void Main()
    {
        // Local Variables
        OrderMenu menu = new OrderMenu();
        bool proceedOrder = false;
        
        // Console.WriteLine("Small Project #1: Small Coffee POS System");
        while (proceedOrder == false)
        {
            Console.WriteLine("What options would you like to choose");
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case (int)UserOptions.Display:
                    menu.DisplayMenu();
                    break;
                case (int)UserOptions.Add:
                    menu.AddProduct();
                    break;
                case (int)UserOptions.Remove:
                    menu.RemoveAProduct();
                    break;
                case (int)UserOptions.Replace:
                    menu.ReplaceAProduct();
                    break;
                case (int)UserOptions.Clear:
                    menu.ClearOrderMenu();
                    break;
                case (int)UserOptions.Proceed:
                    proceedOrder = menu.ProceedOrder();
                    break;
            }
        }
    }
}