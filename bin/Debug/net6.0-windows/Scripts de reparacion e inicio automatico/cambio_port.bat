@echo off

set xampp_path=E:\xampp
set mysql_path=%xampp_path%\mysql
set mysql_bin_path=%mysql_path%\bin
set my_ini_path=%mysql_path%\bin\my.ini

set  new_port=3307

echo Modificando el archivo my.ini...
echo [mysqld] >> %my_ini_path%
echo port=%new_port% >> %my_ini_path%
echo Hecho.

echo Deteniendo el servicio MySQL...
%mysql_bin_path%\mysqladmin.exe -u root -p shutdown
echo Hecho.

echo Iniciando el servicio MySQL...
start "" /B %mysql_bin_path%\mysqld.exe --defaults-file=%my_ini_path% --standalone --console
echo Hecho.

echo El puerto de MySQL se ha cambiado a %new_port%. Recuerde actualizar las configuraciones de conexión en sus aplicaciones.
pause