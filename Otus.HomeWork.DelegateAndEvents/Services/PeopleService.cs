
using Otus.HomeWork.DelegateAndEvents.Abstractions;
using Otus.HomeWork.DelegateAndEvents.Models;

namespace Otus.HomeWork.DelegateAndEvents.Services;

public sealed class PeopleService: IPeopleService
{
    /// <summary>
    /// универсальный метод создания сотрудника компании , либо просто человека
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="number"></param>
    /// <param name="name"></param>
    /// <param name="otherInfo"></param>
    /// <returns></returns>
    private T CreateHuman<T,K>(K number, string name, string otherInfo) where T : class,IBaseEntity<K>
    {
        if (typeof(T) == typeof(Person))
        {
            int personNumber = 0;
            bool result = Int32.TryParse(number.ToString(), out personNumber);
            return new Person(){ Name = name, HobbyName = otherInfo, Number = personNumber } as T;
        }
        return new Employer() { Name = name, CompanyName = otherInfo, Number = number.ToString() } as T;
    }
    /// <summary>
    /// инициализируем коллекцию простых людей
    /// </summary>
    /// <returns></returns>
    public List<Person> CreatePersons()
    {
        List<Person> persons = new();
        persons.Add(CreateHuman<Person,int>(1, "Bob", "Swimming"));
        persons.Add(CreateHuman<Person, int>(2, "Jack", "Run"));
        persons.Add(CreateHuman<Person, int>(3, "Tom", "Cinema"));

        return persons;
    }
    /// <summary>
    /// инициализируем коллекцию сотрудников
    /// </summary>
    /// <returns></returns>
    public List<Employer> CreateEmployers()
    {
        List<Employer> employers = new();
        employers.Add(CreateHuman<Employer, string>("1", "Sam", "Company1"));
        employers.Add(CreateHuman<Employer, string>("2", "Rachel", "Company2"));
        employers.Add(CreateHuman<Employer, string>("3", "Michael", "Company3"));

        return employers;
    }
}

