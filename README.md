# BNR Toolkit

`BNR Toolkit` is a .NET library that helps you working with files and data exported from BNR.

BNR is the National Bank of Romania (Banca Națională Română).

- https://www.bnr.ro/
- https://en.wikipedia.org/wiki/National_Bank_of_Romania

The package is published as `DustInTheWind.Bnr.Toolkit`.

## Installation

Package Manager:

```powershell
Install-Package DustInTheWind.Bnr.Toolkit
```

.NET CLI:

```bash
dotnet add package DustInTheWind.Bnr.Toolkit
```

## Runtime Requirements

- Library target framework: `.NET 8.0`

## Quick Start

TBD

## NBR Document

The NBR files, full name NBR FX Rates files, are XML files containing the BNR exchange rates for different currencies:

- https://www.bnr.ro/23988-cursurile-pietei-valutare-in-format-xml

**Document locations**

- Last entry (day)
  - https://curs.bnr.ro/nbrfxrates.xml

- Last 10 entries (days)
  - https://curs.bnr.ro/nbrfxrates10days.xml
- Whole year:
  - `https://www.bnr.ro/files/xml/years/nbrfxrates<year>.xml`

**The XSD schema**

- https://curs.bnr.ro/xsd/nbrfxrates.xsd

## BNR Document

Older format

TBD

## Demo Project

The repository includes a sample CLI project in `sources/Bnr.Toolkit.Demo` that demonstrates:

- reading `transactions.csv`
- printing parsed data.

You can use this project as a reference implementation for your own importer/exporter tools.
