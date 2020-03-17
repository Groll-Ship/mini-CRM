USE [CRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 17.03.2020 15:02:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUser]
	@id int,
	@login nvarchar(50),
	@role nchar (10),
	@userId int,
	@password nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users SET Login =  @login, Role =  @role , UserId = @userId, Password =  @password WHERE Id = @id;
END