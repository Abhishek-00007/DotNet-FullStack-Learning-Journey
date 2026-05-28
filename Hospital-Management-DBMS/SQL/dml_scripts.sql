-- USE HospitalManagementDB;
-- GO

-- INSERT INTO Departments (DepartmentName)
-- VALUES
-- ('Cardiology'),
-- ('Neurology'),
-- ('Orthopedics'),
-- ('Pediatrics'),
-- ('Dermatology');

-- INSERT INTO Patients
-- (FirstName, LastName, Gender, DOB, Phone, Address, BloodGroup)
-- VALUES
-- ('Rahul', 'Sharma', 'Male', '1998-05-10', '9876543210', 'Delhi', 'B+'),
-- ('Priya', 'Verma', 'Female', '2000-08-15', '9876543211', 'Mumbai', 'A+'),
-- ('Amit', 'Singh', 'Male', '1995-03-22', '9876543212', 'Lucknow', 'O+'),
-- ('Sneha', 'Patel', 'Female', '1999-11-30', '9876543213', 'Ahmedabad', 'AB+'),
-- ('Karan', 'Mehta', 'Male', '2001-01-18', '9876543214', 'Pune', 'B-');

-- INSERT INTO Doctors
-- (DoctorName, Specialization, Phone, DepartmentID)
-- VALUES
-- ('Dr. Anil Kapoor', 'Cardiologist', '9991110001', 1),
-- ('Dr. Meera Joshi', 'Neurologist', '9991110002', 2),
-- ('Dr. Raj Malhotra', 'Orthopedic Surgeon', '9991110003', 3),
-- ('Dr. Pooja Shah', 'Pediatrician', '9991110004', 4),
-- ('Dr. Vikram Rao', 'Dermatologist', '9991110005', 5);

-- INSERT INTO Appointments
-- (PatientID, DoctorID, AppointmentDate, Status)
-- VALUES
-- (1, 1, '2026-05-25 10:00:00', 'Scheduled'),
-- (2, 2, '2026-05-25 11:00:00', 'Completed'),
-- (3, 3, '2026-05-26 09:30:00', 'Scheduled'),
-- (4, 4, '2026-05-26 12:00:00', 'Completed'),
-- (5, 5, '2026-05-27 02:00:00', 'Cancelled');

-- INSERT INTO Treatments
-- (AppointmentID, Diagnosis, TreatmentDetails)
-- VALUES
-- (2, 'Migraine', 'Prescribed pain relief medication and rest'),
-- (4, 'Viral Fever', 'Paracetamol prescribed for 5 days');

-- INSERT INTO Prescriptions
-- (TreatmentID, MedicineName, Dosage, DurationDays)
-- VALUES
-- (1, 'Sumatriptan', '1 tablet daily', 7),
-- (1, 'Ibuprofen', '2 tablets daily', 5),
-- (2, 'Paracetamol', '1 tablet three times daily', 5);

-- INSERT INTO Bills
-- (PatientID, AppointmentID, TotalAmount, BillDate)
-- VALUES
-- (2, 2, 2500.00, '2026-05-25'),
-- (4, 4, 1800.00, '2026-05-26');

-- INSERT INTO Payments
-- (BillID, PaymentMethod, PaymentStatus, PaymentDate)
-- VALUES
-- (1, 'Credit Card', 'Paid', '2026-05-25'),
-- (2, 'UPI', 'Pending', '2026-05-26');

-- UPDATE Appointments
-- SET Status = 'Completed'
-- WHERE AppointmentID = 1;

-- UPDATE Patients
-- SET Phone = '9998887776'
-- WHERE PatientID = 3;

-- DELETE FROM Prescriptions
-- WHERE PrescriptionID = 3;

--TEST TRIGGER

-- INSERT INTO Appointments
-- (PatientID, DoctorID, AppointmentDate, Status)
-- VALUES
-- (1, 2, '2026-06-01 10:30:00', 'Scheduled');