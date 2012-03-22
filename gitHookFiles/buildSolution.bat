@echo off
 
@call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\Tools\vsvars32.bat"
 
msbuild "%~f1" /T:Package
 
exit %ERRORLEVEL%