set SmartWorkingPath=d:\adamnowak\private\Sylwek\SmartWorking
copy %SmartWorkingPath%\contrib\LocBaml\LocBaml.exe %SmartWorkingPath%\bin\gui\Debug\ /-Y
cd %SmartWorkingPath%\bin\gui\Debug\
locbaml /parse en-Us/SmartWorking.Office.Gui.resources.dll /out:%SmartWorkingPath%\src\SmartWorking.Office\SmartWorking.Office.Gui\localizes\localize.csv
del %SmartWorkingPath%\bin\gui\Debug\LocBaml.exe