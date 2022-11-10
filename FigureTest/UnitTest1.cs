using System;
using Xunit;
using System.Collections.Generic;
using AreaOfFigures;


namespace FigureTest
{
    public class UnitTest1
    {
        [Fact]
        public void CircleArea()
        {
            double expected = 12.566370614359172;
            Circle circle = new Circle(2);
            Assert.Equal(circle.GetArea(), expected);
        }
        [Fact]
        public void TriangleArea()
        {
            double expected = 51.521233486786784;
            Figure triangle = new Triangle(10, 11, 12);
            Assert.Equal(triangle.GetArea(), expected);
        }
        [Fact]
        public void CircleHasAngle()
        {
            bool? expected = false;
            var circle = new Figure(2);
            Assert.Equal(circle.HasRightAngle(), expected);
        }
        [Fact]
        public void OtherFigureArea()
        {
            double expected = 6;
            List<double> values = new List<double>(2) { 2, 3 };
            Figure otherFigure = new Figure("Rectangle", $"{values[0] * values[1]}", values, true);
            Assert.Equal(otherFigure.GetArea(), expected);
        }
        [Fact]
        public void EmptyFigureArea()
        {
            double? expected = null;
            Figure f = new Figure();
            Assert.Equal(f.GetArea(), expected);
        }
        [Fact]
        public void BadFigureException()
        {
            try
            {
                Triangle badTriangle = new Triangle(1, 2, 3);
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, "The sum of two sides must strictly be less than the third");
            }
        }
    }
}