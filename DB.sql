USE [master]
GO
/****** Object:  Database [EventBooker]    Script Date: 12/07/2024 21:35:28 ******/
CREATE DATABASE [EventBooker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventBooker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EventBooker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EventBooker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EventBooker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EventBooker] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventBooker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventBooker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EventBooker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EventBooker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EventBooker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EventBooker] SET ARITHABORT OFF 
GO
ALTER DATABASE [EventBooker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EventBooker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EventBooker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EventBooker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EventBooker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EventBooker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EventBooker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EventBooker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EventBooker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EventBooker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EventBooker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EventBooker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EventBooker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EventBooker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EventBooker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EventBooker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EventBooker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EventBooker] SET RECOVERY FULL 
GO
ALTER DATABASE [EventBooker] SET  MULTI_USER 
GO
ALTER DATABASE [EventBooker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EventBooker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EventBooker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EventBooker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EventBooker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EventBooker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EventBooker', N'ON'
GO
ALTER DATABASE [EventBooker] SET QUERY_STORE = ON
GO
ALTER DATABASE [EventBooker] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EventBooker]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Contacto] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliaPermiso]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPermiso](
	[IdFamilia] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaPermiso] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Idioma] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdiomaControl](
	[IdIdiomaControl] [int] IDENTITY(1,1) NOT NULL,
	[IdIdioma] [int] NOT NULL,
	[NombreControl] [nvarchar](100) NOT NULL,
	[Traduccion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_IdiomaControl] PRIMARY KEY CLUSTERED 
(
	[IdIdiomaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilPermiso]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilPermiso](
	[IdPerfil] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
 CONSTRAINT [PK_PerfilPermiso] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IsFamilia] [bit] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdSalon] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Turno] [nvarchar](12) NOT NULL,
	[Invitados] [int] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaServicio](
	[IdReserva] [int] NOT NULL,
	[IdServicio] [int] NOT NULL,
 CONSTRAINT [PK_ReservaServicio] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC,
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salon](
	[IdSalon] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Ubicacion] [nvarchar](100) NOT NULL,
	[Precio] [money] NOT NULL,
	[PrecioCubierto] [money] NOT NULL,
	[Capacidad] [int] NOT NULL,
	[CantidadMinimaInvitados] [int] NOT NULL,
 CONSTRAINT [PK_Salon] PRIMARY KEY CLUSTERED 
(
	[IdSalon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Valor] [money] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [char](64) NOT NULL,
	[IsBlock] [bit] NOT NULL,
	[Dni] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[IdPerfil] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (1, 23765124, N'Rodolfo', N'Perez', N'0qlqdR2zTI3WmguaDnivH7Gi/i9TaoVHkwpzoAm9QBthfTeq6BerGcAPllN+Z2Pc', N'perezrodolfo@gmail.com', 1123425678)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (2, 44721231, N'Lucas', N'Fernandez', N'r8iBLB1j5kuBs9Wq4738mh1SYHakbqg6Mrx14OA0b2kB6zbdg7OgHTREaXHYugT0', N'lucas.fernandez@hotmail.com', 1132567849)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (3, 23123321, N'Hernan', N'Borda', N'Exv6g/7R5+JruSy3OqqZ2j1xuSmRAvN47RAg2J9f78HEfx0vZ5TbUNMMVkXrR4Ds', N'herni.borda@gmail.com', 1121326537)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (4, 26435762, N'Facundo', N'Juarez', N'RJal7a3wRlVyxZyv3rMTFypRGzC9yuInsL3yEqorHmIU0jzfemKw2QZBL+CaGjfT', N'juarez.facundo@hotmail.com', 1199722534)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (5, 29129043, N'Juan', N'Russo', N'fm0uPcTI2Tojd1rvgHbrGz7AdGhJjbk+QyouJNxu8s4K0pR/IP7uK1K+LdR01kzZ', N'juanchoripan@hotmail.com', 1123632512)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (6, 42327123, N'Agustin', N'Borda', N'pu6CiVQzAHBcgjxuFBOo0WvXpXPlpfUf3ctdqGkUOWUDrw/xid2PNOI0qf00IHqv', N'aguscapitolol@gmail.com', 1176231223)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (7, 21672314, N'Natalia', N'Iglesias', N'pu6CiVQzAHBcgjxuFBOo0WvXpXPlpfUf3ctdqGkUOWUDrw/xid2PNOI0qf00IHqv', N'iglesias.natalia@hotmail.com', 1189763213)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 1)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 2)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 3)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 4)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 5)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 1005)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1005, 4)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1005, 5)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1007, 1)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1007, 2)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1007, 5)
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [Idioma]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([IdIdioma], [Idioma]) VALUES (2, N'Ingles')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaControl] ON 

INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (1, 1, N'LblInicioSesion', N'Iniciar Sesion')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (3, 1, N'LblIdioma', N'Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (4, 1, N'LblUsuario', N'Usuario:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (5, 1, N'LblContraseña', N'Contraseña:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (7, 1, N'BtnIngresar', N'Ingresar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (9, 1, N'LblErrorUsuario', N'Debe ingresar usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (10, 1, N'LblErrorPassword', N'Debe ingresar contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (11, 2, N'LblInicioSesion', N'Sign In')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (12, 2, N'LblIdioma', N'Language')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (13, 2, N'LblUsuario', N'User:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (14, 2, N'LblContraseña', N'Password:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (15, 2, N'BtnIngresar', N'Enter')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (16, 2, N'LblErrorUsuario', N'User required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (17, 2, N'LblErrorPassword', N'Password required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (19, 1, N'BtnInicio', N'Inicio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (21, 1, N'BtnAdministrador', N'Administrador')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (22, 1, N'BtnGestionUsuario', N'Gestión Usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (23, 1, N'BtnPerfiles', N'Perfiles')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (24, 1, N'BtnMaestros', N'Maestros')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (25, 1, N'BtnGestionSalon', N'Gestión Salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (26, 1, N'BtnGestionServicios', N'Gestión Servicios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (27, 1, N'BtnGestionClientes', N'Gestión Clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (28, 1, N'BtnRegistrarReserva', N'Registrar Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (29, 1, N'BtnCobranza', N'Cobranza')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (30, 1, N'BtnCollectDeposit', N'Cobrar Seña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (31, 1, N'BtnReportes', N'Reportes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (32, 1, N'BtnAyuda', N'Ayuda')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (33, 1, N'BtnCambiarIdioma', N'Cambiar Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (34, 1, N'BtnCambiarPassword', N'Cambiar Contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (35, 1, N'BtnCerrarSesion', N'Cerrar Sesion')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (36, 2, N'BtnInicio', N'Home')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (37, 2, N'BtnAdministrador', N'Administrator')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (38, 2, N'BtnGestionUsuario', N'User Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (39, 2, N'BtnPerfiles', N'Profiles')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (40, 2, N'BtnMaestros', N'Masters')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (41, 2, N'BtnGestionSalon', N'Salon Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (42, 2, N'BtnGestionServicios', N'Service Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (43, 2, N'BtnGestionClientes', N'Client Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (44, 2, N'BtnRegistrarReserva', N'Register Reservation')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (45, 2, N'BtnCobranza', N'Collection')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (46, 2, N'BtnCollectDeposit', N'Collect Deposit')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (47, 2, N'BtnReportes', N'Reports')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (48, 2, N'BtnAyuda', N'Help')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (49, 2, N'BtnCambiarIdioma', N'Change Language')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (50, 2, N'BtnCambiarPassword', N'Change Password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (51, 2, N'BtnCerrarSesion', N'Log Out')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (52, 1, N'MessageCerrarSesion', N'¿Está seguro de que desea cerrar sesión?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (53, 1, N'CaptionCerrarSesion', N'Confirmar Cierre de Sesión')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (54, 2, N'MessageCerrarSesion', N'Are you sure you want to log out?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (55, 2, N'CaptionCerrarSesion', N'Confirm Log Out')
SET IDENTITY_INSERT [dbo].[IdiomaControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (1, N'Administrador')
INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (5, N'Cajera')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (1, 1003)
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (5, 1005)
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (2, N'Maestros', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (3, N'Registrar Reserva', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (4, N'Cobranza', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (5, N'Reportes', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1003, N'Administrador familia', 1)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1005, N'Cajera', 1)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1007, N'Encargado', 1)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (3, 1, 2, N'Fiesta de 15', CAST(N'2024-06-16' AS Date), N'Diurno', 50, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (4, 4, 2, N'Fiesta infantil', CAST(N'2024-06-17' AS Date), N'Diurno', 120, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (6, 3, 3, N'Fiesta de 50', CAST(N'2024-06-17' AS Date), N'Nocturno', 123, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (8, 7, 2, N'Cumple años de 50', CAST(N'2024-06-18' AS Date), N'Diurno', 120, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (9, 3, 2, N'Cumple de herni', CAST(N'2024-06-18' AS Date), N'Nocturno', 101, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (10, 1, 3, N'Fiesta de 18', CAST(N'2024-06-18' AS Date), N'Nocturno', 122, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (11, 1, 3, N'Evento de presentacion de libro', CAST(N'2024-06-18' AS Date), N'Diurno', 120, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (13, 1, 3, N'Boda', CAST(N'2024-06-20' AS Date), N'Diurno', 230, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (14, 3, 2, N'Fiesta de xv', CAST(N'2024-06-20' AS Date), N'Nocturno', 130, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (15, 2, 3, N'Fiesta de 50', CAST(N'2024-06-20' AS Date), N'Nocturno', 100, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (16, 1, 3, N'Fiesta de xv', CAST(N'2024-06-23' AS Date), N'Diurno', 81, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (17, 3, 3, N'Fiesta de xv', CAST(N'2024-06-24' AS Date), N'Nocturno', 123, N'Pendiente')
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (6, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (6, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (6, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (8, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (8, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (8, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (13, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (13, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (13, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (14, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (14, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (14, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (15, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (15, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (15, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (16, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (16, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (16, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (17, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (17, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (17, 4)
GO
SET IDENTITY_INSERT [dbo].[Salon] ON 

INSERT [dbo].[Salon] ([IdSalon], [Nombre], [Ubicacion], [Precio], [PrecioCubierto], [Capacidad], [CantidadMinimaInvitados]) VALUES (2, N'Azaila Lomas', N'Manuel Acevedo 440, Lomas de zamora', 1500000.0000, 20000.0000, 350, 100)
INSERT [dbo].[Salon] ([IdSalon], [Nombre], [Ubicacion], [Precio], [PrecioCubierto], [Capacidad], [CantidadMinimaInvitados]) VALUES (3, N'Azaila Banfield', N'Av. Adolfo Alsina 527, Banfield', 1200000.0000, 15000.0000, 280, 80)
SET IDENTITY_INSERT [dbo].[Salon] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([IdServicio], [Descripcion], [Valor]) VALUES (1, N'Decoración Personalizada', 250000.0000)
INSERT [dbo].[Servicio] ([IdServicio], [Descripcion], [Valor]) VALUES (3, N'Isla de sushi', 450000.0000)
INSERT [dbo].[Servicio] ([IdServicio], [Descripcion], [Valor]) VALUES (4, N'DJ', 230000.0000)
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (1, N'Admin', N'60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', 0, 44891735, N'Tomas', N'Juarez', N'tjuarez.tm@hotmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (8, N'44891731Tomito', N'9e4a7c6ecf0c36970cae6d88c83c680c50f433729f002a227ba0a0bcef61ebb7', 0, 44891731, N'Tomito', N'Juarez', N'tomito@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (10, N'44891733Facundoo', N'e4a8084b75ad6d39c8ffde70bcef480683c08484949cf28fac35075b437d8b37', 1, 44891733, N'Facundoo', N'Juarez', N'facundo@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (11, N'12345678Bautiti', N'016896c087fbab7fb9c632120d6bd589e0cce1a5c323e73da0422a86fd186b44', 0, 12345678, N'Bautiti', N'Dorelle', N'bautiti@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (12, N'44917321Alejo', N'3455e363cf646277403a8cd846101da7cd1f68044057d194648557982acc388a', 0, 44917321, N'Alejo', N'Tripicho', N'ale.gasolero@hotmail.com', 5)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [NonClusteredIndex_Dni_Unique]    Script Date: 12/07/2024 21:35:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_Dni_Unique] ON [dbo].[Cliente]
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_Dni_Unique]    Script Date: 12/07/2024 21:35:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_Dni_Unique] ON [dbo].[Users]
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FamiliaPermiso]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPermiso_Permiso] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Permiso] ([IdPermiso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FamiliaPermiso] CHECK CONSTRAINT [FK_FamiliaPermiso_Permiso]
GO
ALTER TABLE [dbo].[FamiliaPermiso]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPermiso_Permiso1] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[FamiliaPermiso] CHECK CONSTRAINT [FK_FamiliaPermiso_Permiso1]
GO
ALTER TABLE [dbo].[IdiomaControl]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaControl_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdiomaControl] CHECK CONSTRAINT [FK_IdiomaControl_Idioma]
GO
ALTER TABLE [dbo].[PerfilPermiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilPermiso_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerfilPermiso] CHECK CONSTRAINT [FK_PerfilPermiso_Perfil]
GO
ALTER TABLE [dbo].[PerfilPermiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilPermiso_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([IdPermiso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerfilPermiso] CHECK CONSTRAINT [FK_PerfilPermiso_Permiso]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Salon] FOREIGN KEY([IdSalon])
REFERENCES [dbo].[Salon] ([IdSalon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Salon]
GO
ALTER TABLE [dbo].[ReservaServicio]  WITH CHECK ADD  CONSTRAINT [FK_ReservaServicio_Reserva] FOREIGN KEY([IdReserva])
REFERENCES [dbo].[Reserva] ([IdReserva])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservaServicio] CHECK CONSTRAINT [FK_ReservaServicio_Reserva]
GO
ALTER TABLE [dbo].[ReservaServicio]  WITH CHECK ADD  CONSTRAINT [FK_ReservaServicio_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservaServicio] CHECK CONSTRAINT [FK_ReservaServicio_Servicio]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Perfil]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateCliente]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateCliente]
(
	@In_Dni int,
	@In_Nombre nvarchar(50),
	@In_Apellido nvarchar(50),
	@In_Direccion nvarchar(100),
	@In_Email nvarchar(100),
	@In_Contacto int
)
AS
BEGIN
	
	INSERT INTO Cliente (Dni, Nombre, Apellido, Direccion, Email, Contacto)
	VALUES (@In_Dni, @In_Nombre, @In_Apellido, @In_Direccion, @In_Email, @In_Contacto)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateFamilia]
(
	@In_nombre nvarchar(50),

	@Out_Id int OUTPUT	
)
AS 
BEGIN
	INSERT INTO Permiso (Nombre, IsFamilia)
	VALUES (@In_nombre, 1)

	SET @Out_Id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreatePerfil]
(
	@In_Descripcion nvarchar(50),

	@Out_Id int OUTPUT	
)
AS
BEGIN
	INSERT INTO Perfil(Descripcion)
	VALUES (@In_Descripcion)

	SET @Out_Id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePermisoFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreatePermisoFamilia]
(
	@In_IdFamilia int,
	@In_IdPermiso int
)
AS 
BEGIN
	INSERT INTO FamiliaPermiso(IdFamilia, IdPermiso)
	VALUES (@In_IdFamilia, @In_IdPermiso)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePermisoPerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreatePermisoPerfil]
(
	@In_IdPerfil int,
	@In_IdPermiso int	
)
AS
BEGIN
	INSERT INTO PerfilPermiso(IdPerfil, IdPermiso)
	VALUES (@In_IdPerfil, @In_IdPermiso)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateReserva]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateReserva]
(
	@In_IdCliente int,
	@In_IdSalon int,
	@In_Descripcion nvarchar(100),
	@In_Fecha date,
	@In_Turno nvarchar(12),
	@In_Invitados int,
	@In_Estado nvarchar(50),

	@Out_Id int OUTPUT	
)
AS
BEGIN
	INSERT INTO Reserva (IdCliente, IdSalon, Descripcion, Fecha, Turno, Invitados, Estado)
	VALUES (@In_IdCliente, @In_IdSalon, @In_Descripcion, @In_Fecha, @In_Turno, @In_Invitados, @In_Estado)

	SET @Out_Id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateReservaServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateReservaServicio]
(
	@In_IdReserva int,
	@In_IdServicio int
)
AS
BEGIN
	INSERT INTO ReservaServicio (IdReserva, IdServicio)
	VALUES (@In_IdReserva, @In_IdServicio)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateSalon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateSalon] 
(
	@In_Nombre nvarchar(50),
	@In_Ubicacion nvarchar(100),
	@In_Precio money,
	@In_PrecioCubierto money,
	@In_Capacidad int,
	@In_CantidadMinimaInvitados int
)
AS
BEGIN
	INSERT INTO Salon (Nombre, Ubicacion, Precio, PrecioCubierto, Capacidad, CantidadMinimaInvitados)
	VALUES (@In_Nombre, @In_Ubicacion, @In_Precio, @In_PrecioCubierto, @In_Capacidad, @In_CantidadMinimaInvitados)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateServicio]
(
	@In_Descripcion nvarchar(50),
	@In_Valor money
)
AS
BEGIN
	INSERT INTO Servicio (Descripcion, Valor)
	VALUES (@In_Descripcion, @In_Valor)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateUser]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateUser]
(
	@In_username nvarchar(50),
	@In_Password char(64),
	@In_Dni int,
	@In_Nombre nvarchar(50),
	@In_Apellido nvarchar(50),
	@In_Mail nvarchar(50),
	@In_IdPerfil int
)
AS
BEGIN 
	
	INSERT INTO Users (Username, Password, IsBlock, Dni, Nombre, Apellido, Mail, IdPerfil)
	VALUES (@In_username, @In_Password, 0, @In_Dni, @In_Nombre, @In_Apellido, @In_Mail, @In_IdPerfil)
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCliente]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteCliente]
(
	@In_IdCliente int
)
AS
BEGIN
	DELETE FROM Cliente
	WHERE IdCliente = @In_IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteFamilia]
(
	@In_IdFamilia int
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM PerfilPermiso WHERE IdPermiso = @In_IdFamilia)
	BEGIN
		DELETE FROM Permiso WHERE IdPermiso = @In_IdFamilia
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeletePerfil]
(
	@In_IdPerfil int
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Users WHERE IdPerfil = @In_IdPerfil)
	BEGIN
		DELETE FROM Perfil WHERE IdPerfil = @In_IdPerfil
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePermisoPerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeletePermisoPerfil]
(
	@In_IdPerfil int	
)
AS
BEGIN
	DELETE FROM PerfilPermiso WHERE IdPerfil = @In_IdPerfil
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePermisosFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeletePermisosFamilia]
(
	@In_IdFamilia int
)
AS 
BEGIN
	DELETE FROM FamiliaPermiso WHERE IdFamilia = @In_IdFamilia
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteReservaServicios]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteReservaServicios]
(
	@In_IdReserva int
)
AS
BEGIN
	DELETE FROM ReservaServicio WHERE IdReserva = @In_IdReserva
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteSalon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteSalon] 
(
    @In_Id int
)
AS
BEGIN
	DELETE FROM Salon WHERE IdSalon = @In_Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteServicio]
(
    @In_Id int
)
AS
BEGIN
	DELETE FROM Servicio WHERE IdServicio = @In_Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DeleteUser]
(
	@In_id int
)
AS
BEGIN
	DELETE FROM Users WHERE Id = @In_id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectCliente]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectCliente]
AS
BEGIN
	SELECT * FROM Cliente
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectDisponibilidadSalon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectDisponibilidadSalon]
(
	@In_IdSalon int,
	@In_Fecha date,
	@In_Turno nvarchar(12)
)
AS
BEGIN
	SELECT * FROM Salon
	RIGHT JOIN Reserva ON Salon.IdSalon = Reserva.IdSalon
	WHERE Salon.IdSalon = @In_IdSalon
	AND Reserva.Fecha = @In_Fecha
	AND Reserva.Turno = @In_Turno
	AND Reserva.Estado = 'Confirmado'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectFamilias]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectFamilias]
AS 
BEGIN
	SELECT * FROM Permiso
	WHERE Permiso.IsFamilia = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectIdiomas]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectIdiomas]
AS
BEGIN
	SELECT * FROM Idioma
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectPerfiles]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectPerfiles]
AS
BEGIN
	SELECT * FROM Perfil
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisos]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectPermisos]
AS
BEGIN
	SELECT * FROM Permiso
	WHERE IsFamilia = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisosFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectPermisosFamilia]
(
	@In_IdFamilia int
)
AS
BEGIN
	SELECT Permiso.* FROM FamiliaPermiso
	JOIN Permiso ON Permiso.IdPermiso = FamiliaPermiso.IdPermiso
	WHERE IdFamilia = @In_IdFamilia
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisosPerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectPermisosPerfil]
(
	@In_IdPerfil int
)
AS
BEGIN
	SELECT Permiso.* FROM PerfilPermiso
	JOIN Permiso ON  Permiso.IdPermiso = PerfilPermiso.IdPermiso
	WHERE IdPerfil = @In_IdPerfil
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectReserva]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectReserva]
(
	@In_Estado nvarchar(50) = NULL 	
)
AS
BEGIN
	SELECT 
	Reserva.IdReserva,
	Reserva.Descripcion,
	Reserva.Fecha,
	Reserva.Turno,
	Reserva.Invitados,
	Reserva.Estado,
	Cliente.IdCliente,
	Cliente.Dni,
	Cliente.Nombre as NombreCliente,
	Cliente.Apellido,
	Cliente.Direccion,
	Cliente.Email,
	Cliente.Contacto,
	Salon.IdSalon,
	Salon.Nombre as NombreSalon,
	Salon.Ubicacion,
	Salon.Precio,
	Salon.PrecioCubierto,
	Salon.Capacidad,
	Salon.CantidadMinimaInvitados
	FROM Reserva
	LEFT JOIN Cliente ON Cliente.IdCliente = Reserva.IdCliente
	LEFT JOIN Salon on Salon.IdSalon = Reserva.IdSalon
	WHERE Reserva.Estado = @In_Estado OR @In_Estado IS NULL
	ORDER BY Fecha ASC
END



SELECT * FROM ReservaServicio
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectReservaServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectReservaServicio]
(
    @In_IdReserva int
	
)
AS
BEGIN
	SELECT Reserva.IdReserva, Servicio.* FROM Reserva
	RIGHT JOIN ReservaServicio ON ReservaServicio.IdReserva = Reserva.IdReserva
	LEFT JOIN Servicio ON Servicio.IdServicio = ReservaServicio.IdServicio
	WHERE Reserva.IdReserva = @In_IdReserva
END



SELECT * FROM ReservaServicio
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectSalon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectSalon] 
AS
BEGIN
	SELECT * FROM Salon
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectServicio]

