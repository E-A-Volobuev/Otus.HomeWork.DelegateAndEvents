using Otus.HomeWork.DelegateAndEvents.Abstractions;

namespace Otus.HomeWork.DelegateAndEvents.Models;

public class Person : BaseEntity<int>
{
    /// <summary>
    /// хобби человека
    /// </summary>
    public string HobbyName { get; set; }
}

