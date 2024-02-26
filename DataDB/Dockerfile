FROM mcr.microsoft.com/mssql/server:2019-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password1$
ENV MSSQL_TCP_PORT=1433
EXPOSE 1433

WORKDIR /var/opt/mssql/data
COPY --chmod=755 attach_db.sh /ArtHubDb/
COPY --chmod=777 ArtHubDb2024.mdf .
COPY --chmod=777 ArtHubDb2024_log.ldf .

# RUN chmod +x /ArtHubDb/attach_db.sh
RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started"

ENTRYPOINT /ArtHubDb/attach_db.sh & /opt/mssql/bin/sqlservr