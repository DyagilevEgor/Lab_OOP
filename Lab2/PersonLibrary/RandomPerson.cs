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
        /// Объект класса Random
        /// </summary>
        private static Random _randNum = new Random(DateTime.Now.Second);

        /// <summary>
        /// Мужские имена
        /// </summary>
        private static string[] _maleNames = new string[]
        {
                "Walter", "Jesse", "Rick", "Mattew",
                "Nicholas", "Jotaro", "Morty",
                "Dio", "Clark", "Bruce", "Peter"
        };

        /// <summary>
        /// Женские имена
        /// </summary>
        private static string[] _femaleNames = new string[]
        {
                "Beth", "Summer", "Liza", "Kira",
                "Trish", "Selina", "Diana",
                "Kara", "Mary", "Violet", "Gwen"
        };

        /// <summary>
        /// Фамилии
        /// </summary>
        private static string[] _allSurnames = new string[]
        {
                "White", "Pinkman", "Sanchez", "McConaughey",
                "Cage", "Kujo", "Smith",
                "Joestar", "Kent", "Speedwagon", "Wayne"
        };

        /// <summary>
        /// Генерация случайного человека: взрослый или ребенок
        /// </summary>
        public static Person CreateRandomPerson()
        {
            if (_randNum.Next(0, 2) != 0)
            {
                return CreateRandomChild();
            }
            else
            {
                return CreateRandomAdult();
            }
        }

        /// <summary>
        /// Заполнение базовых полей человека
        /// </summary>
        /// <param name="person">человек</param>
        public static void GetRandomPerson(Person person)
        {
            var sex = _randNum.Next(0, 2);
            switch (sex)
            {
                case 0:
                    {
                        person.Gender = Gender.Male;
                        person.Name = _maleNames[_randNum.Next(_maleNames.Length)];
                        break;
                    }
                case 1:
                    {
                        person.Gender = Gender.Female;
                        person.Name = _femaleNames[_randNum.Next(_femaleNames.Length)];
                        break;
                    }
            }
            person.Surname = _allSurnames[_randNum.Next(_allSurnames.Length)];
        }

        /// <summary>
        /// Генерация паспортных данных
        /// </summary>
        /// <param name="adult">Взрослый человек</param>
        private static void GetPasportData(Adult adult)
        {
            var _passport = _randNum.Next(1000000000, 2000000000).ToString();
            adult.Passport = _passport;
        }

        /// <summary>
        /// Взрослый человек
        /// </summary>
        /// <param name="married">генерирует супруга</param>
        /// <param name="partner">Супруг</param>
        /// <returns></returns>
        public static Adult CreateRandomAdult(bool married = false, Adult partner = null)
        {
            var randomAdult = new Adult();
            GetRandomPerson(randomAdult);
            randomAdult.Age = _randNum.Next(Adult.MinAdultAge, Adult.MaxAdultAge);
            if (!married)
            {
                randomAdult.MaritalStatus = (MaritalStatus)_randNum.Next(0, 4);
                if (randomAdult.MaritalStatus == MaritalStatus.Married)
                {
                    randomAdult.Partner = CreateRandomAdult(true, randomAdult);
                }
            }
            else
            {
                randomAdult.MaritalStatus = MaritalStatus.Married;
                randomAdult.Partner = partner;
            }
            string[] jobs = new string[]
            {
                "Dunder Mifflin", "Google", "School",
                "Police Department", "Hospital", "Bar",
                "Store", "College", "Paper Company"
            };

            randomAdult.Job = jobs[_randNum.Next(0, jobs.Length)];
            GetPasportData(randomAdult);
            return randomAdult;
        }

        /// <summary>
        /// Ребенок
        /// </summary>
        /// <returns>рандомный ребенок</returns>
        public static Child CreateRandomChild()
        {
            Child randomChild = new Child();
            GetRandomPerson(randomChild);
            randomChild.Age = _randNum.Next(Child.MinChildAge, Child.MaxChildAge);

            bool hasMother = _randNum.Next(0, 2) != 0;

            if (hasMother)
            {
                randomChild.ParentOne = CreateRandomAdult();
            }

            bool hasFather = _randNum.Next(0, 2) != 0;

            if (hasFather)
            {
                randomChild.ParentTwo = CreateRandomAdult();
            }

            string[] schools = new string[]
            {
                "Midtown School", "Crystal Lake School",
                "Blackpine", "Mount Massive Asylum", "Enigma Code School",
                "Griffindore Academy", "Infinity School","Kayak School"
            };

            randomChild.School = schools[_randNum.Next(0, schools.Length)];

            return randomChild;
        }
    }
}
