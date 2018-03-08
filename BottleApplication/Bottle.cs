using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleApplication
{
    public class Bottle
    {
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
        
        public void FillBottle()
        {
            double ml = 0.01;

            Console.WriteLine("Begin Pouring\r\n");

            while (Volume > Contents)
            {
                Console.WriteLine("Adding " + ml + "ml to bottle.");

                SetContent(ml);
            }

            Console.WriteLine("Bottle filled with " + Contents + "ml.");
        }

        private void SetContent(double ml)
        {
            Console.WriteLine("Bottle contains " + Contents + "ml.");

            if (Contents + ml > Volume)
            {
                throw new InvalidOperationException("Cannot add " + ml + "ml as the bottle's maximum volume is " + Volume + "ml.");
            }
            else if (Contents + ml < 0)
            {
                throw new InvalidOperationException("Cannot remove " + Math.Abs(ml) + "ml as the bottle contains " + Volume + "ml.");
            }

            Contents = Contents + ml;
        }

        public void AddToContents(double ml)
        {
            try
            {
                SetContent(ml);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(string.Format("\r\nError adding to bottle contents.\r\n{0}",ex.Message));
            }
            Console.WriteLine(string.Format("\r\nContents in bottle:{0}", Contents + "ml."));
        }

        public void RemoveFromContents(double ml)
        {
            ml = ml * -1;

            if (Contents < ml)
            {
                throw new InvalidOperationException("Cannot remove " + ml + "ml from the bottle as it contains a total of " + Math.Round(Contents, 2) + "ml.");
            }
            
            try
            {
                SetContent(ml);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(string.Format("\r\nError removing to bottle contents.\r\n{0}", ex.Message));
            }
            Console.WriteLine(string.Format("\r\nContents in bottle:{0}", Contents + "ml."));
        }

        public Bottle(double r = 0, double h = 0)
        {
            if (r < 0 || h < 0)
            {
                throw new InvalidOperationException("The dimensions provided for the bottle are invalid");
            }
            this.Height = Math.Round(h,2);
            this.Radius = Math.Round(r,2);
            Console.WriteLine(Information());
        }

        public string Information()
        {
            return "The bottle height is " + Height + ", and the radius is " + Radius + ". The contents is currently " + Contents + "ml(Total capacity: " + Volume + "ml).";
        }
    }
}
