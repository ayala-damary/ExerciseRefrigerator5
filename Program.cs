using System;
using System.Collections.Generic;

namespace ExerciseRefrigerator
{
    public class Program
    {
        public static void Initialization()
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            bool stopCreateingRefrigerators = true;
            while (stopCreateingRefrigerators)
            {
                Console.WriteLine("Insert a model of the refrigerator");
                String model = Console.ReadLine();
                Console.WriteLine("Insert a color of the refrigerator");
                string color = Console.ReadLine();
                Console.WriteLine("Insert a num shelves of the refrigerator");
                int numShelves = int.Parse(Console.ReadLine());
                Refrigerator refrigerator = new Refrigerator(model, color, numShelves);
                int floor, freeSpace;
                for (int i = 0; i < numShelves; i++)
                {
                    Console.WriteLine("Enter shelf number from 1 till {0}", numShelves);
                    floor = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter free space to orginize");
                    freeSpace = int.Parse(Console.ReadLine());
                    Shelf shelf = new Shelf(floor, freeSpace);
                    refrigerator.Shelves.Add(shelf);
                }
                //לחלק לפונקצית יצירת פריט!!
                String name;
                DateTime ExpirationDate = new DateTime();
                int size;
                bool item1 = true;
                while (item1)
                {
                    Console.WriteLine("Press 0 no creating the items");
                    item1 = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Insert a name of the item");
                    name = Console.ReadLine();
                    Console.WriteLine("Choose a Type (0=drink, 1=eat):");
                    int type = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Choose a kashrut (0=meet, 1=parve, 2=deary):");
                    int kashrut = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert a expiration date of the item");
                    ExpirationDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Insert a size of the item");
                    size = int.Parse(Console.ReadLine());
                    Item item = new Item(name, (Type)type, (Kashrut)kashrut, ExpirationDate, size);
                }

            }
            Console.WriteLine("Press 0 to finish with creating the refrigerator");
            stopCreateingRefrigerators = bool.Parse(Console.ReadLine());
        }

        public static void DisplayRemoveItemForRefrigerator(Refrigerator refrigerator)
        {
            Console.WriteLine("Enter an item code you want to remove:");
            int code = int.Parse(Console.ReadLine());
            Item item = new Item();
            item = refrigerator.RemoveItemForRefrigerator(code);
            if (item == null)
                Console.WriteLine("there is not this code");
            else
                Console.WriteLine("This item has been successfully removed:{0}", item);
        }

        public static void DisplayFindItemsByTypeAndKashrut(Refrigerator refrigerator)
        {
            Console.WriteLine("Choose a color (0=meet, 1=parve, 2=deary): ");
            int kashrut = int.Parse(Console.ReadLine());

            if (Enum.IsDefined(typeof(Kashrut), kashrut))
            {
                Console.WriteLine("Choose a type (0=drink, 1=eat):");
                int type = int.Parse(Console.ReadLine());
                Kashrut userChoiceKashrut = (Kashrut)kashrut;
                if (Enum.IsDefined(typeof(Type), type))
                {
                    Type userChoiceType = (Type)type;
                    List<Item> t = refrigerator.FindItemsByTypeAndKashrut(userChoiceKashrut, userChoiceType);
                    foreach (Item t1 in t)
                        Console.WriteLine(t1.ToString());
                }
            }
        }

        public static void DisplaySortItemsDescByExpirationDate(Refrigerator refrigerator)
        {
            List<Item> t2 = refrigerator.SortItemsDescByExpirationDate();
            foreach (Item t1 in t2)
                Console.WriteLine(t1.ToString());
        }

        public static void DisplaySortShelvesByFreeSpace(Refrigerator refrigerator)
        {
            List<Shelf> s3 = refrigerator.SortShelvesByFreeSpace(refrigerator.Shelves);
            foreach (Shelf s1 in s3)
                Console.WriteLine(s1.ToString());
        }

