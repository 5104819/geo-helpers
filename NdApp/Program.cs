using System;
using System.Collections.Generic;
using System.Linq;

namespace NdApp
{
    class Program
    {

        static readonly List<Point> Points = new List<Point> {
            new Point { Name = @"Object 1", X= 55.1531574, Y= 61.3822603},
            new Point { Name = @"Object 2", X= 55.153376, Y= 61.3815421},
            new Point { Name = @"Object 3", X= 55.1528871,Y= 61.3831837},
            new Point { Name = @"Object 4", X= 55.1510785,Y= 61.3851864},
            new Point { Name = @"TourPay", X= 55.1526734,Y= 61.3834495},
            new Point { Name = @"Point 5", X= 55.153221,Y= 61.382420},
            new Point { Name = @"Point 6", X= 55.154174,Y= 61.382548},
        };

        static void Main()
        {
            var here = new Point { Name = "You are here", X = 55.1531424, Y = 61.3822751 };
            var nearest = Points.OrderBy(x => Distance(here, x)).ToList();

            var distanceKm = DistanceInKmBetweenEarthCoordinates(here, nearest[0]);

            Console.WriteLine($"{here.Name} : ({here.X}, {here.Y})");
            foreach (var item in nearest)
            {
                Console.WriteLine($"{item.Name} : ({item.X}, {item.Y}). Distance: {(decimal)Distance(item, here)}");
            }
            Console.WriteLine(new string('_', 30));
            Console.WriteLine(nearest[0]?.Name);
            Console.WriteLine(new string('_', 30));
            Console.WriteLine($"Distance: {distanceKm * 1000:F0}m ");
            Console.ReadLine();
        }

        static double Distance(Point p2, Point p1)
        {
            var yDist = p2.Y - p1.Y;
            var xDist = p2.X - p1.X;
//            return Math.Pow(yDist, 2) + Math.Pow(xDist, 2);
            return Math.Sqrt(Math.Pow(yDist, 2) + Math.Pow(xDist, 2));
        }

        static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        static double DistanceInKmBetweenEarthCoordinates(Point p1, Point p2)
        {
            var earthRadiusKm = 6371;

            var dLat = DegreesToRadians(p2.X - p1.X);
            var dLon = DegreesToRadians(p2.Y - p1.Y);

            var lat1 = DegreesToRadians(p1.Y);
            var lat2 = DegreesToRadians(p2.Y);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return earthRadiusKm * c;
        }

        static List<Point> SortByDistance(Point myPt, List<Point> pointList)
        {
            return pointList.OrderBy(x => Distance(myPt, x)).ToList();
        }
    }
}
