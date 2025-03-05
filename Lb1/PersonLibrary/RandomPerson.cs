using System;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, предназначенный для
    /// случайной генерации персоны 
    /// </summary>
    public class RandomPerson
    {

        /// <summary>
        /// Генерирует случайного человека
        /// </summary>
        /// <returns>Персона со случайными данными</returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames = new string[]
            {
                "Walter", "Jesse", "Rick", "Mattew",
                "Nicholas", "Jotaro", "Morty",
                "Dio", "Clark", "Bruce", "Peter"
            };

            string[] femaleNames = new string[]
            {
                "Beth", "Summer", "Liza", "Kira",
                "Trish", "Selina", "Diana",
                "Kara", "Mary", "Violet", "Gwen"
            };

            string[] allSurnames = new string[]
            {
                "White", "Pinkman", "Sanchez", "McConaughey",
                "Cage", "Kujo", "Smith",
                "Joestar", "Kent", "Speedwagon", "Wayne"
            };

            Random random = new Random();

            string name;
            Gender gender = (Gender)random.Next(1, 3);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
                default:
                    return new Person("John", "Smith", 30, Gender.Male);
            }

            string surname = allSurnames[random.Next(allSurnames.Length)];

            int age = random.Next(0, Person.AgeMax);
            return new Person(name, surname, age, gender);
        }
    }
}
