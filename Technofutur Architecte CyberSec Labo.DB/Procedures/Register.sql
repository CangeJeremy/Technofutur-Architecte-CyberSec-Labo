CREATE PROCEDURE [AppUser].[Register]
	@Email NVARCHAR(255),
	@Pwd NVARCHAR(64),
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@City NVARCHAR(255)
AS
BEGIN
	BEGIN TRY
		IF LEN(TRIM(@Email)) = 0
		BEGIN
			RAISERROR (N'INVALID VALUE IN @Email', 16, 1);
			RETURN;
		END
		IF LEN(TRIM(@Pwd)) = 0
		BEGIN
			RAISERROR (N'INVALID VALUE IN @Pwd', 16, 1);
			RETURN;
		END
		IF LEN(TRIM(@FirstName)) = 0
		BEGIN
			RAISERROR (N'INVALID VALUE IN @FirstName', 16, 1);
			RETURN;
		END
		IF LEN(TRIM(@LastName)) = 0
		BEGIN
			RAISERROR (N'INVALID VALUE IN @LastName', 16, 1);
			RETURN;
		END
		IF LEN(TRIM(@City)) = 0
		BEGIN
			RAISERROR (N'INVALID VALUE IN @City', 16, 1);
			RETURN;
		END

		INSERT INTO [dbo].[Users](Email, Pwd, FirstName, LastName, City) VALUES (@Email, [dbo].[HashPwd](@Pwd), @FirstName, @LastName, @City);
	END TRY

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		RETURN
	END CATCH
END