-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 28 Maj 2020, 18:07
-- Wersja serwera: 10.4.11-MariaDB
-- Wersja PHP: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `user`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user1`
--

CREATE TABLE `user1` (
  `id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Surname` varchar(50) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Music` varchar(50) NOT NULL,
  `Sex` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `user1`
--

INSERT INTO `user1` (`id`, `Name`, `Surname`, `Login`, `Password`, `Music`, `Sex`) VALUES
(9, 't1', 't1', 't1', '83f1535f99ab0bf4e9d02dfd85d3e3f7', 'Rock,Metal', 'male'),
(11, 'w', 'w', 'w', 'f1290186a5d0b1ceab27f4e77c0c5d68', '', 'male'),
(13, 'w', 'w', 'wwwwwwww', 'f1290186a5d0b1ceab27f4e77c0c5d68', 'Pop', 'male'),
(14, '1', '1', '1111111', 'c4ca4238a0b923820dcc509a6f75849b', 'Pop', 'male'),
(15, 'w', 'w', 'wwwwwww', 'f1290186a5d0b1ceab27f4e77c0c5d68', 'Metal', 'female'),
(16, 'wer', 'wer', 'werwer', '22c276a05aa7c90566ae2175bcc2a9b0', 'Rock,Metal', 'female');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `user1`
--
ALTER TABLE `user1`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `user1`
--
ALTER TABLE `user1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
