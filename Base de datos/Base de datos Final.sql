-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 27-05-2023 a las 02:42:16
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
('b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', ''),
('roberta', 'donnet', '4000', 'sabe', 'asasas', 'asas', '12', '', 'asas', 'asasas', 'Lista1');

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

--
-- Volcado de datos para la tabla `lista1`
--

INSERT INTO `lista1` (`Promotor`, `Nombre_Completo`, `Credito_Prestado`, `Pagare`, `Fecha_Inicio`, `Fecha_Termino`, `Interes`, `Monto_Total`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Restante`, `Fecha1`, `Fecha2`, `Fecha3`, `Fecha4`, `Fecha5`, `Fecha6`, `Fecha7`, `Fecha8`, `Fecha9`, `Fecha10`, `Fecha11`, `Fecha12`, `Fecha13`, `Fecha14`) VALUES
('Promotor2', 'Cesar Donnet Hernandez Gastelum', '4000', '8000', '22/05/2023', '04/09/2023', 'Normal', '5600', 'asasas', 'asasasasa', '', '122', '12121212121', 'asasasasass', '', '5600', '06/06/2023', '21/06/2023', '06/07/2023', '21/07/2023', '05/08/2023', '20/08/2023', '04/09/2023', '-', '-', '-', '-', '-', '-', '-');

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
  `FECHA 1` varchar(20) NOT NULL,
  `PAGO 1` varchar(20) NOT NULL,
  `FECHA 2` varchar(20) NOT NULL,
  `PAGO 2` varchar(20) NOT NULL,
  `FECHA 3` varchar(20) NOT NULL,
  `PAGO 3` varchar(20) NOT NULL,
  `FECHA 4` varchar(20) NOT NULL,
  `PAGO 4` varchar(20) NOT NULL,
  `FECHA 5` varchar(20) NOT NULL,
  `PAGO 5` varchar(20) NOT NULL,
  `FECHA 6` varchar(20) NOT NULL,
  `PAGO 6` varchar(20) NOT NULL,
  `FECHA 7` varchar(20) NOT NULL,
  `PAGO 7` varchar(20) NOT NULL,
  `FECHA 8` varchar(20) NOT NULL,
  `PAGO 8` varchar(20) NOT NULL,
  `FECHA 9` varchar(20) NOT NULL,
  `PAGO 9` varchar(20) NOT NULL,
  `FECHA 10` varchar(20) NOT NULL,
  `PAGO 10` varchar(20) NOT NULL,
  `FECHA 11` varchar(20) NOT NULL,
  `PAGO 11` varchar(20) NOT NULL,
  `FECHA 12` varchar(20) NOT NULL,
  `PAGO 12` varchar(20) NOT NULL,
  `FECHA 13` varchar(20) NOT NULL,
  `PAGO 13` varchar(20) NOT NULL,
  `FECHA 14` varchar(20) NOT NULL,
  `PAGO 14` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista2`
--

INSERT INTO `lista2` (`Promotor`, `Nombre_Completo`, `Credito_Prestado`, `Monto_Restante`, `Pagare`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_de_pago`, `Liquidacion_Intencion`, `Quita`, `FECHA 1`, `PAGO 1`, `FECHA 2`, `PAGO 2`, `FECHA 3`, `PAGO 3`, `FECHA 4`, `PAGO 4`, `FECHA 5`, `PAGO 5`, `FECHA 6`, `PAGO 6`, `FECHA 7`, `PAGO 7`, `FECHA 8`, `PAGO 8`, `FECHA 9`, `PAGO 9`, `FECHA 10`, `PAGO 10`, `FECHA 11`, `PAGO 11`, `FECHA 12`, `PAGO 12`, `FECHA 13`, `PAGO 13`, `FECHA 14`, `PAGO 14`) VALUES
('adasas', 'd', '2000', '', '4000', 'asasas', 'asasas', 'asasas', '', 'aasasas', 'asasas', 'liquidacion', '2500', '', '-', '-', '-', '-', '-', '-', '-', '-', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''),
('adasas', 'dsdsdsd', '2000', '', '4000', 'asasas', 'asasas', 'asasas', '', 'aasasas', 'asasas', 'liquidacion', '2500', '', '-', '-', '-', '-', '-', '-', '-', '-', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '');

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
('asasa', 'donnet', '4000', '8000', 'asas', 'asas', 'asas', '', 'asas', 'asas', '', 'Embargo', '1');

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
