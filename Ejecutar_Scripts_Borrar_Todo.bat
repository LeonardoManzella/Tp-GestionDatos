sqlcmd -S localhost\SQLSERVER2012 -U gd -P gd2016 -i            dropeos/triggers.sql      ,dropeos/funciones-y-procedures.sql               ,dropeos/drop-tables-esquema.sql  -a 32767 -o resultado_output.txt