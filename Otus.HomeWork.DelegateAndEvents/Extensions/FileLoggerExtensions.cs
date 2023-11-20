using Microsoft.Extensions.Logging;

namespace Otus.HomeWork.DelegateAndEvents.Extensions;

/// <summary>
/// добавляем метод расширения для возможности установки конфигурации записи в файл в классе program
/// </summary>
public static class FileLoggerExtensions
{
    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath)
    {
        builder.AddProvider(new FileLoggerProvider(filePath));
        return builder;
    }
}

