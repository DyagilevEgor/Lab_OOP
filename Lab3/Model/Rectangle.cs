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
                CheckingNumber(value);
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
                CheckingNumber(value);
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
                return Math.Round(Length * Width, 3);
            }
        }
    }
}
