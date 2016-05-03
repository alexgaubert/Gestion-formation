-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mar 03 Mai 2016 à 12:15
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `bd_ex_bddeconnectee`
--

-- --------------------------------------------------------

--
-- Structure de la table `formation`
--

CREATE TABLE IF NOT EXISTS `formation` (
  `IdFormation` int(11) NOT NULL,
  `Intitule` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  ` NbAnnee` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdFormation`),
  KEY `IdFormation` (`IdFormation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Contenu de la table `formation`
--

INSERT INTO `formation` (`IdFormation`, `Intitule`, ` NbAnnee`) VALUES
(1, 'The Offspring', 0),
(2, 'Dropkick Murphys', 2),
(3, 'Disturbed', 2),
(4, 'Twisted Sister', 3);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE IF NOT EXISTS `personne` (
  `IdPersonne` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8_bin NOT NULL,
  `prenom` varchar(250) COLLATE utf8_bin NOT NULL,
  `IdFormation` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdPersonne`),
  KEY `IdFormation` (`IdFormation`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=33 ;

--
-- Contenu de la table `personne`
--

INSERT INTO `personne` (`IdPersonne`, `nom`, `prenom`, `IdFormation`) VALUES
(14, 'Holland', 'Dexter', 1),
(15, 'Kevin', 'Wasserman', 1),
(16, 'Greg', 'Kriesel', 1),
(17, 'Pete', 'Parada', 1),
(18, 'Ken', 'Casey', 2),
(19, 'Al', 'Barr', 2),
(20, 'James', 'Lynch', 2),
(21, 'Tim', 'Brennan', 2),
(22, 'Scruffy', 'Wallace', 2),
(23, 'Matt', 'Kelly', 2),
(24, 'Jeff', 'DaRosa', 2),
(25, 'David', 'Draiman', 3),
(26, 'Dan', 'Donegan', 3),
(27, 'John', 'Moyer', 3),
(28, 'Mike', 'Wengren', 3),
(29, 'See', 'Snider', 4),
(30, 'Jay Jay', 'French', 4),
(31, 'Eddie', 'Ojeda', 4),
(32, 'Mike', 'Portnoy', 4);

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `personne`
--
ALTER TABLE `personne`
  ADD CONSTRAINT `personne_ibfk_1` FOREIGN KEY (`IdFormation`) REFERENCES `formation` (`IdFormation`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
