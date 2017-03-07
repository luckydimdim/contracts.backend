::msbuild /t:pack /p:Configuration=Release
::cd .\Cmas.Backend.Modules.Contracts\bin\Release\
cd .\Cmas.Backend.Modules.Contracts\bin\Debug\

nuget push Cmas.Backend.Modules.Contracts.1.0.4.nupkg -Source http://cm-ylng-msk-04/nuget/nuget

pause