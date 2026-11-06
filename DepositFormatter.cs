using System.Text;

namespace DepositCalculator;

/// <summary>
/// Преобразует результаты расчёта вклада в текстовое представление.
/// </summary>
public static class DepositFormatter
{
    /// <summary>
    /// Форматирует список записей о вкладе в многострочный текст.
    /// </summary>
    /// <param name="records">Записи о размере вклада по годам.</param>
    /// <returns>Строка, где каждая запись находится на отдельной строке в формате «Год YYYY: 0.00 руб.».</returns>
    /// <exception cref="ArgumentNullException">Если <paramref name="records"/> равен <see langword="null"/>.</exception>
    public static string Format(IEnumerable<YearlyDeposit> records)
    {
        ArgumentNullException.ThrowIfNull(records);

        var result = new StringBuilder();

        foreach (var item in records)
        {
            result.AppendLine($"Год {item.Year}: {item.Deposit:F2} руб.");
        }

        return result.ToString();
    }
}