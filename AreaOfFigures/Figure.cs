using System;
using System.Collections.Generic;

/*
 * Класс Figure является базовым для Circle, Triangle и OtherFigure. В базовом классе есть виртуальные методы для требуемого по заданию функционала, а
 * их переопределение написано в классах-наследниках для каждой отдельной фигуры.
 * В run-time`e можно через меню просить вводить название фигуры и используя switch/if конструкции создавать объект ссылочного типа Figure,
 * который будет указывать на нужную нам фигуру.
 * Касательно compile-time: не совсем было понятно, что именно требовалось, поэтому были написаны конструкторы с разной сигнатурой(использовалось
 * только количество параметров), которые в зависимости от переданного количества аргументов создавали нужный нам класс, не указывая его явно,
 * а сам объект присваивался полю. В самих виртуальных методах просто возвращались реализации для ссылки на объект созданного класса.
 * Касательно добавления других фигур: был создан универсальный класс-наследник, при создании объекта которого нужно указать имя фигуры,
 * передать формулу, написанную с помощью интерполяции строк, список аргументов для формулы, а также bool`евскую переменную, сообщающую
 * о наличии о фигуры прямого угла.
 * Также были добавлены некоторые проверки на корректность ввода данных: радиус и стороны > 0 и сумма 2-х сторон строго больше 3-й, если
 * данные условия не выполняются, то будет выброшено исключение, которые нужно отловить, поэтому создание объектов рекомендуется делать
 * используя try-catch блоки.
 */


namespace AreaOfFigures
{
    //Базовый класс для фигуры
    public class Figure
    {
        //Поле для вычисления площади в compile-time, которое будет иметь тот тип, который будет присвоен ему в конструкторе
        Figure f = null;

        //Конструктор по умолчанию для вызова в классах-наследниках
        public Figure()
        {

        }
        //Конструктор, который в compile-time принимает 1 параметр и создаёт объект класса Circle
        public Figure(double radius)
        {
            f = new Circle(radius);
        }
        //Конструктор, который в compile-time принимает 3 параметa и создаёт объект класса Figure
        public Figure(double side1, double side2, double side3)
        {
            f = new Triangle(side1, side2, side3);
        }
        //Конструктор, который в compile-time принимает 4 параметa и создаёт объект класса OtherFigure
        public Figure(string name, string formula, List<double> values, bool rightAngle)
        {
            f = new OtherFigure(name, formula, values, rightAngle);
        }
        //Виртуальный метод для вычисления площади
        public virtual double? GetArea()
        {
            return f?.GetArea();
        }
        //Виртуальный метод для проверки на наличие прямого угла в фигуре
        public virtual bool? HasRightAngle()
        {
            return f?.HasRightAngle();
        }

    }

    //Класс для описания круга
    public class Circle : Figure
    {
        double Radius { get; set; }
        public Circle(double radius) : base()
        {
            if (radius <= 0)
            {
                throw new Exception("Radius <= 0");
            }
            this.Radius = radius;
        }
        public override double? GetArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }
        public override bool? HasRightAngle()
        {
            return false;
        }
    }

    //Класс для описания треугольника
    public class Triangle : Figure
    {
        double side1;
        double side2;
        double side3;
        public Triangle(double side1, double side2, double side3) : base()
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new Exception("One or more sides <= 0");
            else if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
                throw new Exception("The sum of two sides must strictly be less than the third");
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public override double? GetArea()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        //Проверка на прямоугольный треугольник, используя теорему Пифагора
        public override bool? HasRightAngle()
        {
            double max = Math.Max(Math.Max(side1, side2), side3);
            double sum = 0;
            if (max == side1)
                sum += Math.Pow(side2, 2) + Math.Pow(side3, 2);
            else if (max == side2)
                sum += Math.Pow(side1, 2) + Math.Pow(side3, 2);
            else
                sum += Math.Pow(side2, 2) + Math.Pow(side1, 2);

            return Math.Pow(max, 2).Equals(sum);
        }
    }

    //Класс для описания другой фигуры
    public class OtherFigure : Figure
    {
        //Название фигуры
        public string Name { get; set; }
        //Аргументы для вычисления площади
        public List<double> values;
        //Поле для наличия прямого угла у фигуры
        public bool RightAngle { get; set; }
        //формула для вычисления площади фигуры
        string Formula { get; set; }
        public OtherFigure(string name, string formula, List<double> values, bool rightAngle) : base()
        {
            this.values = values;
            this.Name = name;
            this.Formula = formula;
            this.RightAngle = rightAngle;
        }
        public override double? GetArea()
        {
            return Convert.ToDouble(Formula);
        }
        public override bool? HasRightAngle()
        {
            return this.RightAngle;
        }
    }
}
