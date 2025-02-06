using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIsARectangle
{
    class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public int CalculateArea()
        {
            return Height * Width;
        }

    }
    //Lab Done
    class Square : Rectangle
    {

    }
   
    class SquareSquare : Rectangle
    {
        public override int Height
        {
            get { return base.Height; }
            set { base.Height = value; base.Width = value;  }
        }

        public override int Width
        {
            get { return base.Width; }
            set { base.Height = base.Width = value;  }
        }
    } // class SquareSquare
    
}
