# PokemonApi
An experiment in collecting and translating Pokemon data.

## Overview
This repository is to 

## Assumptions and design
The following assumptions have been made and decisions/designs are based on that.

### Reader assumptions
1. The reader has some programming knowledge
2. The reader has used git
3. The user has or is able to get administrator access to the machine this is being run/tested/coded on.

### Design notes
1. This is a design vs. a full scale production ready solution.

2. Certain functions have not been implemented due to a) time, b) it would be over-engineering and c) Agile practice

3. A single language with the first found description is used

4. A simplified HTTP client was used vs. a third party library for a variety of reasons including; not relying on third party code and support, a smaller memory footprint, only using functions that are needed, and better logging/metric capability can be added.

5. See Project breakdown [Project breakdown](docs/ProjectBreakDown.md)

6. Certain mappers have been left off, but in principle should be there to keep responsibilities clean

   

### If it were a production solution
1. Local or distributed caching may be required for performance
2. Circuit breakers would be applied for categorised feature switching off
3. Monitoring and alerting
4. Performance tests would be added
5. Smoke tests to validate live production environment
6. A potential framework for Authentication may have been implemented
7. The deployment process would use the HealthCheck endpoint before switching
8. A green/blue deployment strategy may be used
9. Containerisation may be used as well
10. Logging would include a correlationId/sessionId to better track requests 

## Installation Prerequisites
The solution is written in C# using .NET Core 3.1 due to the Long Term Support (LTS) option. Once another LTS solution is available it will be upgraded.

This means you will require a supported framework and Software Development Kit (SDK) to code for it and run it locally.

1. Install the SDK and Framework from [Microsoft download site](https://dotnet.microsoft.com/download/dotnet/3.1)
2. To confirm this is working open either command prompt (Windows key/start + R, type in CMD or PowerShell). Once loaded type in `dotnet --version`. This should show at least `3.1`. Note: if you have a higher version installed, it will still compile/run.
3. A tool to download/checkout this GitHub Repository e.g. [Git](https://git-scm.com/downloads) - some Integrated Development Environments (IDEs) have built in tools.
Note: An understanding of how to use git is not required - an alternative is to download the solution compressed
4. An IDE such as Visual Studio, or even Visual Studio Code is required to edit/modify code. 
5. You may require local/machine Administrator access to allow API port listeners.


## Building
1. Make sure you have cloned the repository
2. Open PowerShell or your preferred command line utility (could also be the built in one in Visual Studio Code)
3. Navigate into the folder where the `.sln` file is (root folder)
4. Type in `dotnet build` by default this is configured for `Debug` to compile/build for `Release` use `dotnet build  --configuration Release`
5. This should compile to a folder `\Pokemon\src\Pokemon\bin\Debug\netcoreapp3.1` from the current folder.

## Running

## Testing

## Contributing
