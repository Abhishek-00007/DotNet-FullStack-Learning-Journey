-- CREATE DATABASE HospitalManagementDB;
-- GO

-- USE HospitalManagementDB;
-- GO

-- CREATE TABLE Departments (
--     DepartmentID INT PRIMARY KEY IDENTITY(1,1),
--     DepartmentName VARCHAR(100) UNIQUE NOT NULL
-- );

-- CREATE TABLE Patients (
--     PatientID INT PRIMARY KEY IDENTITY(1,1),
--     FirstName VARCHAR(50) NOT NULL,
--     LastName VARCHAR(50) NOT NULL,
--     Gender VARCHAR(10) CHECK (Gender IN ('Male', 'Female', 'Other')),
--     DOB DATE NOT NULL,
--     Phone VARCHAR(15) UNIQUE,
--     Address VARCHAR(255),
--     BloodGroup VARCHAR(5)
-- );

-- CREATE TABLE Doctors (
--     DoctorID INT PRIMARY KEY IDENTITY(1,1),
--     DoctorName VARCHAR(100) NOT NULL,
--     Specialization VARCHAR(100) NOT NULL,
--     Phone VARCHAR(15) UNIQUE,
--     DepartmentID INT,

--     FOREIGN KEY (DepartmentID)
--     REFERENCES Departments(DepartmentID)
-- );

-- CREATE TABLE Appointments (
--     AppointmentID INT PRIMARY KEY IDENTITY(1,1),
--     PatientID INT NOT NULL,
--     DoctorID INT NOT NULL,
--     AppointmentDate DATETIME NOT NULL,
--     Status VARCHAR(20)
--     CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled')),

--     FOREIGN KEY (PatientID)
--     REFERENCES Patients(PatientID),

--     FOREIGN KEY (DoctorID)
--     REFERENCES Doctors(DoctorID)
-- );

-- CREATE TABLE Treatments (
--     TreatmentID INT PRIMARY KEY IDENTITY(1,1),
--     AppointmentID INT UNIQUE,
--     Diagnosis VARCHAR(255) NOT NULL,
--     TreatmentDetails TEXT,

--     FOREIGN KEY (AppointmentID)
--     REFERENCES Appointments(AppointmentID)
-- );

-- CREATE TABLE Prescriptions (
--     PrescriptionID INT PRIMARY KEY IDENTITY(1,1),
--     TreatmentID INT NOT NULL,
--     MedicineName VARCHAR(100) NOT NULL,
--     Dosage VARCHAR(50) NOT NULL,
--     DurationDays INT CHECK (DurationDays > 0),

--     FOREIGN KEY (TreatmentID)
--     REFERENCES Treatments(TreatmentID)
-- );

-- CREATE TABLE Bills (
--     BillID INT PRIMARY KEY IDENTITY(1,1),
--     PatientID INT NOT NULL,
--     AppointmentID INT UNIQUE,
--     TotalAmount DECIMAL(10,2)
--     CHECK (TotalAmount >= 0),
--     BillDate DATE NOT NULL,

--     FOREIGN KEY (PatientID)
--     REFERENCES Patients(PatientID),

--     FOREIGN KEY (AppointmentID)
--     REFERENCES Appointments(AppointmentID)
-- );

-- CREATE TABLE Payments (
--     PaymentID INT PRIMARY KEY IDENTITY(1,1),
--     BillID INT UNIQUE,
--     PaymentMethod VARCHAR(50) NOT NULL,
--     PaymentStatus VARCHAR(20)
--     CHECK (PaymentStatus IN ('Paid', 'Pending', 'Failed')),
--     PaymentDate DATE NOT NULL,

--     FOREIGN KEY (BillID)
--     REFERENCES Bills(BillID)
-- );

-- SELECT * FROM INFORMATION_SCHEMA.TABLES;

CREATE INDEX idx_patient_phone
ON Patients(Phone);

CREATE INDEX idx_appointment_date
ON Appointments(AppointmentDate);