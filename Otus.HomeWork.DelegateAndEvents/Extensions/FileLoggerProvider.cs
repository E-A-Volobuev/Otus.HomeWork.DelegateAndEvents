using Microsoft.Extensions.Logging;

namespace Otus.HomeWork.DelegateAndEvents.Extensions;

/// <summary>
/// переопределяем провайдер логгирования для записи в файл
/// </summary>
public sealed class FileLoggerProvider : ILoggerProvider
{
    string path;
    public FileLoggerProvider(string path)
    {
        this.path = path;
    }
    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(path);
    }

    public void Dispose() { }
}

