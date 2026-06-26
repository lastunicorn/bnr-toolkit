# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Is

`BNR Toolkit` is a .NET 8 library (`DustInTheWind.Bnr.Toolkit`) for reading XML files exported by BNR (National Bank of Romania) containing foreign exchange rates. Published as a NuGet package.

## Build & Run

```bash
# Restore, build, run tests
dotnet restore ./Bnr.Toolkit.slnx --configfile ./nuget.config
dotnet build ./Bnr.Toolkit.slnx -c Release --no-restore

# Run the demo CLI
dotnet run --project sources/Bnr.Toolkit.Demo/Bnr.Toolkit.Demo.csproj
```

The solution file is `Bnr.Toolkit.slnx` (new `.slnx` format). Requires .NET SDK 10.0 (set in `global.json`); library targets `net8.0`.

## Architecture

Two projects under `sources/`:

- **`Bnr.Toolkit`** — the library. All public types live under `DustInTheWind.Bnr.Toolkit.ExchangeRates`.
- **`Bnr.Toolkit.Demo`** — console app demonstrating the library; not part of the NuGet package.

### Key public surface

- `ExchangeRatesDocument` — main entry point. Call `LoadAsync(stream, documentType)` to deserialize an XML file into a document holding `List<DailyExchangeRates>`.
- `ExchangeRatesOnlineDocument` (static) — fetches from BNR URLs then delegates to `ExchangeRatesDocument.LoadAsync`.
- `DocumentType` enum — selects between the current NBR FX Rates format (`NbrFxRates`) and older formats (`OutdatedXmlDaily`, etc.).

### Two XML formats, two internal models

**Current format** (`NbrFxRates`): deserialized via `NbrSerializer` into `NbrXmlModel` types (`NbrDataSet`, `NbrHeader`, `NbrBody`, `NbrCube`, `NbrRate`), then mapped to the public model via `NbrCubeExtensions` / `NbrRateExtensions`.

**Old format** (`OutdatedXmlDaily`): deserialized via `OldXmlSerializer` into `Outdated/OldXmlModel` types, then mapped via `OldXmlRowExtensions`.

Both paths produce the same output: `ExchangeRatesDocument` → `List<DailyExchangeRates>` (date + rates) → `ExchangeRate` (currency string + decimal value).

## Releasing

NuGet is published by the `publish-nuget.yml` workflow. Push a tag in the form `vMAJOR.MINOR.PATCH` (e.g. `v1.3.0`) to trigger it. The version is injected at build time via MSBuild properties; `Directory.Build.props` defaults it to `0.0.0.0`.

## Code Conventions

From `.github/copilot-instructions.md` — apply these consistently:

- No `var`; use the concrete type.
- LINQ lambda parameter for the iterated item: `x`.
- Prefer `new()` target-typed construction.
- Object initializers with multiple properties: one property per line.
- No curly brackets for single-line `if` / `for` / `using` bodies.
- XML doc comments only on public types exposed via NuGet; omit them for solution-internal types.

### Test naming & layout

- One test file per public method/constructor: e.g. `QueryTests.cs`.
- Group test files for a class in a matching directory: e.g. `ColorTests/`.
- Test name pattern: `Having<setup>_When<action>_Then<result>`.
- `Assert.Throws` lambda must use a block body `{ }`.
