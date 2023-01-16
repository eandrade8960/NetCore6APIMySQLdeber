-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-01-2023 a las 23:33:21
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `personal`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mensaje`
--

CREATE TABLE `mensaje` (
  `correo` varchar(100) NOT NULL,
  `remitente` varchar(100) NOT NULL,
  `telefono` varchar(100) NOT NULL,
  `asunto` varchar(100) NOT NULL,
  `mensaje` varchar(100) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `mensaje`
--

INSERT INTO `mensaje` (`correo`, `remitente`, `telefono`, `asunto`, `mensaje`, `id`) VALUES
('e', 'e', '7', 'e', 'e', 4),
('i', 'i', '7', 'i', 'i', 5),
('elbicho7@cr7.fut.com', 'Cristiano Ronaldo', '09777777', 'Me eliminaron del Mundial', 'Que inyusticia', 6),
('string', 'string', 'string', 'string', 'string', 8),
('string', 'string', 'string', 'string', 'string', 9);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `organizacion`
--

CREATE TABLE `organizacion` (
  `nombre` varchar(100) NOT NULL,
  `foto` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `mision` varchar(100) NOT NULL,
  `vision` varchar(100) NOT NULL,
  `valores` varchar(100) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `organizacion`
--

INSERT INTO `organizacion` (`nombre`, `foto`, `descripcion`, `mision`, `vision`, `valores`, `id`) VALUES
('string', 3456, 'string', 'string', 'string', 'string', 7),
('aaa', 0, 'aaa', 'aaa', 'aaa', 'aaaa', 9),
('string', 3333, 'string', 'string', 'string', 'string', 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personal`
--

CREATE TABLE `personal` (
  `cedula` varchar(100) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `telefono` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `rol` varchar(100) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `personal`
--

INSERT INTO `personal` (`cedula`, `nombre`, `apellido`, `telefono`, `correo`, `rol`, `id`) VALUES
('1315047678', 'Yuly Lilibeth', 'Macías Mero', '0909090909', 'ymacias7678@utm.edu.ec', 'Administrador', 2),
('1304567643', 'Erika Elizabeth', 'Andrade Medranda', '099132434', 'eandrade8357@utm.edu.ec', 'Programador', 3),
('123', '123', '', '', '', '', 6),
('string', 'string', 'string', 'string', '', '', 7),
('string', 'string', 'string', 'string', 'string', 'string', 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `foto` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`codigo`, `nombre`, `descripcion`, `foto`, `id`) VALUES
(1, 'Shampoo', 'Para cabello', 6, 2),
(2, 'Jabón', 'Para tocador', 7, 3),
(10, 'ww', 'www', 110, 7),
(660, 'string', 'string', 6660, 8),
(20, 'string', 'string', 220, 9),
(331, 'string', 'string', 33, 114);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `mensaje`
--
ALTER TABLE `mensaje`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `organizacion`
--
ALTER TABLE `organizacion`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `personal`
--
ALTER TABLE `personal`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `mensaje`
--
ALTER TABLE `mensaje`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `organizacion`
--
ALTER TABLE `organizacion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `personal`
--
ALTER TABLE `personal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=115;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
