# Otus.HomeWork.DelegateAndEvents
Курс C# Professional от OTUS. Домашняя работа: Делегаты, события, обобщенные функции, DI и логгирование в файл

## Основное задание:
1) Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
   Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
   public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
2) Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
  Оформить событие и его аргументы с использованием .NET соглашений:
  public event EventHandler FileFound;
  FileArgs – будет содержать имя файла и наследоваться от EventArgs
  Добавить возможность отмены дальнейшего поиска из обработчика;
  Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.