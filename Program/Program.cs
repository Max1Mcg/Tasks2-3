using System;
using System.Collections.Generic;
using AreaOfFigures;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Корректная инициализация переменных
                Circle circle = new Circle(2);
                Figure triangle = new Triangle(10, 11, 12);
                var circle2 = new Figure(2);
                List<double> values = new List<double>(2) { 2, 3 };
                Figure otherFigure = new Figure("Rectangle", $"{values[0] * values[1]}", values, true);
                Figure f = new Figure();

                //Вывод результатов методов для переменных
                Console.WriteLine(circle.GetArea());
                Console.WriteLine(triangle.GetArea());
                Console.WriteLine(circle2.HasRightAngle());
                Console.WriteLine(otherFigure.GetArea());
                Console.WriteLine(f.GetArea());

                //Некорретная инициализация, которая выбросит исключение
                Triangle badTriangle = new Triangle(1,2,3);

                //Этот метод не сработает, как и всё после, т.к. было брошено исключение
                Console.WriteLine(badTriangle.GetArea());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
