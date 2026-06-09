namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

public class DailyExchangeRates
{
	public DateOnly Date { get; set; }

	public List<ExchangeRate> Rates { get; set; }
}