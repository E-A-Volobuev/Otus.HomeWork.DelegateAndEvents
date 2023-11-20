
namespace Otus.HomeWork.DelegateAndEvents.Abstractions;

public interface IFolderReaderService
{
    /// <summary>
    /// находим все файлы (в указанном через константу) каталоге
    /// </summary>
    void DetectFilesInTheFolder();
}

