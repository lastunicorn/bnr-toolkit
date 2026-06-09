using DustInTheWind.Bnr.Toolkit.ExchangeRates;
using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Tables;

namespace DustInTheWind.Bnr.Toolkit.Demo;

internal static class Program
{
	private static async Task Main(string[] args)
	{
		// Uncomment the method you want to test.
		
		//await LoadExchangeRatesFromWeb1();
		//await LoadExchangeRatesFromWeb10();
		//await LoadExchangeRatesFromWeb(2026);
		//await LoadExchangeRatesFromFile();
	}

	private static async Task LoadExchangeRatesFromWeb1()
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadLastOneAsync();
		Display(exchangeRatesDocument, "EUR");
	}

	private static async Task LoadExchangeRatesFromWeb10()
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadLastTenAsync();
		Display(exchangeRatesDocument, "EUR");
	}

	private static async Task LoadExchangeRatesFromWeb(int year)
	{
		ExchangeRatesDocument exchangeRatesDocument = await ExchangeRatesOnlineDocument.LoadForYear(year);
		Display(exchangeRatesDocument, "EUR");
	}

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
			Footer = $"Count: {exchangeRatesDocument.Cubes.Count}"
		};

		dataGrid.Columns.Add("Date");
		dataGrid.Columns.Add("Rates", HorizontalAlignment.Right);
		dataGrid.Columns.Add("Multiplier", HorizontalAlignment.Right);

		foreach (Cube cube in exchangeRatesDocument.Cubes)
		{
			ExchangeRate exchangeRate = cube.Rates
				.FirstOrDefault(x => x.Currency == currency);

			string value = exchangeRate?.Value.ToString() ?? "N/A";
			string multiplier = exchangeRate?.Multiplier.ToString();

			dataGrid.Rows.Add(cube.Date, value, multiplier);
		}

		dataGrid.Display();
	}
}