namespace Lab04_OpenClosed.Problem;

class LineItem{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}

class Order
{
    private List<LineItem> LineItems;
    private string shipping;

    public Order(List<LineItem> lineItems, string shipping)
    {
        LineItems = lineItems;
        this.shipping = shipping;
    }

    public decimal GetTotalPrice(){
        return LineItems.Sum(x => x.Price);
    }

    public decimal GetTotalWeight(){
        return LineItems.Sum(x => x.Weight);
    }

    //This logic will be broken if a new shipping method is created
    public DateTime GetShippingDate(){
        if(shipping == "ground"){
            //will be shipped today
            return DateTime.Now;
        }
        if(shipping == "air"){
            //will be shipped after two days
            return DateTime.Now.AddDays(2);
        }

        throw new ArgumentOutOfRangeException();
    }

    //This logic will be broken if a new shipping method is created
    public decimal GetShippingCost(){
        if(shipping == "ground"){
            //Free ground delivery
            if(GetTotalPrice() > 100) return 0;

            //1.5$ per KG and minimum is 10$
            return Helpers.Max(10, GetTotalWeight() * 1.5M);
        }
        if(shipping == "air"){
            //3$ per KG and minimum is 20$
            return Helpers.Max(20, GetTotalWeight() * 3M);
        }
        throw new ArgumentOutOfRangeException();
    }
}

