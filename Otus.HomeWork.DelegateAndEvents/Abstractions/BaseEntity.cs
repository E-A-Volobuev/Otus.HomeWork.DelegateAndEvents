namespace Otus.HomeWork.DelegateAndEvents.Abstractions;
public abstract class BaseEntity<T>: IBaseEntity<T>
{
    /// <summary>
    /// число, по которому будем сравнивать классы
    /// </summary>
    public T Number { get; set; }
    /// <summary>
    /// имя для сотрудника или класса просто человека 
    /// </summary>
    public string Name { get; set; }
}

