# Introduction

This package just have common models or interfaces that get constantly reused throughout. This should be kept to minimum.

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
- IPagingInfo
- PagingInfo

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
            return JsonConvert.DeserializeObject<T>(serializeObject, converters); ;
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

To install via NuGet, run this command in NuGet package manager console:

PM> Install-Package Common