Set Operations Test Project
===

## Requirements:  
- One of the supported platforms: 
    - Wndows 7+ (Any CPU)
    - Linux (Arm32 | Arm64 | x64 | x64 Alpine)
    - macOS (x64)
- .NET Core 3.1 SDK (https://dotnet.microsoft.com/download/dotnet/3.1)

---    
Run the following command to ensure that .NET Core 3.1 is installed correctly.
```bash
> dotnet --list-sdks
```

---
## Instructions
To run tests use the following command:

```bash
> cd ./src
> dotnet test -v quiet -l:"console;verbosity=normal" --nologo /p:CollectCoverage=true
```
