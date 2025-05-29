using System;

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
        private double _firstSide;

        /// <summary>
        /// Длина второй стороны треугольника
        /// </summary>
        private double _secondSide;

        /// <summary>
        /// Длина третьей стороны треугольника
        /// </summary>
        private double _thirdSide;

        /// <summary>
        /// Длина первой стороны треугольника
        /// </summary>
        public double FirstSide
        {
            get
            {
                return _firstSide;
            }
            set
            {
                CheckingForNegative(value);
                _firstSide = value;
                ValidateTriangle();
            }
        }

        /// <summary>
        /// Длина второй стороны треугольника
        /// </summary>
        public double SecondSide
        {
            get
            {
                return _secondSide;
            }
            set
            {
                CheckingForNegative(value);
                _secondSide = value;
                ValidateTriangle();
            }
        }

        /// <summary>
        /// Длина третьей стороны треугольника
        /// </summary>
        public double ThirdSide
        {
            get
            {
                return _thirdSide;
            }
            set
            {
                CheckingForNegative(value);
                _thirdSide = value;
                ValidateTriangle();
            }
        }

        /// <summary>
        /// Проверка возможности существования треугольника
        /// </summary>
        private void ValidateTriangle()
        {
            // Одна из сторон еще не установлена
            if (FirstSide <= 0 || SecondSide <= 0 || ThirdSide <= 0) return; 

            if ((FirstSide + SecondSide <= ThirdSide) ||
                (FirstSide + ThirdSide <= SecondSide) ||
                (SecondSide + ThirdSide <= FirstSide))
            {
                throw new ArgumentException(
                    "Треугольник с заданными сторонами не может существовать.");
            }
        }

        /// <summary>
        /// Полупериметр
        /// </summary>
        private double HalfSum => (FirstSide + SecondSide + ThirdSide) / 2;

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <retutns>Площадь треугольника</retutns>
        public override double Area
        {
            get
            {
                return Math.Sqrt(HalfSum * (HalfSum - FirstSide)
                    * (HalfSum - SecondSide) * (HalfSum - ThirdSide));
            }
        }
    }
}
