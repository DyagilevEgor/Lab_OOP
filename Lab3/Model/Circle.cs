using System;

namespace Model
{
    /// <summary>
    /// Класс круг 
    /// </summary>
    public class Circle : FigureBase
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        private double _radius;

        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                CheckingNumber(value);
                _radius = value;
            }
        }

        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <retutns>Площадь круга</retutns>
        public override double Area
        {
            get
            {
                //TODO: rewrite
                return Math.Round(Math.PI * Math.Pow(Radius,2), 3);
            }
        }
    }
}
