using System.Globalization;
using DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal static class OldXmlRowExtensions
{
	private static readonly CultureInfo CultureInfo = new("ro-RO");

	public static DailyExchangeRates ToDailyExchangeRates(this OldXmlRow oldXmlRow)
	{
		return new DailyExchangeRates
		{
			Date = DateOnly.Parse(oldXmlRow.Data, CultureInfo),
			Rates = GetExchangeRates(oldXmlRow).ToList()
		};
	}

	private static IEnumerable<ExchangeRate> GetExchangeRates(OldXmlRow oldXmlRow)
	{
		if (oldXmlRow.CursAud.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.AUD,
				Value = decimal.Parse(oldXmlRow.CursAud.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursCad.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.CAD,
				Value = decimal.Parse(oldXmlRow.CursCad.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursChf.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.CHF,
				Value = decimal.Parse(oldXmlRow.CursChf.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursCzk.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.CZK,
				Value = decimal.Parse(oldXmlRow.CursCzk.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursDkk.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.DKK,
				Value = decimal.Parse(oldXmlRow.CursDkk.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursEgp.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.EGP,
				Value = decimal.Parse(oldXmlRow.CursEgp.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursEur.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.EUR,
				Value = decimal.Parse(oldXmlRow.CursEur.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursGbp.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.GBP,
				Value = decimal.Parse(oldXmlRow.CursGbp.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursHuf.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.HUF,
				Value = decimal.Parse(oldXmlRow.CursHuf.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursJpy.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.JPY,
				Value = decimal.Parse(oldXmlRow.CursJpy.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursMdl.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.MDL,
				Value = decimal.Parse(oldXmlRow.CursMdl.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursNok.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.NOK,
				Value = decimal.Parse(oldXmlRow.CursNok.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursPln.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.PLN,
				Value = decimal.Parse(oldXmlRow.CursPln.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursSek.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.SEK,
				Value = decimal.Parse(oldXmlRow.CursSek.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursTry.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.TRY,
				Value = decimal.Parse(oldXmlRow.CursTry.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursUsd.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.USD,
				Value = decimal.Parse(oldXmlRow.CursUsd.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursXau.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.XAU,
				Value = decimal.Parse(oldXmlRow.CursXau.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursXdr.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.XDR,
				Value = decimal.Parse(oldXmlRow.CursXdr.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursRub.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.RUB,
				Value = decimal.Parse(oldXmlRow.CursRub.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursSkk.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.SKK,
				Value = decimal.Parse(oldXmlRow.CursSkk.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursBgn.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.BGN,
				Value = decimal.Parse(oldXmlRow.CursBgn.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursZar.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.ZAR,
				Value = decimal.Parse(oldXmlRow.CursZar.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursBrl.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.BRL,
				Value = decimal.Parse(oldXmlRow.CursBrl.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursCny.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.CNY,
				Value = decimal.Parse(oldXmlRow.CursCny.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursInr.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.INR,
				Value = decimal.Parse(oldXmlRow.CursInr.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursKrw.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.KRW,
				Value = decimal.Parse(oldXmlRow.CursKrw.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursMxn.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.MXN,
				Value = decimal.Parse(oldXmlRow.CursMxn.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursNzd.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.NZD,
				Value = decimal.Parse(oldXmlRow.CursNzd.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursRsd.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.RSD,
				Value = decimal.Parse(oldXmlRow.CursRsd.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursUah.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.UAH,
				Value = decimal.Parse(oldXmlRow.CursUah.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursAed.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.AED,
				Value = decimal.Parse(oldXmlRow.CursAed.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursHrk.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.HRK,
				Value = decimal.Parse(oldXmlRow.CursHrk.Value, CultureInfo)
			};
		}

		if (oldXmlRow.CursThb.Value != "-")
		{
			yield return new ExchangeRate
			{
				Currency = Currency.THB,
				Value = decimal.Parse(oldXmlRow.CursThb.Value, CultureInfo)
			};
		}
	}
}