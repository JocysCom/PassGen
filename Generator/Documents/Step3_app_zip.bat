@echo off
SET wra="%ProgramFiles%\WinRAR\winrar.exe"
IF NOT EXIST %wra% SET wra="%ProgramFiles(x86)%\WinRAR\winrar.exe"
IF NOT EXIST %wra% SET wra="%ProgramW6432%\WinRAR\winrar.exe"
IF NOT EXIST %wra% SET wra="D:\Program Files\WinRAR\winrar.exe"
SET zip=%wra% a -ep
SET nam=PassGen
:: ---------------------------------------------------------------------------
echo --- Delete files
IF NOT EXIST Files\nul MKDIR Files
IF EXIST Files\%nam%.zip DEL %nam%.zip
IF EXIST Files\%nam%_debug.zip DEL %nam%_debug.zip
:: Archive application.
%zip% Files\%nam%.zip "..\bin\Debug\%nam%.exe"
:: Archive application with debug info.
::%zip% Files\%nam%_debug.zip "..\bin\Debug\%nam%.exe"
::%zip% Files\%nam%_debug.zip "..\bin\Debug\%nam%.pdb"
pause