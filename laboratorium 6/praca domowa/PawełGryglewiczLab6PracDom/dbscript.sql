USE [master]
GO
/****** Object:  Database [UniversityLessonSystem]    Script Date: 06.01.2022 13:08:39 ******/
CREATE DATABASE [UniversityLessonSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityLessonSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\UniversityLessonSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversityLessonSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PAWELSQL\MSSQL\DATA\UniversityLessonSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniversityLessonSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityLessonSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityLessonSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityLessonSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityLessonSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniversityLessonSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityLessonSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UniversityLessonSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [UniversityLessonSystem] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityLessonSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityLessonSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityLessonSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityLessonSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversityLessonSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversityLessonSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityLessonSystem', N'ON'
GO
ALTER DATABASE [UniversityLessonSystem] SET QUERY_STORE = OFF
GO
USE [UniversityLessonSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06.01.2022 13:08:39 ******/
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
/****** Object:  Table [dbo].[Buildings]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](1) NOT NULL,
	[Number] [int] NOT NULL,
	[YearOfBuild] [int] NOT NULL,
	[FacultyFK] [int] NOT NULL,
	[NumberOfFloors] [int] NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturers]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Pesel] [nvarchar](20) NOT NULL,
	[Degree] [nvarchar](25) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Lecturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[LecturerId] [int] NOT NULL,
	[RoomId] [int] NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonStudent]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonStudent](
	[LessonsId] [int] NOT NULL,
	[StudentsId] [int] NOT NULL,
 CONSTRAINT [PK_LessonStudent] PRIMARY KEY CLUSTERED 
(
	[LessonsId] ASC,
	[StudentsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[FloorNumber] [int] NOT NULL,
	[NumberOfPlaces] [int] NOT NULL,
	[BuildingId] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 06.01.2022 13:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Pesel] [nvarchar](20) NOT NULL,
	[Index] [int] NOT NULL,
	[FacultyId] [int] NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211228092436_init', N'5.0.13')
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([Id], [Category], [Number], [YearOfBuild], [FacultyFK], [NumberOfFloors]) VALUES (1, N'C', 2, 2014, 2, 3)
INSERT [dbo].[Buildings] ([Id], [Category], [Number], [YearOfBuild], [FacultyFK], [NumberOfFloors]) VALUES (2, N'C', 16, 2014, 5, 4)
INSERT [dbo].[Buildings] ([Id], [Category], [Number], [YearOfBuild], [FacultyFK], [NumberOfFloors]) VALUES (4, N'C', 1, 1968, 4, 2)
INSERT [dbo].[Buildings] ([Id], [Category], [Number], [YearOfBuild], [FacultyFK], [NumberOfFloors]) VALUES (8, N'C', 23, 2005, 4, 20)
INSERT [dbo].[Buildings] ([Id], [Category], [Number], [YearOfBuild], [FacultyFK], [NumberOfFloors]) VALUES (9, N'C', 6, 2005, 4, 20)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([Id], [Number], [FullName]) VALUES (1, 1, N'Wydział Architektury')
INSERT [dbo].[Faculties] ([Id], [Number], [FullName]) VALUES (2, 2, N'Wydział Budownictwa')
INSERT [dbo].[Faculties] ([Id], [Number], [FullName]) VALUES (4, 3, N'Wydział Chemiczny')
INSERT [dbo].[Faculties] ([Id], [Number], [FullName]) VALUES (5, 4, N'Wydział Informatyki i Telekomunikacji')
INSERT [dbo].[Faculties] ([Id], [Number], [FullName]) VALUES (6, 9, N'Wydział Podstawowych Problemów Techniki')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
GO
SET IDENTITY_INSERT [dbo].[Lecturers] ON 

INSERT [dbo].[Lecturers] ([Id], [FirstName], [LastName], [Pesel], [Degree], [FacultyId]) VALUES (1, N'Samuel', N'Nowak', N'94031366693', N'Doktor', 4)
INSERT [dbo].[Lecturers] ([Id], [FirstName], [LastName], [Pesel], [Degree], [FacultyId]) VALUES (2, N'Ariel', N'Pietrzak', N'47101745454', N'Doktor', 4)
INSERT [dbo].[Lecturers] ([Id], [FirstName], [LastName], [Pesel], [Degree], [FacultyId]) VALUES (3, N'Krystyna', N'Kasprzak', N'67120610683', N'Magister inżynier', 4)
INSERT [dbo].[Lecturers] ([Id], [FirstName], [LastName], [Pesel], [Degree], [FacultyId]) VALUES (4, N'Natasza', N'Duda', N'82020209780', N'Magister inżynier', 2)
INSERT [dbo].[Lecturers] ([Id], [FirstName], [LastName], [Pesel], [Degree], [FacultyId]) VALUES (6, N'Tomasz', N'Tomkiewicz', N'82020209750', N'Magister', 4)
SET IDENTITY_INSERT [dbo].[Lecturers] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([Id], [Date], [Subject], [LecturerId], [RoomId]) VALUES (1, CAST(N'2022-01-10T09:45:00' AS SmallDateTime), N'Chemia w przemyśle', 6, 2)
INSERT [dbo].[Lessons] ([Id], [Date], [Subject], [LecturerId], [RoomId]) VALUES (2, CAST(N'2022-01-10T09:45:00' AS SmallDateTime), N'Chemia w medycynie', 3, 3)
INSERT [dbo].[Lessons] ([Id], [Date], [Subject], [LecturerId], [RoomId]) VALUES (4, CAST(N'2022-01-08T11:45:00' AS SmallDateTime), N'Chemia podstawowa', 3, 2)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
INSERT [dbo].[LessonStudent] ([LessonsId], [StudentsId]) VALUES (1, 1)
INSERT [dbo].[LessonStudent] ([LessonsId], [StudentsId]) VALUES (4, 1)
INSERT [dbo].[LessonStudent] ([LessonsId], [StudentsId]) VALUES (1, 2)
INSERT [dbo].[LessonStudent] ([LessonsId], [StudentsId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [Number], [FloorNumber], [NumberOfPlaces], [BuildingId]) VALUES (1, 201, 2, 40, 4)
INSERT [dbo].[Rooms] ([Id], [Number], [FloorNumber], [NumberOfPlaces], [BuildingId]) VALUES (2, 202, 2, 40, 4)
INSERT [dbo].[Rooms] ([Id], [Number], [FloorNumber], [NumberOfPlaces], [BuildingId]) VALUES (3, 101, 1, 40, 4)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [Pesel], [Index], [FacultyId], [Subject]) VALUES (1, N'Mieczysław', N'Świątek', N'97031683629', 255011, 4, N'Chemia')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [Pesel], [Index], [FacultyId], [Subject]) VALUES (2, N'Nadia', N'Wójcik', N'95102649567', 253012, 4, N'Chemia Przemysłowa')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [Pesel], [Index], [FacultyId], [Subject]) VALUES (3, N'Bernadeta', N'Pawlik', N'02250642384', 258010, 2, N'Budownictwo drogowe')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
/****** Object:  Index [IX_Buildings_FacultyFK]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Buildings_FacultyFK] ON [dbo].[Buildings]
(
	[FacultyFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lecturers_FacultyId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Lecturers_FacultyId] ON [dbo].[Lecturers]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lessons_LecturerId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Lessons_LecturerId] ON [dbo].[Lessons]
(
	[LecturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lessons_RoomId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Lessons_RoomId] ON [dbo].[Lessons]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonStudent_StudentsId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_LessonStudent_StudentsId] ON [dbo].[LessonStudent]
(
	[StudentsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rooms_BuildingId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Rooms_BuildingId] ON [dbo].[Rooms]
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_FacultyId]    Script Date: 06.01.2022 13:08:40 ******/
CREATE NONCLUSTERED INDEX [IX_Students_FacultyId] ON [dbo].[Students]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Faculties_FacultyFK] FOREIGN KEY([FacultyFK])
REFERENCES [dbo].[Faculties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Faculties_FacultyFK]
GO
ALTER TABLE [dbo].[Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Lecturers_Faculties_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lecturers] CHECK CONSTRAINT [FK_Lecturers_Faculties_FacultyId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Lecturers_LecturerId] FOREIGN KEY([LecturerId])
REFERENCES [dbo].[Lecturers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Lecturers_LecturerId]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Rooms_RoomId]
GO
ALTER TABLE [dbo].[LessonStudent]  WITH CHECK ADD  CONSTRAINT [FK_LessonStudent_Lessons_LessonsId] FOREIGN KEY([LessonsId])
REFERENCES [dbo].[Lessons] ([Id])
GO
ALTER TABLE [dbo].[LessonStudent] CHECK CONSTRAINT [FK_LessonStudent_Lessons_LessonsId]
GO
ALTER TABLE [dbo].[LessonStudent]  WITH CHECK ADD  CONSTRAINT [FK_LessonStudent_Students_StudentsId] FOREIGN KEY([StudentsId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[LessonStudent] CHECK CONSTRAINT [FK_LessonStudent_Students_StudentsId]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Buildings_BuildingId] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Buildings_BuildingId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties_FacultyId]
GO
USE [master]
GO
ALTER DATABASE [UniversityLessonSystem] SET  READ_WRITE 
GO
