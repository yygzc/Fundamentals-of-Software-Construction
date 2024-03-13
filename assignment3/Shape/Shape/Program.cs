using System.Drawing;

namespace Shape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double areaSum = 0;
            int validNum = 0;

            for(int i = 0; i < 10; i++)
            {
                Shape shape = ObjectCreator.Create();

                if (!shape.isLegal())
                {
                    Console.WriteLine($"第{i}个形状不合法");
                }
                else
                {
                    validNum++;
                    double area = shape.getArea();
                    Console.WriteLine($"第{i}个形状合法，面积为：{area}");
                    areaSum += area;
                }
            }

            Console.WriteLine($"10个中有{validNum}个形状合法，这几个合法形状的面积之和为：{areaSum}");
        }
    }

    interface Shape
    {
        double getArea();

        bool isLegal();
    }

    class Rectangle : Shape
    {
        public double length;
        public double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        double Shape.getArea()
        {
            return length * width;
        }

        bool Shape.isLegal()
        {
            if(length > 0 && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Square : Shape
    {
        public double side;

        public Square(double side)
        {
            this.side = side;
        }

        double Shape.getArea()
        {
            return side * side;
        }

        bool Shape.isLegal()
        {
            if(side > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Triangle : Shape
    {
        public double a;
        public double b;
        public double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        double Shape.getArea()
        {
            double p = (a + b + c) / 2;
            double area = Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);
            return area;
        }

        bool Shape.isLegal()
        {
            if (a > 0 && b > 0 && c > 0 && a+b > c && a+c > b && b+c > a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class ObjectCreator
    {
        public static Shape Create()
        {
            Random random = new Random();
            int number = random.Next(1, 4);
            switch(number)
            {
                case 1:
                    Console.WriteLine("生成长方形对象");
                    return new Rectangle(random.Next(1, 10), random.Next(1, 10));                
                case 2:
                    Console.WriteLine("生成正方形对象");
                    return new Square(random.Next(1, 10));
                case 3:
                    Console.WriteLine("生成三角形对象");
                    return new Triangle(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
                default:
                    return null;
            }
        }
    }
}
