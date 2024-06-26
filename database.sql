USE [master]
GO
/****** Object:  Database [rentaly]    Script Date: 15.6.2024. 14:52:49 ******/
CREATE DATABASE [rentaly]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'rentaly', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\rentaly.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'rentaly_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\rentaly_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [rentaly] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [rentaly].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [rentaly] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [rentaly] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [rentaly] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [rentaly] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [rentaly] SET ARITHABORT OFF 
GO
ALTER DATABASE [rentaly] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [rentaly] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [rentaly] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [rentaly] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [rentaly] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [rentaly] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [rentaly] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [rentaly] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [rentaly] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [rentaly] SET  DISABLE_BROKER 
GO
ALTER DATABASE [rentaly] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [rentaly] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [rentaly] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [rentaly] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [rentaly] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [rentaly] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [rentaly] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [rentaly] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [rentaly] SET  MULTI_USER 
GO
ALTER DATABASE [rentaly] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [rentaly] SET DB_CHAINING OFF 
GO
ALTER DATABASE [rentaly] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [rentaly] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [rentaly] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [rentaly] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [rentaly] SET QUERY_STORE = ON
GO
ALTER DATABASE [rentaly] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [rentaly]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.6.2024. 14:52:49 ******/
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
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Identity] [nvarchar](50) NOT NULL,
	[UseCaseName] [nvarchar](50) NOT NULL,
	[ExecutionDateTime] [datetime2](7) NOT NULL,
	[IsAuthorized] [bit] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingCarAccessories]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingCarAccessories](
	[BookingId] [int] NOT NULL,
	[CarAccessoryId] [int] NOT NULL,
 CONSTRAINT [PK_BookingCarAccessories] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC,
	[CarAccessoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CarId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarAccessories]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarAccessories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CarAccessories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kilometars] [real] NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[VIN] [nvarchar](max) NOT NULL,
	[ManufacturerYear] [date] NOT NULL,
	[ModelId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarServices]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CarId] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[ServiceType] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CarServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarSpecifications]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarSpecifications](
	[CarId] [int] NOT NULL,
	[SpecificationId] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CarSpecifications] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC,
	[SpecificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarTypes]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CarTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[BrandId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PricePerDay] [decimal](18, 2) NOT NULL,
	[CarId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StarsRate] [real] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUseCases]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUseCases](
	[RoleId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_RoleUseCases] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specifications]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Specifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.6.2024. 14:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240603064725_initial', N'8.0.4')
GO
SET IDENTITY_INSERT [dbo].[AuditLogs] ON 

INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (1, 0, N'Anonymous', N'Create initial data Command.', CAST(N'2024-06-03T06:56:39.4878541' AS DateTime2), 1, N'{"Brands":[{"Name":"Audi","Models":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"BMW","Models":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Porsche","Models":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Mercedes Benz","Models":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null}],"CarTypes":[{"Name":"Sedan","Cars":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Hatchback","Cars":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Coupe","Cars":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Convertible","Cars":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"SUV","Cars":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null}],"Specifications":[{"Name":"Engine Power","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Engine Displacement","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Maximum Torque","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Fuel Type","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Number of Gears","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Tire Dimensions","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Drive System","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Fuel Tank Capacity","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Vehicle Weight","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Seating Capacity","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Cargo Capacity","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Fuel Efficiency","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Safety Systems","Cars":null,"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null}],"Roles":[{"Name":"Admin","Users":[],"RoleUseCases":[{"RoleId":0,"UseCaseId":1,"Role":null},{"RoleId":0,"UseCaseId":2,"Role":null},{"RoleId":0,"UseCaseId":3,"Role":null},{"RoleId":0,"UseCaseId":4,"Role":null},{"RoleId":0,"UseCaseId":5,"Role":null},{"RoleId":0,"UseCaseId":6,"Role":null},{"RoleId":0,"UseCaseId":7,"Role":null},{"RoleId":0,"UseCaseId":10,"Role":null},{"RoleId":0,"UseCaseId":11,"Role":null},{"RoleId":0,"UseCaseId":12,"Role":null},{"RoleId":0,"UseCaseId":15,"Role":null},{"RoleId":0,"UseCaseId":16,"Role":null},{"RoleId":0,"UseCaseId":17,"Role":null},{"RoleId":0,"UseCaseId":19,"Role":null},{"RoleId":0,"UseCaseId":20,"Role":null},{"RoleId":0,"UseCaseId":21,"Role":null},{"RoleId":0,"UseCaseId":22,"Role":null},{"RoleId":0,"UseCaseId":23,"Role":null},{"RoleId":0,"UseCaseId":24,"Role":null},{"RoleId":0,"UseCaseId":25,"Role":null},{"RoleId":0,"UseCaseId":26,"Role":null},{"RoleId":0,"UseCaseId":27,"Role":null},{"RoleId":0,"UseCaseId":28,"Role":null},{"RoleId":0,"UseCaseId":29,"Role":null},{"RoleId":0,"UseCaseId":32,"Role":null},{"RoleId":0,"UseCaseId":33,"Role":null}],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"User","Users":[],"RoleUseCases":[{"RoleId":0,"UseCaseId":8,"Role":null},{"RoleId":0,"UseCaseId":9,"Role":null},{"RoleId":0,"UseCaseId":10,"Role":null},{"RoleId":0,"UseCaseId":13,"Role":null},{"RoleId":0,"UseCaseId":14,"Role":null},{"RoleId":0,"UseCaseId":17,"Role":null},{"RoleId":0,"UseCaseId":18,"Role":null},{"RoleId":0,"UseCaseId":20,"Role":null},{"RoleId":0,"UseCaseId":21,"Role":null},{"RoleId":0,"UseCaseId":23,"Role":null},{"RoleId":0,"UseCaseId":24,"Role":null},{"RoleId":0,"UseCaseId":25,"Role":null},{"RoleId":0,"UseCaseId":28,"Role":null},{"RoleId":0,"UseCaseId":30,"Role":null},{"RoleId":0,"UseCaseId":31,"Role":null}],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null}],"Users":null,"Accessories":[{"Name":"Navigation system with built-in regional map","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Bluetooth hands-free kit for safe phone calls while driving","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Child seat tailored to the age and size of the child","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Pet safety cage for transporting pets securely","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Roof racks for transporting bicycles, skis, or other sports equipment","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Parking assistance with sensors for easier vehicle maneuvering","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"In-car Wi-Fi hotspot for connectivity to the internet while driving","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Winter weather package including snow tires and a snow shovel","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Electric charging compartment for charging mobile devices and other electronics","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null},{"Name":"Additional insurance coverage for damage or theft protection for extra peace of mind during the rental","Bookings":[],"Id":0,"CreatedAt":"0001-01-01T00:00:00","UpdatedAt":null,"DeletedAt":null}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (2, 0, N'Anonymous', N'Create new User', CAST(N'2024-06-03T06:58:30.8290586' AS DateTime2), 1, N'{"FirstName":"Jane","LastName":"Doe","Email":"admin@example.com","UserName":"user","Password":"StrongP@ssw0rd"}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (3, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T06:59:54.9317891' AS DateTime2), 1, N'{"Name":"A4","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (4, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:00:03.5318149' AS DateTime2), 1, N'{"Name":"A4","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (5, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:00:27.6698462' AS DateTime2), 1, N'{"Name":"A6","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (6, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:00:39.2818519' AS DateTime2), 1, N'{"Name":"Q5","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (7, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:00:47.5750647' AS DateTime2), 1, N'{"Name":"Q7","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (8, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:00:53.2929130' AS DateTime2), 1, N'{"Name":"R8","BrandId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (9, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:01:22.7294434' AS DateTime2), 1, N'{"Name":"X6","BrandId":2}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (10, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:01:28.5433641' AS DateTime2), 1, N'{"Name":"M5","BrandId":2}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (11, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:01:34.6725852' AS DateTime2), 1, N'{"Name":"320d","BrandId":2}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (12, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:01:44.6621444' AS DateTime2), 1, N'{"Name":"911","BrandId":3}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (13, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:01:52.3319133' AS DateTime2), 1, N'{"Name":"Macan","BrandId":3}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (14, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:02:02.9932959' AS DateTime2), 1, N'{"Name":"CLS","BrandId":4}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (15, 1, N'admin@example.com', N'Create model Command.', CAST(N'2024-06-03T07:02:16.0521022' AS DateTime2), 1, N'{"Name":"GLE 300","BrandId":4}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (16, 1, N'admin@example.com', N'Get all models.', CAST(N'2024-06-03T07:02:25.2711788' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (17, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:03:03.5292933' AS DateTime2), 1, N'{"Kilometars":120000.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2022-01-01","ModelId":1,"TypeId":2,"PricePerDay":50.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (18, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:03:19.3447124' AS DateTime2), 1, N'{"Kilometars":20000.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2022-01-01","ModelId":2,"TypeId":2,"PricePerDay":50.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (19, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:03:34.5391110' AS DateTime2), 1, N'{"Kilometars":20000.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":3,"TypeId":1,"PricePerDay":50.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (20, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:03:44.5778899' AS DateTime2), 1, N'{"Kilometars":20000.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":4,"TypeId":1,"PricePerDay":50.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (21, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:03:57.4795747' AS DateTime2), 1, N'{"Kilometars":10.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":5,"TypeId":1,"PricePerDay":20.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (22, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:04:14.1637666' AS DateTime2), 1, N'{"Kilometars":10.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":6,"TypeId":1,"PricePerDay":20.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (23, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:04:27.5047218' AS DateTime2), 1, N'{"Kilometars":10.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":6,"TypeId":3,"PricePerDay":20.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (24, 1, N'admin@example.com', N'Get all cars.', CAST(N'2024-06-03T07:04:42.3177914' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (25, 1, N'admin@example.com', N'Find car by ID', CAST(N'2024-06-03T07:05:58.0647274' AS DateTime2), 1, N'1')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (26, 1, N'admin@example.com', N'Create car command', CAST(N'2024-06-03T07:06:16.7424274' AS DateTime2), 1, N'{"Kilometars":10.0,"ImagePath":"path/to/image.jpg","ManufacturerYear":"2020-01-01","ModelId":6,"TypeId":3,"PricePerDay":20.00,"CarSpecifications":[{"SpecificationId":1,"Value":"Automatic"},{"SpecificationId":2,"Value":"Petrol"}]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (27, 1, N'admin@example.com', N'Delete car command', CAST(N'2024-06-03T07:06:23.0724858' AS DateTime2), 1, N'8')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (28, 1, N'admin@example.com', N'Update car command', CAST(N'2024-06-03T07:06:35.4822673' AS DateTime2), 1, N'{"Id":1,"PricePerDay":30.0}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (29, 1, N'admin@example.com', N'Get all cars.', CAST(N'2024-06-03T07:06:44.6371499' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (30, 0, N'Anonymous', N'Create new User', CAST(N'2024-06-03T07:07:25.4258151' AS DateTime2), 1, N'{"FirstName":"John","LastName":"Doe","Email":"user@example.com","UserName":"user","Password":"StrongP@ssw0rd"}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (31, 0, N'Anonymous', N'Create new User', CAST(N'2024-06-03T07:29:32.2241961' AS DateTime2), 1, N'{"FirstName":"John","LastName":"Doe","Email":"user@example.com","UserName":"user","Password":"StrongP@ssw0rd"}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (32, 2, N'user@example.com', N'Create model Command.', CAST(N'2024-06-03T07:30:23.7092035' AS DateTime2), 0, N'{"Name":"GLE 300","BrandId":4}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (33, 2, N'user@example.com', N'Create booking command', CAST(N'2024-06-03T07:30:52.4723793' AS DateTime2), 1, N'{"FromDate":"2024-06-22","ToDate":"2024-07-10","CarId":1,"UserId":2,"CarAccessoryIds":[1,2,3,4]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (34, 2, N'user@example.com', N'Create booking command', CAST(N'2024-06-03T07:31:42.6664415' AS DateTime2), 1, N'{"FromDate":"2024-06-22","ToDate":"2024-07-10","CarId":1,"UserId":2,"CarAccessoryIds":[1,2,3,4]}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (35, 2, N'user@example.com', N'Get all bookings', CAST(N'2024-06-03T07:31:57.9869567' AS DateTime2), 0, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (36, 2, N'user@example.com', N'Get profile info of logged in user', CAST(N'2024-06-03T07:37:23.0928394' AS DateTime2), 1, N'{"Keyword":null}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (37, 1, N'admin@example.com', N'Get all bookings', CAST(N'2024-06-03T07:39:32.9388066' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (38, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:43:35.4328740' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (39, 2, N'user@example.com', N'Get profile info of logged in user', CAST(N'2024-06-03T07:44:45.9253655' AS DateTime2), 1, N'{"Keyword":null}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (40, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:45:29.0415540' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (41, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:45:58.9483253' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (42, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:46:16.0710782' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (43, 2, N'user@example.com', N'Get profile info of logged in user', CAST(N'2024-06-03T07:47:13.5999103' AS DateTime2), 1, N'{"Keyword":null}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (44, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:48:37.3668970' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (45, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:48:54.7089962' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (46, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:48:55.9085745' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (47, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:48:56.7522123' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (48, 0, N'Anonymous', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:48:57.8905823' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (49, 2, N'user@example.com', N'Get all Booking for logged in user', CAST(N'2024-06-03T07:54:18.0758830' AS DateTime2), 1, N'{"Keyword":null,"FromDate":null,"ToDate":null,"CarId":null,"UserIds":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (50, 1, N'admin@example.com', N'Complete booking command', CAST(N'2024-06-03T07:55:50.9765156' AS DateTime2), 1, N'{"Id":1,"Kilometars":140000.0}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (51, 1, N'admin@example.com', N'Get Audit Log information', CAST(N'2024-06-03T07:56:06.0019221' AS DateTime2), 1, N'{"Identity":null,"DateStart":null,"DateEnd":null,"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (52, 2, N'user@example.com', N'Create review for booked car', CAST(N'2024-06-03T07:58:46.5499134' AS DateTime2), 1, N'{"StarsRate":4.0,"Comment":"Great car, smooth ride!","UserId":2,"CarId":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (53, 2, N'user@example.com', N'Get all cars.', CAST(N'2024-06-03T07:59:00.7498961' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (54, 0, N'Anonymous', N'Create service command', CAST(N'2024-06-03T08:00:12.6577071' AS DateTime2), 1, N'{"ServiceName":"Regular Maintenance","Description":"Routine checkup and service","CarId":1,"FromDate":"2024-07-12","ToDate":"2024-07-15","ServiceType":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (55, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T08:01:57.4987510' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (56, 1, N'admin@example.com', N'Find service query', CAST(N'2024-06-03T08:02:11.7148604' AS DateTime2), 1, N'1')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (57, 0, N'Anonymous', N'Delete Service command', CAST(N'2024-06-03T08:02:23.3256667' AS DateTime2), 1, N'1')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (58, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T08:02:26.8150705' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (59, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:03:20.1250910' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (60, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:04:13.5756586' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (61, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:04:50.8713684' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (62, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:05:25.1212761' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (63, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:06:04.2760117' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (64, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:06:55.1649947' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (65, 0, N'Anonymous', N'Get all cars.', CAST(N'2024-06-03T08:07:04.0076657' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (66, 0, N'Anonymous', N'Get all models.', CAST(N'2024-06-03T08:07:41.1308037' AS DateTime2), 0, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (67, 0, N'Anonymous', N'Get all models.', CAST(N'2024-06-03T08:08:25.6842893' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (68, 0, N'Anonymous', N'Get all brands', CAST(N'2024-06-03T08:08:38.3041652' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (69, 0, N'Anonymous', N'Create service command', CAST(N'2024-06-03T09:34:52.3650552' AS DateTime2), 0, N'{"ServiceName":"Regular Maintenance","Description":"Routine checkup and service","CarId":1,"FromDate":"2024-07-12","ToDate":"2024-07-15","ServiceType":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (70, 1, N'admin@example.com', N'Create service command', CAST(N'2024-06-03T09:35:13.2571822' AS DateTime2), 1, N'{"ServiceName":"Regular Maintenance","Description":"Routine checkup and service","CarId":1,"FromDate":"2024-07-12","ToDate":"2024-07-15","ServiceType":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (71, 1, N'admin@example.com', N'Create service command', CAST(N'2024-06-03T09:35:37.0873996' AS DateTime2), 1, N'{"ServiceName":"Regular Maintenance","Description":"Routine checkup and service","CarId":1,"FromDate":"2024-07-12","ToDate":"2024-07-15","ServiceType":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (72, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T09:35:42.7701069' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (73, 1, N'admin@example.com', N'Find service query', CAST(N'2024-06-03T09:35:53.4279499' AS DateTime2), 1, N'2')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (74, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T09:36:45.9671746' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (75, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T09:37:20.6528262' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (76, 1, N'admin@example.com', N'Get all services query', CAST(N'2024-06-03T09:38:10.8802170' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (77, 1, N'admin@example.com', N'Get all cars.', CAST(N'2024-06-03T09:48:22.5575281' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":"price_asc","PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (78, 1, N'admin@example.com', N'Get all cars.', CAST(N'2024-06-03T09:48:38.6507123' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":"price_desc","PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (79, 0, N'/', N'Get all brands', CAST(N'2024-06-15T11:43:02.5882162' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (80, 0, N'/', N'Get all cars.', CAST(N'2024-06-15T11:47:44.1730745' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (81, 0, N'/', N'Get all brands', CAST(N'2024-06-15T11:47:55.5993120' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":null,"PerPage":15,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [UserId], [Identity], [UseCaseName], [ExecutionDateTime], [IsAuthorized], [Data]) VALUES (82, 0, N'/', N'Get all cars.', CAST(N'2024-06-15T11:50:11.4891495' AS DateTime2), 1, N'{"Keyword":null,"YearFrom":null,"YearTo":null,"VIN":null,"MoreThenKilometars":null,"LessTheKilometars":null,"CarType":null,"SortBy":null,"PerPage":15,"Page":1}')
SET IDENTITY_INSERT [dbo].[AuditLogs] OFF
GO
INSERT [dbo].[BookingCarAccessories] ([BookingId], [CarAccessoryId]) VALUES (1, 1)
INSERT [dbo].[BookingCarAccessories] ([BookingId], [CarAccessoryId]) VALUES (1, 2)
INSERT [dbo].[BookingCarAccessories] ([BookingId], [CarAccessoryId]) VALUES (1, 3)
INSERT [dbo].[BookingCarAccessories] ([BookingId], [CarAccessoryId]) VALUES (1, 4)
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [FromDate], [ToDate], [TotalPrice], [Status], [CarId], [UserId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, CAST(N'2024-06-22' AS Date), CAST(N'2024-07-10' AS Date), CAST(560.00 AS Decimal(18, 2)), N'Completed', 1, 2, CAST(N'2024-06-03T07:31:11.7666667' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Audi', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'BMW', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'Porsche', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Brands] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'Mercedes Benz', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarAccessories] ON 

INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Navigation system with built-in regional map', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Bluetooth hands-free kit for safe phone calls while driving', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'Child seat tailored to the age and size of the child', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'Pet safety cage for transporting pets securely', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, N'Roof racks for transporting bicycles, skis, or other sports equipment', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (6, N'Parking assistance with sensors for easier vehicle maneuvering', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (7, N'In-car Wi-Fi hotspot for connectivity to the internet while driving', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (8, N'Winter weather package including snow tires and a snow shovel', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (9, N'Electric charging compartment for charging mobile devices and other electronics', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarAccessories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (10, N'Additional insurance coverage for damage or theft protection for extra peace of mind during the rental', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CarAccessories] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, 140000, N'path/to/image.jpg', N'4a61f31d-5412-4a6a-b120-2c304f01045d', CAST(N'2022-01-01' AS Date), 1, 2, CAST(N'2024-06-03T07:03:03.6266667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, 20000, N'path/to/image.jpg', N'699b2aa0-5525-4f1f-89bf-0b91ef849ffc', CAST(N'2022-01-01' AS Date), 2, 2, CAST(N'2024-06-03T07:03:19.3666667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, 20000, N'path/to/image.jpg', N'bcfaec84-1d69-4b08-aed6-beaec51cd9ec', CAST(N'2020-01-01' AS Date), 3, 1, CAST(N'2024-06-03T07:03:34.5633333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, 20000, N'path/to/image.jpg', N'eb765f8b-a537-4bbd-b5c7-dc993c2b14f7', CAST(N'2020-01-01' AS Date), 4, 1, CAST(N'2024-06-03T07:03:44.6000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, 10, N'path/to/image.jpg', N'aa43748f-1a8e-41c3-8448-80e613016458', CAST(N'2020-01-01' AS Date), 5, 1, CAST(N'2024-06-03T07:03:57.5000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (6, 10, N'path/to/image.jpg', N'513126ad-d3ff-454b-8204-efa22c469b0d', CAST(N'2020-01-01' AS Date), 6, 1, CAST(N'2024-06-03T07:04:14.1833333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cars] ([Id], [Kilometars], [ImagePath], [VIN], [ManufacturerYear], [ModelId], [TypeId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (7, 10, N'path/to/image.jpg', N'9ff28057-eabd-4b5a-9415-8decaf59ab05', CAST(N'2020-01-01' AS Date), 6, 3, CAST(N'2024-06-03T07:04:27.5266667' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[CarServices] ON 

INSERT [dbo].[CarServices] ([Id], [ServiceName], [Description], [CarId], [FromDate], [ToDate], [ServiceType], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Regular Maintenance', N'Routine checkup and service', 1, CAST(N'2024-07-12' AS Date), CAST(N'2024-07-15' AS Date), 1, CAST(N'2024-06-03T09:35:38.2800000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CarServices] OFF
GO
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (1, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (1, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (2, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (2, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (3, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (3, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (4, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (4, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (5, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (5, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (6, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (6, 2, N'Petrol')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (7, 1, N'Automatic')
INSERT [dbo].[CarSpecifications] ([CarId], [SpecificationId], [Value]) VALUES (7, 2, N'Petrol')
GO
SET IDENTITY_INSERT [dbo].[CarTypes] ON 

INSERT [dbo].[CarTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Sedan', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Hatchback', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'Coupe', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'Convertible', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[CarTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, N'SUV', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CarTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Models] ON 

INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'A4', 1, CAST(N'2024-06-03T06:59:54.9766667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'A4', 1, CAST(N'2024-06-03T07:00:03.5500000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'A6', 1, CAST(N'2024-06-03T07:00:27.6800000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'Q5', 1, CAST(N'2024-06-03T07:00:39.2933333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, N'Q7', 1, CAST(N'2024-06-03T07:00:47.5900000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (6, N'R8', 1, CAST(N'2024-06-03T07:00:53.3066667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (7, N'X6', 2, CAST(N'2024-06-03T07:01:22.7433333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (8, N'M5', 2, CAST(N'2024-06-03T07:01:28.5533333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (9, N'320d', 2, CAST(N'2024-06-03T07:01:34.6866667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (10, N'911', 3, CAST(N'2024-06-03T07:01:44.6766667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (11, N'Macan', 3, CAST(N'2024-06-03T07:01:52.3500000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (12, N'CLS', 4, CAST(N'2024-06-03T07:02:03.0033333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Models] ([Id], [Name], [BrandId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (13, N'GLE 300', 4, CAST(N'2024-06-03T07:02:16.0633333' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Models] OFF
GO
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, CAST(50.00 AS Decimal(18, 2)), 1, CAST(N'2024-06-03T07:03:03.6500000' AS DateTime2), NULL, CAST(N'2024-06-03T07:06:35.5129791' AS DateTime2))
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, CAST(50.00 AS Decimal(18, 2)), 2, CAST(N'2024-06-03T07:03:19.3700000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, CAST(50.00 AS Decimal(18, 2)), 3, CAST(N'2024-06-03T07:03:34.5666667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, CAST(50.00 AS Decimal(18, 2)), 4, CAST(N'2024-06-03T07:03:44.6000000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, CAST(20.00 AS Decimal(18, 2)), 5, CAST(N'2024-06-03T07:03:57.5033333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (6, CAST(20.00 AS Decimal(18, 2)), 6, CAST(N'2024-06-03T07:04:14.1866667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (7, CAST(20.00 AS Decimal(18, 2)), 7, CAST(N'2024-06-03T07:04:27.5300000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Prices] ([Id], [PricePerDay], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (9, CAST(30.00 AS Decimal(18, 2)), 1, CAST(N'2024-06-03T07:06:35.5133333' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Prices] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [StarsRate], [Comment], [UserId], [CarId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, 4, N'Great car, smooth ride!', 2, 1, CAST(N'2024-06-03T07:58:46.7633333' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Admin', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'User', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 2)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 3)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 4)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 5)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 6)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 7)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 12)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 26)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 29)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 32)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 33)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 50)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 8)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 9)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 14)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 30)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 31)
GO
SET IDENTITY_INSERT [dbo].[Specifications] ON 

INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Engine Power', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Engine Displacement', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'Maximum Torque', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'Fuel Type', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (5, N'Number of Gears', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (6, N'Tire Dimensions', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (7, N'Drive System', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (8, N'Fuel Tank Capacity', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (9, N'Vehicle Weight', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (10, N'Seating Capacity', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (11, N'Cargo Capacity', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (12, N'Fuel Efficiency', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Specifications] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (13, N'Safety Systems', CAST(N'2024-06-03T06:56:41.0400000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Specifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [UserName], [Password], [RoleId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Jane', N'Doe', N'admin@example.com', N'admin', N'$2b$10$pUV8ni6hBomvqmNgqa4RBe/mGpPeGXKOmdzEjC.BYBV2iG0scatbi', 1, CAST(N'2024-06-03T06:58:31.6033333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [UserName], [Password], [RoleId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'John', N'Doe', N'user@example.com', N'user', N'$2b$10$FP/GnoHDjVUicZ5n2P1AsO/RY7clCWkhrM0FLIziE6XLEGma3D.p.', 2, CAST(N'2024-06-03T07:29:32.3066667' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Brands] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CarAccessories] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Cars] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CarServices] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CarTypes] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Models] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Prices] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Reviews] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Specifications] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BookingCarAccessories]  WITH CHECK ADD  CONSTRAINT [FK_BookingCarAccessories_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingCarAccessories] CHECK CONSTRAINT [FK_BookingCarAccessories_Bookings_BookingId]
GO
ALTER TABLE [dbo].[BookingCarAccessories]  WITH CHECK ADD  CONSTRAINT [FK_BookingCarAccessories_CarAccessories_CarAccessoryId] FOREIGN KEY([CarAccessoryId])
REFERENCES [dbo].[CarAccessories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingCarAccessories] CHECK CONSTRAINT [FK_BookingCarAccessories_CarAccessories_CarAccessoryId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Cars_CarId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users_UserId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[CarTypes] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarTypes_TypeId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Models_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Models_ModelId]
GO
ALTER TABLE [dbo].[CarServices]  WITH CHECK ADD  CONSTRAINT [FK_CarServices_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarServices] CHECK CONSTRAINT [FK_CarServices_Cars_CarId]
GO
ALTER TABLE [dbo].[CarSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_CarSpecifications_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarSpecifications] CHECK CONSTRAINT [FK_CarSpecifications_Cars_CarId]
GO
ALTER TABLE [dbo].[CarSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_CarSpecifications_Specifications_SpecificationId] FOREIGN KEY([SpecificationId])
REFERENCES [dbo].[Specifications] ([Id])
GO
ALTER TABLE [dbo].[CarSpecifications] CHECK CONSTRAINT [FK_CarSpecifications_Specifications_SpecificationId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Brands_BrandId]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Cars_CarId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Cars_CarId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users_UserId]
GO
ALTER TABLE [dbo].[RoleUseCases]  WITH CHECK ADD  CONSTRAINT [FK_RoleUseCases_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUseCases] CHECK CONSTRAINT [FK_RoleUseCases_Roles_RoleId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [rentaly] SET  READ_WRITE 
GO
