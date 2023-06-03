@echo off

set xampp_path=E:\xampp
set mysql_bin_path=%xampp_path%\mysql\bin

echo Deteniendo el servicio MySQL...
%mysql_bin_path%\mysqladmin.exe -u root -p shutdown
echo Hecho.

echo Iniciando el servicio MySQL...
start "" /B %mysql_bin_path%\mysqld.exe --standalone --console
echo Hecho.

echo El servicio de MySQL se ha reiniciado correctamente.
pause