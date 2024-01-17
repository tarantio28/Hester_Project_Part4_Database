/*******************************************************************
* Name: Clint Hester
* Date: 1-4-24
* Assignment: CIS317 Week 3 Project Part 3 - Class Implementation
*
* 
* 
* Main Application Class
*/
using System;
using System.Collections.Generic;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        // SQLite connection string
        string connectionString = "Data Source=restaurant.db;Version=3;";

        // Creating SQLite database and tables
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                // Create Orders table
                command.CommandText = "CREATE TABLE IF NOT EXISTS Orders (OrderID INTEGER PRIMARY KEY, OrderStatus INTEGER, CustomerID INTEGER)";
                command.ExecuteNonQuery();

                // Create MenuItems table
                command.CommandText = "CREATE TABLE IF NOT EXISTS MenuItems (ItemID INTEGER PRIMARY KEY, Name TEXT, Description TEXT, Price DECIMAL, Available INTEGER)";
                command.ExecuteNonQuery();

                // Create Customers table
                command.CommandText = "CREATE TABLE IF NOT EXISTS Customers (CustomerID INTEGER PRIMARY KEY, Name TEXT, Email TEXT)";
                command.ExecuteNonQuery();

                // Create KitchenStaff table
                command.CommandText = "CREATE TABLE IF NOT EXISTS KitchenStaff (StaffID INTEGER PRIMARY KEY, Name TEXT, StaffSpecialization INTEGER)";
                command.ExecuteNonQuery();
            }
        }

        // Creating instances of classes
        Customer customer = new Customer
        {
            CustomerID = 1,
            Name = "John Doe",
            Email = "john@example.com"
        };

        MenuItems menuItem1 = new MenuItems
        {
            ItemID = 101,
            Name = "Burger",
            Description = "Classic Burger",
            Price = 8.99m,
            Available = true
        };

        MenuItems menuItem2 = new MenuItems
        {
            ItemID = 102,
            Name = "Pizza",
            Description = "Margherita Pizza",
            Price = 12.99m,
            Available = true
        };

        Order order = new Order
        {
            OrderID = 501,
            Customer = customer
        };

        KitchenStaff kitchenStaff = new KitchenStaff
        {
            StaffID = 201,
            Name = "Chef Gordon",
            StaffSpecialization = KitchenStaff.Specialization.Grill
        };

        // Adding items to order
        order.AddItem(menuItem1);
        order.AddItem(menuItem2);

        // Inserting data into SQLite tables
        DataHelper.InsertOrder(order, connectionString);
        DataHelper.InsertMenuItem(menuItem1, connectionString);
        DataHelper.InsertMenuItem(menuItem2, connectionString);
        DataHelper.InsertCustomer(customer, connectionString);
        DataHelper.InsertKitchenStaff(kitchenStaff, connectionString);

        // Display order details
        Console.WriteLine("Order Details:");
        Console.WriteLine(order.ToString());

        // Display menu item details
        Console.WriteLine("\nMenu Item Details:");
        Console.WriteLine(menuItem1.ToString());

        // Display customer details
        Console.WriteLine("\nCustomer Details:");
        Console.WriteLine(customer.ToString());

        // Kitchen staff preparing order
        kitchenStaff.PrepareOrder(order);

        // Update menu item price
        menuItem1.UpdatePrice(9.99m);
        Console.WriteLine($"\nUpdated Price for {menuItem1.Name}: {menuItem1.Price:C}");

        // Toggle menu item availability
        menuItem1.ToggleAvailability();
        Console.WriteLine($"\nAvailability for {menuItem1.Name}: {menuItem1.Available}");

        // Removing item from order
        order.RemoveItem(menuItem2);
        Console.WriteLine($"\nItems in order after removal: {order.Items.Count}");

        // Update order status
        order.UpdateStatus(Status.Completed);
        Console.WriteLine($"\nUpdated Order Status: {order.OrderStatus}");

        Console.ReadLine();
    }
}

public static class DataHelper
{
    public static void InsertOrder(Order order, string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO Orders (OrderID, OrderStatus, CustomerID) VALUES (@OrderID, @OrderStatus, @CustomerID)";
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@OrderStatus", (int)order.OrderStatus);

                // Handle nullable int (CustomerID) to DBNull conversion
                object customerIDValue = (object)order.Customer.CustomerID ?? DBNull.Value;
                command.Parameters.AddWithValue("@CustomerID", customerIDValue);

                command.ExecuteNonQuery();
            }
        }
    }

    public static void InsertMenuItem(MenuItems menuItem, string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO MenuItems (ItemID, Name, Description, Price, Available) VALUES (@ItemID, @Name, @Description, @Price, @Available)";
                command.Parameters.AddWithValue("@ItemID", menuItem.ItemID);
                command.Parameters.AddWithValue("@Name", menuItem.Name);
                command.Parameters.AddWithValue("@Description", menuItem.Description);
                command.Parameters.AddWithValue("@Price", menuItem.Price);
                command.Parameters.AddWithValue("@Available", menuItem.Available ? 1 : 0);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void InsertCustomer(Customer customer, string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO Customers (CustomerID, Name, Email) VALUES (@CustomerID, @Name, @Email)";
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void InsertKitchenStaff(KitchenStaff kitchenStaff, string connectionString)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO KitchenStaff (StaffID, Name, StaffSpecialization) VALUES (@StaffID, @Name, @StaffSpecialization)";
                command.Parameters.AddWithValue("@StaffID", kitchenStaff.StaffID);
                command.Parameters.AddWithValue("@Name", kitchenStaff.Name);
                command.Parameters.AddWithValue("@StaffSpecialization", (int)kitchenStaff.StaffSpecialization);
                command.ExecuteNonQuery();
            }
        }
    }
}

