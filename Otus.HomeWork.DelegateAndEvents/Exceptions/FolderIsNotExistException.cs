
namespace Otus.HomeWork.DelegateAndEvents.Exceptions;

/// <summary>
/// исключение, если каталог не найден
/// </summary>
public sealed class FolderIsNotExistException : Exception
{
    public FolderIsNotExistException(string message)
        : base(message)
    { }
}

