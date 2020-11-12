using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob5
{
    public class Card
    {
        #region Fields
        #region public

        #endregion

        #region private
        private string face;
        private string suit;

        #endregion
        #endregion

        #region Constructors
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        #endregion

        #region Properties
        public string Face
        {
            get { return face; }
            set { face = value; }
        }


        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        #endregion

        #region Methods
        #region public
        public override string ToString()
        => $"{face} of {suit}";
        #endregion

        #region private

        #endregion
        #endregion
    }
}