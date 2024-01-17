/*******************************************************************
* Name: Clint Hester
* Date: 1-4-24
* Assignment: CIS317 Week 3 Project Part 3 - Class Implementation
*
* 
* 
* Customer class represents a customer in the restaurant.
*/
public class Customer
{
    // Properties
    public int CustomerID { get; set; } // Unique identifier for the customer
    public string? Name { get; set; } // Name of the customer
    public string? Email { get; set; } // Email address of the customer
    public List<MenuItems> Preferences { get; set; } // List of menu items preferred by the customer

    // Constructor initializes the customer with an empty list of preferences.
    public Customer()
    {
        Preferences = new List<MenuItems>();
    }

    // Methods
    // Adds a menu item to the customer's list of preferences.
    public void AddPreference(MenuItems item)
    {
        Preferences.Add(item);
    }

    // Removes a menu item from the customer's list of preferences.
    public void RemovePreference(MenuItems item)
    {
        Preferences.Remove(item);
    }

    // Special Consideration
    // Overrides the ToString method to provide a formatted string representation of the customer.
    public override string ToString()
    {
        return $"Customer ID: {CustomerID}, Name: {Name}, Email: {Email}";
    }
}
