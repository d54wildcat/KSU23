using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIsARectangle
{
    class AreaCalculator
    {

        public void calculateAreas(List<Rectangle> rectangles)
        {
            Console.WriteLine("---          calculateArea           ---");
            Console.WriteLine("--- Treatung everything as Rectangle ---");
            foreach (Rectangle r in rectangles)
            {
                Console.WriteLine("Rectangle: {0} x {1} area is: {2}", r.Width, r.Height, r.CalculateArea().ToString());
            }
        }
    }
}
