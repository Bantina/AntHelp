@echo off

echo *******************Make QX_Frame.ConsoleApp**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.ConsoleApp\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Base"  %cd%"\10-code\QX_Frame.ConsoleApp\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.Helper_DG_Framework"  %cd%"\10-code\QX_Frame.ConsoleApp\bin\Debug"  /y /E /S

echo *******************Make QX_Frame.Data**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.Data\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Base"  %cd%"\10-code\QX_Frame.Data\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.Helper_DG_Framework"  %cd%"\10-code\QX_Frame.Data\bin\Debug"  /y /E /S

echo *******************Make Data.Contract**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.Data.Contract\bin\Debug"  /y /E /S

echo *******************Make QX_Frame.Data.Service**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.Data.Service\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Base"  %cd%"\10-code\QX_Frame.Data.Service\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.Helper_DG_Framework"  %cd%"\10-code\QX_Frame.Data.Service\bin\Debug"  /y /E /S

echo *******************Make QX_Frame.Web**************************


echo *******************Make QX_Frame.WebAPI**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.WebAPI\bin"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Base"  %cd%"\10-code\QX_Frame.WebAPI\bin"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.Helper_DG_Framework"  %cd%"\10-code\QX_Frame.WebAPI\bin"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Web"  %cd%"\10-code\QX_Frame.WebAPI\bin"  /y /E /S

echo *******************Make QX_Frame.WebAPI.Test**************************

xcopy %cd%"\00-bin\Copy.All"  %cd%"\10-code\QX_Frame.WebAPI.Test\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.App.Base"  %cd%"\10-code\QX_Frame.WebAPI.Test\bin\Debug"  /y /E /S
xcopy %cd%"\00-bin\QX_Frame.Helper_DG_Framework"  %cd%"\10-code\QX_Frame.WebAPI.Test\bin\Debug"  /y /E /S

pause
