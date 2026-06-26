using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrXmlModel;

public class NbrRate
{
	[XmlAttribute("currency")]
	public string Currency { get; set; }

	[XmlAttribute("multiplier")]
	public string Multiplier { get; set; }

	[XmlText]
	public string Value { get; set; }
}