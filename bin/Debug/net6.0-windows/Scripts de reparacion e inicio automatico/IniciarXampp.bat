@echo off
pushd "E:\Xampp"
start /b "XAMPP Control Panel" xampp-control.exe
timeout /t 5 /nobreak
cd "E:\Xampp\apache\bin"
start /b "Apache HTTP Server" httpd.exe
cd "E:\Xampp\mysql\bin"
start /b "MySQL Server" mysqld.exe
timeout /t 5 /nobreak
exit