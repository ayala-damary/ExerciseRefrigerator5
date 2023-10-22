using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseRefrigerator
{
    public enum Kashrut
    {
        meet,
        parve,
        deary
    }
    public enum Type
    {
        drink,
        eat
    }
    public class Item
    {
        public static int UniqIdItem = 0;
        public int Id { get; }
        private string _name;
        public Shelf Shelf { get; set; }
        private Type _type;
        public Kashrut _kashrut { get; set; }
        public DateTime _expirationDate;
        public int _size;

        public Item(string name, Type type, Kashrut kashrut, DateTime expirationDate, int size)
        {
            Id = UniqIdItem++;
            Name = name;
            Shelf = null;
            Type = type;
            Kashrut = kashrut;
            ExpirationDate = expirationDate;
            Size = size;
        }
        public Item(string v)
        {
            Id = UniqIdItem++;
        }

        public Item()
        {
            Id = UniqIdItem++;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                try
                {
                    if (value.Length <= 1) throw new Exception("invalide name");
                    _name = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public Type Type
        {
            get
            {
                return this._type;
            }
            set
            {
                try
                {

                    if (Enum.IsDefined(typeof(Type), value))
                    {
                        _type = (Type)value;
                    }
                    else throw new Exception("invalide type");

                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public Kashrut Kashrut
        {
            get
            {
                return this._kashrut;
            }
            set
            {
                try
                {
                    if (Enum.IsDefined(typeof(Kashrut), value))
                    {
                        _kashrut = (Kashrut)value;
                    }
                    else
                        throw new Exception("invalide name");
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public DateTime ExpirationDate
        {
            get
            {
                return this._expirationDate;
            }
            set
            {
                try
                {
                    _expirationDate = Convert.ToDateTime(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error datetime");
                }

            }
        }

        public int Size
        {
            get
            {
                return this._size;
            }
            set
            {
                try
                {
                    if (value is int) throw new Exception("invalide size");
                    _size = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }
        }

        public override string ToString()
        {
            return $"Item Number: {Id}\nName: {Name}\nType: {Type}\nKosher: {Kashrut}\nExpiration Date: {ExpirationDate}\nSize: {Size}\n";
            //return $"Item Number: {Id}\nName: {Name}\nShelf: {Shelf.Floor}\nType: {Type}\nKosher: {Kashrut}\nExpiration Date: {ExpirationDate}\nSize: {Size}\n";
        }


    }
}
