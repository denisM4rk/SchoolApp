USE [master]
GO
/****** Object:  Database [DbSchool]    Script Date: 20.12.2023 17:58:53 ******/
CREATE DATABASE [DbSchool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbSchool', FILENAME = N'D:\Разное\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\DbSchool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbSchool_log', FILENAME = N'D:\Разное\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\DbSchool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DbSchool] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbSchool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbSchool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbSchool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbSchool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbSchool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbSchool] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbSchool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbSchool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbSchool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbSchool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbSchool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbSchool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbSchool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbSchool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbSchool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbSchool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbSchool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbSchool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbSchool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbSchool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbSchool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbSchool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbSchool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbSchool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbSchool] SET  MULTI_USER 
GO
ALTER DATABASE [DbSchool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbSchool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbSchool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbSchool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbSchool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbSchool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DbSchool] SET QUERY_STORE = ON
GO
ALTER DATABASE [DbSchool] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DbSchool]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 20.12.2023 17:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdStudent] [int] NOT NULL,
	[IdTeacher] [int] NOT NULL,
	[IdSubject] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Attendance] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 20.12.2023 17:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 20.12.2023 17:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Processor] [nvarchar](50) NOT NULL,
	[Memory] [nvarchar](50) NOT NULL,
	[Storage] [nvarchar](50) NOT NULL,
	[GraphicsCard] [nvarchar](50) NOT NULL,
	[PowerSupply] [nvarchar](50) NOT NULL,
	[AntivirusLicenseStart] [date] NOT NULL,
	[AntivirusLicenseEnd] [date] NOT NULL,
	[SerialNumber] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [char](1) NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[IdStudent] [int] NOT NULL,
	[IdSubject] [int] NOT NULL,
	[GradeDate] [date] NOT NULL,
	[IdGrade] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClass] [int] NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[IdClass] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[IdComputer] [int] NOT NULL,
	[IdClass] [int] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers_Subjects]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers_Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTeacher] [int] NOT NULL,
	[IdSubject] [int] NOT NULL,
 CONSTRAINT [PK_Teachers_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.12.2023 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON 

INSERT [dbo].[Attendance] ([Id], [IdStudent], [IdTeacher], [IdSubject], [Date], [Attendance]) VALUES (1, 1, 1, 3, CAST(N'2023-12-15' AS Date), N'Да')
SET IDENTITY_INSERT [dbo].[Attendance] OFF
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([Id], [Name]) VALUES (1, N'1А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (2, N'1Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (3, N'1В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (4, N'1Г')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (5, N'2А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (6, N'2Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (7, N'2В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (8, N'3А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (9, N'3Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (10, N'3В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (11, N'3Г')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (12, N'4А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (13, N'4Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (14, N'4В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (15, N'5А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (16, N'5Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (17, N'5В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (18, N'5Г')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (19, N'6А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (20, N'6Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (21, N'6В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (22, N'7А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (23, N'7Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (24, N'7В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (25, N'8А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (26, N'8Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (27, N'8В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (28, N'9А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (29, N'9Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (30, N'9В')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (31, N'9Г')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (32, N'10А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (33, N'10Б')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (34, N'11А')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (35, N'11Б баз.')
INSERT [dbo].[Classes] ([Id], [Name]) VALUES (36, N'11Б проф.')
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Computers] ON 

INSERT [dbo].[Computers] ([Id], [Processor], [Memory], [Storage], [GraphicsCard], [PowerSupply], [AntivirusLicenseStart], [AntivirusLicenseEnd], [SerialNumber]) VALUES (1, N'TestProcessor', N'16', N'123', N'TestCard', N'500', CAST(N'2023-12-06' AS Date), CAST(N'2023-12-30' AS Date), N'123456')
INSERT [dbo].[Computers] ([Id], [Processor], [Memory], [Storage], [GraphicsCard], [PowerSupply], [AntivirusLicenseStart], [AntivirusLicenseEnd], [SerialNumber]) VALUES (2, N'TestProcessor2', N'8', N'1000', N'TestCard2', N'450', CAST(N'2023-12-14' AS Date), CAST(N'2023-12-19' AS Date), N'654321')
SET IDENTITY_INSERT [dbo].[Computers] OFF
GO
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [Grade]) VALUES (1, N'2')
INSERT [dbo].[Grades] ([Id], [Grade]) VALUES (2, N'3')
INSERT [dbo].[Grades] ([Id], [Grade]) VALUES (3, N'4')
INSERT [dbo].[Grades] ([Id], [Grade]) VALUES (4, N'5')
SET IDENTITY_INSERT [dbo].[Grades] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([IdStudent], [IdSubject], [GradeDate], [IdGrade], [Id], [IdClass]) VALUES (1, 5, CAST(N'2023-12-07' AS Date), 4, 1, 30)
INSERT [dbo].[Lessons] ([IdStudent], [IdSubject], [GradeDate], [IdGrade], [Id], [IdClass]) VALUES (1, 1, CAST(N'2023-12-07' AS Date), 1, 2, 8)
INSERT [dbo].[Lessons] ([IdStudent], [IdSubject], [GradeDate], [IdGrade], [Id], [IdClass]) VALUES (1, 16, CAST(N'2023-12-13' AS Date), 3, 3, 30)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Учитель')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FullName], [DateOfBirth], [Gender], [IdClass]) VALUES (1, N'TestUser', CAST(N'2003-06-11' AS Date), N'М', 30)
INSERT [dbo].[Students] ([Id], [FullName], [DateOfBirth], [Gender], [IdClass]) VALUES (2, N'Test2', CAST(N'2010-01-28' AS Date), N'М', 8)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (1, N'Русский язык')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (2, N'Музыка')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (3, N'Математика')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (4, N'Литература')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (5, N'ИЗО')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (6, N'Физическая культура')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (7, N'Окружающий мир')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (8, N'Технология')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (9, N'Английский язык')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (10, N'ОРКиСЭ')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (11, N'Разговоры о важном')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (12, N'Информатика')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (13, N'Основы безопасности жизнедеятельности')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (14, N'ОДНКНР')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (15, N'География')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (16, N'История')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (17, N'Обществознание')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (18, N'Биология')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (19, N'Алгебра')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (20, N'Геометрия')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (21, N'Химия')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (22, N'Вероятность и статистика')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (23, N'Черчение')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (24, N'Компьютерная графика')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (25, N'Экономика')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (26, N'Индивидуальный проект')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (27, N'Алгебра и начала математического анализа')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (28, N'Актуальные вопросы обществознания')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (29, N'Решение химических задач')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (30, N'Информатика и технологии программирования')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (31, N'Русское правописание: орфография и пунктуация')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (32, N'Дополнительные главы проф. математики')
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (33, N'Литературное чтение')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [FullName], [DateOfBirth], [Gender], [IdComputer], [IdClass]) VALUES (1, N'TestTeacher', CAST(N'1989-08-25' AS Date), N'Ж', 1, 1)
INSERT [dbo].[Teachers] ([Id], [FullName], [DateOfBirth], [Gender], [IdComputer], [IdClass]) VALUES (2, N'TestTeacher2', CAST(N'2000-09-23' AS Date), N'М', 1, 1)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers_Subjects] ON 

INSERT [dbo].[Teachers_Subjects] ([Id], [IdTeacher], [IdSubject]) VALUES (1, 1, 1)
INSERT [dbo].[Teachers_Subjects] ([Id], [IdTeacher], [IdSubject]) VALUES (2, 1, 2)
INSERT [dbo].[Teachers_Subjects] ([Id], [IdTeacher], [IdSubject]) VALUES (3, 2, 3)
INSERT [dbo].[Teachers_Subjects] ([Id], [IdTeacher], [IdSubject]) VALUES (4, 2, 4)
SET IDENTITY_INSERT [dbo].[Teachers_Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [IdRole]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[Users] ([Id], [Login], [Password], [IdRole]) VALUES (2, N'teacher', N'teacher', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Students] FOREIGN KEY([IdStudent])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Students]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Subjects] FOREIGN KEY([IdSubject])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Subjects]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Teachers] FOREIGN KEY([IdTeacher])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Teachers]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Grades] FOREIGN KEY([IdGrade])
REFERENCES [dbo].[Grades] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Journal_Grades]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Students] FOREIGN KEY([IdStudent])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Journal_Students]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Subjects] FOREIGN KEY([IdSubject])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Journal_Subjects]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Classes] FOREIGN KEY([IdClass])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Classes]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Classes] FOREIGN KEY([IdClass])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Classes]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Classes] FOREIGN KEY([IdClass])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Classes]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Computers] FOREIGN KEY([IdComputer])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Computers]
GO
ALTER TABLE [dbo].[Teachers_Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Subjects_Subjects] FOREIGN KEY([IdSubject])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Teachers_Subjects] CHECK CONSTRAINT [FK_Teachers_Subjects_Subjects]
GO
ALTER TABLE [dbo].[Teachers_Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Subjects_Teachers1] FOREIGN KEY([IdTeacher])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Teachers_Subjects] CHECK CONSTRAINT [FK_Teachers_Subjects_Teachers1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [DbSchool] SET  READ_WRITE 
GO
