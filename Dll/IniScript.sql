 
/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateLinkDataBaseRemove] ******/
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pos_DbUpdateLinkDataBaseRemove]') AND type = N'P')
    DROP PROCEDURE [dbo].[Pos_DbUpdateLinkDataBaseRemove]
GO

/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateLinkDataBase] ******/
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pos_DbUpdateLinkDataBase]') AND type = N'P')
    DROP PROCEDURE [dbo].[Pos_DbUpdateLinkDataBase]
GO

/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateFromText] ******/
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pos_DbUpdateFromText]') AND type = N'P')
    DROP PROCEDURE [dbo].[Pos_DbUpdateFromText]
GO

/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateFromText]    Script Date: 28/02/2025 11:39:26 AM ******/
CREATE  PROCEDURE [dbo].[Pos_DbUpdateFromText]
    @SQLQuery NVARCHAR(MAX) -- Can be a stored procedure name, SQL query, or DDL statement
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ServerName NVARCHAR(255),
            @DynamicSQL NVARCHAR(MAX),
            @StatusMessage NVARCHAR(MAX);

    DECLARE @ExecutionResults TABLE (
        ServerName NVARCHAR(255),
        StatusMessage NVARCHAR(MAX)
    );

    -- Start Process
    RAISERROR(N'Process Started', 0, 1) WITH NOWAIT;

    DECLARE db_cursor CURSOR FOR
    SELECT name 
    FROM sys.servers 
    WHERE is_linked = 1 AND product='Pos'; -- Include all linked servers

    OPEN db_cursor;
    FETCH NEXT FROM db_cursor INTO @ServerName;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            RAISERROR(N'Started Execution on [%s]', 0, 1, @ServerName) WITH NOWAIT;

            -- Check if the input is a DDL statement (e.g., CREATE, ALTER, DROP)
            IF LEFT(LTRIM(@SQLQuery), 6) IN ('CREATE', 'ALTER ', 'DROP  ')
            BEGIN
                -- Treat it as a DDL statement
                SET @DynamicSQL = 'EXEC (''' + REPLACE(@SQLQuery, '''', '''''') + ''') AT [' + @ServerName + '];';
            END
            ELSE IF LEFT(LTRIM(@SQLQuery), 6) IN ('SELECT', 'UPDATE', 'DELETE', 'INSERT', 'MERGE')
            BEGIN
                -- Treat it as a SQL Query
                SET @DynamicSQL = 'EXEC (''' + REPLACE(@SQLQuery, '''', '''''') + ''') AT [' + @ServerName + '];';
            END
            ELSE
            BEGIN
                -- Treat it as a Stored Procedure
                --SET @DynamicSQL = 'EXEC [' + @ServerName + '].pos.dbo.' + @SQLQuery + ';';
                --SET @DynamicSQL = 'EXEC [' + @ServerName + '].' + @SQLQuery + ';';
                SET @DynamicSQL = 'EXEC (''' + REPLACE(@SQLQuery, '''', '''''') + ''') AT [' + @ServerName + '];';

            END

            EXEC sp_executesql @DynamicSQL;

            RAISERROR(N'Finished Execution on [%s]', 0, 1, @ServerName) WITH NOWAIT;
            SET @StatusMessage = @ServerName + ' - Success';
        END TRY
        BEGIN CATCH
            SET @StatusMessage = @ServerName + ' - Failed: ' + ERROR_MESSAGE();
            RAISERROR(N'Failed Execution on [%s]: %s', 0, 1, @ServerName, @StatusMessage) WITH NOWAIT;
        END CATCH

        INSERT INTO @ExecutionResults (ServerName, StatusMessage)
        VALUES (@ServerName, @StatusMessage);

        FETCH NEXT FROM db_cursor INTO @ServerName;
    END

    CLOSE db_cursor;
    DEALLOCATE db_cursor;

    RAISERROR(N'Process Finished', 0, 1) WITH NOWAIT;
    SELECT * FROM @ExecutionResults;
END
GO
/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateLinkDataBase]    Script Date: 28/02/2025 11:39:26 AM ******/

