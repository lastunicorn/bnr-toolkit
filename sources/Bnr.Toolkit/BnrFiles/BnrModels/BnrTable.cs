using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.BnrFiles.BnrModels;

public class BnrTable
{
    [XmlElement("Row")]
    public List<BnrRow> Rows { get; set; }
}