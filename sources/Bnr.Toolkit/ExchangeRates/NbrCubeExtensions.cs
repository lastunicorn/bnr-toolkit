using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal static class NbrCubeExtensions
{
	public static Cube ToCube(this NbrCube nbrCube)
	{
		return new Cube
		{
			Date = nbrCube.Date,
			Rates = nbrCube.Rates
				.Where(x => x.Value != null && x.Value != "-")
				.Select(x => x.ToExchangeRate())
				.ToList()
		};
	}
}