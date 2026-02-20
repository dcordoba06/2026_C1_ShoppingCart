CREATE PROCEDURE RET_ALL_USER_PR
AS
BEGIN
	SELECT ID, Created, Name, LastName,Password, Email, BirthDate, Status
	FROM tblUser;

END;