        public static void DisplayAddItemForRefrigerator(Refrigerator refrigerator)
        {
            String name;
            DateTime ExpirationDate = new DateTime();
            int size;
            Console.WriteLine("Insert a name of the item");
            name = Console.ReadLine();
            Console.WriteLine("Choose a Type (0=drink, 1=eat):");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a kashrut (0=meet, 1=parve, 2=deary):");
            int kashrut = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert a date of the item");
            ExpirationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Insert a size of the item");
            size = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(Kashrut), kashrut))
            {
                Kashrut userChoiceKashrut = (Kashrut)kashrut;
                if (Enum.IsDefined(typeof(Type), type))
                {
                    Type userChoiceType = (Type)type;
                    Item itemCreating = new Item(name, userChoiceType, userChoiceKashrut, ExpirationDate, size);
                    Console.WriteLine(refrigerator.AddItemForRefrigerator(itemCreating));
                }
            }
        }

        public static void DisplaySortRefrigeratorsByFreeSpace(List<Refrigerator> refrigerators,Refrigerator refrigerator)
        {
            List<Refrigerator> refrigeratorsSorted = refrigerator.SortRefrigeratorsByFreeSpace(refrigerators);
            foreach (Refrigerator refrigerator1 in refrigeratorsSorted)
                Console.WriteLine(refrigerator1.ToString() + "\n");
        }

        public static void DisplayAllItemsRefrigerator(Refrigerator refrigerator)
        {
            Console.WriteLine("Details of the refrigerator and its contents:\n{0}", refrigerator.ToString());
        }

        public static void DisplayFreeSpaceRefrigerator(Refrigerator refrigerator)
        {
            Console.WriteLine("space is left in the refrigerator:\n{0}", refrigerator.GetFreeSpace());
        }

        public static void DisplayCleanExpiredFromRefrigerator(Refrigerator refrigerator)
        {
            Console.WriteLine(refrigerator.CleanExpiredFromRefrigerator());
        }
        public static void Main(string[] args)
        {
            //Program.Initialization();-פונקציה לאתחול ע"י המשתמש
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            Refrigerator refrigerator = new Refrigerator("LG", "לבן", 5);

            Shelf shelf1 = new Shelf(1, 100);
            Shelf shelf2 = new Shelf(2, 200);
            Shelf shelf3 = new Shelf(3, 300);
            Shelf shelf4 = new Shelf(4, 400);
            Shelf shelf5 = new Shelf(5, 500);


            refrigerator.Shelves.Add(shelf1);
            refrigerator.Shelves.Add(shelf2);
            refrigerator.Shelves.Add(shelf3);
            refrigerator.Shelves.Add(shelf4);
            refrigerator.Shelves.Add(shelf5);

            Item item1 = new Item("milk", Type.drink, Kashrut.parve, DateTime.Now.AddDays(7), 100);
            Item item2 = new Item("eges", Type.eat, Kashrut.meet, DateTime.Now.AddDays(3), 200);
            Item item3 = new Item("bread", Type.eat, Kashrut.parve, DateTime.Now.AddDays(1), 300);
            Item item4 = new Item("meet", Type.drink, Kashrut.parve, DateTime.Now.AddDays(6), 400);
            Item item5 = new Item("vegteble", Type.drink, Kashrut.parve, DateTime.Now.AddDays(-1), 500);

            refrigerator.AddItemForRefrigerator(item1);
            refrigerator.AddItemForRefrigerator(item2);
            refrigerator.AddItemForRefrigerator(item3);
            refrigerator.AddItemForRefrigerator(item4);
            refrigerator.AddItemForRefrigerator(item5);

           // refrigerators.Add(refrigerator);
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Display all items");
                Console.WriteLine("2. Show how much space is left in the warehouse");
                Console.WriteLine("3. Add item to warehouse");
                Console.WriteLine("4. Remove item from warehouse");
                Console.WriteLine("5. Clear the warehouse");
                Console.WriteLine("6. What do I want to eat?");
                Console.WriteLine("7. Sort by expiration date");
                Console.WriteLine("8. Sort by available space");
                Console.WriteLine("9. Sort by available space in the warehouse");
                Console.WriteLine("10. Preparing for shopping");
                Console.WriteLine("100. Preparing for close this system ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayAllItemsRefrigerator(refrigerator);
                        break;
                    case 2:
                        DisplayFreeSpaceRefrigerator(refrigerator);
                        break;
                    case 3:
                        DisplayAddItemForRefrigerator(refrigerator);
                        break;
                    case 4:
                        DisplayRemoveItemForRefrigerator(refrigerator);
                        break;
                    case 5:
                        DisplayCleanExpiredFromRefrigerator(refrigerator);
                        break;
                    case 6:
                        DisplayFindItemsByTypeAndKashrut(refrigerator);
                        break;
                    case 7:
                        DisplaySortItemsDescByExpirationDate(refrigerator);
                        break;
                    case 8:
                        DisplaySortShelvesByFreeSpace(refrigerator);
                        break;
                    case 9:
                        DisplaySortRefrigeratorsByFreeSpace(refrigerators,refrigerator);
                        break;
                    case 10:                       
                        refrigerator.PrepareForShopping();
                        break;
                    case 100:
                        running = false;
                        break;

                }
            }
        }
    }
}
