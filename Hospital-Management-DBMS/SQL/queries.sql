-- SELECT * FROM Departments;
-- SELECT * FROM Patients;
-- SELECT * FROM Doctors;
-- SELECT * FROM Appointments;
-- SELECT * FROM Treatments;
-- SELECT * FROM Prescriptions;
-- SELECT * FROM Bills;
-- SELECT * FROM Payments;

--Patient Appointments with Doctor Names

-- SELECT
--     A.AppointmentID,
--     P.FirstName + ' ' + P.LastName AS PatientName,
--     D.DoctorName,
--     A.AppointmentDate,
--     A.Status
-- FROM Appointments A
-- INNER JOIN Patients P
--     ON A.PatientID = P.PatientID
-- INNER JOIN Doctors D
--     ON A.DoctorID = D.DoctorID;

--All Patients with Their Appointments

-- SELECT
--     P.PatientID,
--     P.FirstName,
--     A.AppointmentID,
--     A.Status
-- FROM Patients P
-- LEFT JOIN Appointments A
--     ON P.PatientID = A.PatientID;

--Doctors and Their Appointments

-- SELECT
--     D.DoctorName,
--     A.AppointmentID,
--     A.AppointmentDate
-- FROM Appointments A
-- RIGHT JOIN Doctors D
--     ON A.DoctorID = D.DoctorID;

--Full Appointment-Patient Mapping

-- SELECT
--     P.FirstName,
--     A.AppointmentID,
--     A.Status
-- FROM Patients P
-- FULL JOIN Appointments A
--     ON P.PatientID = A.PatientID;

--Complete Treatment Report

SELECT
    P.FirstName + ' ' + P.LastName AS PatientName,
    D.DoctorName,
    T.Diagnosis,
    T.TreatmentDetails
FROM Treatments T
INNER JOIN Appointments A
    ON T.AppointmentID = A.AppointmentID
INNER JOIN Patients P
    ON A.PatientID = P.PatientID
INNER JOIN Doctors D
    ON A.DoctorID = D.DoctorID;

--Billing and Payment Report

-- SELECT
--     B.BillID,
--     P.FirstName AS PatientName,
--     B.TotalAmount,
--     Pay.PaymentMethod,
--     Pay.PaymentStatus
-- FROM Bills B
-- INNER JOIN Patients P
--     ON B.PatientID = P.PatientID
-- INNER JOIN Payments Pay
--     ON B.BillID = Pay.BillID;

--Depatment-wise Doctor List

-- SELECT
--     Dep.DepartmentName,
--     D.DoctorName,
--     D.Specialization
-- FROM Doctors D
-- INNER JOIN Departments Dep
--     ON D.DepartmentID = Dep.DepartmentID;

--Patients Who Have Completed Appointments

-- SELECT
--     FirstName,
--     LastName
-- FROM Patients
-- WHERE PatientID IN (
--     SELECT PatientID
--     FROM Appointments
--     WHERE Status = 'Completed'
-- );

--Patients with Bills Greater Than Average Bill

-- SELECT
--     PatientID,
--     TotalAmount
-- FROM Bills
-- WHERE TotalAmount > (
--     SELECT AVG(TotalAmount)
--     FROM Bills
-- );

--Doctors Having More Appointments Than Average

-- SELECT
--     DoctorName
-- FROM Doctors D
-- WHERE (
--     SELECT COUNT(*)
--     FROM Appointments A
--     WHERE A.DoctorID = D.DoctorID
-- ) > 1;

--Find Patients Treated by Neurologist

-- SELECT
--     FirstName,
--     LastName
-- FROM Patients
-- WHERE PatientID IN (
--     SELECT PatientID
--     FROM Appointments
--     WHERE DoctorID IN (
--         SELECT DoctorID
--         FROM Doctors
--         WHERE Specialization = 'Neurologist'
--     )
-- );

