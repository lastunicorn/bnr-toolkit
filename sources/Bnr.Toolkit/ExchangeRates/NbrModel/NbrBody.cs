using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.NbrModel;

public class NbrBody
{
    public string Subject { get; set; }

    public string OrigCurrency { get; set; }

    [XmlElement("Cube")]
    public List<NbrCube> Cubes { get; set; }
}