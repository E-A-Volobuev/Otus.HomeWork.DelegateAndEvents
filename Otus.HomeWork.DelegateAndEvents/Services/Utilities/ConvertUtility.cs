using Otus.HomeWork.DelegateAndEvents.Abstractions;

namespace Otus.HomeWork.DelegateAndEvents.Services.Utilities;

public sealed class ConvertUtility
{
    /// <summary>
    /// преобразуем любой тип в число
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="elem"></param>
    /// <returns></returns>
    public static float ConvertToNumber<T, K>(T elem) where T : IBaseEntity<K>
    {
        float number;
        bool result = float.TryParse(elem.Number.ToString(), out number);
        return number;
    }
}

