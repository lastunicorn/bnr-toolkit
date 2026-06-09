using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal static class NbrRateExtensions
{
	public static ExchangeRate ToExchangeRate(this NbrRate nbrRate)
	{
		return new ExchangeRate
		{
			Currency = nbrRate.Currency,
			Multiplier = nbrRate.Multiplier == null
				? 1
				: decimal.Parse(nbrRate.Multiplier),
			Value = decimal.Parse(nbrRate.Value)
		};
	}
}