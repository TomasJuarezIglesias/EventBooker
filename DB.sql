USE [master]
GO
/****** Object:  Database [EventBooker]    Script Date: 22/05/2024 9:57:52 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 22/05/2024 9:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [char](64) NOT NULL,
	[IsBlock] [bit] NULL,
	[Dni] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsBlock], [Dni], [Nombre], [Apellido], [Mail]) VALUES (1, N'Admin', N'3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2', 1, 44891735, N'Tomas', N'Juarez', N'tjuarez.tm@hotmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateUser]    Script Date: 22/05/2024 9:57:53 ******/
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
	@In_Mail nvarchar(50)
)
AS
BEGIN 
	IF NOT EXISTS(SELECT * FROM Users WHERE Username = @In_username)
	BEGIN
		INSERT INTO Users (Username, Password, IsBlock, Dni, Nombre, Apellido, Mail)
		VALUES (@In_username, @In_Password, 0, @In_Dni, @In_Nombre, @In_Apellido, @In_Mail)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 22/05/2024 9:57:53 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GetUser]    Script Date: 22/05/2024 9:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[SP_GetUser]
(
	@In_username nvarchar(50) = NULL
)
AS
BEGIN
	SELECT * FROM Users WHERE Username = @In_username OR @In_username IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateUser]    Script Date: 22/05/2024 9:57:53 ******/
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
	@In_Mail nvarchar(50)
)
AS
BEGIN
	IF EXISTS(SELECT * FROM Users WHERE Id = @In_id)
	BEGIN
		UPDATE Users SET
			Username = @In_Username,
			Password = @In_Password,
			IsBlock = @In_IsBlock,
			Dni = @In_Dni,
			Nombre = @In_Nombre,
			Apellido = @In_Apellido,
			Mail = @In_Mail
		WHERE Id = @In_id
	END
END
GO
USE [master]
GO
ALTER DATABASE [EventBooker] SET  READ_WRITE 
GO
