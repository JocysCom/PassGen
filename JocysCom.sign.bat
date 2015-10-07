@ECHO OFF
CALL:SIG "PassGen.Setup32\Debug\JocysComPassGen-x86.msi"
CALL:SIG "PassGen.Setup32\Debug\setup.exe"
CALL:SIG "PassGen.Setup32\Release\JocysComPassGen-x86.msi"
CALL:SIG "PassGen.Setup32\Release\setup.exe"
pause

GOTO:EOF
::=============================================================
:SIG :: Sign and Timestamp Code
::-------------------------------------------------------------
set sgt=C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\signtool.exe
set pfx=PassGen\Jocys.com.CodeSign.pfx
set d=Password Generator
set du=http://www.jocys.com/projects/passgen
set vsg=http://timestamp.verisign.com/scripts/timestamp.dll
if exist "%~1" "%sgt%" sign /f "%pfx%" /d "%d%" /du "%du%" /t "%vsg%" /v "%~1"
GOTO:EOF
