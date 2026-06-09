using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

public class NbrCube
{
    [XmlAttribute("date")]
    public string Date { get; set; }

    [XmlElement("Rate")]
    public List<NbrRate> Rates { get; set; }
}