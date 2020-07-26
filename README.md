<p align="center">
  <img src=".assets/images/shazam.png" width=100 height =100/>
</p>

<p align="center">
  <img src="https://github.com/roshangautam/shazam/workflows/build/badge.svg?branch=develop" alt="Build Status">
</p>

# Shazam - Jumpstart Your Power Apps

Shazam is an [MSBuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2019) solution to help jumpstart power apps development [Microsoft Power Apps](https://powerapps.microsoft.com/en-us/) including both [Model Driven](https://docs.microsoft.com/en-us/powerapps/maker/model-driven-apps/model-driven-app-overview) and [Canvas Applications](https://docs.microsoft.com/en-us/powerapps/maker/#canvas-apps). The idea is to provide a one stop shop when it comes to building all things power platform.

## Features

- A Sample Power Platform Solution project which builds both managed and unmanaged solutions
- Couple of Sample Power Control Framework Components, which are auto wired to the solution
- A Sample Web Resources project using typescript which is also auto wired to the solution using packageMap file
- A Sample Plugins project which is also wired to the solution using packageMap file
- A Sample .net core 3.1 Azure Function
- A Sample CRM Package to install the Sample solution with pre and post deployment steps
- A Sample github action to publish crm pacakge, solutions and azure functions

## Getting Started

Prerequisites
- Windows 10 Operating Systems
- Install
  - [.net framework 3.5, 4.6.2, 4.7.2, .net core 3.1.*](https://dotnet.microsoft.com/download/dotnet-framework)
  - [Git for windows](https://git-scm.com/download/win)
  - [Latest MSBuild tools](https://visualstudio.microsoft.com/downloads/?q=build+tools)
  - Optionally you can install [Visual Studio 2019](https://visualstudio.microsoft.com/downloads) with all these components selected
- [optional] [Add MSBuild to your path environment variable](https://stackoverflow.com/questions/6319274/how-do-i-run-msbuild-from-the-command-line-using-windows-sdk-7-1)
- [optional] Install [PowerShell Core](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-windows?view=powershell-7)
- [optional] Install [Windows Terminal](https://github.com/microsoft/terminal)
- If you are having trouble installing .net framework 3.5 on Windows 10, read [this](https://www.winhelponline.com/blog/error-0x800f0954-net-framework-3-5-optional-feature-dism/)

Fire up a powershell terminal and clone this repo

```bash
git clone git@github.com:roshangautam/shazam.git
```

Navigate to the project folder

```bash
cd shazam
```

Restore dependencies for web resources, controls and crm package

```bash
cd src/Client/WebResources
npm ci
```

Restore dependencies for controls

```bash
cd src/Client/Controls/SampleDataSet
npm ci
```

```bash
cd src/Client/Controls/SampleField
npm ci
```

Restore dependencies for crm package. Execute following from the root folder

```bash
nuget restore .\src\Solutions\Package\packages.config -PackagesDirectory packages
```

Build the solution

```bash
dotnet build
```

> Optionally, if you added `msbuild` to environment path variable, you can also execute the following to build the solution
>
> ```bash
> msbuild /t:build /restore
> ```
>
> All build artifacts can be found inside the bin folder for each project. For e.g. Sample solution will contain both managed and unmanaged solution with all components injected (plugins, web resources and controls) and Package would contain a package deployer

## IDE Disclaimer

- Visual studio currently doesn't support .pcfproj and .cdsproj projects, although you can open the solution fine and work on rest of the projects you probably wouldn't be able to build the solution in VS. I would suggest using a powershell core terminal to compile the solution until Visual studio starts supporting these project types.

- [Jetbrains Rider](https://www.jetbrains.com/rider/) supports unknown *.*proj files and loads, cleans & builds both .pcfproj and .cdsproj projects. I am currently using this as my primary IDE

- You can also use [Visual Studio Code](https://code.visualstudio.com/docs/languages/csharp) as your code editor with additional extensions installed

## Considerations

- Uses MSBuild as the primary build engine for all projects. You can build the solution using one single command `dotnet build`
- Uses PowerApps MSBuild targets published as part of nuget packages
- Compatible with Power Apps CLI tools to for PCF controls and cds solutions
- The project is setup as a github template, meaning you can start a new project using this template as a baseline. Eventually the plan is to convert this to a dotnet template.

## Roadmap

- [x] Publish build artifacts
- [ ] Add contribution guidelines, license, copyright etc to this repo
- [ ] Add ILMerge to plugins project
- [ ] Add Stylecop
- [ ] Add Sample Console Apps
- [ ] Add Sample Test Projects
- [ ] Add Sample AzureDevops CI/CD pipelines using PowerApps AzureDevOps Extension
- [ ] Add Wiki
- [ ] Build and add CRM dotnet tool to perform common solution actions like import/export solutions/configuration data, import packages, code generators
- [ ] Convert the project to an interactive dotnet template such that a user can provide values for several variables while spinning up a new solution, for e.g. solution name, publisher prefix, publisher name. Also the ability to choose which projects you want to create as part of the solution, for e.g. controls, webresources, plugins, azure functions etc.
- [ ] Add frameworks for both server and client to provide a documented and structured way to add business logic in a test driven development fashion.
