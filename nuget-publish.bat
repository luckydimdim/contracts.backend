set project_name=Cmas.Backend.Modules.Contracts
set nupkg_out_dir=nupkgs

::dotnet pack %project_name%\%project_name%.csproj --output %nupkg_out_dir% --include-source --configuration Release
dotnet nuget push %project_name%\%nupkg_out_dir%\*.nupkg --source http://cm-ylng-msk-04/nuget/nuget

pause