/*******************************************************************
* Name: Clint Hester
* Date: 1-4-24
* Assignment: CIS317 Week 3 Project Part 3 - Class Implementation
*
* 
* 
* MenuItems class represents a menu item in the restaurant.
*/
public class MenuItems
{
    // Properties
    public int ItemID { get; set; } // Unique identifier for the menu item
    public string? Name { get; set; } // Name of the menu item
    public string? Description { get; set; } // Description of the menu item
    public decimal Price { get; set; } // Price of the menu item
    public bool Available { get; set; } // Availability status of the menu item

    // Methods
    // Updates the price of the menu item.
    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }

    // Toggles the availability status of the menu item.
    public void ToggleAvailability()
    {
        Available = !Available;
    }

    // Special Consideration
    // Overrides the ToString method to provide a formatted string representation of the menu item.
    public override string ToString()
    {
        return $"Item ID: {ItemID}, Name: {Name}, Price: {Price}, Available: {Available}";
    }
}