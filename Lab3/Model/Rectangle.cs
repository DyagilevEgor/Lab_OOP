using System;

namespace Model
{
    /// <summary>
    /// Класс прямоугольник 
    /// </summary>
    public class Rectangle : FigureBase
    {
        /// <summary>
        /// Длина
        /// </summary>
        private double _length;

        /// <summary>
        /// Ширина
        /// </summary>
        private double _width;

        /// <summary>
        /// Длина
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                CheckingForNegative(value);
                _length = value;
            }
        }

        /// <summary>
        /// Ширина
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                CheckingForNegative(value);
                _width = value;
            }
        }

        /// <summary>
        /// Вычисление площади прямоугольника
        /// </summary>
        /// <retutns>Площадь прямоугольника</retutns>
        public override double Area
        {
            get
            {
                //TODO: rewrite +
                return Length * Width;
            }
        }
    }
}
