namespace DepositCalculator;

/// <summary>
/// Выполняет расчёт вклада с ежегодной капитализацией процентов.
/// </summary>
public static class DepositCalculator
{
    /// <summary>
    /// Делитель для перевода процентов в доли.
    /// </summary>
    private const decimal PercentDivisor = 100m;

    /// <summary>
    /// Рассчитывает размер вклада на конец каждого года с ежегодной капитализацией процентов.
    /// </summary>
    /// <param name="initialDeposit">Начальная сумма вклада. Должна быть больше нуля.</param>
    /// <param name="years">Срок вклада в годах. Должен быть больше нуля.</param>
    /// <param name="interestRate">Годовая процентная ставка в процентах (например, 7.5). Не может быть отрицательной.</param>
    /// <returns>Список записей по каждому году, начиная со следующего за текущим.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Если <paramref name="initialDeposit"/> или <paramref name="years"/> не положительны,
    /// либо <paramref name="interestRate"/> отрицательна.
    /// </exception>
    public static IReadOnlyList<YearlyDeposit> CalculateYearlyDeposits(
        decimal initialDeposit,
        int years,
        decimal interestRate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initialDeposit);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(years);
        ArgumentOutOfRangeException.ThrowIfNegative(interestRate);

        int startYear = DateTime.Now.Year;
        decimal currentDeposit = initialDeposit;
        var result = new List<YearlyDeposit>(years);

        for (int i = 1; i <= years; i++)
        {
            currentDeposit += currentDeposit * interestRate / PercentDivisor;
            result.Add(new YearlyDeposit(startYear + i, currentDeposit));
        }

        return result;
    }
}