using Otus.HomeWork.DelegateAndEvents.Models;

namespace Otus.HomeWork.DelegateAndEvents.Abstractions;

public interface IPeopleService
{
    /// <summary>
    /// инициализируем коллекцию простых людей
    /// </summary>
    /// <returns></returns>
    List<Person> CreatePersons();

    /// <summary>
    /// инициализируем коллекцию сотрудников
    /// </summary>
    /// <returns></returns>
    List<Employer> CreateEmployers();
}

