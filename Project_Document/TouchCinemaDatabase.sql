USE [master]
GO
/****** Object:  Database [TouchCinemaDatabase]    Script Date: 7/21/2018 3:17:55 PM ******/
CREATE DATABASE [TouchCinemaDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TouchCinemaDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TouchCinemaDatabase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TouchCinemaDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TouchCinemaDatabase_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TouchCinemaDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TouchCinemaDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TouchCinemaDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TouchCinemaDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TouchCinemaDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TouchCinemaDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TouchCinemaDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TouchCinemaDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [TouchCinemaDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TouchCinemaDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TouchCinemaDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TouchCinemaDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TouchCinemaDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TouchCinemaDatabase]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 7/21/2018 3:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](10) NULL,
	[firstName] [nvarchar](20) NULL,
	[lastName] [nvarchar](20) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genre]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[genreID] [int] NOT NULL,
	[genreName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[genreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
	[firstName] [nvarchar](20) NOT NULL,
	[lastName] [nvarchar](20) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[birthDate] [date] NOT NULL,
	[avatar] [nvarchar](max) NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movie]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[movieID] [nvarchar](20) NOT NULL,
	[movieTitle] [nvarchar](max) NOT NULL,
	[length] [int] NOT NULL,
	[rating] [float] NOT NULL,
	[startDate] [date] NOT NULL,
	[poster] [nvarchar](max) NULL,
	[linkTrailer] [nvarchar](max) NULL,
	[producer] [nvarchar](50) NOT NULL,
	[year] [int] NOT NULL,
	[genreID] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[orderID] [nchar](10) NOT NULL,
	[seat] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_OrderDetail_1] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC,
	[seat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderID] [nchar](10) NOT NULL,
	[scheduleID] [nvarchar](20) NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[username] [nvarchar](20) NULL,
	[phone] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[isCheckOut] [bit] NOT NULL,
 CONSTRAINT [PK_Order1] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Point]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Point](
	[username] [nvarchar](20) NOT NULL,
	[point] [int] NULL,
 CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[code] [nvarchar](8) NOT NULL,
	[name] [nvarchar](50) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomID] [int] NOT NULL,
	[numberOfSear] [int] NULL,
	[isAvailable] [bit] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[scheduleID] [nvarchar](20) NOT NULL,
	[date] [datetime] NOT NULL,
	[movieID] [nvarchar](20) NOT NULL,
	[roomID] [int] NOT NULL,
	[priceOfTicket] [float] NOT NULL,
 CONSTRAINT [PK_Schedule_1] PRIMARY KEY CLUSTERED 
(
	[scheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 7/21/2018 3:17:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](10) NULL,
	[firstName] [nvarchar](20) NULL,
	[lastName] [nvarchar](20) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](100) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Admin] ([username], [password], [firstName], [lastName], [phone], [email]) VALUES (N'datnd', N'123456', N'Nguyen', N'Dat', N'01627962333', N'datndse63093@gmail.com')
