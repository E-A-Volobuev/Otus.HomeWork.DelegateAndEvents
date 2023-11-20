using Microsoft.Extensions.Logging;
using Otus.HomeWork.DelegateAndEvents.Abstractions;
using Otus.HomeWork.DelegateAndEvents.Exceptions;
using Otus.HomeWork.DelegateAndEvents.Extensions;
using Otus.HomeWork.DelegateAndEvents.Infrastructure;

namespace Otus.HomeWork.DelegateAndEvents.Services;

/// <summary>
/// П.2 дз:
/// Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла.
/// Оформить событие и его аргументы с использованием .NET соглашений:
/// public event EventHandler FileFound;
/// FileArgs – будет содержать имя файла и наследоваться от EventArgs
/// </summary>
public sealed class FolderReaderService: IFolderReaderService
{
    private readonly ILogger<FolderReaderService> _logger;
    public static event EventHandler<FileEventArgs>? FileFound;
    public static bool IsCancel { get; set; }

    public FolderReaderService(ILogger<FolderReaderService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// находим все файлы (в указанном через константу) каталоге
    /// </summary>
    /// <exception cref="CancelSearchFromFolderException"></exception>
    /// <exception cref="FolderIsNotExistException"></exception>
    public void DetectFilesInTheFolder()
    {
        try
        {
            // если папка существует
            if (Directory.Exists(ConstantsApp.PathToFolder))
            {
                string[] files = Directory.GetFiles(ConstantsApp.PathToFolder);
                foreach (string s in files)
                {
                    //если задача отменена , то бросаем исключение
                    if (IsCancel)
                        throw new CancelSearchFromFolderException(ConstantsApp.CancelSearch);

                    EventHelper(new FileEventArgs() { FileName = s, TypeMessage = TypeMessage.Info });
                }
            }
            else
                throw new FolderIsNotExistException(ConstantsApp.FolderNotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError( $"Path: {ex.StackTrace}  Time:{DateTime.Now.ToLongTimeString()} " +
                             $"Detail :{ex.Message}");
            EventHelper(new FileEventArgs(){ ErrorMessage = ex.Message, TypeMessage = TypeMessage.Error });
        }
        
    }

    private void EventHelper(FileEventArgs args)
    {
        EventHandler<FileEventArgs> handler = FileFound;
        if (handler != null)
            handler(this, args);
    }
}

