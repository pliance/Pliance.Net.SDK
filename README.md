# Pliance .NET SDK

## NuGet
```bash
dotnet add package Pliance.NET-SDK
```

## Create Factory
```csharp
var factory = new PlianceClientFactory(
    secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
    issuer: "Test",
    url: "https://test.pliance.io/",
    certificate: new X509Certificate2("client.pfx")
);
```

## Register Person
```csharp
var client = factory.Create("givenname", "sub");
var result = await client.RegisterPerson(new RegisterPersonCommand()
{
    PersonReferenceId = "reference-id",
    FirstName = "Barack",
    LastName = "Obama"
});
```

## Delete Person
```csharp
var client = factory.Create("givenname", "sub");
var result = await client.DeletePerson(new DeletePersonCommand
{
    PersonReferenceId = "reference-id"
});

```

## Archive Person
```csharp
var client = factory.Create("givenname", "sub");
var result = await client.ArchivePerson(new ArchivePersonCommand
{
    PersonReferenceId = "reference-id"
});
```

## Classify Match
```csharp
var client = factory.Create("givenname", "sub");
var result = await client.ClassifyPersonHit(new ClassifyHitCommand
{
    PersonReferenceId = "reference-id",
    MatchId = "match-id",
    AliasId ="alias-id",
    Classification = ClassificationType.Positive
});
```