INSERT [dbo].[Admin] ([username], [password], [firstName], [lastName], [phone], [email]) VALUES (N'hieubt', N'234432', N'Bui', N'Hieu', N'0122456678', N'hieubt@gmail.com')
INSERT [dbo].[Admin] ([username], [password], [firstName], [lastName], [phone], [email]) VALUES (N'huylm', N'123123', N'Le', N'Huy', N'0986676840', N'huylmse629898@gmail.com')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (1, N'Action')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (2, N'Comedy')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (3, N'Romantic')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (7, N'Musician')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (8, N'Horror')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (9, N'Family')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (10, N'Cartoon')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (11, N'Fiction')
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'botibo', N'111', N'Nguyen', N'botibo', N'0123456789', N'botibo@gmail.com', CAST(N'1986-07-23' AS Date), N'~/Image/Avatar/aang1.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'hiennd', N'111', N'Nguyen Duy', N'Hien', N'0123456789', N'hien@gmail.com', CAST(N'1988-04-21' AS Date), N'~/Image/Avatar/greenhair.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'hoatt', N'111', N'Tran', N'Hoa', N'09760881278', N'hoa@gmail.com', CAST(N'1994-02-13' AS Date), N'~/Image/Avatar/greenhai1r.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'linhnt', N'111', N'Nguyen', N'Linh', N'01627962222', N'linhnt@gmail.com', CAST(N'1992-11-26' AS Date), N'~/Image/Avatar/greenhair.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'phuongnt', N'111', N'Nguyen', N'Phuong', N'01627962333', N'phuongnt@gmail.com', CAST(N'1996-01-07' AS Date), N'~/Image/Avatar/84463.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'thinhnd', N'111', N'Nguyen Duy', N'Thinh', N'0986676840', N'thinh@gmail.com', CAST(N'1971-05-20' AS Date), N'~/Image/Avatar/default-avatar.jpg', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'truongnm', N'12345', N'Nguyen', N'Truong', N'0986676840', N'truongnguyen@gmail.com', CAST(N'1990-08-18' AS Date), N'~/Image/Avatar/84463.jpg', 1)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'EGM', N'Em Gái Mưa', 119, 4.5, CAST(N'2018-06-01' AS Date), N'../Image/Poster/EmGaiMua.jpg', NULL, N'Viễn Đông', 2018, 3)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Hotel-tra1', N'Khách sạn huyền bí 1', 123, 8.7, CAST(N'2018-08-20' AS Date), N'../Image/Poster/hotel-transylvania.jpg', NULL, N'Sony', 2015, 10)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Hotel-tra2', N'Khách sạn Huyền bí 2', 145, 8, CAST(N'2018-08-20' AS Date), N'../Image/Poster/hotel-transylvania2.jpg', NULL, N'Sony', 2016, 10)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Hotel-tra3', N'Khách sạn Huyền bí 3', 150, 7.8, CAST(N'2018-08-20' AS Date), N'../Image/Poster/hotel-transylvania3.jpg', NULL, N'Sony', 2018, 10)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Jura-1', N'Jurasic park 1', 128, 9, CAST(N'2008-12-02' AS Date), N'../Image/Poster/jurassicPark1.jpg', NULL, N'Fox century', 2008, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Jura-2', N'Jurassic park 2', 134, 8.3, CAST(N'2018-06-15' AS Date), N'../Image/Poster/jurassicPark2.jpg', NULL, N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-1', N'Star War', 180, 8.7, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_1.jpg', NULL, N'Fox century', 2014, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-2', N'Star War 2', 180, 8.8, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_2.jpg', NULL, N'Fox century', 2016, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-3', N'Star War 3', 180, 8.8, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_3.jpg', NULL, N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Termi-1', N'Terminator', 180, 9.5, CAST(N'2018-07-31' AS Date), N'../Image/Poster/terminator_1.jpg', NULL, N'Fox century', 2018, 3)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Trans-1', N'Transformer', 180, 9, CAST(N'2018-07-31' AS Date), N'../Image/Poster/PosterNotAvailable(Default).jpg', NULL, N'Fox century', 2018, 2)
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'5T149KV8Q9', N'B2')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'AA8YDSTYZZ', N'B3')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'LMGDA5JX88', N'D5')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'order12345', N'A5')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'order12345', N'A6')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'order12345', N'A7')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'order12346', N'A3')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'order12346', N'A4')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'U0PSZKFEK7', N'A2')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'U0PSZKFEK7', N'B2')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'U0PSZKFEK7', N'B3')
INSERT [dbo].[OrderDetail] ([orderID], [seat]) VALUES (N'U0PSZKFEK7', N'C3')
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'5T149KV8Q9', N'Sche6', CAST(N'2018-07-20 22:21:19.487' AS DateTime), N'phuongnt', N'01627962333', N'phuongnt@gmail.com', 1)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'AA8YDSTYZZ', N'Sche1', CAST(N'2018-07-20 22:30:39.757' AS DateTime), N'phuongnt', N'01627962333', N'phuongnt@gmail.com', 0)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'LMGDA5JX88', N'Sche4', CAST(N'2018-07-20 22:08:35.233' AS DateTime), N'linhnt', N'01627962222', N'linhnt@gmail.com', 1)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'order12345', N'Sche1', CAST(N'2018-01-07 00:00:00.000' AS DateTime), N'linhnt', N'01627962333', N'linh4740@gmail.com', 1)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'order12346', N'Sche1', CAST(N'2018-07-16 00:00:00.000' AS DateTime), N'hiennd', N'0986676840', N'hien@gmail.com', 0)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'U0PSZKFEK7', N'Sche4', CAST(N'2018-07-20 22:04:41.010' AS DateTime), N'linhnt', N'01627962222', N'linhnt@gmail.com', 0)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'botibo', 0)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'hiennd', 100)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'hoatt', 0)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'linhnt', 123)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'phuongnt', 0)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'thinhnd', 0)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'truongnm', 0)
INSERT [dbo].[Promotion] ([code], [name], [active]) VALUES (N'pro1', N'Chiếc áo cho em', 1)
INSERT [dbo].[Promotion] ([code], [name], [active]) VALUES (N'pro2', N'Thứ 5 vui vẻ, giảm 50% giá vé', 1)
INSERT [dbo].[Promotion] ([code], [name], [active]) VALUES (N'pro3', N'Thành viên mới xem phim giá ưu đãi', 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (1, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (2, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (3, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (4, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (5, 40, 1)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche1', CAST(N'2018-08-02 07:30:00.000' AS DateTime), N'EGM', 1, 60)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche10', CAST(N'2018-08-08 21:00:00.000' AS DateTime), N'Staw-1', 2, 50)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche11', CAST(N'2018-08-08 23:00:00.000' AS DateTime), N'Staw-1', 4, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche12', CAST(N'2018-08-09 07:00:00.000' AS DateTime), N'Staw-2', 4, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche13', CAST(N'2018-08-09 12:00:00.000' AS DateTime), N'Staw-2', 1, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche14', CAST(N'2018-08-08 16:00:00.000' AS DateTime), N'Hotel-tra1', 1, 45)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche15', CAST(N'2018-08-08 16:00:00.000' AS DateTime), N'Hotel-tra2', 3, 50)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche16', CAST(N'2018-08-01 12:30:00.000' AS DateTime), N'Jura-2', 1, 50)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche17', CAST(N'2018-08-01 15:30:00.000' AS DateTime), N'Jura-2', 1, 50)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche2', CAST(N'2018-08-30 20:00:00.000' AS DateTime), N'EGM', 2, 70)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche3', CAST(N'2018-08-14 00:00:00.000' AS DateTime), N'EGM', 1, 60)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche4', CAST(N'2018-08-14 08:30:00.000' AS DateTime), N'Jura-1', 2, 80)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche5', CAST(N'2018-08-14 10:30:00.000' AS DateTime), N'Jura-1', 3, 45)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche6', CAST(N'2018-08-13 09:30:00.000' AS DateTime), N'StaW-1', 4, 60)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche7', CAST(N'2018-08-08 00:00:00.000' AS DateTime), N'Staw-2', 1, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche8', CAST(N'2018-08-08 14:00:00.000' AS DateTime), N'Staw-3', 4, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche9', CAST(N'2018-08-08 16:00:00.000' AS DateTime), N'Staw-3', 2, 45)
INSERT [dbo].[Staff] ([username], [password], [firstName], [lastName], [phone], [email], [isActive]) VALUES (N'baotd', N'111', N'Tran', N'Dinh Bao', N'09472392783', N'baotd@gmail.com', 0)
INSERT [dbo].[Staff] ([username], [password], [firstName], [lastName], [phone], [email], [isActive]) VALUES (N'khanhnt', N'111', N'Le', N'Dieu Khanh', N'0976088128', N'khanhlt@gmail.com', 1)
INSERT [dbo].[Staff] ([username], [password], [firstName], [lastName], [phone], [email], [isActive]) VALUES (N'minhlv', N'111', N'Le', N'Van Minh', N'0987654324', N'minhlv@gmail.com', 1)
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([genreID])
REFERENCES [dbo].[Genre] ([genreID])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([orderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([username])
REFERENCES [dbo].[Member] ([username])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[Point]  WITH CHECK ADD  CONSTRAINT [FK_Point_Member] FOREIGN KEY([username])
REFERENCES [dbo].[Member] ([username])
GO
ALTER TABLE [dbo].[Point] CHECK CONSTRAINT [FK_Point_Member]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Movie] FOREIGN KEY([movieID])
REFERENCES [dbo].[Movie] ([movieID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Movie]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Room] FOREIGN KEY([roomID])
REFERENCES [dbo].[Room] ([roomID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Room]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [CK_Movie] CHECK  (([rating]<=(10)))
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [CK_Movie]
GO
USE [master]
GO
ALTER DATABASE [TouchCinemaDatabase] SET  READ_WRITE 
GO
