msbuild /t:pack /p:Configuration=Release

cd .\Cmas.Backend.Modules.Contracts\bin\Release\

nuget push Cmas.Backend.Modules.Contracts.1.0.1.nupkg -Source http://cm-ylng-msk-04/nuget/nuget

pause