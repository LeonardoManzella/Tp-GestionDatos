sqlcmd -S localhost\SQLSERVER2012 -U gd -P gd2016 -i sql/prueba.sql,sql/prueba2.sql  -a 32767 -o resultado_output.txt