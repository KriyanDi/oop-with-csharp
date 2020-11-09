using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Car
    {
        private int horsePower;
        private CarBrands brand;

        public enum CarBrands{FIAT, OPEL, BMW, SKODA};

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public CarBrands Brand
        {
            get { return brand; }
            set { brand = value; }
        }


        public Car(int horsePower)
        {
            HorsePower = horsePower;
        }


    }
}
