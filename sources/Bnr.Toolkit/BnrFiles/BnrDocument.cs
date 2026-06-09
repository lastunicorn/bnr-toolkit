using System.Xml.Serialization;
using DustInTheWind.Bnr.Toolkit.BnrFiles.BnrModels;

namespace DustInTheWind.Bnr.Toolkit.BnrFiles;

public class BnrDocument
{
    public BnrDataSet DataSet { get; private set; }

    public static BnrDocument Load(Stream stream)
    {
        XmlSerializer xmlSerializer = new(typeof(BnrDataSet));

        return new BnrDocument
        {
            DataSet = (BnrDataSet)xmlSerializer.Deserialize(stream)
        };
    }
}