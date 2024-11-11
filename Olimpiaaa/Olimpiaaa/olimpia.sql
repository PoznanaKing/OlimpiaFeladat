-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 11. 10:12
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `olimpia`
--
CREATE DATABASE IF NOT EXISTS `olimpia` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `olimpia`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `datas`
--

CREATE TABLE `datas` (
  `id` varchar(36) COLLATE utf8_hungarian_ci NOT NULL,
  `country` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `county` varchar(60) COLLATE utf8_hungarian_ci NOT NULL,
  `description` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `createdTime` datetime NOT NULL,
  `updatedTime` datetime NOT NULL,
  `playerID` varchar(36) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `datas`
--

INSERT INTO `datas` (`id`, `country`, `county`, `description`, `createdTime`, `updatedTime`, `playerID`) VALUES
('1cd0923e-5e5f-4940-a08c-6e6ec0446a89', 'USA', 'Texas', 'Magasugró', '2024-11-11 08:51:42', '2024-11-11 09:53:29', '55788075-b96c-4dc0-b568-3ca4f9535e44'),
('58bb2258-20ef-4790-968b-0430a217503f', 'Hungary', 'Békés-Megye', 'Magasugrás', '2024-11-11 09:30:55', '2024-11-11 09:30:55', 'a4253dbd-73de-4a07-add1-0dd3ebd72211');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `player`
--

CREATE TABLE `player` (
  `id` varchar(36) COLLATE utf8_hungarian_ci NOT NULL,
  `name` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `age` int(11) NOT NULL,
  `weight` int(11) NOT NULL,
  `height` int(11) NOT NULL,
  `createdTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `player`
--

INSERT INTO `player` (`id`, `name`, `age`, `weight`, `height`, `createdTime`) VALUES
('55788075-b96c-4dc0-b568-3ca4f9535e44', 'Horvath Péter', 25, 67, 192, '2024-11-11 08:25:47'),
('a4253dbd-73de-4a07-add1-0dd3ebd72211', 'Péter Pál', 22, 65, 187, '2024-11-11 09:20:22');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `datas`
--
ALTER TABLE `datas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `playerID` (`playerID`);

--
-- A tábla indexei `player`
--
ALTER TABLE `player`
  ADD PRIMARY KEY (`id`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `datas`
--
ALTER TABLE `datas`
  ADD CONSTRAINT `datas_ibfk_1` FOREIGN KEY (`playerID`) REFERENCES `player` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