CREATE  PROCEDURE [dbo].[Pos_DbUpdateLinkDataBase]
AS
BEGIN
    SET NOCOUNT ON;
    
    EXEC dbo.Pos_DbUpdateLinkDataBaseRemove

    DECLARE @ServerName NVARCHAR(255),
            @DatabaseName NVARCHAR(255),
            @Uname NVARCHAR(50),
            @Pw NVARCHAR(50),
            @SQL NVARCHAR(MAX);

    DECLARE db_cursor CURSOR FOR
    SELECT Terminal_Name, DataBaseName,'SA' Uname, Terminal_Password 
    FROM dbo.tbPosTerminalDetails
    WHERE Terminal_Name  IS NOT NULL AND DataBaseName IS NOT NULL 
            AND Terminal_Password IS NOT NULL AND DatabaseName='POS' AND Terminal_Status='T';

    OPEN db_cursor;
    FETCH NEXT FROM db_cursor INTO @ServerName, @DatabaseName, @Uname, @Pw;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            -- Drop existing linked server if it exists
            IF EXISTS (SELECT * FROM sys.servers WHERE name = @ServerName)
            BEGIN
                SET @SQL = N'EXEC sp_dropserver @server = @ServerName, @droplogins = ''droplogins'';';
                EXEC sp_executesql @SQL, N'@ServerName NVARCHAR(255)', @ServerName;
            END;

            -- Create linked server using SQL Server Native Client or OLE DB Provider
            SET @SQL = N'EXEC sp_addlinkedserver 
                            @server = @ServerName, 
                            @srvproduct = ''POS'',
                            @provider = ''SQLOLEDB'', -- Use SQLNCLI11 for SQL Server Native Client
                            @datasrc = @ServerName, 
                            @catalog = @DatabaseName;';
            EXEC sp_executesql @SQL, 
                               N'@ServerName NVARCHAR(255), @DatabaseName NVARCHAR(255)', 
                               @ServerName, @DatabaseName;

            -- Add security credentials
            SET @SQL = N'EXEC sp_addlinkedsrvlogin 
                            @rmtsrvname = @ServerName, 
                            @useself = ''false'', 
                            @rmtuser = @Uname, 
                            @rmtpassword = @Pw;';
            EXEC sp_executesql @SQL, 
                               N'@ServerName NVARCHAR(255), @Uname NVARCHAR(50), @Pw NVARCHAR(50)', 
                               @ServerName, @Uname, @Pw;

            -- Enable RPC
            SET @SQL = N'EXEC sp_serveroption @ServerName, ''rpc'', ''true'';
                         EXEC sp_serveroption @ServerName, ''rpc out'', ''true'';';
            EXEC sp_executesql @SQL, N'@ServerName NVARCHAR(255)', @ServerName;

            PRINT 'Linked server [' + @ServerName + '] added successfully!';
        END TRY
        BEGIN CATCH
            PRINT 'Error adding linked server [' + @ServerName + ']: ' + ERROR_MESSAGE();
        END CATCH;

        FETCH NEXT FROM db_cursor INTO @ServerName, @DatabaseName, @Uname, @Pw;
    END;

    CLOSE db_cursor;
    DEALLOCATE db_cursor;

    PRINT 'All linked servers processed!';
END;
GO
/****** Object:  StoredProcedure [dbo].[Pos_DbUpdateLinkDataBaseRemove]    Script Date: 28/02/2025 11:39:26 AM ******/
CREATE  PROCEDURE [dbo].[Pos_DbUpdateLinkDataBaseRemove]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ServerName NVARCHAR(255),
            @SQL NVARCHAR(MAX);

    DECLARE db_cursor CURSOR FOR
     SELECT name 
    FROM sys.servers 
    WHERE is_linked = 1 AND product='Pos'; 

    OPEN db_cursor;
    FETCH NEXT FROM db_cursor INTO @ServerName ;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            -- Drop existing linked server if it exists
            IF EXISTS (SELECT * FROM sys.servers WHERE name = @ServerName)
            BEGIN
                SET @SQL = N'EXEC sp_dropserver @server = @ServerName, @droplogins = ''droplogins'';';
                EXEC sp_executesql @SQL, N'@ServerName NVARCHAR(255)', @ServerName;
				  PRINT 'Removed linked server [' + @ServerName + ']: ';
            END;
			 
        END TRY
        BEGIN CATCH
            PRINT 'Error adding linked server [' + @ServerName + ']: ' + ERROR_MESSAGE();
        END CATCH;

        FETCH NEXT FROM db_cursor INTO @ServerName;
    END;

    CLOSE db_cursor;
    DEALLOCATE db_cursor;

    PRINT 'All linked servers processed!';
END;
GO
