using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

public class OldXmlCursZ
{
	[XmlAttribute]
	public string FullName { get; set; }

	[XmlAttribute]
	public string MeasureUnit { get; set; }

	[XmlText]
	public string Value { get; set; }
}