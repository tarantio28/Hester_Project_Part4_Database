/*******************************************************************
* Name: Clint Hester
* Date: 1-4-24
* Assignment: CIS317 Week 3 Project Part 3 - Class Implementation
*
* 
* 
* Order class represents a customer order in the restaurant.
*/
public class Order
{
    // Properties
    public int OrderID { get; set; } // Unique identifier for the order
    public List<MenuItems> Items { get; set; } // List of menu items in the order
    public Status OrderStatus { get; set; } // Status of the order (Pending, InProgress, Completed)
    public Customer Customer { get; set; } // Customer placing the order

    // Constructor initializes the order with an empty list of items and a default status of Pending.
    public Order()
    {
        Items = new List<MenuItems>();
        OrderStatus = Status.Pending;
    }

    // Methods
    // Adds a menu item to the order.
    public void AddItem(MenuItems item)
    {
        Items.Add(item);
    }

    // Removes a menu item from the order.
    public void RemoveItem(MenuItems item)
    {
        Items.Remove(item);
    }

    // Updates the status of the order (e.g., from Pending to InProgress or Completed).
    public void UpdateStatus(Status newStatus)
    {
        OrderStatus = newStatus;
    }

    // Special Consideration
    // Overrides the ToString method to provide a formatted string representation of the order.
    public override string ToString()
    {
        return $"Order ID: {OrderID}, Status: {OrderStatus}, Customer: {Customer.Name}";
    }
}
