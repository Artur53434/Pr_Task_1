namespace DepositCalculator;

/// <summary>
/// Размер вклада на конец указанного года.
/// </summary>
/// <param name="Year">Календарный год.</param>
/// <param name="Deposit">Сумма вклада на конец года с учётом начисленных процентов.</param>
public readonly record struct YearlyDeposit(int Year, decimal Deposit);