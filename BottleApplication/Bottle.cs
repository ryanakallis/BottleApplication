using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleApplication
{
    public class Bottle
    {

        public Bottle(double r = 0, double h = 0)
        {
            if (r < 0 || h < 0)
            {
                throw new InvalidOperationException("The dimensions provided for the bottle are invalid");
            }
            this.Height = Math.Round(h, 2);
            this.Radius = Math.Round(r, 2);
            Console.WriteLine(Information());
        }

        public string Information()
        {
            return "The bottle height is " + Height + ", and the radius is " + Radius + ". The contents is currently " + Contents + "ml(Total capacity: " + Volume + "ml).";
        }

        private double _radius;
        public double Radius
        {
            get
            {
                return _radius;
            }
            private set
            {
                if (Math.Round(_radius, 2) != Math.Round(value, 2))
                {
                    _radius = value;

                }
            }
        }

        private double _height;
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

        public double Volume
        {
            get
            {
                return Math.Round((Math.PI * (Radius * Radius) * Height),2);
            }
        }
        
        /// <summary>
        /// Fills the bottles remaining volume.
        /// </summary>
        public void FillBottle()
        {
            double ml = 0.01;

            Console.WriteLine("Begin Pouring\r\n");

            while (Volume > Contents)
            {
                Console.WriteLine("Fill percentage: " + ((Contents / Volume) * 100));

                SetContents(ml);
            }

            Console.WriteLine("Bottle filled with " + Contents + "ml.");
        }

        /// <summary>
        /// Adjusts the Contents by the given amount
        /// </summary>
        /// <param name="ml"></param>
        private void SetContents(double ml)
        {
            Console.WriteLine("Bottle contains " + Contents + "ml.");

            if (Contents + ml > Volume)
            {
                throw new InvalidOperationException(string.Format("Cannot add {0}ml as the bottle's maximum volume is {1}ml. Contents: {2}ml", ml, Volume, Contents));
            }
            else if (Contents + ml < 0)
            {
                throw new InvalidOperationException(string.Format("Cannot remove {0}ml as the bottle contains {1}ml.", (ml < 0) ? ml * -1 : ml, Contents));
            }

            Contents = Contents + ml;

            Console.WriteLine("After adjustment bottle contains " + Contents + "ml.");
        }

        /// <summary>
        /// Adds amount to contents.
        /// </summary>
        /// <param name="ml"></param>
        public void Add(double ml)
        {
            try
            {
                SetContents(ml);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(string.Format("\r\nError adding to bottle contents.\r\n{0}",ex.Message));
            }
            Console.WriteLine(string.Format("\r\nContents in bottle:{0}", Contents + "ml."));
        }

        /// <summary>
        /// Removes amount from Contents.
        /// </summary>
        /// <param name="ml"></param>
        public void Remove(double ml)
        {
            if (ml > 0)
            {
                ml = ml * -1;
            }
                        
            try
            {
                SetContents(ml);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(string.Format("\r\nError removing to bottle contents.\r\n{0}", ex.Message));
            }
            Console.WriteLine(string.Format("\r\nContents in bottle:{0}", Contents + "ml."));
        }
    }
}
