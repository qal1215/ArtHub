sleep 15s
/opt/mssql-tools/bin/sqlcmd -S . -U sa -P Password1$ \
-Q "CREATE DATABASE [ArtHubDb2024] ON (FILENAME ='/var/opt/mssql/data/ArtHubDb2024.mdf') LOG ON (FILENAME = '/var/opt/mssql/data/ArtHubDb2024_log.ldf') FOR ATTACH;"