CREATE PROCEDURE [AppUser].[Register]
	@Email NVARCHAR(255),
	@Pwd NVARCHAR(64)
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

		INSERT INTO [dbo].[Users](Email, Pwd) VALUES (@Email, [dbo].[HashPwd](@Pwd));
	END TRY

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		RETURN
	END CATCH
END