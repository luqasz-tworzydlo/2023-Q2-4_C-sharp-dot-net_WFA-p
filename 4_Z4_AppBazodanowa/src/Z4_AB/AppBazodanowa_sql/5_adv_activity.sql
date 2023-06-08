-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 09, 2022 at 04:55 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `5_adv_activity`
--

-- --------------------------------------------------------

--
-- Table structure for table `adv_books`
--

CREATE TABLE `adv_books` (
  `id` int(11) NOT NULL,
  `rodzaj_ksiazki` varchar(15) COLLATE utf8mb4_polish_ci NOT NULL,
  `autor` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `rok_rozpoczecia` varchar(4) COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `adv_books`
--

INSERT INTO `adv_books` (`id`, `rodzaj_ksiazki`, `autor`, `rok_rozpoczecia`) VALUES
(1, 'muzyczna', 'Łukasz Wojciech M. Tworzydło', '2018'),
(2, 'edukacyjna', 'Łukasz Wojciech M. Tworzydło', '2019'),
(3, 'naukowa', 'Łukasz Wojciech M. Tworzydło', '2019'),
(4, 'religijna', 'Łukasz Wojciech M. Tworzydło', '2019'),
(5, 'projektowa', 'Łukasz Wojciech M. Tworzydło', '2019');

-- --------------------------------------------------------

--
-- Table structure for table `adv_travel`
--

CREATE TABLE `adv_travel` (
  `id` int(11) NOT NULL,
  `kraj` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `nazwa_filmu` varchar(150) COLLATE utf8mb4_polish_ci NOT NULL,
  `tworca` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `nazwa_kanalu` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `www_youtube` varchar(300) COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `adv_travel`
--

INSERT INTO `adv_travel` (`id`, `kraj`, `nazwa_filmu`, `tworca`, `nazwa_kanalu`, `www_youtube`) VALUES
(1, 'Israel & Jordan', 'Let\'s start our journey!', 'JustTravelToday & luqastro :>', 'Just Travel Today', 'https://youtu.be/g6kZjtrKQtw'),
(2, 'Israel & Jordan', 'The Holy Land, and even more!', 'JustTravelToday & luqastro :>', 'Just Travel Today', 'https://youtu.be/-yAXYJTpksU'),
(3, 'Israel', 'Let’s drive together!', 'JustTravelToday & luqastro :>', 'Just Travel Today', 'https://youtu.be/5DdLthH5ivg'),
(4, 'Israel', 'Driving through Israel… breathtaking views!', 'JustTravelToday & luqastro :>', 'Just Travel Today', 'https://youtu.be/bwnLhjKIdcc'),
(5, 'Israel & Jordan', 'The Last Expedition!', 'JustTravelToday & luqastro :>', 'Just Travel Today', 'https://youtu.be/BhQvj6F6Wk4');

-- --------------------------------------------------------

--
-- Table structure for table `adv_websites`
--

CREATE TABLE `adv_websites` (
  `id` int(11) NOT NULL,
  `nazwa_strony` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `rodzaj_strony` varchar(15) COLLATE utf8mb4_polish_ci NOT NULL,
  `tworca_strony` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `strona_www` varchar(300) COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `adv_websites`
--

INSERT INTO `adv_websites` (`id`, `nazwa_strony`, `rodzaj_strony`, `tworca_strony`, `strona_www`) VALUES
(1, 'ADV Publishing', 'wydawnicza', 'Łukasz Wojciech M. Tworzydło', 'https://advpublishing.wordpress.com/'),
(2, 'Just Travel Today', 'podróżnicza', 'Łukasz Wojciech M. Tworzydło', 'https://just-travel-today.com/'),
(3, 'AVANT DE VENIR', 'muzyczna', 'Łukasz Wojciech M. Tworzydło', 'https://avantdevenir.wordpress.com/'),
(4, 'Edukacja Kreacja', 'edukacyjna', 'Łukasz Wojciech M. Tworzydło', 'https://edukacjakreacja.wordpress.com/'),
(5, 'Wiedza Przyszłości', 'naukowa', 'Łukasz Wojciech M. Tworzydło', 'https://wiedzaprzyszlosci.wordpress.com/'),
(6, 'Projekty AD', 'projektowa', 'Łukasz Wojciech M. Tworzydło', 'https://projektyad.wordpress.com/'),
(7, 'Sacris Coelum', 'religijna', 'Łukasz Wojciech M. Tworzydło', 'https://sacriscoelum.wordpress.com/');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `adv_books`
--
ALTER TABLE `adv_books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `adv_travel`
--
ALTER TABLE `adv_travel`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `adv_websites`
--
ALTER TABLE `adv_websites`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `adv_books`
--
ALTER TABLE `adv_books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `adv_travel`
--
ALTER TABLE `adv_travel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `adv_websites`
--
ALTER TABLE `adv_websites`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
