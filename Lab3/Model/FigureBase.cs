using System;

namespace Model
{
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

        //TODO: rename
        /// <summary>
        /// Проверка числа
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        public static double CheckingNumber(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом!");
            }
            else
            {
                return number;
            }
        }
    }
}
