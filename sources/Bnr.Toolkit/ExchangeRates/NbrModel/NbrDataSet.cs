using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

[XmlRoot("DataSet", Namespace = "http://www.bnr.ro/xsd")]
public class NbrDataSet
{
    public NbrHeader Header { get; set; }

    public NbrBody Body { get; set; }
}