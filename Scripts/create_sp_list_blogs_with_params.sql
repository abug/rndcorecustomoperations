IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ListBlogsParams'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.ListBlogsParams
GO

CREATE PROCEDURE dbo.ListBlogsParams
    @url nvarchar = ''
AS
BEGIN
    -- body of the stored procedure
    SELECT * FROM dbo.Blogs WHERE Url LIKE '%' + @url + '%'
END
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.ListBlogsParams 'g'
GO