using System.Xml.Serialization;
using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

public class ExchangeRatesDocument
{
	public DateOnly? PublishingDate { get; set; }

	public Currency ReferenceCurrency { get; set; }

	public List<Cube> Cubes { get; private init; } = [];

	public static Task<ExchangeRatesDocument> LoadAsync(TextReader textReader)
	{
		return LoadInternal(textReader);
	}

	public static Task<ExchangeRatesDocument> LoadAsync(Stream stream)
	{
		StreamReader streamReader = new(stream);
		return LoadInternal(streamReader);
	}

	private static Task<ExchangeRatesDocument> LoadInternal(TextReader textReader)
	{
		return Task.Run(() =>
		{
			XmlSerializer xmlSerializer = new(typeof(NbrDataSet));
			NbrDataSet nbrDataSet = (NbrDataSet)xmlSerializer.Deserialize(textReader);

			return new ExchangeRatesDocument
			{
				PublishingDate = nbrDataSet?.Header?.PublishingDate == null
					? null
					: DateOnly.Parse(nbrDataSet.Header.PublishingDate),
				ReferenceCurrency = nbrDataSet?.Body?.OrigCurrency,
				Cubes = nbrDataSet?.Body?.Cubes
					.Select(ToCube)
					.ToList() ?? []
			};
		});
	}

	private static Cube ToCube(NbrCube nbrCube)
	{
		return new Cube
		{
			Date = nbrCube.Date,
			Rates = nbrCube.Rates
				.Select(ToRate)
				.ToList()
		};
	}

	private static ExchangeRate ToRate(NbrRate nbrRate)
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