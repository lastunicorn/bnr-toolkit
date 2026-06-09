using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrXmlModel;

public static class NbrSerializer
{
	public static NbrDataSet Deserialize(TextReader textReader)
	{
		XmlSerializer xmlSerializer = new(typeof(NbrDataSet));
		return (NbrDataSet)xmlSerializer.Deserialize(textReader);
	}
}