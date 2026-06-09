using System.Xml;
using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

public static class OldXmlSerializer
{
	public static OldXmlDataSet Deserialize(TextReader textReader)
	{
		XmlNameTable nameTable = new NameTable();
		XmlNamespaceManager namespaceManager = new(nameTable);
		namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
		namespaceManager.AddNamespace(string.Empty, "http://www.bnr.ro/xsd");
		XmlParserContext parserContext = new(nameTable, namespaceManager, null, XmlSpace.None);

		XmlReader xmlReader = XmlReader.Create(textReader, new XmlReaderSettings
		{
			CloseInput = false,
			IgnoreComments = true
		}, parserContext);

		XmlSerializer xmlSerializer = new(typeof(OldXmlDataSet));
		return (OldXmlDataSet)xmlSerializer.Deserialize(xmlReader);
	}
}