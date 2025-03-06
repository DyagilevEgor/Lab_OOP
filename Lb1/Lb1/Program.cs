using System;
using PersonLibrary;

namespace Lb1
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
            Console.WriteLine("Press any button to start");            
            
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Two lists of persons are creating, " +
                "each contains three persons");
            Console.WriteLine();
            Console.ReadKey();

            var firstList = new PersonList();
            var secondList = new PersonList();

            var firstArray = new Person[]
            {
                new Person("Dexter", "Morgan", 40, Gender.Male),
                new Person("Donald John", "Trump", 78, Gender.Male),
                new Person("Tony", "Stark", 45, Gender.Male),
            };

            var secondArray = new Person[]
            {
                new Person("Sarah-Jessica", "Parker", 59, Gender.Female),
                new Person("Kevin", "Smith", 54, Gender.Male),
                new Person("Alex", "Lion", 15, Gender.Male),
            };

            firstList.AddArrayOfPeople(firstArray);
            secondList.AddArrayOfPeople(secondArray);

            Console.WriteLine("Two lists of persons have been" + 
                "sucсessfully created!");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Displaying the contents of " +
                "each list to the console");
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();

            Console.WriteLine("Adding a new person to the first list ");
            firstList.AddPerson(new Person("Homer", "Simpson", 40, Gender.Male));
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();
            Console.WriteLine("A new person has been successfully added" +
                " to the first list!");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Copying the second person from the first" +
                " list to the end of the second list");
            secondList.AddPerson(firstList.FindByIndex(1));
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();
            Console.WriteLine("Now the same person is on both lists!");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Removing the second person from the first list");
            firstList.RemovePersonByIndex(1);
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();
            Console.WriteLine("Removing a person from the 1st list did not " +
                "delete the same person in the 2nd list!");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Clearing the second list");
            secondList.ClearList();
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine("All persons have been successfully removed from the 2nd list!");
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Let's add a new person " +
                "to the second list from keyboard");
            Console.WriteLine();
            secondList.AddPerson(AddConsolePerson.NewPerson());
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();

            Console.WriteLine("Add a random person " +
                "to the second list");
            Person randPerson = RandomPerson.GetRandomPerson();
            secondList.AddPerson(randPerson);
            ShowListOfPersons(firstList, secondList);
            Console.WriteLine();
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод списка персон
        /// </summary>
        /// <param name="firstList">Список один</param>
        /// <param name="secondList">Список два</param>
        public static void ShowListOfPersons(PersonList firstList, PersonList secondList)
        {
            var personLists = new PersonList[]
            {
                firstList,
                secondList
            };
            Console.ReadKey();

            for (int i = 0; i < personLists.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"List {i + 1}");
                Console.WriteLine();

                for (int j = 0; j < personLists[i].Count; j++)
                {
                    Console.WriteLine(personLists[i].FindByIndex(j).Info);
                }
            }
            Console.ReadKey();
        }
    }
}
