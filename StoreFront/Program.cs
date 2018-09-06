/* Author: Anderson Taylor
 * Date: 9/5/2018
 * File: Program.cs
 * Description: A simple storefront inventory management program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront
{
    abstract class Item                     //Abstract Item base class.
    {
        private string Name;

        public string GetName()             //Allows access to the name variable for printing info.
        {
            return Name;
        }

        private string Type;

        public string GetType()
        {
            return Type;
        }

        public Item(string name, string type, int num)      //Constructor
        {
            this.Name = name;
            this.Type = type;
            this.InStock = num;
        }

        public int InStock = 0; //int to store how many of an Item are in stock

        public abstract void Restock(int num);  //
        public abstract void Sell(int num);     //Abstract functions to be defined in the derived classes
        public abstract void Info();            //
    }
    class Book : Item           //Book class for adding books to the inventory. Inherits the Item class.
    {
        private double Price;   //Variable to store the price of the Book.

        public Book(string name, string type, double price, int num) : base(name, type, num)    //Constructor
        {
            this.Price = price;
        }

        public override void Restock(int num)   //Definition for the Restock function.
        {
            this.InStock += num;
        }

        public override void Info() //Print info about Item
        {
            Console.WriteLine("Title: {0}", this.GetName());
            Console.WriteLine("Type: {0}", this.GetType());
            Console.WriteLine("Price: {0:c}", this.Price);
            Console.WriteLine("Quantity in stock: {0}\n", this.InStock);
        }
        public override void Sell(int num)  //Sell function to remove items from inventory
        {
            if (num <= this.InStock)
            {
                this.InStock -= num;
                Console.WriteLine("\n{0} Items Sold!\n", num);
            }
            else
            {
                Console.WriteLine("\nInvalid Quantity Try Again!\n");
            }
        }
    }
    class Movie : Item  //Movie class for adding movies to the inventory. Inherits the Item class.
    {
        private double Price;

        public Movie(string name, string type, double price, int num) : base(name, type, num)   //Constructor
        {
            this.Price = price;
        }

        public override void Restock(int num)
        {
            this.InStock += num;
        }

        public override void Info()
        {
            Console.WriteLine("Type: {0}", this.GetType());
            Console.WriteLine("Title: {0}", this.GetName());
            Console.WriteLine("Price: {0:c}", this.Price);
            Console.WriteLine("Quantity in stock: {0}\n", this.InStock);
        }
        public override void Sell(int num)
        {
            if (num <= this.InStock)
            {
                this.InStock -= num;
                Console.WriteLine("\n{0} Items Sold!\n", num);
            }
            else
            {
                Console.WriteLine("\nInvalid Quantity Try Again!\n");
            }            
            
        }
    }
    class Game : Item   //Game class for adding games to the inventory. Inherits the Item class.
    {
        private double Price;
        private string Platform;    //Added a platform variable to denote the platform the game can be used on.

        public Game(string name, string type, double price, int num, string platform) : base(name, type, num)
        {
            this.Price = price;
            this.Platform = platform;
        }

        public override void Restock(int num)
        {
            this.InStock += num;
        }

        public override void Info()
        {
            Console.WriteLine("Type: {0}", this.GetType());
            Console.WriteLine("Platform: {0}", this.Platform);
            Console.WriteLine("Title: {0}", this.GetName());
            Console.WriteLine("Price: {0:c}", this.Price);
            Console.WriteLine("Quantity in stock: {0}\n", this.InStock);
        }
        public override void Sell(int num)
        {
            if (num <= this.InStock)
            {
                this.InStock -= num;
                Console.WriteLine("\n{0} Items Sold!\n", num);
            }
            else
            {
                Console.WriteLine("\nInvalid Quantity Try Again!\n");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;   //bool to exit the menu loop

            List<Item> Inventory = new List<Item>();    //Create a List of Items

            Inventory.Add(new Book("Bible", "Book", 10.00, 5));             //Preload some inventory items.
            Inventory.Add(new Movie("Castaway", "Movie", 5.00, 15));
            Inventory.Add(new Movie("Spider Man", "Movie", 12.00, 8));
            Inventory.Add(new Game("Cyberpunk 2077", "Game", 60.00, 100, "PC"));


            while (loop)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("     Store Inventory");
                Console.WriteLine("**************************");
                Console.WriteLine("Please choose an option...\n");
                Console.WriteLine("1: List Inventory");
                Console.WriteLine("2: Sell Item");
                Console.WriteLine("3: Restock Item");
                Console.WriteLine("4: Individual Item Detail");
                Console.WriteLine("5: Add Item To Inventory");
                Console.WriteLine("6: Exit\n");

                switch (Convert.ToInt32(Console.ReadLine()))        //Switch to implement the menu options.
                {
                    default:
                        break;

                    case 1:     //List all items in the invnentory and their part numbers.
                        int idx = 0;
                        foreach(Item i in Inventory)
                        {
                            Console.WriteLine("\nPart Number: {0}", idx);
                            
                            i.Info();
                            idx++;
                        }

                        break;

                    case 2:     //Sell an item from the inventory
                        int n, q;
                        Console.WriteLine("\nPlease enter the item number of the item you would like to purchase...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nHow many would you like to purchase?");
                        q = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Sell(q);

                        break;

                    case 3:     //Restock an item in the inventory                      
                        Console.WriteLine("\nPlease enter the item number of the item you would like to restock...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nHow many would you like to restock?");
                        q = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Restock(q);

                        break;

                    case 4:     //Print the info of a single item.
                        Console.WriteLine("\nPlease enter the item number of the item you would like information on...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Info();

                        break;

                    case 5:     //Add an item to the inventory.
                        Console.WriteLine("\nEnter 1 to add a book, 2 to add a movie, and 3 to add a game...");
                        n = Convert.ToInt32(Console.ReadLine());

                        switch (n)      //Switch to find the item type.
                        {
                            default:
                                break;

                            case 1:
                                string name;
                                double price;
                                int quantity;

                                Console.WriteLine("\nWhat is the name of the book?");
                                name = Console.ReadLine();
                                Console.WriteLine("\nHow Much does it cost?");
                                price = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("\nHow many are you adding?");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                Inventory.Add(new Book(name, "Book", price, quantity));

                                break;

                            case 2:                               
                                Console.WriteLine("\nWhat is the name of the movie?");
                                name = Console.ReadLine();
                                Console.WriteLine("\nHow Much does it cost?");
                                price = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("\nHow many are you adding?");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                Inventory.Add(new Book(name, "Movie", price, quantity));

                                break;

                            case 3:
                                string platform;
                                
                                Console.WriteLine("\nWhat is the name of the game?");
                                name = Console.ReadLine();
                                Console.WriteLine("\nWhat platform is the game on?");
                                platform = Console.ReadLine();
                                Console.WriteLine("\nHow Much does it cost?");
                                price = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("\nHow many are you adding?");
                                quantity = Convert.ToInt32(Console.ReadLine());
                                Inventory.Add(new Game(name, "Game", price, quantity, platform));

                                break;
                        }

                        break;
                        
                    case 6:     //Exit the program.
                        loop = false;
                        break;
                }
            }
        }
    }
}
