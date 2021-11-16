IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ListBlogs'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.ListBlogs
GO

CREATE PROCEDURE dbo.ListBlogs
AS
BEGIN
    SELECT * from dbo.Blogs
END
GO

EXECUTE dbo.ListBlogs --1 /*value_for_param1*/, 2 /*value_for_param2*/
GO


