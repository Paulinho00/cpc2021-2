USE [master]
GO
/****** Object:  Database [RailwaySystem]    Script Date: 14.12.2021 11:03:25 ******/
CREATE DATABASE [RailwaySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RailwaySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\RailwaySystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RailwaySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\RailwaySystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RailwaySystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RailwaySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RailwaySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RailwaySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RailwaySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RailwaySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RailwaySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [RailwaySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RailwaySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RailwaySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RailwaySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RailwaySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RailwaySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RailwaySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RailwaySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RailwaySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RailwaySystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RailwaySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RailwaySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RailwaySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RailwaySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RailwaySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RailwaySystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RailwaySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RailwaySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [RailwaySystem] SET  MULTI_USER 
GO
ALTER DATABASE [RailwaySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RailwaySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RailwaySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RailwaySystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RailwaySystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RailwaySystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RailwaySystem', N'ON'
GO
ALTER DATABASE [RailwaySystem] SET QUERY_STORE = OFF
GO
USE [RailwaySystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.12.2021 11:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 14.12.2021 11:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[TicketType] [nvarchar](max) NOT NULL,
	[RailwayConnectionId] [int] NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RailwayConnections]    Script Date: 14.12.2021 11:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RailwayConnections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeOfDeparture] [smalldatetime] NULL,
	[PlaceOfDepartureId] [int] NOT NULL,
	[TimeOfArrival] [smalldatetime] NULL,
	[DestinationId] [int] NULL,
	[TrainId] [int] NOT NULL,
 CONSTRAINT [PK_RailwayConnections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stations]    Script Date: 14.12.2021 11:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Town] [nvarchar](25) NOT NULL,
	[PlatformsNumber] [int] NOT NULL,
	[YearOfFound] [int] NOT NULL,
	[HasTicketOffice] [bit] NOT NULL,
 CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trains]    Script Date: 14.12.2021 11:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](25) NOT NULL,
	[PowerType] [nvarchar](25) NOT NULL,
	[YearOfProduction] [int] NOT NULL,
	[NumberOfCars] [int] NOT NULL,
	[MaxSpeed] [int] NOT NULL,
	[Weigth] [int] NOT NULL,
 CONSTRAINT [PK_Trains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211208181959_ini', N'5.0.12')
GO
SET IDENTITY_INSERT [dbo].[Passengers] ON 

INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (1, N'Jan', N'Kowalski', 44, N'jan.kowalski@gmail.com', N'Ulgowy', 2)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (2, N'Stefan', N'Nowak ', 54, N'stefan.nowak@gmail.pl', N'Normalny', 5)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (5, N'Marcin', N'Kastet', 35, N'm.kastet@gmail.com', N'Normalny', 5)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (8, N'Maksymilian', N'Ostrowski', 32, N'max.ostrowski@gmail.com', N'Normalny', 1)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (10, N'Grzegorz', N'Kaźmierczak', 21, N'grzegorz.kazmierczak@o2.pl', N'Normalny', 6)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (11, N'Patryk', N'Rutkowski', 56, N'rutkowski.p@wp.pl', N'Normalny', 4)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (12, N'Nikola', N'Pająk', 43, N'nikola.pajak@gmail.com', N'Normalny', 6)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (14, N'Antonina', N'Kasprzak', 19, N'antosia.kasprzak@gmail.com', N'Normalny', 8)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (15, N'Norbert', N'Maciejewski', 50, N'maciejewskin@o2.pl', N'Normalny', 9)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (16, N'Alfreda', N'Sobczak', 67, N'sobczakalfreda@interia.pl', N'Ulgowy', 7)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (17, N'Krzysztof', N'Grabowski', 39, N'grabowski_krzysztof', N'Normalny', 8)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (18, N'Maksymilian', N'Nowacki', 31, N'nowacki_maks@gmail.pl', N'Normalny', 8)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (19, N'Bronisław', N'Pawlik', 57, N'bronisław_pawlik@wp.pl', N'Normalny', 9)
INSERT [dbo].[Passengers] ([Id], [FirstName], [LastName], [Age], [EmailAddress], [TicketType], [RailwayConnectionId]) VALUES (33, N'Helmut', N'Olszewski', 6, N'helmut.olszewski@gmail.com', N'Ulgowy', 3)
SET IDENTITY_INSERT [dbo].[Passengers] OFF
GO
SET IDENTITY_INSERT [dbo].[RailwayConnections] ON 

INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (1, CAST(N'2021-12-20T20:31:00' AS SmallDateTime), 1, CAST(N'2021-12-20T22:36:00' AS SmallDateTime), 2, 2)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (2, CAST(N'2021-12-21T15:45:00' AS SmallDateTime), 5, CAST(N'2021-12-21T18:31:00' AS SmallDateTime), 8, 1)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (3, CAST(N'2021-12-21T12:31:00' AS SmallDateTime), 3, CAST(N'2021-12-21T16:00:00' AS SmallDateTime), 6, 4)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (4, CAST(N'2021-12-19T09:00:00' AS SmallDateTime), 7, CAST(N'2021-12-19T11:45:00' AS SmallDateTime), 8, 3)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (5, CAST(N'2021-12-20T11:30:00' AS SmallDateTime), 2, CAST(N'2021-12-20T17:15:00' AS SmallDateTime), 6, 6)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (6, CAST(N'2021-12-23T09:28:00' AS SmallDateTime), 8, CAST(N'2021-12-23T12:56:00' AS SmallDateTime), 4, 3)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (7, CAST(N'2021-12-22T08:21:00' AS SmallDateTime), 6, CAST(N'2021-12-22T11:32:00' AS SmallDateTime), 3, 2)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (8, CAST(N'2021-12-22T05:10:00' AS SmallDateTime), 4, CAST(N'2021-12-22T09:15:00' AS SmallDateTime), 5, 4)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (9, CAST(N'2021-12-20T07:20:00' AS SmallDateTime), 3, CAST(N'2021-12-22T11:10:00' AS SmallDateTime), 7, 1)
INSERT [dbo].[RailwayConnections] ([Id], [TimeOfDeparture], [PlaceOfDepartureId], [TimeOfArrival], [DestinationId], [TrainId]) VALUES (11, CAST(N'2021-12-23T08:24:00' AS SmallDateTime), 6, CAST(N'2021-12-23T12:36:00' AS SmallDateTime), 8, 5)
SET IDENTITY_INSERT [dbo].[RailwayConnections] OFF
GO
SET IDENTITY_INSERT [dbo].[Stations] ON 

INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (1, N'Wrocław', 6, 1857, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (2, N'Kraków', 10, 1847, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (3, N'Warszawa', 2, 2021, 0)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (4, N'Poznań', 10, 2012, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (5, N'Gdańsk', 6, 1900, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (6, N'Szczecin', 4, 1843, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (7, N'Białystok', 4, 1861, 1)
INSERT [dbo].[Stations] ([Id], [Town], [PlatformsNumber], [YearOfFound], [HasTicketOffice]) VALUES (8, N'Suwałki', 3, 1896, 0)
SET IDENTITY_INSERT [dbo].[Stations] OFF
GO
SET IDENTITY_INSERT [dbo].[Trains] ON 

INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (1, N'Skoda', N'EP05', N'Elektryczny', 1977, 6, 160, 20600)
INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (2, N'Pafawag', N'EP08', N'Elektryczny', 1975, 5, 160, 25000)
INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (3, N'Pafawag', N'EP07', N'Elektryczny', 1980, 8, 125, 21500)
INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (4, N'Fablok', N'6D', N'Spalinowy', 1993, 20, 90, 70000)
INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (5, N'Pesa', N'111Db', N'Spalinowy', 2013, 10, 160, 84000)
INSERT [dbo].[Trains] ([Id], [Manufacturer], [Model], [PowerType], [YearOfProduction], [NumberOfCars], [MaxSpeed], [Weigth]) VALUES (6, N'Pesa', N'Dart', N'Elektryczny', 2015, 1, 160, 395000)
SET IDENTITY_INSERT [dbo].[Trains] OFF
GO
/****** Object:  Index [IX_Passengers_RailwayConnectionId]    Script Date: 14.12.2021 11:03:25 ******/
CREATE NONCLUSTERED INDEX [IX_Passengers_RailwayConnectionId] ON [dbo].[Passengers]
(
	[RailwayConnectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RailwayConnections_DestinationId]    Script Date: 14.12.2021 11:03:25 ******/
CREATE NONCLUSTERED INDEX [IX_RailwayConnections_DestinationId] ON [dbo].[RailwayConnections]
(
	[DestinationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RailwayConnections_PlaceOfDepartureId]    Script Date: 14.12.2021 11:03:25 ******/
CREATE NONCLUSTERED INDEX [IX_RailwayConnections_PlaceOfDepartureId] ON [dbo].[RailwayConnections]
(
	[PlaceOfDepartureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RailwayConnections_TrainId]    Script Date: 14.12.2021 11:03:25 ******/
CREATE NONCLUSTERED INDEX [IX_RailwayConnections_TrainId] ON [dbo].[RailwayConnections]
(
	[TrainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Passengers]  WITH CHECK ADD  CONSTRAINT [FK_Passengers_RailwayConnections_RailwayConnectionId] FOREIGN KEY([RailwayConnectionId])
REFERENCES [dbo].[RailwayConnections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Passengers] CHECK CONSTRAINT [FK_Passengers_RailwayConnections_RailwayConnectionId]
GO
ALTER TABLE [dbo].[RailwayConnections]  WITH CHECK ADD  CONSTRAINT [FK_RailwayConnections_Stations_DestinationId] FOREIGN KEY([DestinationId])
REFERENCES [dbo].[Stations] ([Id])
GO
ALTER TABLE [dbo].[RailwayConnections] CHECK CONSTRAINT [FK_RailwayConnections_Stations_DestinationId]
GO
ALTER TABLE [dbo].[RailwayConnections]  WITH CHECK ADD  CONSTRAINT [FK_RailwayConnections_Stations_PlaceOfDepartureId] FOREIGN KEY([PlaceOfDepartureId])
REFERENCES [dbo].[Stations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RailwayConnections] CHECK CONSTRAINT [FK_RailwayConnections_Stations_PlaceOfDepartureId]
GO
ALTER TABLE [dbo].[RailwayConnections]  WITH CHECK ADD  CONSTRAINT [FK_RailwayConnections_Trains_TrainId] FOREIGN KEY([TrainId])
REFERENCES [dbo].[Trains] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RailwayConnections] CHECK CONSTRAINT [FK_RailwayConnections_Trains_TrainId]
GO
USE [master]
GO
ALTER DATABASE [RailwaySystem] SET  READ_WRITE 
GO
