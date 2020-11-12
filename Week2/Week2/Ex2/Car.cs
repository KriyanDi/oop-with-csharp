using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Car
    {
        #region Constant Fields
        #region public
        public enum CarBrands { FIAT, OPEL, BMW, SKODA };
        #endregion

        #region private

        #endregion
        #endregion

        #region Fields
        #region public

        #endregion

        #region private
        private int horsePower;
        private CarBrands brand;

        #endregion
        #endregion

        #region Constructors
        public Car(int horsePower)
        {
            HorsePower = horsePower;
        }

        #endregion

        #region Properties
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

        #endregion
    }
}
