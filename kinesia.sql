-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 16, 2025 at 02:58 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kinesia`
--

-- --------------------------------------------------------

--
-- Table structure for table `assessments`
--

CREATE TABLE `assessments` (
  `AssessmentID` varchar(50) NOT NULL,
  `PatientID` varchar(50) NOT NULL,
  `Extremity` varchar(50) NOT NULL,
  `Joint` varchar(50) NOT NULL,
  `JointSide` varchar(50) NOT NULL,
  `AssessmentStatus` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE `logs` (
  `LogID` varchar(50) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `LogType` varchar(50) NOT NULL,
  `LogDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`LogID`, `UserID`, `Description`, `LogType`, `LogDate`) VALUES
('LOG1', 'USER3', 'Has Logged In', 'Sessions', '2025-10-16 08:58:15');

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `PatientID` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `Contact` varchar(13) NOT NULL,
  `Birthdate` date NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Occupation` varchar(50) NOT NULL,
  `Status` int(11) NOT NULL,
  `DateAdded` datetime NOT NULL,
  `LastArchiveDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`PatientID`, `FirstName`, `LastName`, `MiddleName`, `Contact`, `Birthdate`, `Gender`, `Address`, `Occupation`, `Status`, `DateAdded`, `LastArchiveDate`) VALUES
('PATIENT1', 'Jose Crisanto', 'Calayag', '', '+639285321382', '2005-07-24', 'Male', 'dsadsa', 'Student', 0, '2025-07-24 14:20:05', NULL),
('PATIENT2', 'Mari Nicole', 'Medel', 'Relos', '+639285321382', '2002-11-26', 'Female', 'Sta Clara', 'Student', 1, '2025-07-24 18:35:50', NULL),
('PATIENT3', 'asdas', 'dsad', 'sad', '9285321382', '2020-09-09', 'Male', 'sadsad', 'student', 1, '2025-09-09 15:41:28', NULL),
('PATIENT4', 'dasdsad', 'dsffds', 'dsfs', '+639285321382', '2019-09-09', 'Male', 'dsad', 'sadas', 1, '2025-09-09 15:45:35', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `rom`
--

CREATE TABLE `rom` (
  `ROMID` varchar(50) NOT NULL,
  `AssessmentID` varchar(50) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `InitialROM` int(11) NOT NULL,
  `EndROM` int(11) NOT NULL,
  `Movement` varchar(50) NOT NULL,
  `MotionType` varchar(50) NOT NULL,
  `Subjective` varchar(255) DEFAULT NULL,
  `Objective` varchar(255) DEFAULT NULL,
  `Deviation` varchar(255) NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `Birthdate` date NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Contact` varchar(13) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Role` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Salt` varchar(255) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `DateAdded` datetime DEFAULT NULL,
  `LastArchiveDate` datetime DEFAULT NULL,
  `Status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `FirstName`, `LastName`, `MiddleName`, `Birthdate`, `Gender`, `Contact`, `Address`, `Role`, `Username`, `Password`, `Salt`, `Email`, `DateAdded`, `LastArchiveDate`, `Status`) VALUES
('USER1', 'das', 'dsa', 'dsa', '2007-08-12', 'Female', '+639285321382', 'sdad', 'Admin', 'jab', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', 'jcbcalayag@gmail.com', '2025-08-12 15:03:45', '2025-09-15 06:36:00', 0),
('USER2', 'das', 'dsa', 'dsa', '2007-08-12', 'Male', '+639285321382', 'sdad', 'Admin', 'sda', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', 'jcbcalayag@gmail.com', '2025-08-12 15:03:45', '2025-09-03 14:05:00', 0),
('USER3', 'das', 'dsa', '', '2007-08-12', 'Male', '+639285321382', 'dsad', 'Admin', 'test', '3f710f0e1119fd11c99cb4e10ef07a66f4a529554b7bd6031f2bc504dcc09ebe', '/eqfI94wMWaW67hRSJK6AQ==', 'jccalayag@gmail.com', '2025-08-12 16:27:16', NULL, 1),
('USER4', 'Jc', 'Calayag', '', '2007-09-13', 'Male', '+639285321382', 'sadsads', 'Admin', 'jc', '547d26c3bb071ae87d57b85bee865de5bbf821267d28891fd8f107e8da34a02d', '+2KV5A7NQXthZhBjyHoVPQ==', 'jcbcalayag@gmail.com', '2025-09-13 15:45:05', NULL, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assessments`
--
ALTER TABLE `assessments`
  ADD PRIMARY KEY (`AssessmentID`),
  ADD KEY `Assessments->Patients` (`PatientID`);

--
-- Indexes for table `logs`
--
ALTER TABLE `logs`
  ADD PRIMARY KEY (`LogID`),
  ADD KEY `Logs->Users` (`UserID`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`PatientID`);

--
-- Indexes for table `rom`
--
ALTER TABLE `rom`
  ADD PRIMARY KEY (`ROMID`,`AssessmentID`),
  ADD KEY `ROM->Assessments` (`AssessmentID`),
  ADD KEY `ROM->Users` (`UserID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `assessments`
--
ALTER TABLE `assessments`
  ADD CONSTRAINT `Assessments->Patients` FOREIGN KEY (`PatientID`) REFERENCES `patients` (`PatientID`);

--
-- Constraints for table `logs`
--
ALTER TABLE `logs`
  ADD CONSTRAINT `Logs->Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `rom`
--
ALTER TABLE `rom`
  ADD CONSTRAINT `ROM->Assessments` FOREIGN KEY (`AssessmentID`) REFERENCES `assessments` (`AssessmentID`),
  ADD CONSTRAINT `ROM->Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
