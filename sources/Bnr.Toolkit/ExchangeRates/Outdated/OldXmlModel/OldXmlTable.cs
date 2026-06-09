using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

public class OldXmlTable
{
    [XmlElement("Row")]
    public List<OldXmlRow> Rows { get; set; }
}