SELECT FORMAT(TimeIn, 'dd/MM/yyyy HH:mm:ss') As DateIn,
CASE WHEN FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') IS NULL THEN FORMAT(TimeOut2, 'dd/MM/yyyy HHh:mm:ss') ELSE FORMAT(TimeOut, 'dd/MM/yyyy HH:mm:ss') END As DateOut,
OldDeviceName,OldPackage,LotNo,BeforeOSNG1,BeforeOSNG2,OSNG1,
CASE 
	WHEN CONVERT(varchar(5), OSNG1)  IS NULL THEN '' 
	WHEN CONVERT(varchar(5), OSNG1) = '0' THEN 'OK' 
	ELSE CONVERT(varchar(5), OSNG1) END As NG1,OSNG2,
CASE 
	WHEN CONVERT(varchar(5), OSNG2)  IS NULL THEN '' 
	WHEN CONVERT(varchar(5), OSNG2)  ='0' THEN 'OK' 
	ELSE CONVERT(varchar(5), OSNG2) END As NG2,
GotoProcess,GotoProcess2,QCJugdement
FROM [DBx].[QYI].[QYICase] WHERE Mode='BIN19'