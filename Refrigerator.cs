using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRefrigerator
{
    public class Refrigerator
    {
        public static int UniqIdFriger = 0;
        public int Id { get; }
        private string _model;
        private string _color;
        private int _numShelves;
        public List<Shelf> Shelves { get; set; }
        public Refrigerator()
        {

        }
        public Refrigerator(string model, string color, int numShelves)
        {
            Id = UniqIdFriger++;
            Model = model;
            Color = color;
            NumShelves = numShelves;
            Shelves = new List<Shelf>();
        }

        public string Model
        {
            get
            {
                return this._model;
            }
            set
            {
                try
                {
                    if (value.Length <= 1) throw new Exception("invalide model");
                    _model = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public string Color
        {
            get
            {
                return this._color;
            }
            set
            {
                try
                {
                    if (value.Length <= 1) throw new Exception("invalide color");
                    _color = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public int NumShelves
        {
            get
            { return _numShelves; }

            set
            {
                try
                {
                    if (value <= 0) throw new Exception("invalide size");
                    _numShelves = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
            }
        }

        //2
        public int GetFreeSpace()
        {
            int freeSpace = 0;

            //for (int i = 0; i < NumShelves; i++)
            //{
            //    freeSpace += Shelves[i].GetCurrentFreeSpace();
            //}
            freeSpace = Shelves.Sum(item => item.GetCurrentFreeSpace() + freeSpace);
            return freeSpace;
        }

        //3
        public bool AddItemForRefrigerator(Item item)
        {
            foreach (Shelf shelf in Shelves)
            {
                if (shelf.AddItemToShelf(item, shelf))
                {
                    Console.WriteLine("The product add succses to the fridge");
                    return true;
                }
            }
            Console.WriteLine("Their is not place in fridge");
            return false;
        }


        //4
        public Item RemoveItemForRefrigerator(int itemId)
        {
            Item item = new Item();
            foreach (Shelf shelf in Shelves)
            {
                item = shelf.RemoveItemFromShelf(itemId);
                if (item != null)
                    break;
            }
            //item=(Item)Shelves.Where(s => s.REmoveItem(itemId)!=null);
            return item;
        }

        //5*
        public String CleanExpiredFromRefrigerator()
        {
            String ItemsCleanExpired = "";
            foreach (Shelf shelf in Shelves)
            {
                ItemsCleanExpired += shelf.CleanExpiredFromShelf();
            }
            return ItemsCleanExpired;
        }


        //6
        public List<Item> FindItemsByTypeAndKashrut(Kashrut kashrut, Type type)
        {
            List<Item> itemsTypeAndKashrut = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                itemsTypeAndKashrut.AddRange(shelf.FindItemsByTypeAndKashrut(kashrut, type));
            }

            return itemsTypeAndKashrut;
        }


        //7.1
        public List<Item> SortItemsDescByExpirationDate()
        {

            List<Item> itemsSorted = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                itemsSorted.AddRange(shelf.Items);
            }
            itemsSorted.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
            return itemsSorted;
        }

        //8.2
        public List<Shelf> SortShelvesByFreeSpace(List<Shelf> shelves)
        {
            List<Shelf> shelvesSorted = new List<Shelf>();
            shelvesSorted.AddRange(shelves);
            shelvesSorted.Sort((x, y) => x.FreeSpace - y.FreeSpace);
            return shelvesSorted;
        }

        public List<Refrigerator> SortRefrigeratorsByFreeSpace(List<Refrigerator> refrigerators)
        {
            List<Refrigerator> refrigeratorsSorted = refrigerators;
            refrigeratorsSorted.Add(this);
            refrigeratorsSorted.Sort((x, y) => y.GetFreeSpace() - x.GetFreeSpace());
            return refrigeratorsSorted;
        }

        public void CleansByExpirationdateAndKosher(Kashrut kashrut, int countDay)
        {
            DateTime currentTime = DateTime.Now;
            DateTime ExpirationDateFinall = currentTime.AddDays(countDay);
            List<Item> filteredNumbers = new List<Item>();

            foreach(Shelf shelf in Shelves)
            {
                shelf.RemoveItemByKashrutAndDate(kashrut,countDay);
            }           
        }
        public void PrepareForShopping()
        {
            if (this.GetFreeSpace() < 20)
            {
              CleanExpiredFromRefrigerator();
                if (this.GetFreeSpace() < 20)
                {
                    CleansByExpirationdateAndKosher(Kashrut.deary, 3);
                    Console.WriteLine("Throw away all dairy items that are valid for less than three days.");
                    if (this.GetFreeSpace() < 20)
                    {
                        CleansByExpirationdateAndKosher(Kashrut.meet, 7);
                        Console.WriteLine("Throw away all meeting items that are valid for less than seven days.");
                        if (this.GetFreeSpace() < 20)
                        {
                            CleansByExpirationdateAndKosher(Kashrut.parve, 1);
                            Console.WriteLine("Throw away all meeting items that are valid for less than one days.");
                            if (this.GetFreeSpace() < 20)
                                Console.WriteLine("No their is place in the fridgre ,This is not the time to shop.");
                        }
                    }
                }


            }

        }

        public override string ToString()
        {
            String displayShelf = $"Warehouse number: {Id}\nModel: {Model}\nColor: {Color}\nNumber of shelves: {NumShelves}\n";
            for (int i = 0; i < Shelves.Count; i++)
                displayShelf += Shelves[i].ToString();
            return displayShelf;
        }



    }
}
