namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

public static class ExchangeRatesOnlineDocument
{
	public static async Task<ExchangeRatesDocument> LoadLastOneAsync(CancellationToken cancellationToken = default)
	{
		Uri uri = new("https://curs.bnr.ro/nbrfxrates.xml");

		await using ExchangeRatesOnlineStream stream = new(uri);
		await stream.Open(cancellationToken);

		return await ExchangeRatesDocument.LoadAsync(stream);
	}

	public static async Task<ExchangeRatesDocument> LoadLastTenAsync(CancellationToken cancellationToken = default)
	{
		Uri uri = new("https://curs.bnr.ro/nbrfxrates10days.xml");

		await using ExchangeRatesOnlineStream stream = new(uri);
		await stream.Open(cancellationToken);

		return await ExchangeRatesDocument.LoadAsync(stream);
	}

	[Obsolete("Use LoadByYear instead.")]
	public static async Task<ExchangeRatesDocument> LoadForYear(int year, CancellationToken cancellationToken = default)
	{
		return await LoadByYear(year, cancellationToken);
	}

	public static async Task<ExchangeRatesDocument> LoadByYear(int year, CancellationToken cancellationToken = default)
	{
		const string urlTemplate = "https://www.bnr.ro/files/xml/years/nbrfxrates{0}.xml";
		string url = string.Format(urlTemplate, year);
		Uri uri = new(url);
		
		await using ExchangeRatesOnlineStream stream = new(uri);
		await stream.Open(cancellationToken);

		return await ExchangeRatesDocument.LoadAsync(stream);
	}
}