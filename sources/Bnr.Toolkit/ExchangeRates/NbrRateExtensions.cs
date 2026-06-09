using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrXmlModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal static class NbrRateExtensions
{
	public static ExchangeRate ToExchangeRate(this NbrRate nbrRate)
	{
		decimal value = decimal.Parse(nbrRate.Value);

		if (nbrRate.Multiplier != null)
		{
			decimal multiplier = decimal.Parse(nbrRate.Multiplier);
			value /= multiplier;
		}

		return new ExchangeRate
		{
			Currency = nbrRate.Currency,
			Value = value
		};
	}
}