/*******************************************************************
* Name: Clint Hester
* Date: 1-4-24
* Assignment: CIS317 Week 3 Project Part 3 - Class Implementation
*
* 
* 
* KitchenStaff class represents staff members working in the kitchen.
*/
public class KitchenStaff
{
    // Properties
    public int StaffID { get; set; } // Unique identifier for the kitchen staff member
    public string? Name { get; set; } // Name of the kitchen staff member
    public Specialization StaffSpecialization { get; set; } // Specialization of the kitchen staff member (e.g., Grill, Fryer, Prep)

    // Methods
    // Prepares an order in the kitchen.
    public void PrepareOrder(Order order)
    {
        // Logic for preparing an order
        Console.WriteLine($"Preparing order for {order.Customer.Name}");
    }

    // Special Consideration
    // Class Hierarchy: The KitchenStaff class may be part of a broader hierarchy if additional staff roles are introduced in the future.

    // Enum defining possible specializations for kitchen staff.
    public enum Specialization
    {
        Grill,
        Fryer,
        Prep
    }
}

// Status enum represents the status of an order.
public enum Status
{
    Pending,
    InProgress,
    Completed
}