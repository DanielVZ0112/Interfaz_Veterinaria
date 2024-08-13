-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-06-2024 a las 06:26:18
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyecto_finalpoo_avanzada`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `consultas`
--

CREATE TABLE `consultas` (
  `id` int(5) NOT NULL,
  `IdPropietario` int(5) NOT NULL,
  `IdPaciente` int(5) NOT NULL,
  `IdDoctor` int(5) NOT NULL,
  `FechaConsulta` date NOT NULL,
  `CostoConsulta` decimal(10,0) NOT NULL,
  `MotivoConsulta` text DEFAULT NULL,
  `Sintomas` text DEFAULT NULL,
  `Diagnostico` text DEFAULT NULL,
  `FormulaMedica` text DEFAULT NULL,
  `AplicaExamenes` tinyint(1) NOT NULL,
  `NotasAdicionales` text DEFAULT NULL,
  `ProximoControl` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `consultas`
--

INSERT INTO `consultas` (`id`, `IdPropietario`, `IdPaciente`, `IdDoctor`, `FechaConsulta`, `CostoConsulta`, `MotivoConsulta`, `Sintomas`, `Diagnostico`, `FormulaMedica`, `AplicaExamenes`, `NotasAdicionales`, `ProximoControl`) VALUES
(7, 13, 8, 7, '2024-05-31', 105000, 'Vomito y malestar', 'Dolor de panza', 'por comer lombrices ', 'aceptaminofen', 0, 'que no lo vuelva a hacerlo ', '2024-05-31');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `doctores`
--

CREATE TABLE `doctores` (
  `id` int(5) NOT NULL,
  `idTipoDocumento` int(5) NOT NULL,
  `Documento` varchar(15) NOT NULL,
  `clave` varchar(50) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Especialidad` varchar(255) NOT NULL,
  `Jornada` varchar(255) NOT NULL,
  `FechaDeIngreso` date NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `Telefono` varchar(7) NOT NULL,
  `Celular` varchar(10) NOT NULL,
  `Correo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `doctores`
--

INSERT INTO `doctores` (`id`, `idTipoDocumento`, `Documento`, `clave`, `Nombre`, `Especialidad`, `Jornada`, `FechaDeIngreso`, `Direccion`, `Telefono`, `Celular`, `Correo`) VALUES
(1, 1, '1214717544', 'Carolinaveterianria0112', 'Carolina Ochoa Jiménez', 'Cirugía Veterinaria', 'Diurna', '2019-02-08', 'Calle 120 # 48B 94', '4901234', '3002203456', 'carolinadoctora@gmail.com'),
(7, 1, '1152211744', 'Vasco0112', 'Felipe Zapata Vasco', 'Medicina Interna Veterinaria', 'Diurna', '2018-03-20', 'Avenida 25 # 40C 103', '5209083', '3218972731', 'doctorfelipe@gmail.com'),
(8, 1, '1152211700', 'Lauraveterinaria0112', 'Laura Cardona Lopez', 'Oftalmología Veterinaria', 'Noturna', '2019-06-27', 'Carrera 41A # 87 22', '7896543', '3129872313', 'laura-medicinavet@gmail.com'),
(9, 1, '1152211700', 'Noravetarinaria0112', 'Nora Cogollo Ruiz', 'Medicina de Emergencia y Cuidados Intensivos Veterinarios', 'Diurna', '2020-01-05', 'Carrera 56 # 23 18D', '2349494', '3002331242', 'nora-medicinaanimal@hotmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pacientes`
--

