USE EmployeeDB;
GO

IF OBJECT_ID('Sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE Sp_GetEmployeeCountByDepartment;
GO

CREATE PROCEDURE Sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO
