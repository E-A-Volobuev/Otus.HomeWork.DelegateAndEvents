
namespace Otus.HomeWork.DelegateAndEvents.Abstractions;

public interface IBaseEntity<T>
{
    /// <summary>
    /// число, по которому будем сравнивать классы
    /// </summary>
    public T Number { get; set; }
}

