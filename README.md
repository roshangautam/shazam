# Power App Template
This is a boilerplate Visual studio solution to build power apps including model driven and canvas applications in power platform environments. This solutions contains the following

1. A Sample Power Platform Solution project which builds both managed and unmanaged solutions
2. Couple of Sample Power Control Framework Components, which are wired to the solution using Microsoft.PowerApps.MSbuild.Pcf targets
3. A Sample Plugins project which is also wired to the solution using packageMap file
4. A Sample Webresources project using typescript which is also wired to the solution using packageMap file

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

Install npm dependencies for controls

```bash
$ cd Src/Client/Controls/SampleDataSet
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

This will generate both managed and unmanaged solution with all components injected (plugins, webresources and controls)


## More Coming Soon
