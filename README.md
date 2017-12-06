# TSQL-CLR.
My TSQL CLR helper functions.

# To compile DLL use(the DLL will be placed to Framework's directory):
C:\WINDOWS\Microsoft.NET\Framework\v3.5> ./csc.exe /target:library C:\CLR\CLR_PKM.cs

# To add assembly to SQL Server use:
use [MyDB]
go

EXEC sp_changedbowner 'sa'
ALTER DATABASE [MyDB] SET trustworthy ON
go

sp_configure 'clr enabled', 1
go

reconfigure
go

CREATE ASSEMBLY CLR_PKM FROM 'C:\CLR\CLR_PKM.dll' WITH PERMISSION_SET = UNSAFE;
go

CREATE FUNCTION [dbo].RegExSimpleMatch(@pattern [nvarchar](max), @matchString [nvarchar](max))
RETURNS BIT
EXTERNAL NAME CLR_PKM.Regex_PKM.RegExSimpleMatch
go

CREATE FUNCTION [dbo].StringTrim(@pattern [nvarchar](max), @charTrim [nvarchar](max))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLR_PKM.StringTrim_PKM.StringTrim
go

CREATE FUNCTION [dbo].StringTrimStart(@pattern [nvarchar](max), @charTrim [nvarchar](max))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLR_PKM.StringTrim_PKM.StringTrimStart
go

CREATE FUNCTION [dbo].StringTrimEnd(@pattern [nvarchar](max), @charTrim [nvarchar](max))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLR_PKM.StringTrim_PKM.StringTrimEnd
go

# Where in CLR_PKM.Regex_PKM.RegExSimpleMatch:
# CLR_PKM - Assembly name;
# Regex_PKM - Public class in DLL;
# RegExSimpleMatch - Function name in DLL.
