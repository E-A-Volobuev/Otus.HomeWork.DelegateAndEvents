
namespace Otus.HomeWork.DelegateAndEvents.Exceptions;

/// <summary>
/// исключение при отмене задачи поиска файла
/// </summary>
public sealed class CancelSearchFromFolderException : Exception
{
    public CancelSearchFromFolderException(string message)
        : base(message)
    { }
}

