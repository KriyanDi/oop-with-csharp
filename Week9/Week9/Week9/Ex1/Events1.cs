using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    delegate void OnFiredEventHandler();

    class Employee
    {
        public event OnFiredEventHandler Fired;
    }

    //////////////////////////////////////////////

    public interface IDrawingObject
    {
        event EventHandler ShapeChanged;
    }

    public class MyEventArgs : EventArgs
    {

    }

    public class Shape : IDrawingObject
    {
        public event EventHandler ShapeChanged;

        void ChangeShape()
        {
            //smth before the event
            OnShapeChanged(new MyEventArgs(/*args*/));
            //smth after the event
        }

        protected virtual void OnShapeChanged(MyEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }

    //////////////////////////////////////////////
    public class Pub
    {
        public event Action OnChange = delegate { };
        public void Raise()
        {
            OnChange?.Invoke();
        }
    }

    //////////////////////////////////////////////

    class Incrementer
    {
        public event EventHandler CountADozen;

        public void DoCount()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0)
                {
                    CountADozen?.Invoke(this, null);
                }
            }
        }
    }

    class Dozens
    {
        public int DozensCount { get; set; }

        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountADozen += IncrementDozensCount;
        }

        void IncrementDozensCount(object source, EventArgs e)
        {
            DozensCount++;
        }
    }

    //////////////////////////////////////////////
    class Room
    {
        public event EventHandler Alert;

        private int temp;

        public int Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                if (this.temp > 60)
                {
                    HotelData hotelData = new HotelData
                    {
                        HotelName = "5 star Hotel",
                        TotalRooms = 450
                    };

                    Alert?.Invoke(this, hotelData);
                }
            }
        }

    }

    class HotelData : EventArgs
    {
        public string HotelName { get; set; }
        public int TotalRooms { get; set; }
    }

    //////////////////////////////////////////////

    public class Person : INotifyPropertyChanged
    {
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {

        }

        public Person(string value)
        {
            this.name = value;
        }

        public string PersonName
        {
            get => name;
            set 
            {
                name = value;
                OnPropertyChanged("PersonName");
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (name.Equals(nameof(PersonName)))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
