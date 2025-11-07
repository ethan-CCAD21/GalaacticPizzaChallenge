using System.Collections;

namespace GalacticPizzaChallenge;

class Order
{

    public string UserName { get; set; } = "";

    private DeliveryLocation? _location;
    public DeliveryLocation? Location {
        get => _location;
        set => _location = value is null ? null : value with { };
    }

    private Dictionary<string, OrderItem> _orderItems;
    public Dictionary<string, OrderItem> OrderItems {
        get => _orderItems;
    }

    public Order()
    {
        _orderItems = new Dictionary<string, OrderItem>();
    }

    public void AddItem(MenuItem item)
    {

        if (_orderItems.ContainsKey(item.Id))
        {
            OrderItem orderItem = _orderItems[item.Id];

            _orderItems[item.Id] = orderItem with { Quantity = orderItem.Quantity + 1 };

        }
        else
        {
            _orderItems.Add(item.Id, new OrderItem(item.Id, item.Name, item.Cost, 1));
        }
    }

    public void ClearOrderItems()
    {
        _orderItems.Clear();
    }
}