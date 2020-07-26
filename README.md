<p align="center">
  <img src="https://github.com/roshangautam/shazam/images/shazam.png?branch=develop" alt="Shazam"/>
</p>
<p align="center">
    <img src="https://github.com/roshangautam/shazam/workflows/build/badge.svg?branch=develop" alt="Build Status">
</p>

# Shazam

This is a template to develop [Microsoft Power Apps](https://powerapps.microsoft.com/en-us/) including both [Model Driven](https://powerapps.microsoft.com/en-us/) and [Canvas Applications](https://docs.microsoft.com/en-us/powerapps/maker/#canvas-apps) for power platform environments including MSFT Dynamics 365. This solutions contains the following

1. A Sample Power Platform Solution project which builds both managed and unmanaged solutions
2. Couple of Sample Power Control Framework Components, which are auto wired to the solution
3. A Sample Web Resources project using typescript which is also auto wired to the solution using packageMap file
4. A Sample Plugins project which is also wired to the solution using packageMap file
5. A Sample .net core 3.1 Azure Function
6. A Sample CRM Package to install the Sample solution with pre and post deployment steps

## Getting Started

Install the following

1. Install Visual Studio 2019 with .net framework 4.6.2, 4.7.2, .net core 3.1.* and MSBuild
2. Add MSBuild to your path variable or install dotnet cli

Clone the repo

```bash
$ git clone git@github.com:roshangautam/power-app.git
```

Navigate to the project folder

```bash
$ cd power-app
```

Install npm dependencies for web resources and controls

```bash
$ cd Src/Client/WebResources
$ npm ci
```

```bash
$ cd ../Controls/SampleDataSet
$ npm ci
```

```bash
$ cd ../SampleField
$ npm ci
```

Build the solution

```bash
$ dotnet build
```

if you have `msbuild` in your path, you can also execute the following to start a build

```bash
$ msbuild /t:build /restore
```
All build artifacts can be found inside the bin folder for each project. For e.g. Sample solution will contain both managed and unmanaged solution with all components injected (plugins, web resources and controls) and Package would contain a package deployer


## Roadmap
- [] Add Test Projects
- [] Build and add CRM dotnet tool to perform common solution actions like import/export solutions, packages and configuration data
- [] Add Wiki