AS
BEGIN
	SELECT * FROM Servicio
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectTraduccion]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectTraduccion]
(
	@In_IdIdioma int,
	@In_NombreControl nvarchar(100)
)
AS 
BEGIN 
	SELECT Traduccion FROM IdiomaControl 
	WHERE IdIdioma = @In_IdIdioma AND NombreControl = @In_NombreControl
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectUser]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[SP_SelectUser]
(
	@In_username nvarchar(50) = NULL
)
AS
BEGIN
	SELECT * FROM Users
	JOIN Perfil ON Perfil.IdPerfil = Users.IdPerfil
	WHERE Username = @In_username OR @In_username IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectUserPerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectUserPerfil]
(
	 @In_IdUser int
)
AS 
BEGIN
	SELECT * FROM Users
	JOIN Perfil ON Perfil.IdPerfil = Users.IdPerfil
	WHERE Users.Id = @In_IdUser
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCliente]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateCliente]
(
	@In_IdCliente int,
	@In_Dni int,
	@In_Nombre nvarchar(50),
	@In_Apellido nvarchar(50),
	@In_Direccion nvarchar(100),
	@In_Email nvarchar(100),
	@In_Contacto int
)
AS
BEGIN
	UPDATE Cliente SET
		Dni = @In_Dni,
		Nombre = @In_Nombre,
		Apellido = @In_Apellido,
		Direccion = @In_Direccion,
		Email = @In_Email,
		Contacto = @In_Contacto
	WHERE IdCliente = @In_IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateFamilia]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateFamilia]
