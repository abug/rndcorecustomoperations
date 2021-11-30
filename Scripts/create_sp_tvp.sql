CREATE TYPE BlogTableType 
   AS TABLE
      ( IdValue INT
      , UrlValue NVARCHAR(MAX));
GO

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ListBlogsWithTableParams'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.ListBlogsWithTableParams
GO

CREATE PROCEDURE dbo.ListBlogsWithTableParams
    @BlogIds BlogTableType READONLY
AS
SET NOCOUNT ON
BEGIN
    --SELECT 'VALUE'
    SELECT UrlValue AS BlogUrl FROM @BlogIds
    --SELECT * FROM dbo.Blogs JOIN @TVP ON BlogId = IdValue
    SELECT * FROM @BlogIds
END
GO

DECLARE @BlogTVP AS BlogTableType;
/* Add data to the table variable. */
INSERT INTO @BlogTVP (IdValue, UrlValue)
    VALUES (11, 'http://www.twitter.com')
INSERT INTO @BlogTVP (IdValue, UrlValue)
    VALUES (12, 'http://www.google.co.in')

--SELECT * FROM @LocationTVP

EXEC dbo.ListBlogsWithTableParams @BlogTVP;
GO