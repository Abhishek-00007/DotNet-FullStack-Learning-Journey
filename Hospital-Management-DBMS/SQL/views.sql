
--Patient Appointment View

-- CREATE VIEW PatientAppointmentView AS
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

-- SELECT * FROM PatientAppointmentView;

--Billing Report View

-- CREATE VIEW BillingReportView AS
-- SELECT
--     B.BillID,
--     P.FirstName AS PatientName,
--     B.TotalAmount,
--     Pay.PaymentStatus
-- FROM Bills B
-- INNER JOIN Patients P
--     ON B.PatientID = P.PatientID
-- INNER JOIN Payments Pay
--     ON B.BillID = Pay.BillID;

--SELECT * FROM BillingReportView;