(
	@In_IdPermiso int,
	@In_Nombre nvarchar(50)
)
AS 
BEGIN
	UPDATE Permiso SET
		Nombre = @In_Nombre
	WHERE IdPermiso = @In_IdPermiso
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePerfil]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdatePerfil]
(
	@In_IdPerfil int,
	@In_Descripcion nvarchar(50)
)
AS
BEGIN
	UPDATE Perfil SET
		Descripcion = @In_Descripcion
	WHERE IdPerfil = @In_IdPerfil
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateReserva]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateReserva]
(
	@In_IdReserva int,
	@In_IdCliente int,
	@In_IdSalon int,
	@In_Descripcion nvarchar(100),
	@In_Fecha date,
	@In_Turno nvarchar(12),
	@In_Invitados int,
	@In_Estado nvarchar(50)
)
AS
BEGIN
	UPDATE Reserva SET
		IdCliente = @In_IdCliente,
		IdSalon = @In_IdSalon,
		Descripcion = @In_Descripcion,
		Fecha = @In_Fecha,
		Turno = @In_Turno,
		Invitados = @In_Invitados,
		Estado = @In_Estado
	WHERE IdReserva = @In_IdReserva
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateSalon]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateSalon] 
(
    @In_Id int,
	@In_Nombre nvarchar(50),
	@In_Ubicacion nvarchar(100),
	@In_Precio money,
	@In_PrecioCubierto money,
	@In_Capacidad int,
	@In_CantidadMinimaInvitados int
)
AS
BEGIN
	IF EXISTS(SELECT * FROM Salon WHERE IdSalon = @In_Id)
	BEGIN
		UPDATE Salon SET
			Nombre = @In_Nombre,
			Ubicacion = @In_Ubicacion,
			Precio = @In_Precio,
			PrecioCubierto = @In_PrecioCubierto,
			Capacidad = @In_Capacidad,
			CantidadMinimaInvitados = @In_CantidadMinimaInvitados
		WHERE IdSalon = @In_Id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateServicio]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateServicio]
(
	@In_Id int,
	@In_Descripcion nvarchar(50),
	@In_Valor money
)
AS
BEGIN
	IF EXISTS(SELECT * FROM Servicio WHERE IdServicio = @In_Id)
	BEGIN
		UPDATE Servicio SET
			Descripcion = @In_Descripcion,
			Valor = @In_Valor
		WHERE IdServicio = @In_Id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateUser]    Script Date: 12/07/2024 21:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_UpdateUser]
(
	@In_Id int,
	@In_Username nvarchar(50),
	@In_Password char(64),
	@In_IsBlock bit,
	@In_Dni int,
	@In_Nombre nvarchar(50),
	@In_Apellido nvarchar(50),
	@In_Mail nvarchar(50),
	@In_IdPerfil int
)
AS
BEGIN
	
	UPDATE Users SET
		Username = @In_Username,
		Password = @In_Password,
		IsBlock = @In_IsBlock,
		Dni = @In_Dni,
		Nombre = @In_Nombre,
		Apellido = @In_Apellido,
		Mail = @In_Mail,
		IdPerfil = @In_IdPerfil
	WHERE Id = @In_id
	
END
GO
USE [master]
GO
ALTER DATABASE [EventBooker] SET  READ_WRITE 
GO
