using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_0_Dyagilev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите фигуру для расчета площади:");
            Console.WriteLine("1. Квадрат");
            Console.WriteLine("2. Прямоугольник");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CalculateSquareArea();
                    break;
                case "2":
                    CalculateRectangleArea();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите 1 или 2.");
                    break;
            }
        }

        static void CalculateSquareArea()
        {
            Console.Write("Введите длину стороны квадрата: ");
            int c = Convert.ToInt32(Console.ReadLine());

            if (c > 0)
            {
                double area = c * c;
                Console.WriteLine($"Площадь квадрата: {area}");
            }
            else
            {
                Console.WriteLine("Ошибка: введено недопустимое значение для стороны квадрата.");
            }
            Console.ReadLine();
        }

        static void CalculateRectangleArea()
        {
            Console.Write("Введите длину прямоугольника: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину прямоугольника: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (c > 0 & b > 0)
            {
                double area = c * b;
                Console.WriteLine($"Площадь прямоугольника: {area}");
            }
            else
            {
                Console.WriteLine("Ошибка: одно из введенных значений недопустимо.");
            }
            Console.ReadLine();
        }
    }
}
