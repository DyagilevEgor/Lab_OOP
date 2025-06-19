using System;
using System.Xml.Serialization;

namespace Model
{   
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]

    /// <summary>
    /// Базовый класс 
    /// для всех фигур
    /// </summary>
    public abstract class FigureBase
    {
        /// <summary>
        /// Расчёт площади
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Название типа фигуры
        /// </summary>
        public virtual string TypeName => "Фигура";

        /// <summary>
        /// Проверка числа положительность и конечность
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        protected void CheckingForNegative(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Значение должно быть конечным числом, не NaN и не Infinity.");
            }

            if (value <= 0)
            {
                throw new ArgumentException("Значение должно быть положительным числом.");
            }
        }
    }
}
