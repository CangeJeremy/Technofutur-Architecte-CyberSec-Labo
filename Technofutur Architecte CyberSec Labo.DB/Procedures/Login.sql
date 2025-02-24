CREATE PROCEDURE [AppUser].[Login]
	@Email NVARCHAR(255),
	@Pwd NVARCHAR(64)
AS
BEGIN
	SELECT * FROM Users WHERE Email = @Email AND Pwd = [dbo].[HashPwd](@Pwd)
END
