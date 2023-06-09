USE [master]
GO
/****** Object:  Database [PackageDelivery]    Script Date: 15.02.2022 19:47:06 ******/
CREATE DATABASE [PackageDelivery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PackageDelivery', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\PackageDelivery.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PackageDelivery_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\PackageDelivery_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PackageDelivery] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PackageDelivery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PackageDelivery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PackageDelivery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PackageDelivery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PackageDelivery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PackageDelivery] SET ARITHABORT OFF 
GO
ALTER DATABASE [PackageDelivery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PackageDelivery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PackageDelivery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PackageDelivery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PackageDelivery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PackageDelivery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PackageDelivery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PackageDelivery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PackageDelivery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PackageDelivery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PackageDelivery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PackageDelivery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PackageDelivery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PackageDelivery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PackageDelivery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PackageDelivery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PackageDelivery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PackageDelivery] SET RECOVERY FULL 
GO
ALTER DATABASE [PackageDelivery] SET  MULTI_USER 
GO
ALTER DATABASE [PackageDelivery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PackageDelivery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PackageDelivery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PackageDelivery] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PackageDelivery] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PackageDelivery] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PackageDelivery', N'ON'
GO
ALTER DATABASE [PackageDelivery] SET QUERY_STORE = OFF
GO
USE [PackageDelivery]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 15.02.2022 19:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[idClient] [int] NOT NULL,
	[name] [nchar](50) NOT NULL,
	[surname] [nchar](50) NOT NULL,
	[phoneNumber] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 15.02.2022 19:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[idPackage] [int] NOT NULL,
	[idClient] [int] NOT NULL,
	[description] [nchar](50) NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[idPackage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clients] ([idClient], [name], [surname], [phoneNumber]) VALUES (1, N'Jan                                               ', N'Kowalski                                          ', N'123456789           ')
INSERT [dbo].[Clients] ([idClient], [name], [surname], [phoneNumber]) VALUES (2, N'Robert                                            ', N'Stonoga                                           ', N'125122515           ')
INSERT [dbo].[Clients] ([idClient], [name], [surname], [phoneNumber]) VALUES (3, N'Jan                                               ', N'Zerg                                              ', N'125512526           ')
INSERT [dbo].[Clients] ([idClient], [name], [surname], [phoneNumber]) VALUES (4, N'Daniel                                            ', N'Trałka                                            ', N'123165755           ')
INSERT [dbo].[Clients] ([idClient], [name], [surname], [phoneNumber]) VALUES (5, N'Zofia                                             ', N'Tracz                                             ', N'114223647           ')
GO
INSERT [dbo].[Packages] ([idPackage], [idClient], [description]) VALUES (1, 3, N'Przesyłka z allegro                               ')
INSERT [dbo].[Packages] ([idPackage], [idClient], [description]) VALUES (2, 3, N'Przesyłka z amazon.com                            ')
INSERT [dbo].[Packages] ([idPackage], [idClient], [description]) VALUES (3, 1, N'Zwrot towaru                                      ')
INSERT [dbo].[Packages] ([idPackage], [idClient], [description]) VALUES (4, 2, N'Przesyłka z ebay                                  ')
INSERT [dbo].[Packages] ([idPackage], [idClient], [description]) VALUES (5, 5, N'Przesyłka poczty kwiatowej                        ')
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_Packages_Clients] FOREIGN KEY([idClient])
REFERENCES [dbo].[Clients] ([idClient])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_Packages_Clients]
GO
USE [master]
GO
ALTER DATABASE [PackageDelivery] SET  READ_WRITE 
GO
