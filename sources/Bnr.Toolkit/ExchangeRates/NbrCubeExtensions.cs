using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrXmlModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal static class NbrCubeExtensions
{
	public static DailyExchangeRates ToCube(this NbrCube nbrCube)
	{
		return new DailyExchangeRates
		{
			Date = DateOnly.Parse(nbrCube.Date),
			Rates = nbrCube.Rates
				.Where(x => x.Value != null && x.Value != "-")
				.Select(x => x.ToExchangeRate())
				.ToList()
		};
	}
}