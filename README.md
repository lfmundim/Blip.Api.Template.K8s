# BLiP.API.Template.K8s [![Build Status](https://travis-ci.org/lfmundim/Blip.Api.Template.K8s.svg?branch=master)](https://travis-ci.org/lfmundim/Blip.Api.Template.K8s) [![Nuget](https://buildstats.info/nuget/Blip.Api.Template.K8s?includePreReleases=true)](https://www.nuget.org/packages/blip.api.template.K8s) [![GitHub stars](https://img.shields.io/github/stars/lfmundim/Blip.Api.Template.K8s.svg)](https://github.com/lfmundim/Blip.Api.Template.K8s/stargazers)


## This template aims to kickstart the development of an API to be used alongside BLiP's Builder feature, ready for Kubernetes orchestration

## Installation
If you already have `dotnet` installed, you can install this template with the command
```sh
dotnet new -i Blip.Api.Template.K8s
```

If you don't have `dotnet` installed, follow [these](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial) instructions from _Microsoft_ to install it on GNU/Linux, Mac or Windows, and then use the command above.

## Usage
To create a new project using this template, after installing, type in the following command
```sh
dotnet new blip-api-k8s --projectName NameOfYourApi --aksName NameInAKS
```
Replace `NameOfYourApi` with whatever your API will be called within the Orhcestration YAML files. Your new project should be created in the open folder.

### Renaming the `Services` project
By default, when you create a new solution using the template, all `.csproj` files will use the name of the folder you're in (along with any mentions of `Blip.Api.Template`. You can give the `Services` project a different name should you like it using the CLI param `--Services`. 

For example, if you run the command

```bash
dotnet new blip-api-k8s --projectName blipapi-template --aksName NameInAKS --Services DifferentName.Services
```

inside a folder named `Blip.Bot.Project`, it will create a `.sln` with two projects: `Blip.Bot.Project.csproj` and `DifferentName.Services.csproj`, instead of a `Blip.Bot.Project.Services.csproj`.

## File Structure
```cs
 📁Blip.Bot.Project // assuming your folder is called Blip.Bot.Project. Whatever name you choose will replace all occurrences of that string in the sln
 |__📁Api
    |__📃{azure-pipelines.yml}
    |__📁Blip.Bot.Project // The Web API project Folder
    |   |__📁Controllers 
    |   |   |__📃{HealthController.cs}
    |   |   |__📃{...}
    |   |__📁Middleware
    |   |   |__📃{ErrorHandlingMiddleware.cs}
    |   |   |__📃{YourMiddlewares.cs}
    |   |   |__📃{...}
    |   |__📁charts
    |   |   |__📁blipapitemplate
    |   |   |   |__📁templates // autoscale should be moved inside this folder when HPA begins to work
    |   |   |   |   |__📃{_helpers.tpl}
    |   |   |   |   |__📃{autoscale.yaml} 
    |   |   |   |   |__📃{deployment.yaml}
    |   |   |   |   |__📃{ingress.yaml}
    |   |   |   |   |__📃{secrets.yaml}
    |   |   |   |   |__📃{service.yaml}
    |   |   |   |__📃{.helmignore}
    |   |   |   |__📃{Chart.yaml}
    |   |   |   |__📃{values.yaml}
    |   |__📃Startup.cs
    |   |__📃Program.cs
    |   |__📃appsettings.json
    |__📁Blip.Bot.Project.Facades // Project to use for any logic to be handled
    |   |__📁Extensions // Recommended architecture
    |   |   |__📃{ServiceCollectionExtensions.cs}
    |   |   |__📃{YourExtensionFiles}
    |   |__📁Interfaces // Recommended architecture
    |   |   |__📃{IAuthorizationFacade.cs}
    |   |   |__📃{YourInterfaceFiles}
    |   |__📃{AuthorizationFacade.cs}
    |   |__📃{YourServiceFiles}
    |__📁Blip.Bot.Project.Services // (If needed) The project to use for 3rd party APIs to be consumed
    |   |__📁Interfaces // Recommended architecture
    |   |   |__📃{YourInterfaceFiles}
    |   |__📃{YourServiceFiles}
    |__📁Blip.Bot.Project.Models // Models to be used by the Solution
    |   |__📁UI // Models directly used by the API project
    |   |   |__📃{ApiSettings.cs}
    |   |   |__📃{BlipBotSettings.cs}
    |   |   |__📃{YourUIModels}
    |   |__📃{Constants.cs}
    |   |__📃{YourSharedModels}
    |__📁Blip.Api.Template.Tests // It is strongly suggested that you try to cover most parts of your code
    |   |__{YourTestsFiles.cs}
    |__⚙️.editorconfig
```

## Uninstallation
To uninstall the template from your local machine, use the command
```sh
dotnet new -u Blip.Api.Template.K8s
```
Your current projects that already use the template **will not** be affected.

## Recommended Packages
This template comes bundled with a few highly recommended packages, such as [Blip.HttpClient](https://github.com/lfmundim/Blip.HttpClient), [RestEase](https://github.com/canton7/RestEase), [Serilog](https://github.com/serilog/serilog) and [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore). Those packages' repositories do a great job at explaining what they do, and it is strongly recommended that you familiarize yourself with them.

Furthermore, I will list some other interesting packages:
* For testing:
    * [Shouldly](https://github.com/shouldly/shouldly): *Assert* library that makes it easy to read and understand tests assertions. For example:
    ```cs
    bex.Reason.Description.ShouldBe("The requested resource was not found");
    getResource.ShouldNotBeNull();
    exceptionThrown.ShouldBeTrue();
    ```
    * [XUnit](https://github.com/xunit/xunit): Widely used Testing Framework for .NET
    * [NSubstitute](https://github.com/nsubstitute/NSubstitute): Library that allows the mocking of 3rd party (or 1st party) services that act like *black boxes*, meaning that you can't access their source code and therefore it is not up to you (or not interesting for you) to test it, but you still need to verify if the required methods are *at least* being called. Note that, as it is a substitute, the actual method *will not* be called, meaning that it *will not* access any external sources. For example:
    ```cs
    Serilog.ILogger _logger = Substitute.For<ILogger>();
    // <...>
    // Substitute call that will not, in fact, log anything anywhere
    _logger.Received(1).Information(Arg.Any<string>(), Arg.Any<string>()); 
    // Checks if the Serilog.ILogger.Information method was called EXACTLY one time with two params, where both of them are strings
    ```
* For logging:
    * [RestingLogger](https://github.com/lfmundim/RestingLogger): easy-to-use RestEase-powered library that logs every request sent and response received from external APIs. Optimized and tested using Serilog while logging on SEQ. **Note: might not work on other architectures.**
