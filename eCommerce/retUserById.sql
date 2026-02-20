CREATE PROCEDURE RET_USER_BY_ID_PR
@P_ID INT
AS
BEGIN
	SELECT ID, Created, Name, LastName,Password, Email, BirthDate, Status
	FROM tblUser
	WHERE Id=@P_ID;

END;