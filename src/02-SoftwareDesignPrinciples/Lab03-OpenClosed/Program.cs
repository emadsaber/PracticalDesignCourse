namespace Lab03_OpenClosed;
class Program{

    public static void Main(string[] args){

        //Problem Test
        var pItems = new List<Problem.LineItem>{
            new Problem.LineItem{Name = "Item 1", Price = 100, Weight = 20},
            new Problem.LineItem{Name = "Item 2", Price = 250, Weight = 15},
            new Problem.LineItem{Name = "Item 3", Price = 70, Weight = 40},
        };
        var pOrder = new Problem.Order(lineItems: pItems, shipping: "air");
        Console.WriteLine($"Total Shipping Cost is: {pOrder.GetShippingCost()}, and will be shipped on {pOrder.GetShippingDate()}");

        //Solution Test
        var sItems = new List<Solution.LineItem>{
            new Solution.LineItem{Name = "Item 4", Price = 200, Weight = 98},
            new Solution.LineItem{Name = "Item 5", Price = 750, Weight = 54},
            new Solution.LineItem{Name = "Item 6", Price = 10, Weight = 30},
        };
        var shipping = new Solution.GroundShipping();
        var sOrder = new Solution.Order(lineItems: sItems, shipping);
        Console.WriteLine($"Total Shipping Cost is: {sOrder.GetShippingCost()} because it's total cost is {sOrder.GetTotalPrice()}, "+
        $"and will be shipped on {sOrder.GetShippingDate()}");
    }
}