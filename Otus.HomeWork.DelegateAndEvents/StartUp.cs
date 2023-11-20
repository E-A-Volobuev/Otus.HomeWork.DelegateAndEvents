using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Otus.HomeWork.DelegateAndEvents.Abstractions;
using Otus.HomeWork.DelegateAndEvents.Extensions;
using Otus.HomeWork.DelegateAndEvents.Models;
using Otus.HomeWork.DelegateAndEvents.Services.Utilities;
using Otus.HomeWork.DelegateAndEvents.Infrastructure;
using Otus.HomeWork.DelegateAndEvents.Services;
using Otus.HomeWork.DelegateAndEvents.Exceptions;

namespace Otus.HomeWork.DelegateAndEvents;

public class StartUp : BackgroundService
{
    private readonly IPeopleService _peopleService;
    private readonly IFolderReaderService _folderReadService;
    private readonly ILogger<StartUp> _logger;
    public StartUp(IPeopleService peopleService, IFolderReaderService folderReadService, ILogger<StartUp> logger)
    {
        _peopleService = peopleService ?? throw new ArgumentNullException(nameof(peopleService));
        _folderReadService = folderReadService ?? throw new ArgumentNullException(nameof(folderReadService));
        _logger=logger ?? throw new ArgumentNullException(nameof(logger));
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            FolderReaderService.FileFound += EventDisplayMessage;
            // первый пункт дз:
            (Person person, Employer employer) = GetPeople();
            DisplayMessageByFirstTask(person, employer);

            Console.WriteLine("\nЧтение файлов из каталога: {0}", ConstantsApp.PathToFolder);
            //второй пункт дз:
            _folderReadService.DetectFilesInTheFolder();
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            if((ex is not CancelSearchFromFolderException) && (ex is not FolderIsNotExistException))
                _logger.LogError($"Path: {ex.StackTrace}  Time:{DateTime.Now.ToLongTimeString()} " +
                                        $"Detail :{ex.Message}");
        }
    }

    /// <summary>
    /// П. 1 дз
    /// Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
    /// Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
    /// </summary>
    /// <returns></returns>
    private (Person person, Employer employer) GetPeople()
    {
        //создаем сотрудников и обычных людей
        List<Person> persons = _peopleService.CreatePersons();
        List<Employer> employers = _peopleService.CreateEmployers();
        // из коллекции persons находим человека с наибольшим значением поля "Number"
        Person person = MathUtility.GetMaxVal(persons, ConvertUtility.ConvertToNumber<Person, int>);
        // из коллекции employers находим человека с наибольшим значением поля "Number"
        Employer employer = MathUtility.GetMaxVal(employers, ConvertUtility.ConvertToNumber<Employer, string>);

        return (person, employer);
    }
    /// <summary>
    /// вывод в консоль первого пункта дз
    /// </summary>
    /// <param name="person"></param>
    /// <param name="employer"></param>
    private void DisplayMessageByFirstTask(Person person, Employer employer)
    {
        Console.WriteLine("Вывыд объектов с наибольшим значением параметра «Number»:");
        Console.WriteLine($"Employer - «Name»:{employer.Name}  «Number»:{employer.Number}");
        Console.WriteLine($"Person - «Name»:{person.Name}  «Number»:{person.Number}");
    }

    private void EventDisplayMessage(object sender, FileEventArgs e)
    {
        if (e.TypeMessage == TypeMessage.Info)
        {
            Console.WriteLine("Найден файл! Name: {0}", e.FileName);
            SearchFilesCancel();
        }
        else
            Console.WriteLine(e.ErrorMessage);
    }

    private void SearchFilesCancel()
    {
        Console.WriteLine("Чтобы продолжить поиск нажмите - Y. Для отмены нажмите любую другую клавишу");
        string selectAction = Console.ReadLine();
        
        if (selectAction.ToLower() != "y")
            FolderReaderService.IsCancel = true;
    }
}

