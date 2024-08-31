USE [master]
GO
/****** Object:  Database [EventBooker]    Script Date: 31/08/2024 15:51:29 ******/
CREATE DATABASE [EventBooker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventBooker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EventBooker.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[BitacoraEventos]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BitacoraEventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Modulo] [nvarchar](50) NOT NULL,
	[Evento] [nvarchar](50) NOT NULL,
	[Criticidad] [int] NOT NULL,
 CONSTRAINT [PK_BitacoraEventos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[FamiliaPermiso]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Perfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[PerfilPermiso]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Reserva]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[ReservaServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Salon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Servicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 31/08/2024 15:51:30 ******/
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
SET IDENTITY_INSERT [dbo].[BitacoraEventos] ON 

INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (1, 1, CAST(N'2024-08-26T16:25:36.230' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (2, 1, CAST(N'2024-08-26T17:12:12.000' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (3, 1, CAST(N'2024-08-26T17:12:19.620' AS DateTime), N'Administrador', N'Desbloqueo de usuario', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (4, 1, CAST(N'2024-08-26T17:12:35.910' AS DateTime), N'Maestros', N'Creación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (5, 1, CAST(N'2024-08-26T17:12:56.033' AS DateTime), N'Maestros', N'Creación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (6, 1, CAST(N'2024-08-26T17:13:03.140' AS DateTime), N'Menú Principal', N'Logout', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (7, 1, CAST(N'2024-08-26T17:13:25.880' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (8, 1, CAST(N'2024-08-26T17:13:37.320' AS DateTime), N'Maestros', N'Creación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (9, 1, CAST(N'2024-08-26T17:14:28.630' AS DateTime), N'Maestros', N'Creación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (10, 1, CAST(N'2024-08-26T17:19:37.710' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (11, 1, CAST(N'2024-08-26T17:20:05.053' AS DateTime), N'Maestros', N'Creación de salón', 3)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (12, 1, CAST(N'2024-08-26T17:20:09.350' AS DateTime), N'Maestros', N'Modificación de salón', 3)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (13, 1, CAST(N'2024-08-26T17:20:11.460' AS DateTime), N'Maestros', N'Eliminación de salón', 2)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (14, 1, CAST(N'2024-08-26T17:20:24.090' AS DateTime), N'Maestros', N'Modificación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (15, 1, CAST(N'2024-08-26T17:21:34.893' AS DateTime), N'Administrador', N'Modificación de perfil', 3)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (16, 1, CAST(N'2024-08-26T17:23:14.007' AS DateTime), N'Administrador', N'Modificación de familia de permisos', 3)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (17, 1, CAST(N'2024-08-26T17:23:21.377' AS DateTime), N'Administrador', N'Modificación de familia de permisos', 3)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (18, 1, CAST(N'2024-08-26T17:26:20.517' AS DateTime), N'Menú Principal', N'Logout', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (19, 1, CAST(N'2024-08-26T17:29:23.220' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (20, 1, CAST(N'2024-08-26T17:29:41.650' AS DateTime), N'Menú Principal', N'Logout', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (21, 10, CAST(N'2024-08-26T17:29:56.020' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (22, 10, CAST(N'2024-08-26T17:30:01.590' AS DateTime), N'Menú Principal', N'Logout', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (23, 1, CAST(N'2024-08-26T19:55:50.370' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (24, 1, CAST(N'2024-08-26T19:56:53.780' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (25, 1, CAST(N'2024-08-26T20:00:05.737' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (26, 1, CAST(N'2024-08-26T20:03:32.317' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (27, 1, CAST(N'2024-08-26T20:05:26.913' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (28, 1, CAST(N'2024-08-26T20:06:46.470' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (29, 1, CAST(N'2024-08-26T20:07:48.897' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (30, 1, CAST(N'2024-08-26T20:09:07.820' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (31, 1, CAST(N'2024-08-26T20:11:07.817' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (32, 1, CAST(N'2024-08-26T20:16:17.273' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (33, 1, CAST(N'2024-08-26T20:17:07.383' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (34, 1, CAST(N'2024-08-26T20:18:06.110' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (35, 1, CAST(N'2024-08-26T20:18:58.660' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (36, 1, CAST(N'2024-08-26T20:26:49.437' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (37, 1, CAST(N'2024-08-26T20:30:24.027' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (38, 1, CAST(N'2024-08-26T20:35:21.127' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (39, 1, CAST(N'2024-08-26T20:37:01.653' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (40, 1, CAST(N'2024-08-26T20:48:15.250' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (41, 1, CAST(N'2024-08-26T20:48:56.847' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (42, 1, CAST(N'2024-08-27T10:15:40.120' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (43, 1, CAST(N'2024-08-30T15:34:03.170' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (44, 1, CAST(N'2024-08-30T15:41:33.490' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (45, 1, CAST(N'2024-08-30T15:45:32.447' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (46, 1, CAST(N'2024-08-30T15:46:45.180' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (47, 1, CAST(N'2024-08-30T15:47:38.447' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (48, 1, CAST(N'2024-08-30T16:04:38.940' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (49, 1, CAST(N'2024-08-30T16:06:16.303' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (50, 1, CAST(N'2024-08-30T16:26:59.450' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (51, 1, CAST(N'2024-08-30T16:30:04.680' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (52, 1, CAST(N'2024-08-30T20:37:54.080' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (53, 1, CAST(N'2024-08-30T21:01:30.440' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (54, 1, CAST(N'2024-08-30T21:04:49.753' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (55, 1, CAST(N'2024-08-30T21:12:08.917' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (56, 1, CAST(N'2024-08-30T21:14:37.007' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (57, 1, CAST(N'2024-08-30T21:32:52.860' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (58, 1, CAST(N'2024-08-30T22:20:17.827' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (59, 1, CAST(N'2024-08-30T22:22:43.753' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (60, 1, CAST(N'2024-08-30T22:25:24.750' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (61, 1, CAST(N'2024-08-30T22:27:55.260' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (62, 1, CAST(N'2024-08-31T14:18:53.313' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (63, 1, CAST(N'2024-08-31T15:32:40.770' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (64, 1, CAST(N'2024-08-31T15:33:32.173' AS DateTime), N'Maestros', N'Creación de servicio', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (65, 1, CAST(N'2024-08-31T15:44:05.523' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (66, 1, CAST(N'2024-08-31T15:48:56.153' AS DateTime), N'Login', N'Inicio de sesion', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (67, 1, CAST(N'2024-08-31T15:49:05.150' AS DateTime), N'Administrador', N'Backup', 1)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (68, 1, CAST(N'2024-08-31T15:49:25.630' AS DateTime), N'Maestros', N'Serializacion', 4)
INSERT [dbo].[BitacoraEventos] ([Id], [IdUser], [Fecha], [Modulo], [Evento], [Criticidad]) VALUES (69, 1, CAST(N'2024-08-31T15:49:40.213' AS DateTime), N'Menú Principal', N'Logout', 1)
SET IDENTITY_INSERT [dbo].[BitacoraEventos] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (1, 23765124, N'Rodolfo', N'Perez', N'0qlqdR2zTI3WmguaDnivH7Gi/i9TaoVHkwpzoAm9QBthfTeq6BerGcAPllN+Z2Pc', N'perezrodolfo@gmail.com', 1123425678)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (2, 44721231, N'Lucas', N'Fernandez', N'r8iBLB1j5kuBs9Wq4738mh1SYHakbqg6Mrx14OA0b2kB6zbdg7OgHTREaXHYugT0', N'lucas.fernandez@hotmail.com', 1132567849)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (3, 23123321, N'Hernan', N'Borda', N'Exv6g/7R5+JruSy3OqqZ2j1xuSmRAvN47RAg2J9f78HEfx0vZ5TbUNMMVkXrR4Ds', N'herni.borda@gmail.com', 1121326537)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (4, 26435762, N'Facundo', N'Juarez', N'RJal7a3wRlVyxZyv3rMTFypRGzC9yuInsL3yEqorHmIU0jzfemKw2QZBL+CaGjfT', N'juarez.facundo@hotmail.com', 1199722534)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (5, 29129043, N'Juan', N'Russo', N'fm0uPcTI2Tojd1rvgHbrGz7AdGhJjbk+QyouJNxu8s4K0pR/IP7uK1K+LdR01kzZ', N'juanchoripan@hotmail.com', 1123632512)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (6, 42327123, N'Agustin', N'Borda', N'pu6CiVQzAHBcgjxuFBOo0WvXpXPlpfUf3ctdqGkUOWUDrw/xid2PNOI0qf00IHqv', N'aguscapitolol@gmail.com', 1176231223)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (7, 21672314, N'Natalia', N'Iglesias', N'pu6CiVQzAHBcgjxuFBOo0WvXpXPlpfUf3ctdqGkUOWUDrw/xid2PNOI0qf00IHqv', N'iglesias.natalia@hotmail.com', 1189763213)
INSERT [dbo].[Cliente] ([IdCliente], [Dni], [Nombre], [Apellido], [Direccion], [Email], [Contacto]) VALUES (11, 12376412, N'Tomas', N'Juarez', N'sas7k7lGywLbBahJB1d7zPxiOFl2gm4WeU49eCUqF3Q=', N'tomas.juarez.12@hotmail.com', 1143231423)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 1)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 2)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 3)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 4)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1003, 5)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1005, 4)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1005, 5)
INSERT [dbo].[FamiliaPermiso] ([IdFamilia], [IdPermiso]) VALUES (1012, 5)
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [Idioma]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([IdIdioma], [Idioma]) VALUES (2, N'Ingles')
INSERT [dbo].[Idioma] ([IdIdioma], [Idioma]) VALUES (3, N'Portugués')
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
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (41, 2, N'BtnGestionSalon', N'Hall Management')
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
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (56, 1, N'MessageUsuarioIncorrecto', N'Usuario Incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (57, 1, N'MessageUsuarioBloqueado', N'Usuario Bloqueado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (58, 1, N'MessageContraseñaIncorecta', N'Contraseña Incorrecta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (59, 1, N'MessageNuevasContraseñasNoCoinciden', N'Las nuevas contraseñas no coinciden')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (60, 1, N'MessageValidacionContraseña', N'La contraseña debe contener mínimo 8 caracteres, una mayúscula y al menos un numero')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (61, 1, N'MessageContraseñasNoCoinciden', N'Contraseñas no coinciden')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (62, 1, N'MessageModificadoCorrectamente', N'Modificado correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (64, 1, N'MessageErrorAlModificar', N'Error al modificar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (65, 1, N'MessageUsuarioBloqueado', N'El usuario ha sido bloqueado por exceder número de intentos fallidos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (66, 1, N'MessageErrorAlBloquearUsuario', N'Error al bloquear usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (67, 1, N'MessageDesbloqueadoCorrectamente', N'Desbloqueado Correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (68, 1, N'MessageNoSePudoDesbloquear', N'No se pudo desbloquear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (69, 1, N'MessageCreadoCorrectamente', N'Creado Correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (70, 1, N'MessageUsuarioExistenteConDni', N'Ya existe un usuario con mismo dni')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (72, 1, N'MessageEliminadoCorrectamente', N'Eliminado Correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (73, 1, N'MessageErrorAlEliminar', N'Error Al Eliminar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (74, 2, N'MessageUsuarioIncorrecto', N'Incorrect User')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (75, 2, N'MessageUsuarioBloqueado', N'Blocked User')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (76, 2, N'MessageContraseñaIncorecta', N'Incorrect Password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (77, 2, N'MessageNuevasContraseñasNoCoinciden', N'New passwords do not match')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (78, 2, N'MessageValidacionContraseña', N'Password must contain at least 8 characters, one uppercase letter, and one number')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (79, 2, N'MessageContraseñasNoCoinciden', N'Passwords do not match')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (80, 2, N'MessageModificadoCorrectamente', N'Successfully modified')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (81, 2, N'MessageErrorAlModificar', N'Error modifying')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (82, 2, N'MessageUsuarioBloqueado', N'User has been blocked due to too many failed attempts')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (83, 2, N'MessageErrorAlBloquearUsuario', N'Error blocking user')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (84, 2, N'MessageDesbloqueadoCorrectamente', N'Successfully unblocked')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (85, 2, N'MessageNoSePudoDesbloquear', N'Could not unblock')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (86, 2, N'MessageCreadoCorrectamente', N'Successfully created')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (87, 2, N'MessageUsuarioExistenteConDni', N'A user with the same ID already exists')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (88, 2, N'MessageEliminadoCorrectamente', N'Successfully deleted')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (89, 2, N'MessageErrorAlEliminar', N'Error deleting')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (90, 1, N'LblGestionUsuarios', N'Gestión de usuarios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (91, 1, N'LblNombre', N'Nombre:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (92, 1, N'LblDni', N'Dni:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (93, 1, N'LblApellido', N'Apellido:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (94, 1, N'LblMail', N'Mail:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (95, 1, N'LblPerfil', N'Perfil:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (96, 1, N'BtnCancelar', N'Cancelar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (97, 1, N'BtnGuardar', N'Guardar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (98, 1, N'LblErrorNombre', N'Debe Ingresar el nombre')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (99, 1, N'LblErrorDni', N'Debe ingresar dni')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (100, 1, N'LblErrorApellido', N'Debe ingresar apellido')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (101, 1, N'LblErrorMail', N'Debe ingresar mail')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (102, 1, N'BtnCrear', N'Crear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (103, 1, N'BtnModificar', N'Modificar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (104, 1, N'BtnEliminar', N'Eliminar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (105, 1, N'BtnDesbloquear', N'Desbloquear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (106, 1, N'LblCantidadUsuarios', N'Cantidad de usuarios:')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (107, 1, N'LblUsuariosBloqueados', N'Usuarios Bloqueados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (108, 1, N'MessageFormatoDniIncorrecto', N'Formato del dni incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (109, 1, N'MessageFormatoMailIncorrecto', N'Formato del mail incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (110, 2, N'MessageFormatoMailIncorrecto', N'Incorrect email format')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (111, 2, N'MessageFormatoDniIncorrecto', N'Incorrect ID format')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (112, 2, N'LblUsuariosBloqueados', N'Blocked Users:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (113, 2, N'LblCantidadUsuarios', N'Number of users:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (114, 2, N'BtnDesbloquear', N'Unblock')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (115, 2, N'BtnEliminar', N'Delete')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (116, 2, N'BtnModificar', N'Modify')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (117, 2, N'BtnCrear', N'Create')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (118, 2, N'LblErrorMail', N'Email required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (119, 2, N'LblErrorApellido', N'Last name required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (120, 2, N'LblErrorDni', N'ID required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (121, 2, N'LblErrorNombre', N'First name required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (122, 2, N'BtnGuardar', N'Save')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (123, 2, N'BtnCancelar', N'Cancel')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (124, 2, N'LblPerfil', N'Profile:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (125, 2, N'LblMail', N'Email:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (126, 2, N'LblApellido', N'Last Name:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (127, 2, N'LblDni', N'ID:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (128, 2, N'LblNombre', N'First Name:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (129, 2, N'LblGestionUsuarios', N'User Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (130, 1, N'MessageDebeSeleccionarUsuario', N'Debe seleccionar un usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (131, 1, N'MessageDebeSeleccionarPerfil', N'Debe seleccionar Perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (132, 1, N'MessageDeseaEliminarUsuario', N'¿Está seguro de que desea eliminar el usuario?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (133, 1, N'CaptionConfirmarEliminar', N'Confirmar eliminar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (134, 2, N'CaptionConfirmarEliminar', N'Confirm delete')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (135, 2, N'MessageDeseaEliminarUsuario', N'Are you sure you want to delete the user?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (136, 2, N'MessageDebeSeleccionarPerfil', N'You must select a profile')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (137, 2, N'MessageDebeSeleccionarUsuario', N'You must select a user')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (138, 1, N'MessageDeseaDesbloquearUsuario', N'¿Está seguro de que desea Desbloquear el usuario?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (139, 1, N'CaptionConfirmarDesbloquear', N'Confirmar Desbloquear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (140, 2, N'CaptionConfirmarDesbloquear', N'Confirm Unblock')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (141, 2, N'MessageDeseaDesbloquearUsuario', N'Are you sure you want to unblock the user?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (142, 1, N'LblGestionPerfiles', N'Gestión de Perfiles')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (143, 1, N'BtnNuevoPerfil', N'Nuevo Perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (144, 1, N'BtnCrearFamilia', N'Nueva Familia')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (145, 1, N'LblNombrePerfil', N'Nombre Perfil:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (146, 1, N'LblErrorNombrePerfil', N'Debe ingresar nombre de perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (147, 1, N'LblPermisos', N'Permisos:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (148, 1, N'LblFamilias', N'Familias:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (149, 1, N'LblListaPermisos', N'Lista permisos:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (150, 1, N'LblGestionFamilias', N'Gestión de Familias de Permisos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (151, 1, N'LblFamiliasPermisos', N'Familias de permisos:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (152, 1, N'BtnNuevaFamilia', N'Nueva Familia de Permisos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (153, 1, N'LblNombreFamilia', N'Nombre Familia:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (154, 1, N'LblErrorNombreFamilia', N'Debe ingresar nombre de familia')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (155, 2, N'LblErrorNombreFamilia', N'Family name required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (156, 2, N'LblNombreFamilia', N'Family Name:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (157, 2, N'BtnNuevaFamilia', N'New Permission Family')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (158, 2, N'LblFamiliasPermisos', N'Permission Families:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (159, 2, N'LblGestionFamilias', N'Permission Family Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (160, 2, N'LblListaPermisos', N'Permission List:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (161, 2, N'LblFamilias', N'Families:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (162, 2, N'LblPermisos', N'Permissions:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (163, 2, N'LblErrorNombrePerfil', N'Profile name required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (164, 2, N'LblNombrePerfil', N'Profile Name:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (165, 2, N'BtnCrearFamilia', N'New Family')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (166, 2, N'BtnNuevoPerfil', N'New Profile')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (167, 2, N'LblGestionPerfiles', N'Profile Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (168, 1, N'BtnAgregarPermiso', N'<=')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (169, 1, N'BtnSacarPermiso', N'=>')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (172, 2, N'BtnAgregarPermiso', N'<=')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (173, 2, N'BtnSacarPermiso', N'=>')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (174, 1, N'MessageDeseaEliminarFamilia', N'¿Está seguro de que desea eliminar la familia?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (175, 1, N'MessageDeseaEliminarPerfil', N'¿Está seguro de que desea eliminar el perfil?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (176, 1, N'MessageDebeSeleccionarPermisos', N'Debe seleccionar permisos o familias de permisos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (177, 1, N'MessageDeseaCancelarProceso', N'¿Está seguro de que desea cancelar el proceso?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (178, 1, N'CaptionCancelar', N'Cancelar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (179, 1, N'MessageSeTienePermisoEnLista', N'Ya se tiene el permiso en la lista de permisos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (180, 1, N'MessagePerfilAsignadoAUsuario', N'Perfil asignado a un usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (181, 1, N'MessageErrorAlCrear', N'Error al crear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (182, 1, N'MessageFamiliaAsignadaAPerfil', N'Familia asignada a un perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (183, 2, N'MessageFamiliaAsignadaAPerfil', N'Family assigned to a profile')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (184, 2, N'MessageErrorAlCrear', N'Error creating')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (185, 2, N'MessagePerfilAsignadoAUsuario', N'Profile assigned to a user')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (186, 2, N'MessageSeTienePermisoEnLista', N'Permission already in the list')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (187, 2, N'CaptionCancelar', N'Cancel')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (188, 2, N'MessageDeseaCancelarProceso', N'Are you sure you want to cancel the process?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (189, 2, N'MessageDebeSeleccionarPermisos', N'You must select permissions or permission families')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (190, 2, N'MessageDeseaEliminarPerfil', N'Are you sure you want to delete the profile?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (191, 2, N'MessageDeseaEliminarFamilia', N'Are you sure you want to delete the family?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (192, 1, N'LblGestionSalon', N'Gestión de salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (193, 1, N'LblPrecio', N'Precio:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (194, 1, N'LblUbicacion', N'Ubicación:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (195, 1, N'LblPrecioCubierto', N'Precio por cubierto:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (196, 1, N'LblCapacidad', N'Capacidad:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (197, 1, N'LblErrorPrecio', N'Formato del precio incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (198, 1, N'LblErrorUbicacion', N'Debe ingresar ubicación')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (199, 1, N'LblErrorPrecioCubierto', N'Formato del precio por cubierto incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (200, 1, N'LblErrorCapacidad', N'Capacidad incorrecta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (201, 1, N'LblErrorCantidadMinimaInvitados', N'Cantidad minima de invitados incorrecta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (202, 1, N'MessageDebeSeleccionarSalon', N'Debe seleccionar un salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (203, 1, N'MessageDeseaEliminarSalon', N'¿Está seguro de que desea eliminar el salón?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (204, 1, N'MessageSalonNoDisponible', N'Salon no disponible para fecha y turno seleccionado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (205, 1, N'MessageSalonSeleccionado', N'Salon seleccionado correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (206, 2, N'MessageSalonSeleccionado', N'Hall selected successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (207, 2, N'MessageSalonNoDisponible', N'Hall not available for selected date and time')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (208, 2, N'MessageDeseaEliminarSalon', N'Are you sure you want to delete the hall?')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (209, 2, N'MessageDebeSeleccionarSalon', N'You must select a hall')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (210, 2, N'LblErrorCantidadMinimaInvitados', N'Incorrect minimum guest count')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (211, 2, N'LblErrorCapacidad', N'Incorrect capacity')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (212, 2, N'LblErrorPrecioCubierto', N'Incorrect price per cover format')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (213, 2, N'LblErrorUbicacion', N'Location required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (214, 2, N'LblErrorPrecio', N'Incorrect price format')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (215, 2, N'LblCapacidad', N'Capacity:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (216, 2, N'LblPrecioCubierto', N'Price per cover:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (217, 2, N'LblUbicacion', N'Location:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (218, 2, N'LblPrecio', N'Price:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (219, 2, N'LblGestionSalon', N'Hall Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (220, 1, N'LblCantidadMinimaInvitados', N'Cantidad minima invitados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (221, 2, N'LblCantidadMinimaInvitados', N'Minimum guest count:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (222, 1, N'MessageClienteExisteConDni', N'Ya existe cliente con el dni ingresado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (223, 1, N'LblGestionServicios', N'Gestión de servicios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (224, 1, N'LblDescripcion', N'Descripción:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (225, 1, N'LblValor', N'Valor:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (226, 1, N'LblErrorDescripcion', N'Debe Ingresar descripción')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (227, 1, N'LblErrorValor', N'Debe ingresar valor')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (228, 1, N'MessageSeleccionarServicio', N'Debe seleccionar un servicio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (229, 1, N'MessageDeseaEliminarServicio', N'¿Está seguro de que desea eliminar el servicio?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (230, 2, N'MessageDeseaEliminarServicio', N'Are you sure you want to delete the service?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (231, 2, N'MessageSeleccionarServicio', N'You must select a service')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (232, 2, N'LblErrorValor', N'Value required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (233, 2, N'LblErrorDescripcion', N'Description required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (234, 2, N'LblValor', N'Value:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (235, 2, N'LblDescripcion', N'Description:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (236, 2, N'LblGestionServicios', N'Service Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (237, 2, N'MessageClienteExisteConDni', N'A client with the entered ID already exists')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (238, 1, N'LblGestionClientes', N'Gestión de clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (239, 1, N'LblDireccion', N'Dirección:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (240, 1, N'LblContacto', N'Contacto:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (241, 1, N'LblErrorDireccion', N'Debe ingresar dirección')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (242, 1, N'LblErrorContacto', N'Debe Ingresar contacto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (243, 1, N'CheckShowDireccion', N'Ver direccion clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (244, 1, N'MessageSeleccionarCliente', N'Debe seleccionar un cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (245, 1, N'MessageFormatoContactoIncorrecto', N'Formato del contacto incorrecto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (246, 1, N'MessageDeseaEliminarCliente', N'¿Está seguro de que desea eliminar el cliente?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (247, 2, N'MessageDeseaEliminarCliente', N'Are you sure you want to delete the client?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (248, 2, N'MessageFormatoContactoIncorrecto', N'Incorrect contact format')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (249, 2, N'MessageSeleccionarCliente', N'You must select a client')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (250, 2, N'CheckShowDireccion', N'View client addresses')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (251, 2, N'LblErrorContacto', N'Contact required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (252, 2, N'LblErrorDireccion', N'Address required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (253, 2, N'LblContacto', N'Contact:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (254, 2, N'LblDireccion', N'Address:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (255, 2, N'LblGestionClientes', N'Client Management')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (256, 1, N'BtnCambiar', N'Cambiar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (257, 1, N'LblSeleccionarIdioma', N'Seleccionar Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (258, 2, N'LblSeleccionarIdioma', N'Select Language')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (259, 2, N'BtnCambiar', N'Change')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (260, 1, N'MessageCancelarProcesoReserva', N'¿Está seguro de que desea cancelar el proceso de reserva?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (261, 1, N'LblFecha', N'Fecha:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (262, 1, N'LblTurno', N'Turno:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (263, 1, N'LblCapacidadMaxima', N'Capacidad máxima:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (264, 1, N'LblListaServicios', N'Lista servicios:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (265, 1, N'LblCostoTotal', N'Costo total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (266, 1, N'LblCostoSenia', N'Costo Seña:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (267, 1, N'LblErrorDescripcionEvento', N'Debe ingresar descripción del evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (268, 1, N'LblErrorCantidadInvitados', N'Fuera de rango de la capacidad')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (269, 1, N'LblRegistrarReserva', N'Registrar Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (270, 1, N'LblSalon', N'Salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (271, 1, N'BtnSeleccionarSalon', N'Seleccionar Salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (272, 1, N'BtnRegistrarCliente', N'Registrar cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (273, 1, N'LblCostosEvento', N'Costos del evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (274, 1, N'LblCliente', N'Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (275, 1, N'LblDescripcionEvento', N'Descripción del evento:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (276, 1, N'LblCantidadInvitados', N'Cantidad invitados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (277, 1, N'LblServiciosAdicionales', N'Servicios Adicionales:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (278, 1, N'BtnSeleccionarServicios', N'Seleccionar Servicios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (279, 1, N'LblServiciosSinSeleccionados', N'Sin Servicios Seleccionados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (280, 1, N'MessageReservaRegistradaConExito', N'Reserva registrada con éxito')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (281, 1, N'MessageErrorRegistrarReserva', N'Error al registrar la reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (282, 2, N'MessageErrorRegistrarReserva', N'Error registering the reservation')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (283, 2, N'MessageReservaRegistradaConExito', N'Reservation successfully registered')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (284, 2, N'LblServiciosSinSeleccionados', N'No services selected')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (285, 2, N'BtnSeleccionarServicios', N'Select Services')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (286, 2, N'LblServiciosAdicionales', N'Additional Services:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (287, 2, N'LblCantidadInvitados', N'Guest count:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (288, 2, N'LblDescripcionEvento', N'Event description:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (289, 2, N'LblCliente', N'Client')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (290, 2, N'LblCostosEvento', N'Event costs')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (291, 2, N'BtnRegistrarCliente', N'Register client')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (292, 2, N'BtnSeleccionarSalon', N'Select Hall')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (293, 2, N'LblSalon', N'Hall')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (294, 2, N'LblRegistrarReserva', N'Register Reservation')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (295, 2, N'LblErrorCantidadInvitados', N'Out of capacity range')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (296, 2, N'LblErrorDescripcionEvento', N'Event description required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (297, 2, N'LblCostoSenia', N'Deposit cost:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (298, 2, N'LblCostoTotal', N'Total cost:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (299, 2, N'LblListaServicios', N'Service list:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (300, 2, N'LblCapacidadMaxima', N'Maximum capacity:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (301, 2, N'LblTurno', N'Shift:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (302, 2, N'LblFecha', N'Date:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (303, 2, N'MessageCancelarProcesoReserva', N'Are you sure you want to cancel the reservation process?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (304, 1, N'LblSeleccionarSalon', N'Seleccionar Salón')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (305, 1, N'LblInformacionSalon', N'Información del salón:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (306, 1, N'BtnSeleccionar', N'Seleccionar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (307, 1, N'MessageDebeSeleccionarFechaMayor', N'Debe seleccionar una fecha mayor a la actual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (308, 1, N'MessageDebeSeleccionarTurno', N'Debe seleccionar turno')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (309, 1, N'LblRegistrarCliente', N'Registrar Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (310, 1, N'BtnRegistrar', N'Registrar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (311, 1, N'BtnVolver', N'Volver')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (312, 1, N'MessageEstaSeguroQueDeseaVolver', N'¿Está seguro que desea volver?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (313, 1, N'CaptionVolver', N'Volver')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (314, 1, N'LblSeleccionarServicios', N'Seleccionar Servicios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (315, 1, N'LblLista', N'Lista:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (316, 1, N'LblValoresTitulo', N'Valores:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (317, 1, N'LblValores', N'Valores:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (318, 1, N'MessageServiciosSeleccionadosCorrectamente', N'Servicios Seleccionados correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (319, 1, N'MessageValorTotal', N'Valor Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (320, 2, N'MessageValorTotal', N'Total Value:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (321, 2, N'MessageServiciosSeleccionadosCorrectamente', N'Services selected successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (322, 2, N'LblValores', N'Values:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (323, 2, N'LblValoresTitulo', N'Values:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (324, 2, N'LblLista', N'List:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (325, 2, N'LblSeleccionarServicios', N'Select Services')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (326, 2, N'CaptionVolver', N'Back')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (327, 2, N'MessageEstaSeguroQueDeseaVolver', N'Are you sure you want to go back?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (328, 2, N'BtnVolver', N'Back')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (329, 2, N'BtnRegistrar', N'Register')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (330, 2, N'LblRegistrarCliente', N'Register Client')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (331, 2, N'MessageDebeSeleccionarTurno', N'You must select a shift')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (332, 2, N'MessageDebeSeleccionarFechaMayor', N'You must select a date later than today')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (333, 2, N'BtnSeleccionar', N'Select')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (334, 2, N'LblInformacionSalon', N'Hall information:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (335, 2, N'LblSeleccionarSalon', N'Select Hall')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (336, 1, N'LblNombreSalon', N'Nombre:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (337, 2, N'LblNombreSalon', N'Name:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (338, 1, N'LblCobrarSenia', N'Cobrar seña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (339, 1, N'LblBuscarReserva', N'Buscar reserva:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (340, 1, N'BtnBuscar', N'Buscar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (341, 1, N'LblMedioDePago', N'Medio de pago:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (342, 1, N'LblCostos', N'Costos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (343, 1, N'LblDeposit', N'Seña:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (344, 1, N'LblTotal', N'Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (345, 1, N'LblNumeroTarjeta', N'Número de tarjeta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (346, 1, N'LblTipoTarjeta', N'Tipo de tarjeta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (347, 1, N'LblNombreTitular', N'Nombre del titular')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (348, 1, N'LblFechaVencimiento', N'Fecha Vencimiento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (349, 1, N'MessageDebeSeleccionarMedioPago', N'Debe seleccionar medio de pago')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (350, 1, N'MessageDeseaRealizarCobroSenia', N'¿Está seguro que desea realizar el cobro de la seña?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (351, 1, N'CaptionConfirmarCobro', N'Confirmar Cobro')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (352, 1, N'LblErrorNumeroTarjeta', N'Debe ingresar número de tarjeta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (353, 1, N'MessageVerificarDatosTarjeta', N'Tarjeta no valida, verifique los datos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (354, 1, N'LblErrorNombreTitular', N'Debe ingresar nombre del titular')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (355, 1, N'LblErrorTipoTarjeta', N'Debe seleccionar tipo de tarjeta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (356, 1, N'MessagePagoRealizadoSenia', N'Se ha realizado el pago de la seña correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (357, 1, N'MessagePagoRechazado', N'Pago rechazado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (358, 1, N'MessageComprobanteReserva', N'comprobante_reserva_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (359, 1, N'MessageComprobanteReservaTitulo', N'Comprobante de Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (360, 1, N'MessageInformacionReserva', N'Información de la reserva:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (361, 1, N'MessageCostoSalon', N'Costo del Salón:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (362, 1, N'MessageServiciosSolicitados', N'Servicios Solicitados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (363, 1, N'MessageMontoTotal', N'Monto Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (364, 1, N'MessageSaldoPendiente', N'Saldo Pendiente:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (365, 2, N'MessageSaldoPendiente', N'Outstanding Balance:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (366, 2, N'MessageMontoTotal', N'Total Amount:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (367, 2, N'MessageServiciosSolicitados', N'Requested Services:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (368, 2, N'MessageCostoSalon', N'Hall Cost:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (369, 2, N'MessageInformacionReserva', N'Reservation Information:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (370, 2, N'MessageComprobanteReservaTitulo', N'Reservation Receipt')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (371, 2, N'MessageComprobanteReserva', N'reservation_receipt_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (372, 2, N'MessagePagoRechazado', N'Payment rejected')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (373, 2, N'MessagePagoRealizadoSenia', N'Deposit payment completed successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (374, 2, N'LblErrorTipoTarjeta', N'Card type required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (375, 2, N'LblErrorNombreTitular', N'Cardholder name required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (376, 2, N'MessageVerificarDatosTarjeta', N'Invalid card, please verify the details')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (377, 2, N'LblErrorNumeroTarjeta', N'Card number required')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (378, 2, N'CaptionConfirmarCobro', N'Confirm Payment')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (379, 2, N'MessageDeseaRealizarCobroSenia', N'Are you sure you want to process the deposit payment?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (380, 2, N'MessageDebeSeleccionarMedioPago', N'You must select a payment method')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (381, 2, N'LblFechaVencimiento', N'Expiration Date')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (382, 2, N'LblNombreTitular', N'Cardholder Name')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (383, 2, N'LblTipoTarjeta', N'Card Type')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (384, 2, N'LblNumeroTarjeta', N'Card Number')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (385, 2, N'LblTotal', N'Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (386, 2, N'LblDeposit', N'Deposit:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (387, 2, N'LblCostos', N'Costs')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (388, 2, N'LblMedioDePago', N'Payment Method:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (389, 2, N'BtnBuscar', N'Search')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (390, 2, N'LblBuscarReserva', N'Search reservation:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (391, 2, N'LblCobrarSenia', N'Collect deposit')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (392, 1, N'MessageEstadoCuenta', N'Estado de cuenta:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (393, 2, N'MessageEstadoCuenta', N'Account Statement:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (394, 1, N'MessageMontoAbonado', N'Monto Abonado:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (395, 2, N'MessageMontoAbonado', N'Amount Paid:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (396, 1, N'LblCambiarContrasenia', N'Cambiar Contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (397, 1, N'LblIngresarContraseniaActual', N'Ingresar contraseña actual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (398, 1, N'LblIngresarNuevaContrasenia', N'Ingresar nueva contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (399, 1, N'LblRepetirNuevaContrasenia', N'Repetir nueva contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (400, 1, N'BtnChangePassword', N'Cambiar Contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (401, 1, N'LblErrorActualPass', N'Debe ingresar contraseña actual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (402, 1, N'LblErrorNewPass', N'Debe ingresar nueva contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (403, 1, N'LblErrorNewPassRep', N'Debe repetir la nueva contraseña')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (404, 2, N'LblErrorNewPassRep', N'You must repeat the new password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (405, 2, N'LblErrorNewPass', N'You must enter a new password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (406, 2, N'LblErrorActualPass', N'You must enter the current password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (407, 2, N'BtnChangePassword', N'Change Password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (408, 2, N'LblRepetirNuevaContrasenia', N'Repeat new password')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (409, 2, N'LblIngresarNuevaContrasenia', N'Enter new password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (410, 2, N'LblIngresarContraseniaActual', N'Enter current password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (411, 2, N'LblCambiarContrasenia', N'Change Password')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (412, 1, N'DGVColumnaUsuario', N'Usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (413, 1, N'DGVColumnaBloqueado', N'Bloqueado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (414, 1, N'DGVColumnaDni', N'Dni')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (415, 1, N'DGVColumnaNombre', N'Nombre')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (416, 1, N'DGVColumnaApellido', N'Apellido')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (417, 1, N'DGVColumnaMail', N'Mail')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (418, 1, N'DGVColumnaDescripcion', N'Descripcion')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (419, 1, N'DGVColumnaFecha', N'Fecha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (420, 1, N'DGVColumnaTurno', N'Turno')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (421, 1, N'DGVColumnaInvitados', N'Invitados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (422, 1, N'DGVColumnaCliente', N'Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (423, 1, N'DGVColumnaValor', N'Valor')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (424, 1, N'DGVColumnaUbicacion', N'Ubicacion')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (425, 1, N'DGVColumnaPrecio', N'Precio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (426, 1, N'DGVColumnaCapacidad', N'Capacidad')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (427, 1, N'DGVColumnaDireccion', N'Direccion')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (428, 1, N'DGVColumnaContacto', N'Contacto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (429, 1, N'DGVColumnaPrecioCubierto', N'Precio Cubierto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (430, 1, N'DGVColumnaCantidadMinimaInvitados', N'Cantidad Minima Invitados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (431, 2, N'DGVColumnaCantidadMinimaInvitados', N'Minimum Guests')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (432, 2, N'DGVColumnaPrecioCubierto', N'Cover Price')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (433, 2, N'DGVColumnaContacto', N'Contact')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (434, 2, N'DGVColumnaDireccion', N'Address')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (435, 2, N'DGVColumnaCapacidad', N'Capacity')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (436, 2, N'DGVColumnaPrecio', N'Price')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (437, 2, N'DGVColumnaUbicacion', N'Location')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (438, 2, N'DGVColumnaValor', N'Value')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (439, 2, N'DGVColumnaCliente', N'Client')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (440, 2, N'DGVColumnaInvitados', N'Guests')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (441, 2, N'DGVColumnaTurno', N'Shift')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (442, 2, N'DGVColumnaFecha', N'Date')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (443, 2, N'DGVColumnaDescripcion', N'Description')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (444, 2, N'DGVColumnaMail', N'Email')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (445, 2, N'DGVColumnaApellido', N'Last Name')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (446, 2, N'DGVColumnaNombre', N'Name')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (447, 2, N'DGVColumnaDni', N'ID Number')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (448, 2, N'DGVColumnaBloqueado', N'Blocked')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (449, 2, N'DGVColumnaUsuario', N'User')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (450, 3, N'LblInicioSesion', N'Iniciar Sessão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (451, 3, N'LblIdioma', N'Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (452, 3, N'LblUsuario', N'Usuário:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (453, 3, N'LblContraseña', N'Senha:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (454, 3, N'BtnIngresar', N'Entrar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (455, 3, N'LblErrorUsuario', N'Você deve inserir um usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (456, 3, N'LblErrorPassword', N'Você deve inserir uma senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (457, 3, N'BtnInicio', N'Início')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (458, 3, N'BtnAdministrador', N'Administrador')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (459, 3, N'BtnGestionUsuario', N'Gerenciar Usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (460, 3, N'BtnPerfiles', N'Perfis')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (461, 3, N'BtnMaestros', N'Mestres')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (462, 3, N'BtnGestionSalon', N'Gerenciar Salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (463, 3, N'BtnGestionServicios', N'Gerenciar Serviços')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (464, 3, N'BtnGestionClientes', N'Gerenciar Clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (465, 3, N'BtnRegistrarReserva', N'Registrar Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (466, 3, N'BtnCobranza', N'Cobrança')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (467, 3, N'BtnCollectDeposit', N'Cobrar Sinal')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (468, 3, N'BtnReportes', N'Relatórios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (469, 3, N'BtnAyuda', N'Ajuda')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (470, 3, N'BtnCambiarIdioma', N'Alterar Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (471, 3, N'BtnCambiarPassword', N'Alterar Senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (472, 3, N'BtnCerrarSesion', N'Encerrar Sessão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (473, 3, N'MessageCerrarSesion', N'Tem certeza de que deseja encerrar a sessão?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (474, 3, N'CaptionCerrarSesion', N'Confirmar Encerramento da Sessão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (475, 3, N'MessageUsuarioIncorrecto', N'Usuário Incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (476, 3, N'MessageUsuarioBloqueado', N'Usuário Bloqueado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (477, 3, N'MessageContraseñaIncorecta', N'Senha Incorreta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (478, 3, N'MessageNuevasContraseñasNoCoinciden', N'As novas senhas não coincidem')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (479, 3, N'MessageValidacionContraseña', N'A senha deve conter pelo menos 8 caracteres, uma maiúscula e um número')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (480, 3, N'MessageContraseñasNoCoinciden', N'Senhas não coincidem')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (481, 3, N'MessageModificadoCorrectamente', N'Modificado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (482, 3, N'MessageErrorAlModificar', N'Erro ao modificar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (483, 3, N'MessageUsuarioBloqueado', N'O usuário foi bloqueado por exceder o número de tentativas falhas')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (484, 3, N'MessageErrorAlBloquearUsuario', N'Erro ao bloquear usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (485, 3, N'MessageDesbloqueadoCorrectamente', N'Desbloqueado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (486, 3, N'MessageNoSePudoDesbloquear', N'Não foi possível desbloquear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (487, 3, N'MessageCreadoCorrectamente', N'Criado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (488, 3, N'MessageUsuarioExistenteConDni', N'Já existe um usuário com o mesmo número de identificação')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (489, 3, N'MessageEliminadoCorrectamente', N'Excluído com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (490, 3, N'MessageErrorAlEliminar', N'Erro ao Excluir')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (491, 3, N'LblGestionUsuarios', N'Gerenciamento de Usuários')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (492, 3, N'LblNombre', N'Nome:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (493, 3, N'LblDni', N'Número de Identificação:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (494, 3, N'LblApellido', N'Sobrenome:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (495, 3, N'LblMail', N'E-mail:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (496, 3, N'LblPerfil', N'Perfil:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (497, 3, N'BtnCancelar', N'Cancelar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (498, 3, N'BtnGuardar', N'Salvar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (499, 3, N'LblErrorNombre', N'Você deve inserir o nome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (500, 3, N'LblErrorDni', N'Você deve inserir o número de identificação')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (501, 3, N'LblErrorApellido', N'Você deve inserir o sobrenome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (502, 3, N'LblErrorMail', N'Você deve inserir o e-mail')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (503, 3, N'BtnCrear', N'Criar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (504, 3, N'BtnModificar', N'Modificar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (505, 3, N'BtnEliminar', N'Excluir')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (506, 3, N'BtnDesbloquear', N'Desbloquear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (507, 3, N'LblCantidadUsuarios', N'Número de Usuários:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (508, 3, N'LblUsuariosBloqueados', N'Usuários Bloqueados:')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (509, 3, N'MessageFormatoDniIncorrecto', N'Formato de número de identificação incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (510, 3, N'MessageFormatoMailIncorrecto', N'Formato de e-mail incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (511, 3, N'MessageDebeSeleccionarUsuario', N'Você deve selecionar um usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (512, 3, N'MessageDebeSeleccionarPerfil', N'Você deve selecionar um Perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (513, 3, N'MessageDeseaEliminarUsuario', N'Tem certeza de que deseja excluir o usuário?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (514, 3, N'CaptionConfirmarEliminar', N'Confirmar Exclusão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (515, 3, N'MessageDeseaDesbloquearUsuario', N'Tem certeza de que deseja desbloquear o usuário?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (516, 3, N'CaptionConfirmarDesbloquear', N'Confirmar Desbloqueio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (517, 3, N'LblGestionPerfiles', N'Gerenciamento de Perfis')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (518, 3, N'BtnNuevoPerfil', N'Novo Perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (519, 3, N'BtnCrearFamilia', N'Nova Família')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (520, 3, N'LblNombrePerfil', N'Nome do Perfil:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (521, 3, N'LblErrorNombrePerfil', N'Você deve inserir o nome do perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (522, 3, N'LblPermisos', N'Permissões:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (523, 3, N'LblFamilias', N'Famílias:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (524, 3, N'LblListaPermisos', N'Lista de Permissões:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (525, 3, N'LblGestionFamilias', N'Gerenciamento de Famílias de Permissões')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (526, 3, N'LblFamiliasPermisos', N'Famílias de Permissões:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (527, 3, N'BtnNuevaFamilia', N'Nova Família de Permissões')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (528, 3, N'LblNombreFamilia', N'Nome da Família:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (529, 3, N'LblErrorNombreFamilia', N'Você deve inserir o nome da família')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (530, 3, N'BtnAgregarPermiso', N'<=')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (531, 3, N'BtnSacarPermiso', N'=>')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (532, 3, N'MessageDeseaEliminarFamilia', N'Tem certeza de que deseja excluir a família?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (533, 3, N'MessageDeseaEliminarPerfil', N'Tem certeza de que deseja excluir o perfil?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (534, 3, N'MessageDebeSeleccionarPermisos', N'Você deve selecionar permissões ou famílias de permissões')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (535, 3, N'MessageDeseaCancelarProceso', N'Tem certeza de que deseja cancelar o processo?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (536, 3, N'CaptionCancelar', N'Cancelar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (537, 3, N'MessageSeTienePermisoEnLista', N'Você já tem permissão na lista de permissões')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (538, 3, N'MessagePerfilAsignadoAUsuario', N'Perfil atribuído a um usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (539, 3, N'MessageErrorAlCrear', N'Erro ao criar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (540, 3, N'MessageFamiliaAsignadaAPerfil', N'Família atribuída a um perfil')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (541, 3, N'LblGestionSalon', N'Gerenciamento de Salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (542, 3, N'LblPrecio', N'Preço:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (543, 3, N'LblUbicacion', N'Localização:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (544, 3, N'LblPrecioCubierto', N'Preço por Cobertura:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (545, 3, N'LblCapacidad', N'Capacidade:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (546, 3, N'LblErrorPrecio', N'Formato de preço incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (547, 3, N'LblErrorUbicacion', N'Você deve inserir a localização')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (548, 3, N'LblErrorPrecioCubierto', N'Formato de preço por cobertura incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (549, 3, N'LblErrorCapacidad', N'Capacidade incorreta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (550, 3, N'LblErrorCantidadMinimaInvitados', N'Quantidade mínima de convidados incorreta')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (551, 3, N'MessageDebeSeleccionarSalon', N'Você deve selecionar um salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (552, 3, N'MessageDeseaEliminarSalon', N'Tem certeza de que deseja excluir o salão?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (553, 3, N'MessageSalonNoDisponible', N'Salão não disponível para a data e turno selecionados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (554, 3, N'MessageSalonSeleccionado', N'Salão selecionado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (555, 3, N'LblCantidadMinimaInvitados', N'Quantidade mínima de convidados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (556, 3, N'MessageClienteExisteConDni', N'Já existe cliente com o número de identificação informado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (557, 3, N'LblGestionServicios', N'Gerenciamento de Serviços')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (558, 3, N'LblDescripcion', N'Descrição:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (559, 3, N'LblValor', N'Valor:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (560, 3, N'LblErrorDescripcion', N'Você deve inserir a descrição')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (561, 3, N'LblErrorValor', N'Você deve inserir o valor')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (562, 3, N'MessageSeleccionarServicio', N'Você deve selecionar um serviço')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (563, 3, N'MessageDeseaEliminarServicio', N'Tem certeza de que deseja excluir o serviço?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (564, 3, N'LblGestionClientes', N'Gerenciamento de Clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (565, 3, N'LblDireccion', N'Endereço:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (566, 3, N'LblContacto', N'Contato:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (567, 3, N'LblErrorDireccion', N'Você deve inserir o endereço')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (568, 3, N'LblErrorContacto', N'Você deve inserir o contato')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (569, 3, N'CheckShowDireccion', N'Mostrar endereço dos clientes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (570, 3, N'MessageSeleccionarCliente', N'Você deve selecionar um cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (571, 3, N'MessageFormatoContactoIncorrecto', N'Formato de contato incorreto')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (572, 3, N'MessageDeseaEliminarCliente', N'Tem certeza de que deseja excluir o cliente?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (573, 3, N'BtnCambiar', N'Alterar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (574, 3, N'LblSeleccionarIdioma', N'Selecionar Idioma')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (575, 3, N'MessageCancelarProcesoReserva', N'Tem certeza de que deseja cancelar o processo de reserva?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (576, 3, N'LblFecha', N'Data:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (577, 3, N'LblTurno', N'Turno:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (578, 3, N'LblCapacidadMaxima', N'Capacidade máxima:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (579, 3, N'LblListaServicios', N'Lista de serviços:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (580, 3, N'LblCostoTotal', N'Custo total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (581, 3, N'LblCostoSenia', N'Custo da Sinal:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (582, 3, N'LblErrorDescripcionEvento', N'Você deve inserir a descrição do evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (583, 3, N'LblErrorCantidadInvitados', N'Fora da faixa de capacidade')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (584, 3, N'LblRegistrarReserva', N'Registrar Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (585, 3, N'LblSalon', N'Salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (586, 3, N'BtnSeleccionarSalon', N'Selecionar Salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (587, 3, N'BtnRegistrarCliente', N'Registrar Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (588, 3, N'LblCostosEvento', N'Custos do evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (589, 3, N'LblCliente', N'Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (590, 3, N'LblDescripcionEvento', N'Descrição do evento:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (591, 3, N'LblCantidadInvitados', N'Quantidade de convidados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (592, 3, N'LblServiciosAdicionales', N'Serviços Adicionais:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (593, 3, N'BtnSeleccionarServicios', N'Selecionar Serviços')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (594, 3, N'LblServiciosSinSeleccionados', N'Sem Serviços Selecionados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (595, 3, N'MessageReservaRegistradaConExito', N'Reserva registrada com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (596, 3, N'MessageErrorRegistrarReserva', N'Erro ao registrar a reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (597, 3, N'LblSeleccionarSalon', N'Selecionar Salão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (598, 3, N'LblInformacionSalon', N'Informações do salão:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (599, 3, N'BtnSeleccionar', N'Selecionar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (600, 3, N'MessageDebeSeleccionarFechaMayor', N'Você deve selecionar uma data posterior à atual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (601, 3, N'MessageDebeSeleccionarTurno', N'Você deve selecionar um turno')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (602, 3, N'LblRegistrarCliente', N'Registrar Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (603, 3, N'BtnRegistrar', N'Registrar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (604, 3, N'BtnVolver', N'Voltar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (605, 3, N'MessageEstaSeguroQueDeseaVolver', N'Tem certeza de que deseja voltar?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (606, 3, N'CaptionVolver', N'Voltar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (607, 3, N'LblSeleccionarServicios', N'Selecionar Serviços')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (608, 3, N'LblLista', N'Lista:')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (609, 3, N'LblValoresTitulo', N'Valores:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (610, 3, N'LblValores', N'Valores:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (611, 3, N'MessageServiciosSeleccionadosCorrectamente', N'Serviços selecionados corretamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (612, 3, N'MessageValorTotal', N'Valor Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (613, 3, N'LblNombreSalon', N'Nome:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (614, 3, N'LblCobrarSenia', N'Cobrar Sinal')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (615, 3, N'LblBuscarReserva', N'Buscar reserva:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (616, 3, N'BtnBuscar', N'Buscar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (617, 3, N'LblMedioDePago', N'Método de pagamento:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (618, 3, N'LblCostos', N'Custos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (619, 3, N'LblDeposit', N'Sinal:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (620, 3, N'LblTotal', N'Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (621, 3, N'LblNumeroTarjeta', N'Número do cartão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (622, 3, N'LblTipoTarjeta', N'Tipo de cartão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (623, 3, N'LblNombreTitular', N'Nome do titular')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (624, 3, N'LblFechaVencimiento', N'Data de vencimento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (625, 3, N'MessageDebeSeleccionarMedioPago', N'Você deve selecionar um método de pagamento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (626, 3, N'MessageDeseaRealizarCobroSenia', N'Tem certeza de que deseja cobrar o sinal?')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (627, 3, N'CaptionConfirmarCobro', N'Confirmar Cobrança')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (628, 3, N'LblErrorNumeroTarjeta', N'Você deve inserir o número do cartão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (629, 3, N'MessageVerificarDatosTarjeta', N'Cartão inválido, verifique os dados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (630, 3, N'LblErrorNombreTitular', N'Você deve inserir o nome do titular')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (631, 3, N'LblErrorTipoTarjeta', N'Você deve selecionar o tipo de cartão')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (632, 3, N'MessagePagoRealizadoSenia', N'O pagamento do sinal foi realizado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (633, 3, N'MessagePagoRechazado', N'Pagamento recusado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (634, 3, N'MessageComprobanteReserva', N'comprobante_reserva_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (635, 3, N'MessageComprobanteReservaTitulo', N'Comprovante de Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (636, 3, N'MessageInformacionReserva', N'Informações da reserva:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (637, 3, N'MessageCostoSalon', N'Custo do Salão:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (638, 3, N'MessageServiciosSolicitados', N'Serviços Solicitados:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (639, 3, N'MessageMontoTotal', N'Montante Total:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (640, 3, N'MessageSaldoPendiente', N'Saldo Pendente:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (641, 3, N'MessageEstadoCuenta', N'Estado de conta:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (642, 3, N'MessageMontoAbonado', N'Montante Pago:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (643, 3, N'LblCambiarContrasenia', N'Alterar Senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (644, 3, N'LblIngresarContraseniaActual', N'Inserir senha atual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (645, 3, N'LblIngresarNuevaContrasenia', N'Inserir nova senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (646, 3, N'LblRepetirNuevaContrasenia', N'Repetir nova senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (647, 3, N'BtnChangePassword', N'Alterar Senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (648, 3, N'LblErrorActualPass', N'Você deve inserir a senha atual')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (649, 3, N'LblErrorNewPass', N'Você deve inserir uma nova senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (650, 3, N'LblErrorNewPassRep', N'Você deve repetir a nova senha')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (651, 3, N'DGVColumnaUsuario', N'Usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (652, 3, N'DGVColumnaBloqueado', N'Bloqueado')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (653, 3, N'DGVColumnaDni', N'Número de Identificação')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (654, 3, N'DGVColumnaNombre', N'Nome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (655, 3, N'DGVColumnaApellido', N'Sobrenome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (656, 3, N'DGVColumnaMail', N'E-mail')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (657, 3, N'DGVColumnaDescripcion', N'Descrição')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (658, 3, N'DGVColumnaFecha', N'Data')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (659, 3, N'DGVColumnaTurno', N'Turno')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (660, 3, N'DGVColumnaInvitados', N'Convidados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (661, 3, N'DGVColumnaCliente', N'Cliente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (662, 3, N'DGVColumnaValor', N'Valor')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (663, 3, N'DGVColumnaUbicacion', N'Localização')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (664, 3, N'DGVColumnaPrecio', N'Preço')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (665, 3, N'DGVColumnaCapacidad', N'Capacidade')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (666, 3, N'DGVColumnaDireccion', N'Endereço')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (667, 3, N'DGVColumnaContacto', N'Contato')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (668, 3, N'DGVColumnaPrecioCubierto', N'Preço por Cobertura')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (669, 3, N'DGVColumnaCantidadMinimaInvitados', N'Quantidade Mínima de Convidados')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (670, 1, N'MessageFamiliaExisteConMismoNombre', N'Ya existe familia con mismo nombre')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (671, 2, N'MessageFamiliaExisteConMismoNombre', N'Family with the same name already exists')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (672, 3, N'MessageFamiliaExisteConMismoNombre', N'Já existe uma família com o mesmo nome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (673, 1, N'MessagePerfilExisteConMismoNombre', N'Ya existe perfil con mismo nombre')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (674, 2, N'MessagePerfilExisteConMismoNombre', N'Profile with the same name already exists')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (675, 3, N'MessagePerfilExisteConMismoNombre', N'Já existe um perfil com o mesmo nome')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (676, 1, N'BtnInformeReservasDelMes', N'Reservas del mes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (677, 2, N'BtnInformeReservasDelMes', N'Reservations of the month')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (678, 3, N'BtnInformeReservasDelMes', N'Reservas do mês')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (679, 1, N'LblSeleccionarMes', N'Seleccionar Mes')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (680, 2, N'LblSeleccionarMes', N'Select Month')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (681, 3, N'LblSeleccionarMes', N'Selecionar Mês')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (682, 1, N'BtnGenerar', N'Generar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (683, 2, N'BtnGenerar', N'Generate')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (684, 3, N'BtnGenerar', N'Gerar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (685, 1, N'MessageNoHayDatosGenerarReporteReservas', N'No hay datos para generar reporte')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (686, 2, N'MessageNoHayDatosGenerarReporteReservas', N'No data to generate report')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (687, 3, N'MessageNoHayDatosGenerarReporteReservas', N'Não há dados para gerar o relatório')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (688, 1, N'DDGVColumnaReserva', N'Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (689, 2, N'DDGVColumnaReserva', N'Reservation')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (690, 3, N'DDGVColumnaReserva', N'Reserva')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (691, 1, N'NombreArchivoReporteReserva', N'Reporte_Reservas_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (692, 2, N'NombreArchivoReporteReserva', N'Reservation_Report_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (693, 3, N'NombreArchivoReporteReserva', N'Relatório_Reservas_')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (694, 1, N'BtnEventos', N'Eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (695, 2, N'BtnEventos', N'Events')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (696, 3, N'BtnEventos', N'Eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (697, 1, N'LblBitacoraEventos', N'Bitácora Eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (698, 2, N'LblBitacoraEventos', N'Event Log')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (699, 3, N'LblBitacoraEventos', N'Registro de Eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (700, 1, N'LblModulo', N'Modulo:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (701, 2, N'LblModulo', N'Module:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (702, 3, N'LblModulo', N'Módulo:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (703, 3, N'LblEvento', N'Evento:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (704, 2, N'LblEvento', N'Event:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (705, 1, N'LblEvento', N'Evento:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (706, 1, N'LblFechaIni', N'Fecha Inicial:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (707, 1, N'LblFechaFin', N'Fecha Fin:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (708, 1, N'LblCriticidad', N'Criticidad:')
GO
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (709, 2, N'LblCriticidad', N'Criticality:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (710, 2, N'LblFechaFin', N'End Date:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (711, 2, N'LblFechaIni', N'Start Date:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (712, 3, N'LblCriticidad', N'Criticidade:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (713, 3, N'LblFechaFin', N'Data Final:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (714, 3, N'LblFechaIni', N'Data Inicial:')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (715, 1, N'BtnAplicar', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (716, 1, N'BtnLimpiar', N'Limpiar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (717, 1, N'BtnImprimir', N'Imprimir')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (718, 2, N'BtnImprimir', N'Print')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (719, 2, N'BtnLimpiar', N'Clear')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (720, 2, N'BtnAplicar', N'Apply')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (721, 3, N'BtnImprimir', N'Imprimir')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (722, 3, N'BtnLimpiar', N'Limpar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (723, 3, N'BtnAplicar', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (724, 1, N'MessageFechaIniMayorFechaFin', N'Fecha inicial es mayor a fecha fin')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (725, 2, N'MessageFechaIniMayorFechaFin', N'Start date is later than end date')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (726, 3, N'MessageFechaIniMayorFechaFin', N'Data inicial é maior que a data final')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (727, 1, N'DGVColumnaUser', N'Usuario')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (728, 1, N'DGVColumnaModulo', N'Modulo')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (729, 1, N'DGVColumnaEvento', N'Evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (730, 1, N'DGVColumnaCriticidad', N'Criticidad')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (731, 1, N'NombreArchivoBitacora', N'BitacoraEventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (732, 1, N'MessageNoHayDatosGenerarReporteBitacoraEventos', N'No hay datos para generar reporte de bitacora de eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (733, 2, N'MessageNoHayDatosGenerarReporteBitacoraEventos', N'No data to generate event log report')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (734, 2, N'NombreArchivoBitacora', N'EventLog')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (735, 2, N'DGVColumnaCriticidad', N'Criticality')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (736, 2, N'DGVColumnaEvento', N'Event')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (737, 2, N'DGVColumnaModulo', N'Module')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (738, 2, N'DGVColumnaUser', N'User')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (739, 3, N'MessageNoHayDatosGenerarReporteBitacoraEventos', N'Não há dados para gerar relatório de registro de eventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (740, 3, N'NombreArchivoBitacora', N'RegistroEventos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (741, 3, N'DGVColumnaCriticidad', N'Criticidade')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (742, 3, N'DGVColumnaEvento', N'Evento')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (743, 3, N'DGVColumnaModulo', N'Módulo')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (744, 3, N'DGVColumnaUser', N'Usuário')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (745, 1, N'BtnRespaldo', N'Respaldos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (746, 2, N'BtnRespaldo', N'Backup')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (747, 3, N'BtnRespaldo', N'Backup')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (748, 1, N'LblRespaldos', N'Respaldos')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (749, 1, N'LblBackup', N'Backup')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (750, 1, N'BtnSeleccionarDirBackup', N'Seleccionar directorio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (751, 1, N'BtnAplicarBackup', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (752, 1, N'LblRestore', N'Restore')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (753, 1, N'BtnAplicarRestore', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (754, 1, N'BtnSeleccionarDirRestore', N'Seleccionar directorio')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (755, 1, N'BtnSalir', N'Salir')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (756, 2, N'BtnSalir', N'Exit')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (757, 2, N'BtnSeleccionarDirRestore', N'Select directory')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (758, 2, N'BtnAplicarRestore', N'Apply')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (759, 2, N'LblRestore', N'Restore')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (760, 2, N'BtnAplicarBackup', N'Apply')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (761, 2, N'BtnSeleccionarDirBackup', N'Select directory')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (762, 2, N'LblBackup', N'Backup')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (763, 2, N'LblRespaldos', N'Backups')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (764, 3, N'BtnSalir', N'Sair')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (765, 3, N'BtnSeleccionarDirRestore', N'Selecionar diretório')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (766, 3, N'BtnAplicarRestore', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (767, 3, N'LblRestore', N'Restaurar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (768, 3, N'BtnAplicarBackup', N'Aplicar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (769, 3, N'BtnSeleccionarDirBackup', N'Selecionar diretório')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (770, 3, N'LblBackup', N'Backup')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (771, 3, N'LblRespaldos', N'Backups')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (772, 1, N'MessageAplicadoCorrectamente', N'Aplicado correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (773, 2, N'MessageAplicadoCorrectamente', N'Applied successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (774, 3, N'MessageAplicadoCorrectamente', N'Aplicado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (775, 1, N'BtnSerializacion', N'Serializar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (776, 1, N'BtnDeserializar', N'Deserializar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (777, 2, N'BtnDeserializar', N'Deserialize')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (778, 2, N'BtnSerializacion', N'Serialize')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (779, 3, N'BtnDeserializar', N'Desserializar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (780, 3, N'BtnSerializacion', N'Serializar')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (781, 1, N'LblServiciosSerializar', N'Servicios')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (782, 2, N'LblServiciosSerializar', N'Services')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (783, 3, N'LblServiciosSerializar', N'Serviços')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (784, 1, N'MessageSerializadoCorrectamente', N'Serializado correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (785, 1, N'MessageDeserializadoCorrectamente', N'Deserializado correctamente')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (786, 2, N'MessageDeserializadoCorrectamente', N'Deserialized successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (787, 2, N'MessageSerializadoCorrectamente', N'Serialized successfully')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (788, 3, N'MessageDeserializadoCorrectamente', N'Desserializado com sucesso')
INSERT [dbo].[IdiomaControl] ([IdIdiomaControl], [IdIdioma], [NombreControl], [Traduccion]) VALUES (789, 3, N'MessageSerializadoCorrectamente', N'Serializado com sucesso')
SET IDENTITY_INSERT [dbo].[IdiomaControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (1, N'Administrador')
INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (5, N'Cajera')
INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (7, N'Contador')
INSERT [dbo].[Perfil] ([IdPerfil], [Descripcion]) VALUES (11, N'Perfil Cajera 2')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (1, 1003)
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (5, 1005)
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (7, 1012)
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (11, 2)
INSERT [dbo].[PerfilPermiso] ([IdPerfil], [IdPermiso]) VALUES (11, 1005)
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (2, N'Maestros', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (3, N'Registrar Reserva', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (4, N'Cobranza', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (5, N'Reportes', 0)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1003, N'Familia Administrador', 1)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1005, N'Familia cajera', 1)
INSERT [dbo].[Permiso] ([IdPermiso], [Nombre], [IsFamilia]) VALUES (1012, N'Familia Contador', 1)
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
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (17, 3, 3, N'Fiesta de xv', CAST(N'2024-06-24' AS Date), N'Nocturno', 123, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (1017, 2, 3, N'Fiesta de 21', CAST(N'2024-07-14' AS Date), N'Nocturno', 100, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (1018, 5, 3, N'Alguna fiesta', CAST(N'2024-07-14' AS Date), N'Diurno', 123, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (1019, 6, 2, N'Algun otro evento', CAST(N'2024-07-14' AS Date), N'Nocturno', 123, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (1020, 3, 2, N'Un evento copado', CAST(N'2024-07-14' AS Date), N'Diurno', 123, N'Confirmado')
INSERT [dbo].[Reserva] ([IdReserva], [IdCliente], [IdSalon], [Descripcion], [Fecha], [Turno], [Invitados], [Estado]) VALUES (1021, 3, 3, N'Fiesta de 50', CAST(N'2024-07-15' AS Date), N'Nocturno', 200, N'Confirmado')
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
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1017, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1017, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1017, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1018, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1018, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1019, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1019, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1020, 1)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1020, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1020, 4)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1021, 3)
INSERT [dbo].[ReservaServicio] ([IdReserva], [IdServicio]) VALUES (1021, 4)
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
INSERT [dbo].[Servicio] ([IdServicio], [Descripcion], [Valor]) VALUES (6, N'Show', 250000.0000)
INSERT [dbo].[Servicio] ([IdServicio], [Descripcion], [Valor]) VALUES (7, N'Fotografo', 500000.0000)
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (1, N'Admin', N'60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', 0, 44891735, N'Tomas', N'Juarez', N'tjuarez.tm@hotmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (8, N'44891731Tomito', N'9e4a7c6ecf0c36970cae6d88c83c680c50f433729f002a227ba0a0bcef61ebb7', 0, 44891731, N'Tomito', N'Juarez', N'tomito@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (10, N'44891733Facundo', N'95473abe9148c76f699da9376b40369e52ed42bb2fb6d0f57cdf25f18a4ab803', 0, 44891733, N'Facundo', N'Juarez', N'facundo@gmail.com', 7)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (11, N'12345678Bautiti', N'016896c087fbab7fb9c632120d6bd589e0cce1a5c323e73da0422a86fd186b44', 0, 12345678, N'Bautiti', N'Dorelle', N'bautiti@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail], [IdPerfil]) VALUES (12, N'44917321Alejo', N'3455e363cf646277403a8cd846101da7cd1f68044057d194648557982acc388a', 0, 44917321, N'Alejo', N'Tripicho', N'ale.gasolero@hotmail.com', 5)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [Idx-Fecha]    Script Date: 31/08/2024 15:51:30 ******/
CREATE NONCLUSTERED INDEX [Idx-Fecha] ON [dbo].[BitacoraEventos]
(
	[Fecha] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_Dni_Unique]    Script Date: 31/08/2024 15:51:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_Dni_Unique] ON [dbo].[Cliente]
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20240714-143152]    Script Date: 31/08/2024 15:51:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20240714-143152] ON [dbo].[IdiomaControl]
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20240714-143225]    Script Date: 31/08/2024 15:51:30 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20240714-143225] ON [dbo].[IdiomaControl]
(
	[NombreControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20240714-144406]    Script Date: 31/08/2024 15:51:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20240714-144406] ON [dbo].[Perfil]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20240714-144341]    Script Date: 31/08/2024 15:51:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20240714-144341] ON [dbo].[Permiso]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_Dni_Unique]    Script Date: 31/08/2024 15:51:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_Dni_Unique] ON [dbo].[Users]
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BitacoraEventos] ADD  CONSTRAINT [DF_BitacoraEventos_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[BitacoraEventos]  WITH CHECK ADD  CONSTRAINT [FK_BitacoraEventos_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BitacoraEventos] CHECK CONSTRAINT [FK_BitacoraEventos_Users]
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
/****** Object:  StoredProcedure [dbo].[SP_CreateBitacoraEvento]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CreateBitacoraEvento]
(
	@In_IdUser int,
	@In_Modulo nvarchar(50),
	@In_Evento nvarchar(50),
	@In_Criticidad int
)
AS
BEGIN
	INSERT INTO BitacoraEventos (IdUser, Modulo, Evento, Criticidad)
	VALUES (@In_IdUser, @In_Modulo, @In_Evento, @In_Criticidad)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateCliente]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
	IF NOT EXISTS(SELECT * FROM Permiso WHERE Nombre = @In_nombre)
	BEGIN
		INSERT INTO Permiso (Nombre, IsFamilia)
		VALUES (@In_nombre, 1)

		SET @Out_Id = SCOPE_IDENTITY()	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
	IF NOT EXISTS(SELECT * FROM Perfil WHERE Descripcion = @In_Descripcion)
	BEGIN
		INSERT INTO Perfil(Descripcion)
		VALUES (@In_Descripcion)

		SET @Out_Id = SCOPE_IDENTITY()	
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePermisoFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreatePermisoPerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateReserva]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateReservaServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateSalon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CreateUser]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteCliente]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeletePerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeletePermisoPerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeletePermisosFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteReservaServicios]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteSalon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GenerarReporteReservasMes]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GenerarReporteReservasMes]
(
	@In_Fecha DATE
)
AS
BEGIN
	SELECT Fecha, Turno, Descripcion, Invitados, Salon.Nombre AS NombreSalon, Salon.Ubicacion, 
	(ValoresServicios.ValorTotalServicios + Salon.Precio + (Salon.PrecioCubierto * Invitados)) AS ValorTotal
	FROM Reserva
	JOIN Salon ON Salon.IdSalon = Reserva.IdSalon
	JOIN (
		SELECT Reserva.IdReserva, SUM(Servicio.Valor) AS ValorTotalServicios FROM Reserva
		JOIN ReservaServicio ON ReservaServicio.IdReserva = Reserva.IdReserva
		JOIN Servicio ON Servicio.IdServicio = ReservaServicio.IdServicio
		GROUP BY Reserva.IdReserva
	) AS ValoresServicios ON ValoresServicios.IdReserva = Reserva.IdReserva
	WHERE Estado <> 'Pendiente'
	AND YEAR(Fecha) = YEAR(@In_Fecha)
	AND MONTH(Fecha) = MONTH(@In_Fecha)
	ORDER BY Fecha
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectBitacoraEvento]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectBitacoraEvento]
(
	@In_IdUser int = null,
	@In_FechaInicio date = null,
	@In_FechaFin date = null,
	@In_Modulo nvarchar(50) = null,
	@In_Evento nvarchar(50) = null,
	@In_Criticidad int = null
)
AS
BEGIN
	SELECT BitacoraEventos.*, Users.Username, Users.Password, Users.IsBlock, Users.Dni, Users.Nombre,
	Users.Apellido, Users.Mail
	FROM BitacoraEventos
	JOIN Users on Users.Id = BitacoraEventos.IdUser
	WHERE BitacoraEventos.IdUser = ISNULL(@In_IdUser, BitacoraEventos.IdUser)
	AND CONVERT(DATE,BitacoraEventos.Fecha) BETWEEN ISNULL(@In_FechaInicio, DATEADD(DAY, -3, GETDATE())) AND ISNULL(@In_FechaFin, GETDATE())
	AND BitacoraEventos.Modulo = ISNULL(@In_Modulo, BitacoraEventos.Modulo)
	AND BitacoraEventos.Evento = ISNULL(@In_Evento, BitacoraEventos.Evento)
	AND BitacoraEventos.Criticidad = ISNULL(@In_Criticidad, BitacoraEventos.Criticidad)
	ORDER BY Fecha DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectCliente]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectDisponibilidadSalon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectEventosBitacoraEventos]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectEventosBitacoraEventos]
AS
BEGIN
	SELECT DISTINCT Evento AS Eventos FROM BitacoraEventos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectFamilias]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectIdiomas]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectModulosBitacoraEvento]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectModulosBitacoraEvento]
AS
BEGIN
	SELECT DISTINCT Modulo as Modulos FROM BitacoraEventos
	ORDER BY Modulos ASC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectPerfiles]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisos]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisosFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectPermisosPerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectReserva]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectReservaServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectSalon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectTraduccion]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectUser]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectUserPerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_SelectUsersBitacoraEventos]    Script Date: 31/08/2024 15:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_SelectUsersBitacoraEventos]
AS
BEGIN
	SELECT DISTINCT Users.* FROM BitacoraEventos
	JOIN Users ON Users.Id = BitacoraEventos.IdUser
	ORDER BY Users.Username Desc
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCliente]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_UpdateFamilia]    Script Date: 31/08/2024 15:51:30 ******/
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
	IF NOT EXISTS(SELECT * FROM Permiso WHERE Nombre = @In_Nombre AND IdPermiso <> @In_IdPermiso)
	BEGIN
		UPDATE Permiso SET
			Nombre = @In_Nombre
		WHERE IdPermiso = @In_IdPermiso
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePerfil]    Script Date: 31/08/2024 15:51:30 ******/
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
	IF NOT EXISTS(SELECT * FROM Perfil WHERE Descripcion = @In_Descripcion AND IdPerfil != @In_IdPerfil)
	BEGIN
		UPDATE Perfil SET
			Descripcion = @In_Descripcion
		WHERE IdPerfil = @In_IdPerfil
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateReserva]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_UpdateSalon]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_UpdateServicio]    Script Date: 31/08/2024 15:51:30 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_UpdateUser]    Script Date: 31/08/2024 15:51:30 ******/
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
