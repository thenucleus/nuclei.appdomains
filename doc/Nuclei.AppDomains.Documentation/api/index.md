# Nuclei.AppDomains


## AppDomainBuilder

The `AppDomainBuilder` class provides a single method that creates a new AppDomain and installs both a top level exception handler
and a assembly resolution method.

[!code-csharp[AppDomainBuilder.Assemble](..\..\Nuclei.AppDomains.Samples\AppDomainBuilderSample.cs?range=23-42)]
