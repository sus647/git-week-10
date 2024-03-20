// See https://aka.ms/new-console-template for more information

using System;

class Point
{
  private double x;
  private double y;

  public Point(double x, double y)
  {
    this.x = x;
    this.y = y;
  }

  public double GetX()  
  {
    return x;
  }

  public double GetY()
  {
    return y;
  }

  public void SetX(double x) 
  {
    this.x = x;
  }

  public void SetY(double y)
  {
    this.y = y;
  }
}

class Circle
{
  private Point center;
  private double radius;

  public Circle(Point center, double radius)
  {
    this.center = center;
    this.radius = radius;
  }

  public double GetRadius()
  {
    return radius;
  }

  public void SetRadius(double radius)
  {
    this.radius = radius;
  }

  public double CalculatePerimeter()
  {
    return 2 * Math.PI * radius;
  }

  public double CalculateSurfaceArea()
  {
    return Math.PI * radius * radius;
  }

  public bool IsPointInside(Point testPoint)
  {
    double distance = Math.Sqrt(Math.Pow(testPoint.GetX() - center.GetX(), 2) + Math.Pow(testPoint.GetY() - center.GetY(), 2));
    return distance <= radius;
  }
}

class CircleManager
{
  public Circle[] CreateCircles(int numberOfCircles)
  {
    Circle[] circles = new Circle[numberOfCircles];
    for (int i = 0; i < numberOfCircles; i++)
    {
      Console.WriteLine($"Tell me about Circle {i + 1}:");
      Point center = GetPointFromUser();
      Console.Write("Enter the radius: ");
      double radius = Convert.ToDouble(Console.ReadLine());
      circles[i] = new Circle(center, radius);
      Console.WriteLine();
    }
    return circles;
  }

  public void PrintCircleInfo(Circle circle)
  {
    Console.WriteLine($"Perimeter: {circle.CalculatePerimeter()}, Surface Area: {circle.CalculateSurfaceArea()}");
  }

  public Point GetPointFromUser()
  {
    Console.Write("Enter X coordinate for a point: ");
    double x = Convert.ToDouble(Console.ReadLine());
    Console.Write("Enter Y coordinate for a point: ");
    double y = Convert.ToDouble(Console.ReadLine());
    return new Point(x, y);
  }

  public void CheckPointInCircles(Point testPoint, Circle[] circles)
  {
    for (int i = 0; i < circles.Length; i++)
    {
      bool isInside = circles[i].IsPointInside(testPoint);
      Console.WriteLine($"The test point is {(isInside ? "inside" : "outside")} Circle {i + 1}");
    }
  }
}

class Program
{
  static void Main()
  {
    CircleManager manager = new CircleManager();

    Console.Write("How many circles do you want to create? ");
    int numberOfCircles = Convert.ToInt32(Console.ReadLine());

    Circle[] circles = manager.CreateCircles(numberOfCircles);

    Console.WriteLine("Here are the details of the circles:");
    for (int i = 0; i < numberOfCircles; i++)
    {
      Console.WriteLine($"Circle {i + 1} - ");
      manager.PrintCircleInfo(circles[i]);
    }

    Point testPoint = manager.GetPointFromUser();
    manager.CheckPointInCircles(testPoint, circles);
  }
}
