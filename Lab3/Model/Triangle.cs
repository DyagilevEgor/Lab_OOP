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
                IsCorrectThirdSide(value);
                _thirdSide = value;
            }
        }

        /// <summary>
        /// Проверка третьей стороны
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректная длина стороны</returns>
        public double IsCorrectThirdSide(double number)
        {
            if (number >= FirstSide + SecondSide) 
            {
                throw new ArgumentException($"Длина стороны должна быть меньше " +
                    $"{FirstSide + SecondSide}.");
            }
            else
            {
                return number;
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
                return Math.Sqrt((HalfSum * (HalfSum - FirstSide)
                    * (HalfSum - SecondSide) * (HalfSum - ThirdSide)));
            }
        }
    }
}
