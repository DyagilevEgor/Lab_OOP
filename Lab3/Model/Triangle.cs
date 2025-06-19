using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс треугольник 
    /// </summary>
    public class Triangle : FigureBase
    {
        /// <summary>
        /// Длина первой стороны треугольника
        /// </summary>
        public double FirstSide { get; set; }

        /// <summary>
        /// Длина второй стороны треугольника
        /// </summary>
        public double SecondSide { get; set; }

        /// <summary>
        /// Длина третьей стороны треугольника
        /// </summary>
        public double ThirdSide { get; set; }

        /// <summary>
        /// Название типа фигуры
        /// </summary>
        public override string TypeName => "Треугольник";

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Triangle()
        {
            FirstSide = 3;
            SecondSide = 4;
            ThirdSide = 5;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="first">Первая сторона.</param>
        /// <param name="second">Вторая сторона.</param>
        /// <param name="third">Третья сторона.</param>
        public Triangle(double first, double second, double third)
        {
            CheckingForNegative(first);
            CheckingForNegative(second);
            CheckingForNegative(third);

            FirstSide = first;
            SecondSide = second;
            ThirdSide = third;

            Validate();
        }

        /// <summary>
        /// Проверка возможности существования треугольника
        /// </summary>
        public void Validate()
        {
            if ((FirstSide + SecondSide <= ThirdSide) ||
                (FirstSide + ThirdSide <= SecondSide) ||
                (SecondSide + ThirdSide <= FirstSide))
            {
                throw new ArgumentException("Треугольник с заданными сторонами не может существовать.");
            }
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double Area
        {
            get
            {
                double s = (FirstSide + SecondSide + ThirdSide) / 2;
                double area = Math.Sqrt(s * (s - FirstSide) * (s - SecondSide) * (s - ThirdSide));
                CheckingForNegative(area);
                return area;
            }
        }
    }
}

