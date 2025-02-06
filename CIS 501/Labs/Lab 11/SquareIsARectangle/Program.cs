using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIsARectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            AreaCalculator areaCalcApp =new AreaCalculator();
            List<Rectangle> rectangles = new List<Rectangle>();

            // First problem
            Rectangle r1 = new Rectangle();
            r1.Height = 4;
            r1.Width = 5;
            rectangles.Add(r1);
            Console.WriteLine("Rectangle-01 Width:{0} x Height:{1} area is: {2}", r1.Width, r1.Height, r1.CalculateArea().ToString());

            Rectangle r2 = new Rectangle();
            r2.Width = 5;
            r2.Height = 4;
            rectangles.Add(r2);
            Console.WriteLine("Rectangle-02 Width:{0} x Height:{1} area is: {2}", r2.Width, r2.Height, r2.CalculateArea().ToString());

            bool match = (r1.Height == r2.Height) && (r1.Width == r2.Width); // true
            Console.WriteLine("Matching rectangles sides is {0}", match);

            // Let's treat the Subclass as the Supperclass, that is,
            // Let's treat the Square as Rectangle
            Rectangle square1 = new SquareSquare();  //SquareSquare();
            square1.Height = 4; // Same as in square2
            square1.Width = 5; // Same as in square2
            rectangles.Add(square1);
            Console.WriteLine();
            Console.WriteLine("Square-01 Width:{0} x Height:{1} area is: {2}", square1.Width, square1.Height, square1.CalculateArea().ToString());

            // Let's treat the Subclass as the Supperclass, that is,
            // Let's treat the Square as Rectangle
            Rectangle square2 = new SquareSquare();  //SquareSquare();
            square2.Width = 5;  // Same as in square1
            square2.Height = 4; // Same as in square1
            rectangles.Add(square2);
            Console.WriteLine("Square-02 Width:{0} x Height:{1} area is: {2}", square2.Width, square2.Height, square2.CalculateArea().ToString());

            bool match2 = (square1.Height == square2.Height) && (square1.Width == square2.Width); // False
            Console.WriteLine("Matching squares sides is {0}", match2);

            Console.WriteLine();
            doubleEachSide(r2);
            Console.WriteLine("After doubling the side of Rectangle-02.....Now is: {0} x {1}", r2.Width, r2.Height);

            doubleEachSide(square2);
            Console.WriteLine("After doubling the side of Square-02........Now is: {0} x {1}", square2.Width, square2.Height);
            
            //areaCalcApp.calculateAreas(rectangles);
            Console.ReadLine();
        }

        //Is it LSP Compliant???
        static void doubleEachSide(Rectangle r)
        {
            r.Width = r.Width * 2;
            r.Height = r.Height * 2;
        }
    }
}
