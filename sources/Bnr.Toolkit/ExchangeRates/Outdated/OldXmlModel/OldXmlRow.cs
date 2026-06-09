using System.Xml.Serialization;

namespace DustInTheWind.Bnr.Toolkit.ExchangeRates.Outdated.OldXmlModel;

public class OldXmlRow
{
    public string Data { get; set; }

    [XmlElement("CURSZ_AUD")]
    public OldXmlCursZ CursAud { get; set; }

    [XmlElement("CURSZ_CAD")]
    public OldXmlCursZ CursCad { get; set; }

    [XmlElement("CURSZ_CHF")]
    public OldXmlCursZ CursChf { get; set; }

    [XmlElement("CURSZ_CZK")]
    public OldXmlCursZ CursCzk { get; set; }

    [XmlElement("CURSZ_DKK")]
    public OldXmlCursZ CursDkk { get; set; }

    [XmlElement("CURSZ_EGP")]
    public OldXmlCursZ CursEgp { get; set; }

    [XmlElement("CURSZ_EUR")]
    public OldXmlCursZ CursEur { get; set; }

    [XmlElement("CURSZ_GBP")]
    public OldXmlCursZ CursGbp { get; set; }

    [XmlElement("CURSZ_HUF")]
    public OldXmlCursZ CursHuf { get; set; }

    [XmlElement("CURSZ_JPY")]
    public OldXmlCursZ CursJpy { get; set; }

    [XmlElement("CURSZ_MDL")]
    public OldXmlCursZ CursMdl { get; set; }

    [XmlElement("CURSZ_NOK")]
    public OldXmlCursZ CursNok { get; set; }

    [XmlElement("CURSZ_PLN")]
    public OldXmlCursZ CursPln { get; set; }

    [XmlElement("CURSZ_SEK")]
    public OldXmlCursZ CursSek { get; set; }

    [XmlElement("CURSZ_TRY")]
    public OldXmlCursZ CursTry { get; set; }

    [XmlElement("CURSZ_USD")]
    public OldXmlCursZ CursUsd { get; set; }

    [XmlElement("CURSZ_XAU")]
    public OldXmlCursZ CursXau { get; set; }

    [XmlElement("CURSZ_XDR")]
    public OldXmlCursZ CursXdr { get; set; }

    [XmlElement("CURSZ_RUB")]
    public OldXmlCursZ CursRub { get; set; }

    [XmlElement("CURSZ_SKK")]
    public OldXmlCursZ CursSkk { get; set; }

    [XmlElement("CURSZ_BGN")]
    public OldXmlCursZ CursBgn { get; set; }

    [XmlElement("CURSZ_ZAR")]
    public OldXmlCursZ CursZar { get; set; }

    [XmlElement("CURSZ_BRL")]
    public OldXmlCursZ CursBrl { get; set; }

    [XmlElement("CURSZ_CNY")]
    public OldXmlCursZ CursCny { get; set; }

    [XmlElement("CURSZ_INR")]
    public OldXmlCursZ CursInr { get; set; }

    [XmlElement("CURSZ_KRW")]
    public OldXmlCursZ CursKrw { get; set; }

    [XmlElement("CURSZ_MXN")]
    public OldXmlCursZ CursMxn { get; set; }

    [XmlElement("CURSZ_NZD")]
    public OldXmlCursZ CursNzd { get; set; }

    [XmlElement("CURSZ_RSD")]
    public OldXmlCursZ CursRsd { get; set; }

    [XmlElement("CURSZ_UAH")]
    public OldXmlCursZ CursUah { get; set; }

    [XmlElement("CURSZ_AED")]
    public OldXmlCursZ CursAed { get; set; }

    [XmlElement("CURSZ_HRK")]
    public OldXmlCursZ CursHrk { get; set; }

    [XmlElement("CURSZ_THB")]
    public OldXmlCursZ CursThb { get; set; }
}