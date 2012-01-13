@echo off

echo [Installing NuGet Packages]

echo.
nuget install tests\MavenThought.IoCDemo.Tests\packages.config -o packages


echo.
echo Done
