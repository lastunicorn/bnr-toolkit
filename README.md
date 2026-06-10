# BNR Toolkit

[![GitHub Repo](https://img.shields.io/badge/github-repo-blue?logo=github)](https://github.com/lastunicorn/bnr-toolkit) [![GitHub Build](https://img.shields.io/github/actions/workflow/status/lastunicorn/bnr-toolkit/build-master.yml?logo=github)](https://github.com/lastunicorn/bnr-toolkit/actions/workflows/build-master.yml) [![NuGet Version](https://img.shields.io/nuget/v/DustInTheWind.Bnr.Toolkit?logo=nuget)](https://www.nuget.org/packages/DustInTheWind.Bnr.Toolkit) [![NuGet Downloads](https://img.shields.io/nuget/dt/DustInTheWind.Bnr.Toolkit?logo=nuget)](https://www.nuget.org/packages/DustInTheWind.Bnr.Toolkit)

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
