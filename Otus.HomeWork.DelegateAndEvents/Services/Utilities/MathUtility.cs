namespace Otus.HomeWork.DelegateAndEvents.Services.Utilities;

/// <summary>
/// класс для кастомных математических вычислений
/// </summary>
public sealed class MathUtility
{
    /// <summary>
    /// обобщённая функция расширения, вычисляющая максимальный элемент коллекции.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="convertToNumber"></param>
    /// <returns></returns>
    public static T GetMaxVal<T>(IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        float maxValue = default;
        Predicate<float> isMoreVal = (x) => x > maxValue;
        T resultElem = default;

        collection.ToList().ForEach(elem =>
        {
            if (isMoreVal(convertToNumber(elem)))
                resultElem = elem;
        });
        return resultElem;
    }
}

