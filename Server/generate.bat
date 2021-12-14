

silagen generate-server -n "SilaFluentController" -o "tecan" -u "fluent" Build\Tecan.VisionX.Sila2.Contracts.dll SilaFluentServer\SilaFluentServer.csproj
silagen generate-provider .\SilaFluentServer\SimulationController.sila.xml .\SilaFluentServer\SimulationController\Dtos.cs .\SilaFluentServer\SimulationController\Provider.cs -n Tecan.VisionX.Sila2 -s

