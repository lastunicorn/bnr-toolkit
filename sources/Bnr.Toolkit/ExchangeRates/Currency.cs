namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

/// <summary>
/// Value object that represents a transaction currency (ISO 4217 currency code).
/// </summary>
public sealed record class Currency
{
	public static readonly Currency RON = new("RON");
	public static readonly Currency AUD = new("AUD");
	public static readonly Currency BGN = new("BGN");
	public static readonly Currency CAD = new("CAD");
	public static readonly Currency CHF = new("CHF");
	public static readonly Currency CZK = new("CZK");
	public static readonly Currency DKK = new("DKK");
	public static readonly Currency EGP = new("EGP");
	public static readonly Currency EUR = new("EUR");
	public static readonly Currency GBP = new("GBP");
	public static readonly Currency HUF = new("HUF");
	public static readonly Currency JPY = new("JPY");
	public static readonly Currency MDL = new("MDL");
	public static readonly Currency NOK = new("NOK");
	public static readonly Currency PLN = new("PLN");
	public static readonly Currency RUB = new("RUB");
	public static readonly Currency SEK = new("SEK");
	public static readonly Currency SKK = new("SKK");
	public static readonly Currency TRY = new("TRY");
	public static readonly Currency USD = new("USD");
	public static readonly Currency XAU = new("XAU");
	public static readonly Currency XDR = new("XDR");

	private static readonly Dictionary<string, Currency> KnownValues = new(StringComparer.OrdinalIgnoreCase)
	{
		[RON.Value] = RON,
		[AUD.Value] = AUD,
		[BGN.Value] = BGN,
		[CAD.Value] = CAD,
		[CHF.Value] = CHF,
		[CZK.Value] = CZK,
		[DKK.Value] = DKK,
		[EGP.Value] = EGP,
		[EUR.Value] = EUR,
		[GBP.Value] = GBP,
		[HUF.Value] = HUF,
		[JPY.Value] = JPY,
		[MDL.Value] = MDL,
		[NOK.Value] = NOK,
		[PLN.Value] = PLN,
		[RUB.Value] = RUB,
		[SEK.Value] = SEK,
		[SKK.Value] = SKK,
		[TRY.Value] = TRY,
		[USD.Value] = USD,
		[XAU.Value] = XAU,
		[XDR.Value] = XDR
	};

	public string Value { get; }

	public Currency(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			throw new ArgumentNullException(nameof(value));

		if (value.Length != 3)
			throw new ArgumentException("Currency code must be exactly 3 characters long.", nameof(value));

		Value = value.ToUpperInvariant();
	}

	public override string ToString()
	{
		return Value;
	}

	public static implicit operator Currency(string value)
	{
		return value == null
			? null
			: new Currency(value);
	}

	public static implicit operator string(Currency currency)
	{
		return currency?.Value;
	}
}