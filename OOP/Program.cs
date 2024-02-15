abstract class Delivery
{
    protected string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public abstract void Deliver();
}

class HomeDelivery : Delivery
{
    public override void Deliver()
    {
        Console.WriteLine("Доставка по домашнему адресу: " + Address);
    }
}

class PickPointDelivery : Delivery
{
    public string PickPointLocation { get; set; }

    public override void Deliver()
    {
        Console.WriteLine("Доставка до пункта выдачи: " + PickPointLocation);
    }
}

class ShopDelivery : Delivery
{
    public string ShopName { get; set; }

    public override void Deliver()
    {
        Console.WriteLine("Доставка до магазина: " + ShopName);
    }
}

class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }

    public Order(TDelivery delivery, int number, string description)
    {
        Delivery = delivery;
        Number = number;
        Description = description;
    }

    public void DisplayAddress()
    {
        Console.WriteLine("Адрес доставки: " + Delivery.Address);
    }

    public void Deliver()
    {
        Delivery.Deliver();
    }
}

class Program
{
    static void Main(string[] args)
    {
        HomeDelivery homeDelivery = new HomeDelivery();
        homeDelivery.Address = "Улица Ленина, дом 10, квартира 5, Москва";

        PickPointDelivery pickPointDelivery = new PickPointDelivery();
        pickPointDelivery.Address = "Проезд Володарского, дом 7, квартира 12, Екатеринбург";
        pickPointDelivery.PickPointLocation = "Пункт выдачи А";

        ShopDelivery shopDelivery = new ShopDelivery();
        shopDelivery.Address = "Площадь Ленина, дом 1, офис 10, Казань";
        shopDelivery.ShopName = "Мой магазин";

        Order<HomeDelivery> homeOrder = new Order<HomeDelivery>(homeDelivery, 1, "Домашняя доставка");
        Order<PickPointDelivery> pickPointOrder = new Order<PickPointDelivery>(pickPointDelivery, 2, "Доставка до пункта выдачи");
        Order<ShopDelivery> shopOrder = new Order<ShopDelivery>(shopDelivery, 3, "Доставка до магазина");

        homeOrder.DisplayAddress();
        homeOrder.Deliver();

        pickPointOrder.DisplayAddress();
        pickPointOrder.Deliver();

        shopOrder.DisplayAddress();
        shopOrder.Deliver();
    }
}
