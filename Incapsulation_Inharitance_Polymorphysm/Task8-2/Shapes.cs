using System;

namespace Task8_2
{
    public abstract class Shape
    {
        public Point Position;
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

    }

    public class Rectangle : Shape
    {
        public double Angle;
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
        public override double Area{ get => Width * Height; }
        public override double Perimeter { get => (Width + Height) * 2; }

        public Rectangle(Point position, double width = 1, double height = 1, double angle = 0)
        {
            Angle = angle;
            Width = width;
            Height = height;
            Position = position;
        }

    }

    public class Square : Rectangle
    {
        public override double Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        
        public Square(Point position, double width = 1, double angle = 0) : base(position, width, width, angle)
        {
            Angle = angle;
            Width = width;
            Position = position;
        }

        public override double Height
        {
            get => base.Height;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }

    public class Circle : Shape
    {
        public double Radius;
        public override double Area => Math.PI * Radius * Radius;
        public override double Perimeter => 2 * Math.PI * Radius;

        public Circle(Point position, double radius)
        {
            Position = position;
            Radius = radius;
        }
    }

    public class Triangle:Shape
    {
        private double a;
        private double b;
        private double abAng;

        public double ALenght { get { return a; } set { a = value; RecalculateShape(); } }
        public double BLenght { get { return b; } set { b = value; RecalculateShape(); } }
        public double CLenght { get; private set; }

        public double ABAngle { get { return abAng; } set { abAng = value; RecalculateShape(); } }
        public double BCAngle { get; private set; }
        public double ACAngle { get; private set; }

        public override double Area => Math.Sqrt(p * (p - ALenght) * (p - BLenght) * (p - CLenght));
        public override double Perimeter => ALenght + BLenght + CLenght;
        private double p => Perimeter / 2;

        public Triangle(double aLenght, double bLenght, double abAngle)
        {
            a = aLenght;
            b = bLenght;
            abAng = abAngle;
            RecalculateShape();
        }

        private void RecalculateShape()
        {
            CLenght = Math.Sqrt(ALenght * ALenght + BLenght * BLenght - 2 * ALenght * BLenght * Math.Cos(ABAngle));
            ACAngle = Math.Acos((ALenght * ALenght + CLenght * CLenght - BLenght * BLenght) / (2 * ALenght * CLenght * Math.PI));
            BCAngle = Math.PI - ABAngle - ACAngle;
        }
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
