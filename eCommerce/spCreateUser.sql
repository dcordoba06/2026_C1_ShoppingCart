CREATE PROCEDURE CRE_USER_PR
	@P_NAME nvarchar(50),
	@P_LAST_NAME nvarchar(50),
	@P_PASSWORD nvarchar(20),
	@P_EMAIL nvarchar(50),
	@P_BIRTH_DATE datetime,
	@P_STATUS nvarchar(2)
	AS

	BEGIN

		INSERT INTO tblUser(Created, Name, LastName, Password, Email, BirthDate,Status)
		VALUES(GETDATE(), @P_NAME, @P_LAST_NAME, @P_PASSWORD, @P_EMAIL, @P_BIRTH_DATE, @P_STATUS);

	END
