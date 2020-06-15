

silagen generate-server -n "SilaFluentController" -o "Tecan.Sila2" .\Contracts\bin\Debug\Tecan.Sila2.Contracts.dll .\SilaFluentServer\SilaFluentServer.csproj

copy .\SilaFluentServer\SilaFluentController.sila.xml ..\tecan\fluent_sila_project

cd ..

fluent_python_venv\Scripts\activate

cd tecan

silacodegenerator -b fluent_sila_project -o _SilaFluentController



