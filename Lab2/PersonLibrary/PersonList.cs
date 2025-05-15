using System;
using System.Collections.Generic;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, представляющий список людей (Person).
    /// Предоставляет методы для управления списком: добавление, удаление,
    /// поиск и очистка.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Приватное поле для хранения списка людей
        /// </summary>
        private List<PersonBase> _people;

        /// <summary>
        /// Конструктор для инициализации нового списка людей.
        /// </summary>
        public PersonList()
        {
            _people = new List<PersonBase>();
        }

        /// <summary>
        ///  Метод для добавления человека в список.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно добавить
        /// в список.</param>
        public void AddPerson(PersonBase person)
        {
            _people.Add(person);
        }

        /// <summary>
        /// Добавление нескольких людей
        /// </summary>
        /// <param name="persons">Массив людей</param>
        public void AddArrayOfPeople(PersonBase[] persons)
        {
            foreach (PersonBase person in persons)
            {
                AddPerson(person);
            }
        }


        /// <summary>
        /// Метод для удаления человека из списка по объекту.
        /// </summary>
        /// <param name="person">Объект типа Person, который нужно удалить из
        /// списка.</param>
        public void RemovePerson(PersonBase person)
        {
            _people.Remove(person);
        }

        /// <summary>
        /// Метод для удаления человека из списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента, который нужно удалить.</param>
        public void RemovePersonByIndex(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people.RemoveAt(index);
            }
        }

        /// <summary>
        /// Метод для возврата индекса указанного человека в списке.
        /// </summary>
        /// <param name="person">Объект типа Person, индекс которого нужно
        /// найти.</param>
        /// <returns>Индекс объекта в списке, если он найден; в противном
        /// случае — -1.</returns>
        public int GetIndexOfPerson(PersonBase person)
        {
            return _people.IndexOf(person);
        }

        /// <summary>
        /// Поиск элемента по индексу
        /// </summary>
        /// <param name="index">Индекс человека</param>
        /// <returns>возвращает значение по указанному индексу</returns> 
        public PersonBase FindByIndex(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                return _people[index];
            }
            else
            {
                throw new Exception("The index you requested " +
                    "does not exist!");
            }
        }

        /// <summary>
        /// Метод для очистки всего списка.
        /// </summary>
        public void ClearList()
        {
            _people.Clear();
        }

        /// <summary>
        /// Метод для получения количества элементов в списке.
        /// </summary>
        public int Count => _people.Count;
    }
}
