using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleApplication
{
    public class Bottle
    {
        /// <summary>
        /// Creates a new bottle with the given diameter and height dimensions.
        /// </summary>
        /// <param name="diameter"></param>
        /// <param name="height"></param>
        public Bottle(double diameter, double height)
        {
            if (diameter <= 0.0D || height <= 0.0D)
            {
                throw new InvalidOperationException("The dimensions provided for the bottle are invalid.");
            }
            Height = Math.Round(height, 2);
            Diameter = Math.Round(diameter, 2);
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// Returns a string representation of the bottle.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "The bottle height is " + Height + ", and the radius is " + Diameter + ". The contents is currently " + Contents + "ml(Total capacity: " + Volume + "ml).";
        }

        private double _diameter;
        /// <summary>
        /// Get's or sets the diameter of the bottle.
        /// </summary>
        public double Diameter
        {
            get
            {
                return _diameter;
            }
            private set
            {
                if (Math.Round(_diameter, 2) != Math.Round(value, 2))
                {
                    _diameter = Math.Round(value, 2);

                }
            }
        }

        private double _height;
        /// <summary>
        /// Get's or sets the height of the bottle.
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            private set
            {
                if (Math.Round(_height, 2) != Math.Round(value, 2))
                {
                    _height = Math.Round(value,2);
                }
            }
        }

        private double _contents;
        /// <summary>
        /// Get's or sets the contents of the bottle.
        /// </summary>
        public double Contents
        {
            get
            {
                return _contents;
            }
            private set
            {
                if (Math.Round(_contents, 2) != Math.Round(value, 2))
                {
                    _contents = Math.Round(value,2);
                }
            }
        }

        /// <summary>
        /// Get's the maximum content value of the bottle can contain.
        /// </summary>
        public double Volume
        {
            get
            {
                return Math.Round((Math.PI * ((Diameter / 2)*(Diameter / 2)) * Height),2);
            }
        }

        /// <summary>
        /// Adjusts the bottles contents by the given amount.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if trying to add more than the bottles total volume.</exception>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if trying to remove more than the bottles current contents.</exception>
        private void SetContents(double ml)
        {
            if (Contents + ml > Volume)
            {
                throw new InvalidOperationException(string.Format("Cannot add {0}ml as the bottles contents is currently {2}ml, and the bottles maximum volume is {1}ml.", ml, Volume, Contents));
            }
            else if (Contents + ml < 0)
            {
                throw new InvalidOperationException(string.Format("Cannot remove {0}ml as the bottle contains a total of {1}ml.", (ml < 0) ? ml * -1 : ml, Contents));
            }

            Contents = Contents + ml;
        }
        
        /// <summary>
        /// Adds amount to bottle contents.
        /// </summary>
        /// <param name="ml"></param>
        public void Fill(double ml)
        {
            SetContents(ml);
        }
        
        /// <summary>
        /// Removes amount from bottle contents.
        /// </summary>
        /// <param name="ml"></param>
        public void Pour(double ml)
        {
            if (ml > 0)
            {
                ml = ml * -1;
            }

            SetContents(ml);
        }

    }
}
