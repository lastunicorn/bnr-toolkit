using DustInTheWind.Bnr.Toolkit.ExchangeRates;
using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Tables;

namespace DustInTheWind.Bnr.Toolkit.Demo;

internal static class Program
{
	private static async Task Main(string[] args)
	{
		// --------------------------------------------------
		// Uncomment the method you want to test.
		// --------------------------------------------------

		//await LoadExchangeRatesFromWeb1();
		//await LoadExchangeRatesFromWeb10();
		//await LoadExchangeRatesFromWeb(2026);
		//await LoadExchangeRatesFromFile();

		await LoadExchangeRatesFromOldXml();
	}

	private static async Task LoadExchangeRatesFromOldXml()
	{
		FileStream fileStream = File.OpenRead("old-daily-rates-2023.xml");
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesDocument.LoadAsync(fileStream, DocumentType.OutdatedXmlDaily);
		Display(exchangeRatesDocument, "EUR");
	}

	/// <summary>
	/// Retrieves the exchange rates for the last day from the BNR website.
	/// BNR has a dedicated URL for this purpose.
	/// </summary>
	private static async Task LoadExchangeRatesFromWeb1()
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadLastOneAsync();
		Display(exchangeRatesDocument, "EUR");
	}

	/// <summary>
	/// Retrieves the exchange rates for the last ten days from the BNR website.
	/// BNR has a dedicated URL for this purpose.
	/// </summary>
	private static async Task LoadExchangeRatesFromWeb10()
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadLastTenAsync();
		Display(exchangeRatesDocument, "EUR");
	}

	/// <summary>
	/// Retrieves the exchange rates for the specified year from the BNR website.
	/// </summary>
	private static async Task LoadExchangeRatesFromWeb(int year)
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadByYear(year);
		Display(exchangeRatesDocument, "EUR");
	}

	/// <summary>
	/// Retrieves the exchange rates from a local file.
	/// The file must be in the same format as the one provided by the BNR website.
	/// </summary>
	private static async Task LoadExchangeRatesFromFile()
	{
		FileStream fileStream = File.OpenRead("nbrfxrates2005.xml");
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesDocument.LoadAsync(fileStream);
		Display(exchangeRatesDocument, "EUR");
	}

	private static void Display(ExchangeRatesDocument exchangeRatesDocument, string currency)
	{
		DataGrid dataGrid = new()
		{
			Title = $"Exchange rates for {currency}",
			Footer = $"Count: {exchangeRatesDocument.DailyExchangeRates.Count}"
		};

		dataGrid.Columns.Add("Date");
		dataGrid.Columns.Add("Rates", HorizontalAlignment.Right);

		foreach (DailyExchangeRates cube in exchangeRatesDocument.DailyExchangeRates)
		{
			ExchangeRate exchangeRate = cube.Rates
				.FirstOrDefault(x => x.Currency == currency);

			string value = exchangeRate?.Value.ToString() ?? "N/A";

			dataGrid.Rows.Add(cube.Date, value);
		}

		dataGrid.Display();
	}
}