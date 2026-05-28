USE HospitalManagementDB;
GO
--Create User

-- CREATE LOGIN HospitalStaff
-- WITH PASSWORD = 'Hospital@123';
-- GO

--Grant Permission

-- GRANT SELECT, INSERT
-- ON dbo.Patients
-- TO HospitalStaff;
-- GO

--Revoke Permission

REVOKE INSERT
ON Patients
FROM HospitalStaff;