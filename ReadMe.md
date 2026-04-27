# Introduction

This package has common models or interfaces that are reused across projects. Keep it small.

- AuditInfo
- Messages (Generic Bases)
- Paging


## Package Dependencies

- HI.Core.DomainDrivenDesign

## AuditInfo

- SourceAuditInfo
- IAuditInfo (is already in DomainDrivenDesign )
- AuditInfo (is already in DomainDrivenDesign)

## Paging

- Connection
- IPageInfo
- PageInfo

## Messages

- ICommand
- IExternalCommand
- IExternalEvent
- ExternalCommand
- ExternalEvent
- IEvent (is already in DomainDrivenDesign )

## Json Convertors

There are also some helpful custom JsonConvertors, for example DateOnly and Abstracted Class (ie AuditInfo)


### AbstractConverter

Use this class, for mapping abstract type, to real type:

```
var settings = new JsonSerializerSettings
{
    Converters = {
        new AbstractConverter<Thing, IThingy>(),
        new AbstractConverter<Thing2, IThingy2>()
    },
};

JsonConvert.DeserializeObject(json, type, settings);

```

### DateOnlyJsonConverter

Example

```
       var expected = tableCollection.Select(x => x.Convert<BENCHMARK_ACCOUNTING_ANALYTICS>(new DateOnlyJsonConverter())).ToList();

        public static T Convert<T>(this object instance, params JsonConverter[] converters)
        {
            var serializeObject = JsonConvert.SerializeObject(instance, converters);
            return JsonConvert.DeserializeObject<T>(serializeObject, converters);
        }

```

### ConcreteTypeConverter

This is in DomainDrivenDesign, so will have access to this as well

```
    public class DomainEvent : IDomainEvent
    {
        public string Id { get; set; }

        [JsonConverter(typeof(ConcreteTypeConverter<AuditInfo>))]
        public IAuditInfo AuditInfo { get; set; }

        .....
    }

```



## Installing from NuGet

Package id: **Cbrown11.Common.Models**

```bash
dotnet add package Cbrown11.Common.Models
```

In the Package Manager Console:

```
Install-Package Cbrown11.Common.Models
```

## Publishing to GitHub Packages (CI)

The workflow [`.github/workflows/publish-package.yml`](.github/workflows/publish-package.yml) builds, tests, packs **Cbrown11.Common.Models**, and pushes to **GitHub Packages** for this repo’s owner (`https://nuget.pkg.github.com/cbrown11/index.json`).

It runs when any of these happen:

| Trigger | What to do |
|--------|------------|
| **Manual** | GitHub → **Actions** → **Publish package** → **Run workflow**. Uses the `Version` in `src/Common.Models/Common.Models.csproj`. |
| **Git tag** | Push a tag matching `v*` (e.g. `v1.0.1`). The NuGet package version is the tag with the leading `v` removed (`1.0.1`). |
| **Release** | Publish a **GitHub Release** (not draft). Version is taken from the release’s tag name the same way (`v1.0.1` → `1.0.1`). |

Example tag publish:

```bash
git tag v1.0.1
git push origin v1.0.1
```

## Installing from GitHub Packages (private feed)

If the package is only on GitHub Packages, add the feed and authenticate. In the consuming repo, extend **`nuget.config`**:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="github-cbrown11" value="https://nuget.pkg.github.com/cbrown11/index.json" />
  </packageSources>
</configuration>
```

Then use a **PAT** with `read:packages` (and `repo` if the package visibility requires it), or set **`NUGET_AUTH_TOKEN`** in CI. See GitHub’s docs: [Working with the NuGet registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry).

```bash
dotnet add package Cbrown11.Common.Models --source github-cbrown11
```