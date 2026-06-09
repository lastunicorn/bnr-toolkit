using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.BnrFiles.BnrModels;

public class BnrCursEur
{
    [XmlAttribute]
    public string FullName { get; set; }

    [XmlAttribute]
    public string MeasureUnit { get; set; }

    [XmlText]
    public string Value { get; set; }
}