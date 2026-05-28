
--Calculate Age Function

-- CREATE FUNCTION CalculateAge
-- (
--     @DOB DATE
-- )
-- RETURNS INT
-- AS
-- BEGIN
--     DECLARE @Age INT;

--     SET @Age = DATEDIFF(YEAR, @DOB, GETDATE());

--     RETURN @Age;
-- END;

-- SELECT
--     FirstName,
--     LastName,
--     dbo.CalculateAge(DOB) AS Age
-- FROM Patients;

--Get Completed Appointments Function

-- CREATE FUNCTION GetCompletedAppointments()
-- RETURNS TABLE
-- AS
-- RETURN
-- (
--     SELECT *
--     FROM Appointments
--     WHERE Status = 'Completed'
-- );

-- SELECT * 
-- FROM dbo.GetCompletedAppointments();