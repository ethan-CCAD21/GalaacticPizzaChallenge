namespace GalacticPizzaChallenge;

public record OrderItem(
    string MenuItemId,
    string MenuItemName,
    float MenuItemPrice,
    int Quantity
)
{
    public float TotalPrice => MenuItemPrice * Quantity;
}
