-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 23, 2025 at 12:27 PM
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
('LOG1', 'USER2', 'Sample', 'dsad', '2025-08-23 12:26:15');

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
('PATIENT1', 'Jose Crisanto', 'Calayag', '', '+639285321382', '2005-07-24', 'Male', 'dsadsa', 'Student', 0, '2025-07-24 14:20:05', '2025-08-10 16:41:43'),
('PATIENT2', 'Mari Nicole', 'Medel', 'Relos', '+639285321382', '2002-11-26', 'Female', 'Sta Clara', 'Student', 1, '2025-07-24 18:35:50', NULL);

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
('USER2', 'das', 'dsa', 'dsa', '2007-08-12', 'Male', '+639285321382', 'sdad', 'Admin', 'sda', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', '08bc4b3d5475c3ffad7ff8d757b3bc0cbbcb49136ed88a95eec67d41c9df73fd', 'jcbcalayag@gmail.com', '2025-08-12 15:03:45', NULL, 1),
('USER3', 'das', 'dsa', '', '2007-08-12', 'Male', '+639285321382', 'dsad', 'Admin', 'test', '3f710f0e1119fd11c99cb4e10ef07a66f4a529554b7bd6031f2bc504dcc09ebe', '/eqfI94wMWaW67hRSJK6AQ==', 'jccalayag@gmail.com', '2025-08-12 16:27:16', NULL, 1);

--
-- Indexes for dumped tables
--

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
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `logs`
--
ALTER TABLE `logs`
  ADD CONSTRAINT `Logs->Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
