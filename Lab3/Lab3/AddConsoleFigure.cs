using Model;
using System;
using System.Collections.Generic;

namespace ConsoleLoader
{
    /// <summary>
    /// Добавление фигур с консоли
    /// </summary>
    public static class AddConsoleFigure
    {
        /// <summary>
        /// Ввод данных о радиусе круга
        /// </summary>
        /// <returns>Экземпляр класса круг</returns>
        public static Circle GetCircle()
        {
            var circle = new Circle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Длина радиуса, см: ");
                    circle.Radius =
                        ReadFromConsoleAndParse();
                })
            };
            actions.ForEach(SetValue);
            return circle;
        }

        /// <summary>
        /// Ввод данных о прямоугольнике
        /// </summary>
        /// <returns>Экземпляр класса прямоугольник</returns>
        public static Rectangle GetRectangle()
        {
            var rectangle = new Rectangle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Длина, см: ");
                    rectangle.Length =
                        ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Ширина, см: ");
                    rectangle.Width =
                        ReadFromConsoleAndParse();
                }),
            };
            actions.ForEach(SetValue);
            return rectangle;
        }

        /// <summary>
        /// Ввод данных о треугольнике
        /// </summary>
        /// <returns>Экземпляр класса треугольник</returns>
        public static Triangle GetTriangle()
        {
            var triangle = new Triangle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Длина первой стороны, см: ");
                    triangle.FirstSide =
                        ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Длина второй стороны, см: ");
                    triangle.SecondSide =
                        ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    Console.WriteLine("Длина третьей " +
                        "стороны, см: ");
                    triangle.ThirdSide =
                        ReadFromConsoleAndParse();
                }),
            };
            actions.ForEach(SetValue);
            return triangle;
        }

        /// <summary>
        /// Чтение с консоли и преобразование в double
        /// </summary>
        public static double ReadFromConsoleAndParse()
        {
            return double.Parse(Console.ReadLine().Replace('.', ','));
        }

        /// <summary>
        /// Получение пользовательского ввода
        /// и задание параметра
        /// </summary>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }
    }
}
