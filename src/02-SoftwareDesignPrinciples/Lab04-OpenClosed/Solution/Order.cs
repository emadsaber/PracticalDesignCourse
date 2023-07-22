namespace Lab04_OpenClosed.Solution;

class LineItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}

interface IShipping
{
    decimal GetCost(Order order);
    DateTime GetDate(Order order);
}

class AirShipping : IShipping
{
    public decimal GetCost(Order order)
    {
        //3$ per KG and minimum is 20$
        return Helpers.Max(20, order.GetTotalWeight() * 3);
    }

    public DateTime GetDate(Order order)
    {
        //will be shipped after two days
        return DateTime.Now.AddDays(2);
    }
}

class GroundShipping : IShipping
{
    public decimal GetCost(Order order)
    {
        //Free ground delivery
        if (order.GetTotalPrice() > 100)
            return 0;

        //1.5$ per KG and minimum is 10$
        return Helpers.Max(10, order.GetTotalWeight() * 1.5M);
    }

    public DateTime GetDate(Order order)
    {
        //will be shipped today
        return DateTime.Now;
    }
}

class Order
{
    private List<LineItem> LineItems = new List<LineItem>();
    private IShipping shipping; //designed to an implementation

    public Order(List<LineItem> lineItems, IShipping shipping)
    {
        LineItems = lineItems;
        this.shipping = shipping;
    }

    public decimal GetTotalPrice()
    {
        return LineItems.Sum(x => x.Price);
    }

    public decimal GetTotalWeight()
    {
        return LineItems.Sum(x => x.Weight);
    }

    public DateTime GetShippingDate(){
        return shipping.GetDate(this);
    }

    public decimal GetShippingCost(){
        return shipping.GetCost(this);
    }
}
