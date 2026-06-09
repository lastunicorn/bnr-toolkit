using System.Xml;
using DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrXmlModel;
using DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

public class ExchangeRatesDocument
{
	public DateOnly? PublishingDate { get; set; }

	public Currency ReferenceCurrency { get; set; }

	public List<DailyExchangeRates> DailyExchangeRates { get; private init; } = [];

	public static Task<ExchangeRatesDocument> LoadAsync(TextReader textReader, DocumentType documentType = DocumentType.Default)
	{
		return LoadInternalAsync(textReader, documentType);
	}

	public static Task<ExchangeRatesDocument> LoadAsync(Stream stream, DocumentType documentType = DocumentType.Default)
	{
		switch (documentType)
		{
			case DocumentType.Default:
			case DocumentType.NbrFxRates:
				return LoadInternalNbrAsync(new StreamReader(stream));

			case DocumentType.OutdatedXmlDaily:
				return LoadInternalOldXmlAsync(new StreamReader(stream));

			case DocumentType.OutdatedXmlMonthly:
			case DocumentType.OutdatedXmlQuarterly:
			case DocumentType.OutdatedXmlAnnual:
				throw new NotImplementedException();

			default:
				throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
		}
	}

	private static Task<ExchangeRatesDocument> LoadInternalAsync(TextReader xmlReader, DocumentType documentType)
	{
		switch (documentType)
		{
			case DocumentType.Default:
			case DocumentType.NbrFxRates:
				return LoadInternalNbrAsync(xmlReader);

			case DocumentType.OutdatedXmlDaily:
				return LoadInternalOldXmlAsync(xmlReader);

			case DocumentType.OutdatedXmlMonthly:
			case DocumentType.OutdatedXmlQuarterly:
			case DocumentType.OutdatedXmlAnnual:
				throw new NotImplementedException();

			default:
				throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
		}
	}

	private static Task<ExchangeRatesDocument> LoadInternalNbrAsync(TextReader xmlReader)
	{
		return Task.Run(() =>
		{
			NbrDataSet nbrDataSet = NbrSerializer.Deserialize(xmlReader);

			return new ExchangeRatesDocument
			{
				PublishingDate = nbrDataSet?.Header?.PublishingDate == null
					? null
					: DateOnly.Parse(nbrDataSet.Header.PublishingDate),
				ReferenceCurrency = nbrDataSet?.Body?.OrigCurrency,
				DailyExchangeRates = nbrDataSet?.Body?.Cubes
					.Select(x => x.ToCube())
					.ToList() ?? []
			};
		});
	}

	private static Task<ExchangeRatesDocument> LoadInternalOldXmlAsync(TextReader xmlReader)
	{
		return Task.Run(() =>
		{
			OldXmlDataSet oldXmlDataSet = OldXmlSerializer.Deserialize(xmlReader);

			return new ExchangeRatesDocument
			{
				DailyExchangeRates = oldXmlDataSet?.Table?.Rows
					.Select(x => x.ToDailyExchangeRates())
					.ToList() ?? []
			};
		});
	}
}