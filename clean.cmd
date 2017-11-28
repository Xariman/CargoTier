del "*.mwm" /s /q /f
for /d /r . %%d in (bin,obj) do if exist "%%d" rd /s /q "%%d"
