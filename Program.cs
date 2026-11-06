namespace DepositCalculator;

/// <summary>
/// Консольное приложение для расчёта доходности вклада.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Точка входа. Запрашивает параметры вклада, выполняет расчёт и выводит результат.
    /// </summary>
    private static void Main()
    {
        decimal initialDeposit = ConsoleInput.Read<decimal>("Введите размер начального вклада: ");
        int years = ConsoleInput.Read<int>("Введите количество лет: ");
        decimal interestRate = ConsoleInput.Read<decimal>("Введите годовую процентную ставку: ");

        try
        {
            var deposits = DepositCalculator.CalculateYearlyDeposits(initialDeposit, years, interestRate);
            Console.WriteLine(DepositFormatter.Format(deposits));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка в параметрах: {ex.Message}");
        }
    }
}