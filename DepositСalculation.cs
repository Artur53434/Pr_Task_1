using System.Numerics;
using System.Text;

internal class DepositCalculation
{   
    public struct YearlyDeposit(int year, decimal deposit)
    {
        public int Year { get; set; } = year;
        public decimal Deposit { get; set; } = deposit;
    }
    private static void Main(string[] args)
    {
        Console.Write("Введите размер начального вклада: ");
        decimal initial_deposit = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Введите количество лет: ");
        int years = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите годовую процентную ставку: ");
        decimal interest_rate = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine(ParseYearlyDepositToString(
            CalculationInitialDeposit(initial_deposit, years, interest_rate)
        ));
    }
    public static List<YearlyDeposit> CalculationInitialDeposit(
        decimal initial_deposit,
        int years,
        decimal interest_rate)
    {
        #region Валидация
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(initial_deposit);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(years);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(interest_rate);
        #endregion

        var result = new List<YearlyDeposit>();

        for (int i = 1; i <= years; i++)
        {
            initial_deposit += initial_deposit * (interest_rate / 100);
            var record = new YearlyDeposit(DateTime.Now.Year + i, initial_deposit);
            result.Add(record);
        }

        return result;
    }
    public static string ParseYearlyDepositToString(List<YearlyDeposit> records)
    {
        ArgumentNullException.ThrowIfNull(records);

        var result = new StringBuilder();
        
        foreach (var item in records)
        {
            result.Append($"Год: {item.Year}: {item.Deposit:F2} Руб.\n");
        }

        return result.ToString();
    }

}