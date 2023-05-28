-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 28-05-2023 a las 09:53:54
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

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
  `Promotor` varchar(100) NOT NULL,
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Forma_Liquidacion` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `liquidados`
--

INSERT INTO `liquidados` (`Promotor`, `Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Forma_Liquidacion`) VALUES
('roberta', 'donnet', '4000', '27/05/2023', 'asasas', 'asas', '12', '', 'asas', 'asasas', 'Lista1'),
('Promotor2', 'Ricardo Suñiga', '1000', '27/05/2023', 'b', 'b', 'b', 'b', 'b', 'b', 'Lista 2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista1`
--

CREATE TABLE `lista1` (
  `Promotor` varchar(100) NOT NULL,
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Pagare` varchar(20) NOT NULL,
  `Fecha_Inicio` varchar(100) NOT NULL,
  `Fecha_Termino` varchar(30) NOT NULL,
  `Interes` varchar(20) NOT NULL,
  `Monto_Total` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_pago` varchar(20) NOT NULL,
  `Monto_Restante` varchar(100) NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista2`
--

CREATE TABLE `lista2` (
  `Promotor` varchar(100) NOT NULL,
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Monto_Restante` varchar(20) NOT NULL,
  `Pagare` varchar(20) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_de_pago` varchar(20) NOT NULL,
  `Liquidacion_Intencion` varchar(20) NOT NULL,
  `Quita` varchar(20) NOT NULL,
  `FECHA1` varchar(20) NOT NULL,
  `PAGO1` varchar(20) NOT NULL,
  `FECHA2` varchar(20) NOT NULL,
  `PAGO2` varchar(20) NOT NULL,
  `FECHA3` varchar(20) NOT NULL,
  `PAGO3` varchar(20) NOT NULL,
  `FECHA4` varchar(20) NOT NULL,
  `PAGO4` varchar(20) NOT NULL,
  `FECHA5` varchar(20) NOT NULL,
  `PAGO5` varchar(20) NOT NULL,
  `FECHA6` varchar(20) NOT NULL,
  `PAGO6` varchar(20) NOT NULL,
  `FECHA7` varchar(20) NOT NULL,
  `PAGO7` varchar(20) NOT NULL,
  `FECHA8` varchar(20) NOT NULL,
  `PAGO8` varchar(20) NOT NULL,
  `FECHA9` varchar(20) NOT NULL,
  `PAGO9` varchar(20) NOT NULL,
  `FECHA10` varchar(20) NOT NULL,
  `PAGO10` varchar(20) NOT NULL,
  `FECHA11` varchar(20) NOT NULL,
  `PAGO11` varchar(20) NOT NULL,
  `FECHA12` varchar(20) NOT NULL,
  `PAGO12` varchar(20) NOT NULL,
  `FECHA13` varchar(20) NOT NULL,
  `PAGO13` varchar(20) NOT NULL,
  `FECHA14` varchar(20) NOT NULL,
  `PAGO14` varchar(20) NOT NULL,
  `Pago_Total_EXT` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista2`
--

INSERT INTO `lista2` (`Promotor`, `Nombre_Completo`, `Credito_Prestado`, `Monto_Restante`, `Pagare`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_de_pago`, `Liquidacion_Intencion`, `Quita`, `FECHA1`, `PAGO1`, `FECHA2`, `PAGO2`, `FECHA3`, `PAGO3`, `FECHA4`, `PAGO4`, `FECHA5`, `PAGO5`, `FECHA6`, `PAGO6`, `FECHA7`, `PAGO7`, `FECHA8`, `PAGO8`, `FECHA9`, `PAGO9`, `FECHA10`, `PAGO10`, `FECHA11`, `PAGO11`, `FECHA12`, `PAGO12`, `FECHA13`, `PAGO13`, `FECHA14`, `PAGO14`, `Pago_Total_EXT`) VALUES
('Promotor1', 'Cesar Donnet', '4000', '5,600.00', '8000', 'Paseo del rincon verde', 'San nicolas', '', '328', '4495919159', 'DonnetGastelum@gmail.com', 'Liquidacion', '', '6700', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '8000'),
('Promotor2', 'Yarely Ruiz', '3200', '4,096.00', '6400', 'asas', 'asas', '12', '', '121212', 'asasas', 'Liquidacion', '1200', '5200', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '6400');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lista3`
--

CREATE TABLE `lista3` (
  `Promotor` varchar(100) NOT NULL,
  `Nombre_Completo` varchar(100) NOT NULL,
  `Credito_Prestado` varchar(100) NOT NULL,
  `Pagare` varchar(20) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Num_int` varchar(100) NOT NULL,
  `Num_ext` varchar(100) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Tipo_de_Resolucion` varchar(20) NOT NULL,
  `Resolucion_Demanda` varchar(20) NOT NULL,
  `Importe` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista3`
--

INSERT INTO `lista3` (`Promotor`, `Nombre_Completo`, `Credito_Prestado`, `Pagare`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_de_Resolucion`, `Resolucion_Demanda`, `Importe`) VALUES
('Promotor2', 'donnet', '4000', '8000', 'asas', 'asas', 'asas', '', 'asas', 'asas', 'Liquidacion', 'Embargo', '1');

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
