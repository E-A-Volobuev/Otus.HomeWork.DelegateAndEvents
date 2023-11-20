
namespace Otus.HomeWork.DelegateAndEvents.Infrastructure;

public sealed class FileEventArgs : EventArgs
{
    /// <summary>
    /// название обнаруженного файла
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// сообщение о ошибке
    /// </summary>
    public string ErrorMessage { get; set; }
    /// <summary>
    /// тип сообщения
    /// </summary>
    public TypeMessage TypeMessage { get; set; }
}

public enum TypeMessage
{
    Info,
    Error
}
