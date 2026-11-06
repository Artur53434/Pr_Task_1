using System.Globalization;

namespace DepositCalculator;

/// <summary>
/// Вспомогательные методы для безопасного ввода данных с консоли.
/// </summary>
internal static class ConsoleInput
{
    /// <summary>
    /// Запрашивает у пользователя значение указанного типа, повторяя запрос до корректного ввода.
    /// </summary>
    /// <typeparam name="T">Тип значения, поддерживающий разбор из строки.</typeparam>
    /// <param name="prompt">Приглашение к вводу.</param>
    /// <returns>Корректно введённое пользователем значение.</returns>
    public static T Read<T>(string prompt) where T : IParsable<T>
    {
        while (true)
        {
            Console.Write(prompt);

            if (T.TryParse(Console.ReadLine(), CultureInfo.CurrentCulture, out T? value))
            {
                return value;
            }

            Console.WriteLine("Некорректное значение. Повторите ввод.");
        }
    }
}