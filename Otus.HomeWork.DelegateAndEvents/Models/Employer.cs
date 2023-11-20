
using Otus.HomeWork.DelegateAndEvents.Abstractions;
namespace Otus.HomeWork.DelegateAndEvents.Models;

public class Employer:BaseEntity<string>
{
    /// <summary>
    /// название компании
    /// </summary>
    public string CompanyName { get; set; }
}

