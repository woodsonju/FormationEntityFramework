USE [master]
GO
/****** Object:  Database [firstdemo_db_prepa]    Script Date: 08/11/2022 11:45:36 ******/
CREATE DATABASE [firstdemo_db_prepa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'firstdemo_db_prepa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\firstdemo_db_prepa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'firstdemo_db_prepa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\firstdemo_db_prepa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [firstdemo_db_prepa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [firstdemo_db_prepa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [firstdemo_db_prepa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ARITHABORT OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [firstdemo_db_prepa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [firstdemo_db_prepa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [firstdemo_db_prepa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [firstdemo_db_prepa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [firstdemo_db_prepa] SET  MULTI_USER 
GO
ALTER DATABASE [firstdemo_db_prepa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [firstdemo_db_prepa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [firstdemo_db_prepa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [firstdemo_db_prepa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [firstdemo_db_prepa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [firstdemo_db_prepa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [firstdemo_db_prepa] SET QUERY_STORE = OFF
GO
USE [firstdemo_db_prepa]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 08/11/2022 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Num] [int] NULL,
	[Street] [nvarchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08/11/2022 11:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lastname] [nvarchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[age] [int] NULL,
	[addressId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [Num], [Street]) VALUES (1, 12, N'place capitole')
INSERT [dbo].[Address] ([Id], [Num], [Street]) VALUES (2, 1, N'Avenu toulouse')
INSERT [dbo].[Address] ([Id], [Num], [Street]) VALUES (3, 1, N'place du capitole')
INSERT [dbo].[Address] ([Id], [Num], [Street]) VALUES (4, 2, N'avenue de montauban')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [lastname], [firstname], [age], [addressId]) VALUES (1, N'toto', N'tata', 15, 3)
INSERT [dbo].[Employee] ([id], [lastname], [firstname], [age], [addressId]) VALUES (2, N'dupont', N'pierre', 28, 4)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Address] FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Address]
GO
USE [master]
GO
ALTER DATABASE [firstdemo_db_prepa] SET  READ_WRITE 
GO
