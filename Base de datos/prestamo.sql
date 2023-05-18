-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 18-05-2023 a las 02:31:52
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `liquidados`
--

INSERT INTO `liquidados` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Fecha_Ultimo_Pago`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`) VALUES
('Yarely117', '1500', '16/05/2023', '04/07/2023', 'Se', '1296', 'Yael', 'Yael', 'Roberto', 'Bustamante ', 'Centro ', '', '123', 1);

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

INSERT INTO `lista1` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Restante`, `Fecha1`, `Fecha2`, `Fecha3`, `Fecha4`, `Fecha5`, `Fecha6`, `Fecha7`, `Fecha8`, `Fecha9`, `Fecha10`, `Fecha11`, `Fecha12`, `Fecha13`, `Fecha14`) VALUES
('guatefuck', '121212', '14/05/2023', '10', '133333.2', 'Roberto', 'asasa', 'asas', '12', '', '1212122', '32232asa', 1, '133333.2', '21/05/2023-', '28/05/2023-', '04/06/2023-', '11/06/2023-', '18/06/2023-', '25/06/2023-', '02/07/2023-', '09/07/2023-', '16/07/2023-', '23/07/2023-', '30/07/2023-', '06/08/2023-', '13/08/2023-', '20/08/2023-'),
('Yarely Bomnita2', '1265', '17/05/2023', 'Se', '1366.2', 'Roberto', 'asass', 'asas', '1212', '', '121212', 'asasas', 1, '1366.2', '01/06/2023-', '16/06/2023-', '01/07/2023-', '16/07/2023-', '31/07/2023-', '15/08/2023-', '30/08/2023-', '-', '-', '-', '-', '-', '-', '-');

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
  `Monto_Restante` varchar(100) NOT NULL,
  `Fecha_Limite` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista2`
--

INSERT INTO `lista2` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Restante`, `Fecha_Limite`) VALUES
('Yarely3', '1234', '17/05/2023', '8%', '121212', 'Yael', 'asas', 'asas', '12', '', '1231212', 'asasasas', 1, '1212', '17/05/2023');

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
  `Tipo_pago` int(2) NOT NULL,
  `Monto_Restante` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `lista3`
--

INSERT INTO `lista3` (`Nombre_Completo`, `Credito_Prestado`, `Fecha_Inicio`, `Interes`, `Monto_Total`, `Promotor`, `Calle`, `Colonia`, `Num_int`, `Num_ext`, `Telefono`, `Correo`, `Tipo_pago`, `Monto_Restante`) VALUES
('Yarely117', '1200', '10/05/2023', '8%', '1212', 'Yael', 'asas', 'asas', '12', '', '121212', 'asasas', 1, '121212');

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
