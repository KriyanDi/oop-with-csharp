using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        private static void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();
        }

        private static void DozensCounter()
        {
            Incrementer incrementer = new Incrementer();
            Dozens dozensCounter = new Dozens(incrementer);

            incrementer.DoCount();
            Console.WriteLine("number of dozens = {0}", dozensCounter.DozensCount);

        }

        private static void RoomAlert()
        {
            Room room = new Room();
            room.Alert += OnAlert;
            room.Temp = 75;
        }

        private static void OnAlert(object s, EventArgs e)
        {
            Room room = (Room)s;
            Console.WriteLine("Shutting down, temp is {0}", room.Temp);
        }

        private static void PersonProperty()
        {
            Person person = new Person("Krisko");
            person.PropertyChanged += OnPropertyChanged;
            person.PersonName = "Ivan";
        }

        private static void OnPropertyChanged(object s, PropertyChangedEventArgs e)
        {
            Person person = (Person)s;
            Console.WriteLine("Property {0}, new {1}", e.PropertyName, person.PersonName);
        }

        static void Main(string[] args)
        {
            //CreateAndRaise();
            //DozensCounter();
            //RoomAlert();
            PersonProperty();
        }
    }
}
