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
        /// Проверка числа положительность
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        public static double CheckingForNegative(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом");
            }
            else
            {
                return number;
            }
        }
    }
}
