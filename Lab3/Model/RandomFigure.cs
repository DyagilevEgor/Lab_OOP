using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс для генерации случайной фигуры
    /// </summary>
    public static class RandomFigure
    {
        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        private const int _maxValue = 10000;

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        private const int _minValue = 1;

        /// <summary>
        /// Стороны треугольника
        /// </summary>
        private static List<(double A, double B, double C)> 
            _triangleSides = new List<(double, double, double)>
            {
                (3, 4, 5),
                (5, 5, 6),
                (6, 6, 6),
                (7, 10, 12),
                (9, 9, 14),
                (13, 14, 15)
            };

        /// <summary>
        /// Сгенерировать случайное число double через int
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="divider">Делитель</param>
        public static double GetRandomDouble(int minValue, int maxValue)
        {
            var randomValue = Convert.ToDouble(_random.Next(minValue, maxValue));
            return randomValue;
        }

        /// <summary>
        /// Сгенерировать случайную фигуру
        /// </summary>
        /// <returns>Сгенерированный объект класса FigureBase</returns>
        public static FigureBase GetRandomFigure()
        {
            var figureType = _random.Next(0, 3);

            switch (figureType)
            {
                case 0:
                    {
                        return GetRandomRectangle();
                    }
                case 1:
                    {
                        return GetRandomTriangle();
                    }
                case 2:
                    {
                        return GetRandomCircle();
                    }
                default:
                    {
                        throw new ArgumentException("Тип фигуры отсутствует.");
                    }
            }
        }

        /// <summary>
        /// Сгенерировать случайный прямоугольник
        /// </summary>
        /// <returns>Случайный прямоугольник</returns>
        public static FigureBase GetRandomRectangle()
        {
            var rectangle = new Rectangle
            {
                Length = GetRandomDouble(_minValue, _maxValue),
                Width = GetRandomDouble(_minValue, _maxValue)
            };
            return rectangle;
        }

        /// <summary>
        /// Сгенерировать случайный треугольник
        /// </summary>
        /// <returns>Случайный тругольник</returns>

        public static FigureBase GetRandomTriangle()
        {
            var (firstSide, secondSide, thirdSide) = 
                _triangleSides[_random.Next(_triangleSides.Count)];
            return new Triangle(firstSide, secondSide, thirdSide);
        }

        /// <summary>
        /// Сгенерировать случайный круг
        /// </summary>
        /// <returns>Случайный круг</returns>
        public static FigureBase GetRandomCircle()
        {
            var circle = new Circle
            {
                Radius = GetRandomDouble(_minValue, _maxValue),
            };
            return circle;
        }
    }
}