CREATE TABLE `pacientes` (
  `id` int(5) NOT NULL,
  `idPropietario` int(5) NOT NULL,
  `NombreMascota` varchar(255) NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `Edad` double(5,2) NOT NULL,
  `Especie` varchar(255) NOT NULL,
  `Raza` varchar(255) NOT NULL,
  `Color` varchar(255) NOT NULL,
  `Peso` int(5) NOT NULL,
  `Sexo` varchar(1) NOT NULL,
  `Vacunado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `pacientes`
--

INSERT INTO `pacientes` (`id`, `idPropietario`, `NombreMascota`, `FechaNacimiento`, `Edad`, `Especie`, `Raza`, `Color`, `Peso`, `Sexo`, `Vacunado`) VALUES
(8, 13, 'Calcifer Chuan', '2024-05-31', 1.00, 'Gato Hermoso', 'Chandoso', 'Atigrado (rayas de diferentes colores)', 4, 'M', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietarios`
--

CREATE TABLE `propietarios` (
  `id` int(5) NOT NULL,
  `IdTipoDocumento` int(5) NOT NULL,
  `Documento` varchar(15) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `Telefono` varchar(7) NOT NULL,
  `Celular` varchar(10) NOT NULL,
  `Correo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `propietarios`
--

INSERT INTO `propietarios` (`id`, `IdTipoDocumento`, `Documento`, `Nombre`, `Direccion`, `Telefono`, `Celular`, `Correo`) VALUES
(12, 1, '123456789', 'Carolina Ochoa Zapata', 'Calle 129 # 84A - 83 int 201', '4788490', '3126758790', 'carolinaOcho@gmail.com'),
(13, 1, '121467890', 'Pedro Perez ', 'Carrera 41 B 76 -89', '2447788', '3017891234', 'PPerez@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodocumento`
--

CREATE TABLE `tipodocumento` (
  `id` int(11) NOT NULL,
  `Abreviatura` varchar(3) NOT NULL,
  `Descripcion` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipodocumento`
--

INSERT INTO `tipodocumento` (`id`, `Abreviatura`, `Descripcion`) VALUES
(1, 'CC', 'Cédula de ciudadanía'),
(2, 'CE', 'Cédula de extranjería'),
(3, 'NIT', 'Número de Identificación Tributaria'),
(4, 'PA', 'Pasaporte'),
(5, 'TE', 'Tarjeta de extranjería');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `consultas`
--
ALTER TABLE `consultas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IdPropietario` (`IdPropietario`) USING BTREE,
  ADD KEY `IdDoctor` (`IdDoctor`) USING BTREE,
  ADD KEY `IdPaciente` (`IdPaciente`) USING BTREE;

--
-- Indices de la tabla `doctores`
--
ALTER TABLE `doctores`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTipoDocumento_2` (`idTipoDocumento`),
  ADD KEY `idTipoDocumento` (`idTipoDocumento`) USING BTREE;

--
-- Indices de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idPropietario` (`idPropietario`) USING BTREE;

--
-- Indices de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IdTipoDocumento` (`IdTipoDocumento`),
  ADD KEY `IdTipoDocumento_2` (`IdTipoDocumento`) USING BTREE;

--
-- Indices de la tabla `tipodocumento`
--
ALTER TABLE `tipodocumento`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `consultas`
--
ALTER TABLE `consultas`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `doctores`
--
ALTER TABLE `doctores`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `tipodocumento`
--
ALTER TABLE `tipodocumento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `consultas`
--
ALTER TABLE `consultas`
  ADD CONSTRAINT `Doctores-Consultas` FOREIGN KEY (`IdDoctor`) REFERENCES `doctores` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Pacientes-Consultas` FOREIGN KEY (`IdPaciente`) REFERENCES `pacientes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Propietarios-Consultas` FOREIGN KEY (`IdPropietario`) REFERENCES `propietarios` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `doctores`
--
ALTER TABLE `doctores`
  ADD CONSTRAINT `tipoDocumento-Doctores` FOREIGN KEY (`idTipoDocumento`) REFERENCES `tipodocumento` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `pacientes`
--
ALTER TABLE `pacientes`
  ADD CONSTRAINT `Propietarios-Pacientes` FOREIGN KEY (`idPropietario`) REFERENCES `propietarios` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `propietarios`
--
ALTER TABLE `propietarios`
  ADD CONSTRAINT `tipoDocumento-Propietarios` FOREIGN KEY (`IdTipoDocumento`) REFERENCES `tipodocumento` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
