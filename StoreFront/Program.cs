using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront
{
    abstract class Item
    {
        private string Name;

        public string GetName()
        {
            return Name;
        }

        private string Type;

        public string GetType()
        {
            return Type;
        }

        public Item(string name, string type, int num)
        {
            this.Name = name;
            this.Type = type;
            this.InStock = num;
        }

        public int InStock = 0;

        public abstract void Restock(int num);
        public abstract void Sell(int num);
        public abstract void Info();
    }
    class Book : Item
    {
        private double Price;

        public Book(string name, string type, double price, int num) : base(name, type, num)
        {
            this.Price = price;
        }

        public override void Restock(int num)
        {
            this.InStock += num;
        }

        public override void Info()
        {
            Console.WriteLine("Title: {0}", this.GetName());
            Console.WriteLine("Type: {0}", this.GetType());
            Console.WriteLine("Price: {0:c}", this.Price);
            Console.WriteLine("Quantity in stock: {0}\n", this.InStock);
        }
        public override void Sell(int num)
        {
            this.InStock -= num;
            Console.WriteLine("{0} Items Sold!\n", num);
        }
    }
    class Movie : Item
    {
        private double Price;

        public Movie(string name, string type, double price, int num) : base(name, type, num)
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
    class Game : Item
    {
        private double Price;
        private string Platform;

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
            bool loop = true;

            List<Item> Inventory = new List<Item>();
            Inventory.Add(new Book("poo", "Book", 10.00, 5));
            Inventory.Add(new Movie("pokemon", "Movie", 5.00, 15));
            Inventory.Add(new Movie("notebook", "Movie", 12.00, 8));

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

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    default:
                        break;

                    case 1:
                        int idx = 0;
                        foreach(Item i in Inventory)
                        {
                            Console.WriteLine("\nPart Number: {0}", idx);
                            
                            i.Info();
                            idx++;
                        }

                        break;

                    case 2:
                        int n, q;
                        Console.WriteLine("\nPlease enter the item number of the item you would like to purchase...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nHow many would you like to purchase?");
                        q = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Sell(q);

                        break;

                    case 3:                     
                        Console.WriteLine("\nPlease enter the item number of the item you would like to restock...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nHow many would you like to restock?");
                        q = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Restock(q);

                        break;

                    case 4:
                        Console.WriteLine("\nPlease enter the item number of the item you would like information on...");
                        n = Convert.ToInt32(Console.ReadLine());
                        Inventory[n].Info();

                        break;

                    case 5:
                        Console.WriteLine("\nEnter 1 to add a book, 2 to add a movie, and 3 to add a game...");
                        n = Convert.ToInt32(Console.ReadLine());

                        switch (n)
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
                        
                    case 6:
                        loop = false;
                        break;
                }
            }
        }
    }
}
