-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 09-05-2023 a las 23:24:10
-- Versión del servidor: 10.4.25-MariaDB
-- Versión de PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prestamos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `liquidados`
--

CREATE TABLE `liquidados` (
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Fecha_Ultimo_Pago` varchar(100) NOT NULL,
  `Interes` varchar(2) NOT NULL,
  `Monto_Total` varchar(100) NOT NULL,
  `Promotor` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_pago` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `liquidados`
--

INSERT INTO `liquidados` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Fecha_Ultimo_Pago`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`) VALUES
('b', 'b', 'b', '', 'b', '', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista1`
--

CREATE TABLE `lista1` (
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Interes` varchar(2) NOT NULL,
  `Monto_Total` varchar(100) NOT NULL,
  `Promotor` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_pago` int(2) NOT NULL,
  `Monto_Pagado` varchar(100) NOT NULL,
  `Fecha1` varchar(30) NOT NULL,
  `Fecha2` varchar(30) NOT NULL,
  `Fecha3` varchar(30) NOT NULL,
  `Fecha4` varchar(30) NOT NULL,
  `Fecha5` varchar(30) NOT NULL,
  `Fecha6` varchar(30) NOT NULL,
  `Fecha7` varchar(30) NOT NULL,
  `Fecha8` varchar(30) NOT NULL,
  `Fecha9` varchar(30) NOT NULL,
  `Fecha10` varchar(30) NOT NULL,
  `Fecha11` varchar(30) NOT NULL,
  `Fecha12` varchar(30) NOT NULL,
  `Fecha13` varchar(30) NOT NULL,
  `Fecha14` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lista1`
--

INSERT INTO `lista1` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Pagado`, `Fecha1`, `Fecha2`, `Fecha3`, `Fecha4`, `Fecha5`, `Fecha6`, `Fecha7`, `Fecha8`, `Fecha9`, `Fecha10`, `Fecha11`, `Fecha12`, `Fecha13`, `Fecha14`) VALUES
('x', 'x', 'x', 'x', '', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 2, '', 'x', 'x', 'x', 'x', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista2`
--

CREATE TABLE `lista2` (
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Interes` varchar(2) NOT NULL,
  `Monto_Total` varchar(100) NOT NULL,
  `Promotor` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_pago` int(2) NOT NULL,
  `Monto_Pagado` varchar(100) NOT NULL,
  `Monto_Restante` varchar(100) NOT NULL,
  `Fecha_Limite` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lista2`
--

INSERT INTO `lista2` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Pagado`, `Monto_Restante`, `Fecha_Limite`) VALUES
('q', 'q', 'q', 'q', '', 'q', 'q', 'q', 'q', 'q', 'q', 'q', 0, '', '', '-');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista3`
--

CREATE TABLE `lista3` (
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Interes` varchar(2) NOT NULL,
  `Monto_Total` varchar(100) NOT NULL,
  `Promotor` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Monto_Pagado` varchar(100) NOT NULL,
  `Monto_Restante` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `lista3`
--

INSERT INTO `lista3` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Monto_Pagado`, `Monto_Restante`) VALUES
('b', 'b', 'b', 'b', '', 'b', 'b', 'b', 'b', 'b', 'b', 'b', '0', '0');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `liquidados`
--
ALTER TABLE `liquidados`
  ADD PRIMARY KEY (`Nombre_Completo`);

--
-- Indices de la tabla `lista1`
--
ALTER TABLE `lista1`
  ADD PRIMARY KEY (`Nombre_Completo`);

--
-- Indices de la tabla `lista2`
--
ALTER TABLE `lista2`
  ADD PRIMARY KEY (`Nombre_Completo`);

--
-- Indices de la tabla `lista3`
--
ALTER TABLE `lista3`
  ADD PRIMARY KEY (`Nombre_Completo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
