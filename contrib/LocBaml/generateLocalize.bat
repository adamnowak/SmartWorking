set SmartWorkingPath=d:\adamnowak\private\Sylwek\SmartWorking
copy %SmartWorkingPath%\contrib\LocBaml\LocBaml.exe %SmartWorkingPath%\bin\gui\Debug\ /-Y
cd %SmartWorkingPath%\bin\gui\Debug\
locbaml /generate en-Us/SmartWorking.Office.Gui.resources.dll /trans:%SmartWorkingPath%\src\SmartWorking.Office\SmartWorking.Office.Gui\localizes\localize.csv /cul:en-US /out:%SmartWorkingPath%\src\SmartWorking.Office\SmartWorking.Office.Gui\localizes
locbaml /generate pl-PL/SmartWorking.Office.Gui.resources.dll /trans:%SmartWorkingPath%\src\SmartWorking.Office\SmartWorking.Office.Gui\localizes\localizePL.csv /cul:pl-PL /out:%SmartWorkingPath%\src\SmartWorking.Office\SmartWorking.Office.Gui\localizes
del %SmartWorkingPath%\bin\gui\Debug\LocBaml.exe
cd %SmartWorkingPath%\contrib\LocBaml