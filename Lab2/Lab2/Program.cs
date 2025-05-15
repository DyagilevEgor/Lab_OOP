﻿using System;
using PersonLibrary;

namespace Lab2
{
    /// <summary>
    /// Основной класс  
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Параметры</param>
        internal static void Main(string[] args)
        {
            Console.WindowWidth = 100;

            Console.WriteLine("Press any key to start...");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Generation of 7 random people...");
            Console.WriteLine();
            Console.ReadKey();

            var listOfPersons = new PersonList();

            for (int i = 0; i < 7; i++)
            {
                listOfPersons.AddPerson(RandomPerson.CreateRandomPerson());
            }

            Console.WriteLine("A list of persons has been sucсessfully created!");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Randomly generated list:\n");

            for (int i = 0; i < listOfPersons.Count; i++)
            {
                Console.ReadKey();
                Console.WriteLine(listOfPersons.FindByIndex(i).Info);
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Write("The fourth person in the list is...\n ");
            switch (listOfPersons.FindByIndex(3))
            {
                //TODO: RSDN ++
                case Adult adult:
                {
                    Console.WriteLine(adult.GoToWork());
                    break;
                }

                case Child child:
                {
                    Console.WriteLine(child.WatchCartoons());
                    break;
                }
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}