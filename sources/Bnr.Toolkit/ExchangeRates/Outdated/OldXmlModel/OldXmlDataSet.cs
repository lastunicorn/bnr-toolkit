using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

[XmlRoot("DataSet", Namespace = "http://www.bnr.ro/xsd")]
public class OldXmlDataSet
{
	public string NumeClasaStatistica { get; set; }

	public string ObservatiiClasaStatistica { get; set; }

	public string NotaClasaStatistica { get; set; }

	public string Metodologie { get; set; }

	public OldXmlTable Table { get; set; }
}