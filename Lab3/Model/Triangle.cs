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
                CheckingNumber(value);
                _firstSide = value;
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
                CheckingNumber(value);
                _secondSide = value;
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
                CheckingNumber(value);
                _thirdSide = value;
            }
        }

        /// <summary>
        /// Полупериметр
        /// </summary>
        private double HalfSum
        {
            get
            {
                return (FirstSide + SecondSide + ThirdSide) / 2;
            }
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <retutns>Площадь треугольника</retutns>
        public override double Area
        {
            get
            {
                return Math.Round(Math.Sqrt((HalfSum * (HalfSum - FirstSide)
                    * (HalfSum - SecondSide) * (HalfSum - ThirdSide))), 3);
            }
        }
    }
}
