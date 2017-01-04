@echo off

echo *******************Clear QX_Frame.ConsoleApp**************************

rd   /S /Q  %cd%"\10-code\QX_Frame.ConsoleApp\bin\Debug\"

echo *******************Clear QX_Frame.Data**************************

rd   /S /Q %cd%"\10-code\QX_Frame.Data\bin\Debug\"

echo *******************Clear Data.Contract**************************

rd   /S /Q  %cd%"\10-code\QX_Frame.Data.Contract\bin\Debug\"

echo *******************Clear QX_Frame.Data.Service**************************

rd   /S /Q  %cd%"\10-code\QX_Frame.Data.Service\bin\Debug\"

echo *******************Clear QX_Frame.Web**************************


echo *******************Clear QX_Frame.WebAPI**************************

rd   /S /Q  %cd%"\10-code\QX_Frame.WebAPI\bin\"

echo *******************Clear QX_Frame.WebAPI.Test**************************

rd   /S /Q  %cd%"\10-code\QX_Frame.WebAPI.Test\bin\Debug\"

pause

