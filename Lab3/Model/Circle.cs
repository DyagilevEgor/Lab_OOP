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
                CheckingForNegative(value);
                _radius = value;
            }
        }

        /// <summary>
        /// Название типа фигуры
        /// </summary>
        public override string TypeName => "Круг";

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Circle(double first)
        {
            Radius = first;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Circle()
        {
            Radius = 2;
        }

        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <retutns>Площадь круга</retutns>
        public override double Area
        {
            get
            {
                double area = Math.PI * Math.Pow(Radius,2);
                CheckingForNegative(area);
                return area;
            }
        }
    }
}
