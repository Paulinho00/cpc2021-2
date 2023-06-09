USE [master]
GO
/****** Object:  Database [F1Cars]    Script Date: 19.11.2021 09:22:53 ******/
CREATE DATABASE [F1Cars]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'F1Cars', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\F1Cars.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'F1Cars_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\F1Cars_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [F1Cars] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [F1Cars].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [F1Cars] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [F1Cars] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [F1Cars] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [F1Cars] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [F1Cars] SET ARITHABORT OFF 
GO
ALTER DATABASE [F1Cars] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [F1Cars] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [F1Cars] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [F1Cars] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [F1Cars] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [F1Cars] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [F1Cars] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [F1Cars] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [F1Cars] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [F1Cars] SET  DISABLE_BROKER 
GO
ALTER DATABASE [F1Cars] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [F1Cars] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [F1Cars] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [F1Cars] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [F1Cars] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [F1Cars] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [F1Cars] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [F1Cars] SET RECOVERY FULL 
GO
ALTER DATABASE [F1Cars] SET  MULTI_USER 
GO
ALTER DATABASE [F1Cars] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [F1Cars] SET DB_CHAINING OFF 
GO
ALTER DATABASE [F1Cars] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [F1Cars] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [F1Cars] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [F1Cars] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'F1Cars', N'ON'
GO
ALTER DATABASE [F1Cars] SET QUERY_STORE = OFF
GO
USE [F1Cars]
GO
/****** Object:  Table [dbo].[Brakes]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brakes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [nchar](10) NOT NULL,
	[Model] [nchar](10) NOT NULL,
	[MaxTemperature] [int] NOT NULL,
	[MaxRacesNumber] [int] NOT NULL,
 CONSTRAINT [PK_Brakes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[YearOfReveal] [int] NOT NULL,
	[DesignerId] [int] NOT NULL,
	[BrakesId] [int] NOT NULL,
	[GearboxId] [int] NOT NULL,
	[TyreId] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[EngineId] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designers]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[NumberOfDesignedCars] [int] NOT NULL,
 CONSTRAINT [PK_Designers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[NumberOfStarts] [int] NOT NULL,
	[Polepositions] [int] NOT NULL,
	[Podiums] [int] NOT NULL,
	[Wins] [int] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engines]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[YearOfProduction] [int] NOT NULL,
	[Horsepower] [int] NOT NULL,
 CONSTRAINT [PK_Engines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gearboxes]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gearboxes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[Gears] [int] NOT NULL,
	[GearShiftDelay] [float] NOT NULL,
	[MaxRacesNumber] [int] NOT NULL,
 CONSTRAINT [PK_Gearboxes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamPrincipals]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamPrincipals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[ExpierenceYears] [int] NOT NULL,
 CONSTRAINT [PK_TeamPrincipals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ConstructorsChampionshipTitles] [int] NOT NULL,
	[FirstDriverId] [int] NOT NULL,
	[SecondDriverId] [int] NOT NULL,
	[TeamPrincipalId] [int] NOT NULL,
	[Base] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tyres]    Script Date: 19.11.2021 09:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tyres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[FrontTyresWidth] [int] NOT NULL,
	[RearTyresWidth] [int] NOT NULL,
 CONSTRAINT [PK_Tyres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brakes] ON 

INSERT [dbo].[Brakes] ([Id], [Manufacturer], [Model], [MaxTemperature], [MaxRacesNumber]) VALUES (1, N'Brembo    ', N'BRB02     ', 1000, 10)
INSERT [dbo].[Brakes] ([Id], [Manufacturer], [Model], [MaxTemperature], [MaxRacesNumber]) VALUES (2, N'Brembo    ', N'BRB03     ', 1040, 12)
INSERT [dbo].[Brakes] ([Id], [Manufacturer], [Model], [MaxTemperature], [MaxRacesNumber]) VALUES (10, N'Magneti   ', N'MMB01     ', 980, 14)
SET IDENTITY_INSERT [dbo].[Brakes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [Model], [YearOfReveal], [DesignerId], [BrakesId], [GearboxId], [TyreId], [Length], [Width], [TeamId], [EngineId]) VALUES (3, N'W12', 2021, 3, 1, 1, 1, 570, 200, 2, 3)
INSERT [dbo].[Cars] ([Id], [Model], [YearOfReveal], [DesignerId], [BrakesId], [GearboxId], [TyreId], [Length], [Width], [TeamId], [EngineId]) VALUES (4, N'A521', 2021, 4, 2, 3, 1, 568, 195, 4, 5)
INSERT [dbo].[Cars] ([Id], [Model], [YearOfReveal], [DesignerId], [BrakesId], [GearboxId], [TyreId], [Length], [Width], [TeamId], [EngineId]) VALUES (5, N'RB16B', 2021, 1, 10, 2, 1, 567, 199, 1, 3)
INSERT [dbo].[Cars] ([Id], [Model], [YearOfReveal], [DesignerId], [BrakesId], [GearboxId], [TyreId], [Length], [Width], [TeamId], [EngineId]) VALUES (1003, N'W07', 2016, 3, 2, 1, 2, 500, 180, 2, 2)
INSERT [dbo].[Cars] ([Id], [Model], [YearOfReveal], [DesignerId], [BrakesId], [GearboxId], [TyreId], [Length], [Width], [TeamId], [EngineId]) VALUES (1006, N'W01', 2010, 3, 2, 2, 3, 399, 151, 2, 3)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Designers] ON 

INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Age], [NumberOfDesignedCars]) VALUES (1, N'Adrian', N'Newey', 62, 34)
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Age], [NumberOfDesignedCars]) VALUES (3, N'James', N'Allison', 53, 31)
INSERT [dbo].[Designers] ([Id], [FirstName], [LastName], [Age], [NumberOfDesignedCars]) VALUES (4, N'Pat', N'Fry', 57, 13)
SET IDENTITY_INSERT [dbo].[Designers] OFF
GO
SET IDENTITY_INSERT [dbo].[Drivers] ON 

INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (1, N'Max', N'Verstappen', 24, 138, 12, 57, 19)
INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (2, N'Sergio', N'Perez', 31, 210, 0, 15, 2)
INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (3, N'Lewis', N'Hamilton', 36, 285, 101, 179, 101)
INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (4, N'Valtteri', N'Bottas', 32, 175, 20, 66, 10)
INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (5, N'Esteban', N'Ocon', 25, 86, 0, 2, 1)
INSERT [dbo].[Drivers] ([Id], [FirstName], [LastName], [Age], [NumberOfStarts], [Polepositions], [Podiums], [Wins]) VALUES (6, N'Fernando', N'Alonso', 40, 330, 22, 97, 32)
SET IDENTITY_INSERT [dbo].[Drivers] OFF
GO
SET IDENTITY_INSERT [dbo].[Engines] ON 

INSERT [dbo].[Engines] ([Id], [Model], [Manufacturer], [YearOfProduction], [Horsepower]) VALUES (1, N'M12 Performance', N'Mercedes', 2020, 1000)
INSERT [dbo].[Engines] ([Id], [Model], [Manufacturer], [YearOfProduction], [Horsepower]) VALUES (2, N'M08 EQ Power+', N'Mercedes', 2017, 800)
INSERT [dbo].[Engines] ([Id], [Model], [Manufacturer], [YearOfProduction], [Horsepower]) VALUES (3, N'RA621H', N'Honda', 2020, 980)
INSERT [dbo].[Engines] ([Id], [Model], [Manufacturer], [YearOfProduction], [Horsepower]) VALUES (5, N'E-Tech 21', N'Renault', 2020, 960)
SET IDENTITY_INSERT [dbo].[Engines] OFF
GO
SET IDENTITY_INSERT [dbo].[Gearboxes] ON 

INSERT [dbo].[Gearboxes] ([Id], [Manufacturer], [Gears], [GearShiftDelay], [MaxRacesNumber]) VALUES (1, N'Mercedes', 8, 0.0012, 5)
INSERT [dbo].[Gearboxes] ([Id], [Manufacturer], [Gears], [GearShiftDelay], [MaxRacesNumber]) VALUES (2, N'Red Bull', 8, 0.0014, 7)
INSERT [dbo].[Gearboxes] ([Id], [Manufacturer], [Gears], [GearShiftDelay], [MaxRacesNumber]) VALUES (3, N'Renault', 7, 0.0015, 5)
SET IDENTITY_INSERT [dbo].[Gearboxes] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamPrincipals] ON 

INSERT [dbo].[TeamPrincipals] ([Id], [FirstName], [LastName], [Age], [ExpierenceYears]) VALUES (2, N'Christian', N'Horner', 48, 16)
INSERT [dbo].[TeamPrincipals] ([Id], [FirstName], [LastName], [Age], [ExpierenceYears]) VALUES (3, N'Toto', N'Wolff', 49, 9)
INSERT [dbo].[TeamPrincipals] ([Id], [FirstName], [LastName], [Age], [ExpierenceYears]) VALUES (4, N'Marcin', N'Budkowski', 44, 2)
SET IDENTITY_INSERT [dbo].[TeamPrincipals] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [Name], [ConstructorsChampionshipTitles], [FirstDriverId], [SecondDriverId], [TeamPrincipalId], [Base]) VALUES (1, N'Red Bull Racing', 4, 1, 2, 2, N'Wielka Brytania')
INSERT [dbo].[Teams] ([Id], [Name], [ConstructorsChampionshipTitles], [FirstDriverId], [SecondDriverId], [TeamPrincipalId], [Base]) VALUES (2, N'Mercedes F1 Team', 7, 3, 4, 3, N'Niemcy')
INSERT [dbo].[Teams] ([Id], [Name], [ConstructorsChampionshipTitles], [FirstDriverId], [SecondDriverId], [TeamPrincipalId], [Base]) VALUES (4, N'Alpine F1 Team', 2, 6, 5, 4, N'Francja')
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Tyres] ON 

INSERT [dbo].[Tyres] ([Id], [Manufacturer], [FrontTyresWidth], [RearTyresWidth]) VALUES (1, N'Pirelli', 305, 405)
INSERT [dbo].[Tyres] ([Id], [Manufacturer], [FrontTyresWidth], [RearTyresWidth]) VALUES (2, N'Pirelli', 245, 325)
INSERT [dbo].[Tyres] ([Id], [Manufacturer], [FrontTyresWidth], [RearTyresWidth]) VALUES (3, N'Bridgestone', 245, 350)
SET IDENTITY_INSERT [dbo].[Tyres] OFF
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Brakes] FOREIGN KEY([BrakesId])
REFERENCES [dbo].[Brakes] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Brakes]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Designers] FOREIGN KEY([DesignerId])
REFERENCES [dbo].[Designers] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Designers]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Gearboxes] FOREIGN KEY([GearboxId])
REFERENCES [dbo].[Gearboxes] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Gearboxes]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Teams] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Teams]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Tyres] FOREIGN KEY([TyreId])
REFERENCES [dbo].[Tyres] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Tyres]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Drivers] FOREIGN KEY([FirstDriverId])
REFERENCES [dbo].[Drivers] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Drivers]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Drivers1] FOREIGN KEY([SecondDriverId])
REFERENCES [dbo].[Drivers] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Drivers1]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_TeamPrincipals] FOREIGN KEY([TeamPrincipalId])
REFERENCES [dbo].[TeamPrincipals] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_TeamPrincipals]
GO
USE [master]
GO
ALTER DATABASE [F1Cars] SET  READ_WRITE 
GO
