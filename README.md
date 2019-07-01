# Pliance .NET SDK

```csharp
var factory = new PlianceClientFactory(
    secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
    issuer: "Test",
    url: "https://test.pliance.io/",
    certificate: new X509Certificate2("client.pfx")
);

var client = factory.Create("givenname", "sub");
var result = await client.RegisterPerson(new RegisterPersonCommand()
{
    PersonReferenceId = "reference-id",
    FirstName = "Adam",
    LastName = "Användare"
});
```