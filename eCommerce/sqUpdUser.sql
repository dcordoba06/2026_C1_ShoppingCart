

CREATE PROCEDURE [dbo].[UPD_USER_PR]
	@P_ID int,
	@P_NAME nvarchar(50),
	@P_LAST_NAME nvarchar(50),
	@P_PASSWORD nvarchar(20),
	@P_EMAIL nvarchar(50),
	@P_BIRTH_DATE datetime,
	@P_STATUS nvarchar(2)
	AS

	BEGIN

		UPDATE tblUser
			SET 
				Name=@P_NAME,
				LastName=@P_LAST_NAME,
				Email=@P_EMAIL,
				Password=@P_PASSWORD,
				BirthDate=@P_BIRTH_DATE,
				Status=@P_STATUS
			WHERE ID=@P_ID;
	END