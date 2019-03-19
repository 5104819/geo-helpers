using System;
using System.Collections.Generic;
using System.Linq;

namespace NdApp
{
    class Program
    {

        static readonly List<Point> Points = new List<Point> {
            new Point { Name = @"Пятерочка", X= 55.1531574, Y= 61.3822603},
            new Point { Name = @"Продукты", X= 55.153376, Y= 61.3815421},
            new Point { Name = @"Разливное № 1", X= 55.1528871,Y= 61.3831837},
            new Point { Name = @"Www.icafe", X= 55.1510785,Y= 61.3851864},
        };

        static void Main()
        {
            var here = new Point { Name = "You are here", X = 55.1531424, Y = 61.3822751 };
            var nearest = Points.OrderBy(x => Distance(here, x)).ToList();


            Console.WriteLine($"{here.Name} : ({here.X}, {here.Y})");
            foreach (var item in nearest)
            {
                Console.WriteLine($"{item.Name} : ({item.X}, {item.Y}). Distance: {(decimal)Distance(item, here)}");
            }
            Console.WriteLine(new string('_', 30));
            Console.WriteLine(nearest[0]?.Name);
            Console.ReadLine();
        }

        static double Distance(Point p2, Point p1)
        {
            var yDist = p2.Y - p1.Y;
            var xDist = p2.X - p1.X;
            return Math.Sqrt(Math.Pow(yDist, 2) + Math.Pow(xDist, 2));
        }

        static List<Point> SortByDistance(Point myPt, List<Point> pointList)
        {
            return pointList.OrderBy(x => Distance(myPt, x)).ToList();
        }
    }
}
