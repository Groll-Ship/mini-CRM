SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUser] 
	@login nvarchar(50),
	@role nchar(10),
	@userId int,
	@password nvarchar(50)
AS
BEGIN
	INSERT INTO Users (Login, Role, UserId, Password) VALUES (1, 2, 3, 4)
	SELECT SCOPE_IDENTITY()
END
GO

