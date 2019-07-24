@ECHO OFF
CALL:SIG "..\bin\Debug\passgen.exe"
CALL:SIG "..\bin\Release\passgen.exe"
echo.
pause
GOTO:EOF

::=============================================================
:SIG :: Sign and Timestamp Code
::-------------------------------------------------------------
:: SIGNTOOL.EXE Note:
:: Use the Windows 7 Platform SDK web installer that lets you
:: download just the components you need - so just choose the
:: ".NET developer \ Tools" and deselect everything else.
echo.
IF NOT EXIST "%~1" (
  ECHO "%~1" not exist. Skipping.
  GOTO:EOF
)
SET sgt=Tools\signtool.exe
IF NOT EXIST "%sgt%" SET sgt=%ProgramFiles(x86)%\Windows Kits\10\App Certification Kit\signtool.exe
IF NOT EXIST "%sgt%" SET sgt=%ProgramFiles(x86)%\Windows Kits\10\bin\x86\signtool.exe
IF NOT EXIST "%sgt%" SET sgt=%ProgramFiles%\Windows Kits\10\bin\x86\signtool.exe
:: Other options.
set pfx=D:\_Backup\Configuration\SSL\CodeSign_Standard\2016\Evaldas_Jocys.CodeSign.pfx
set d=Jocys.com Password Generator
set du=http://www.jocys.com/projects/passgen
set vsg=http://timestamp.verisign.com/scripts/timestamp.dll
if not exist "%sgt%" CALL:Error "%sgt%"
if not exist "%~1"   CALL:Error "%~1"
if not exist "%pfx%" CALL:Error "%pfx%"
"%sgt%" sign /f "%pfx%" /d "%d%" /du "%du%" /t "%vsg%" /v "%~1"
GOTO:EOF

:Error
echo File doesn't Exist: "%~1"
pause
