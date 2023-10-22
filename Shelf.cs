using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExerciseRefrigerator
{
    public class Shelf
    {
        public static int UniqIdShelf = 0;
        public int Id { get; }
        private int _floor;
        private int _freeSpace;
        private int _currentFreeSpace;
        public List<Item> Items { get; set; }
        //public Shelf()
        //{
        //    Id = UniqIdShelf++;
        //}
        public Shelf(int floor, int freeSpace)
        {
            Id = UniqIdShelf++;
            Floor = floor;
            FreeSpace = freeSpace;
            CurrentFreeSpace = freeSpace;
            Items = new List<Item>();
        }

        public int Floor
        {
            get
            { return _floor; }

            set
            {
                try
                {
                    if (value <= 0) throw new Exception("invalide size");
                    _floor = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            }
        }
        public int FreeSpace
        {
            get
            { return _freeSpace; }

            set
            {
                try
                {
                    if (value <= 0) throw new Exception("invalide size");
                    _freeSpace = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("שגיאה: " + e.Message);
                }

            }
        }
        public int CurrentFreeSpace
        {
            get
            { return _currentFreeSpace; }

            set
            {
                try
                {
                    if (value <= 0) throw new Exception("invalide size");
                    _currentFreeSpace = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("שגיאה: " + e.Message);
                }
            }
        }
        //public int GetFreeSpaceRest()
        //{
        //    int TakeupPspace = 0;

        //    for (int i = 0; i < Items.Count; i++)
        //    {
        //        TakeupPspace += Items[i].Size;
        //    }
        //    return FreeSpace - TakeupPspace;

        //}
        public int GetCurrentFreeSpace()
        {
            return CurrentFreeSpace;
        }

        public bool AddItemToShelf(Item item, Shelf shelf)
        {
            if (item.Size <= this.GetCurrentFreeSpace())
            {
                item.Shelf = shelf;
                this.Items.Add(item);
                this.CurrentFreeSpace -= item.Size;
                return true;

            }
            return false;
        }

        //4
        public Item SearchItemOnItems(int itemId)
        {
            foreach (Item item in Items)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }
            return null;
        }

        //4
        public Item RemoveItemFromShelf(int itemId)
        {
            Item item = SearchItemOnItems(itemId);
            if (item != null)
            {
                item.Shelf = null;
                this.Items.Remove(item);
                this.CurrentFreeSpace += item.Size;
            }

            return item;
        }

        public void RemoveItemByKashrutAndDate(Kashrut kashrut, int countDay)
        {
            DateTime currentTime = DateTime.Now;
            DateTime ExpirationDateFinall = currentTime.AddDays(countDay);
            List<Item> filteredNumbers = new List<Item>();

            foreach (Item item in Items)
            {
                if (item.Kashrut == kashrut && item.ExpirationDate < ExpirationDateFinall)
                    RemoveItemFromShelf(item.Id);
            }

        }

        //4
        public Item REmoveItem1(Item item)
        {
            item.Shelf = null;
            this.Items.Remove(item);
            this.CurrentFreeSpace += item.Size;
            return item;
        }

        public String CleanExpiredFromShelf()
        {
            DateTime currentTime = DateTime.Now;
            String itemlist = "";
            foreach (Item item in Items)
            {
                itemlist = item.ToString() + "\n";
                if (item.ExpirationDate < currentTime)
                {
                    REmoveItem1(item);
                }

            }

            // Items.RemoveAll(item => item.ExpirationDate < DateTime.Now);

            return itemlist;
        }

        public String PrepareForShopping2(Kashrut kashrut, int countDay)
        {
            DateTime currentTime = DateTime.Now;
            DateTime ExpirationDateFinall = currentTime.AddDays(countDay);
            String itemlist = "";
            foreach (Item item in Items)
            {
                itemlist = item.ToString() + "\n";
                if (item.Kashrut == kashrut && item.ExpirationDate < ExpirationDateFinall)
                {
                    itemlist = item.ToString() + "\n";
                    RemoveItemFromShelf(item.Id);
                }

            }
            // Items.RemoveAll(item => item.ExpirationDate < DateTime.Now);
            return itemlist;
        }

        public List<Item> FindItemsByTypeAndKashrut(Kashrut kashrut, Type type)
        {
            List<Item> items = new List<Item>();
            foreach (Item item in this.Items)
            {
                if (item.Type == type && item.Kashrut == kashrut && item.ExpirationDate >= DateTime.Now)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public override string ToString()
        {
            String displayShelf = $"Shelf number: {Id}\nFloor: {Floor}\nFree space: {CurrentFreeSpace}\n";
            for (int i = 0; i < Items.Count; i++)
                displayShelf += Items[i].ToString();
            return displayShelf;
        }

    }
}
