-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 19, 2025 at 03:08 PM
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
('LOG1', 'USER3', 'Has Logged In', 'Sessions', '2025-09-07 19:12:55'),
('LOG10', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 15:41:13'),
('LOG11', 'USER3', 'Added PATIENT3', 'Patients', '2025-09-09 15:41:28'),
('LOG12', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 15:44:27'),
('LOG13', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 15:45:22'),
('LOG14', 'USER3', 'Added PATIENT4', 'Patients', '2025-09-09 15:45:36'),
('LOG15', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:02:30'),
('LOG16', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:11:36'),
('LOG17', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:14:00'),
('LOG18', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:15:34'),
('LOG19', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:17:52'),
('LOG2', 'USER3', 'Has Logged In', 'Sessions', '2025-09-08 06:53:38'),
('LOG20', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 09:47:04'),
('LOG21', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 20:59:13'),
('LOG22', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 21:08:03'),
('LOG23', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 21:08:57'),
('LOG24', 'USER3', 'Edited PATIENT1\'s personal information', 'Patients', '2025-09-10 21:09:03'),
('LOG25', 'USER3', 'Has Logged In', 'Sessions', '2025-09-10 21:09:35'),
('LOG26', 'USER3', 'Edited PATIENT1\'s personal information', 'Patients', '2025-09-10 21:09:40'),
('LOG27', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 18:03:17'),
('LOG28', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 18:05:15'),
('LOG29', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 18:05:44'),
('LOG3', 'USER3', 'Has Logged In', 'Sessions', '2025-09-08 06:55:34'),
('LOG30', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 18:07:11'),
('LOG31', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 18:07:49'),
('LOG32', 'USER3', 'Unarchived PATIENT1', 'Patients', '2025-09-11 18:07:51'),
('LOG33', 'USER3', 'Archived PATIENT1', 'Patients', '2025-09-11 18:07:54'),
('LOG34', 'USER3', 'Has Logged In', 'Sessions', '2025-09-11 19:29:03'),
('LOG35', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 16:58:42'),
('LOG36', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 17:00:05'),
('LOG37', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 17:02:25'),
('LOG38', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 17:08:44'),
('LOG39', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 20:32:37'),
('LOG4', 'USER3', 'Has Logged In', 'Sessions', '2025-09-08 06:58:54'),
('LOG40', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 20:33:47'),
('LOG41', 'USER3', 'Has Logged In', 'Sessions', '2025-09-12 20:35:22'),
('LOG42', 'USER3', 'Has Logged In', 'Sessions', '2025-09-13 15:41:43'),
('LOG43', 'USER3', 'Has Logged In', 'Sessions', '2025-09-13 15:44:44'),
('LOG44', 'USER3', 'Added USER4', 'Users', '2025-09-13 15:45:06'),
('LOG45', 'USER4', 'Has Logged In', 'Sessions', '2025-09-13 15:45:17'),
('LOG46', 'USER3', 'Has Logged In', 'Sessions', '2025-09-14 08:43:58'),
('LOG47', 'USER3', 'Edited USER1\'s personal information', 'Users', '2025-09-14 08:44:06'),
('LOG48', 'USER3', 'Has Logged In', 'Sessions', '2025-09-15 06:35:45'),
('LOG49', 'USER3', 'Has Logged In', 'Sessions', '2025-09-15 06:35:45'),
('LOG5', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 10:07:07'),
('LOG50', 'USER3', 'Unarchived USER1', 'Users', '2025-09-15 06:35:51'),
('LOG51', 'USER3', 'Archived USER1', 'Users', '2025-09-15 06:35:53'),
('LOG52', 'USER3', 'Unarchived USER1', 'Users', '2025-09-15 06:35:58'),
('LOG53', 'USER3', 'Archived USER1', 'Users', '2025-09-15 06:36:00'),
('LOG54', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 09:20:57'),
('LOG55', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 09:20:58'),
('LOG56', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 09:23:15'),
('LOG57', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 09:56:26'),
('LOG58', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 10:02:40'),
('LOG59', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 10:05:11'),
('LOG6', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 10:07:07'),
('LOG60', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:19:04'),
('LOG61', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:19:10'),
('LOG62', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:22:00'),
('LOG63', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:23:14'),
('LOG64', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:24:24'),
('LOG65', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:27:02'),
('LOG66', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 14:28:52'),
('LOG67', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:39:55'),
('LOG68', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:40:53'),
('LOG69', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:42:17'),
('LOG7', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 10:08:44'),
('LOG70', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:42:47'),
('LOG71', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:43:45'),
('LOG72', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:44:41'),
('LOG73', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:47:22'),
('LOG74', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:53:28'),
('LOG75', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:53:28'),
('LOG76', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:55:36'),
('LOG77', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 19:56:10'),
('LOG78', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:03:12'),
('LOG79', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:03:40'),
('LOG8', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 10:09:29'),
('LOG80', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:04:25'),
('LOG81', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:05:21'),
('LOG82', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:10:36'),
('LOG83', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:10:55'),
('LOG84', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:14:09'),
('LOG85', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:14:59'),
('LOG86', 'USER3', 'Has Logged In', 'Sessions', '2025-09-16 20:15:22'),
('LOG87', 'USER3', 'Has Logged In', 'Sessions', '2025-09-17 07:59:32'),
('LOG9', 'USER3', 'Has Logged In', 'Sessions', '2025-09-09 15:15:32');

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
