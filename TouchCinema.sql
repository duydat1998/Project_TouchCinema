USE [master]
GO
/****** Object:  Database [TouchCinemaDatabase]    Script Date: 17-Jul-18 8:22:12 PM ******/
CREATE DATABASE [TouchCinemaDatabase] ON  PRIMARY 
( NAME = N'TouchCinemaDatabase', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.HIEUBTSE62797\MSSQL\DATA\TouchCinemaDatabase.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TouchCinemaDatabase_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.HIEUBTSE62797\MSSQL\DATA\TouchCinemaDatabase_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TouchCinemaDatabase] SET COMPATIBILITY_LEVEL = 100
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
USE [TouchCinemaDatabase]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Genre]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Member]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Movie]    Script Date: 17-Jul-18 8:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[movieID] [nvarchar](20) NOT NULL,
	[movieTitle] [nvarchar](max) NULL,
	[length] [int] NULL,
	[rating] [float] NULL,
	[startDate] [date] NULL,
	[poster] [nvarchar](max) NULL,
	[linkTrailer] [nvarchar](max) NULL,
	[producer] [nvarchar](50) NULL,
	[year] [int] NULL,
	[genreID] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[movieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 17-Jul-18 8:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[detailID] [int] IDENTITY(1,1) NOT NULL,
	[orderID] [nchar](10) NOT NULL,
	[seat] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[detailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Point]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
/****** Object:  Table [dbo].[Schedule]    Script Date: 17-Jul-18 8:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[scheduleID] [nvarchar](20) NOT NULL,
	[date] [datetime] NULL,
	[movieID] [nvarchar](20) NULL,
	[roomID] [int] NULL,
	[priceOfTicket] [float] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[scheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 17-Jul-18 8:22:12 PM ******/
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
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (4, N'Only above 18')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (5, N'Only above 16')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (6, N'Only above 13')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (7, N'Musician')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (8, N'Horror')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (9, N'Family')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (10, N'Cartoon')
INSERT [dbo].[Genre] ([genreID], [genreName]) VALUES (11, N'Fiction')
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'linhnt', N'111', N'Nguyen ', N'Linh', N'01627962333', N'linhnt@gmail.com', CAST(N'1992-11-26' AS Date), N'linh.png', 1)
INSERT [dbo].[Member] ([username], [password], [firstName], [lastName], [phone], [email], [birthDate], [avatar], [isActive]) VALUES (N'phuongnt', N'111', N'Nguyen', N'Phuong', N'01627962333', N'phuongnt@gmail.com', CAST(N'1996-01-07' AS Date), N'phuong.jpeg', 1)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'EGM', N'Em Gái Mưa', 119, 4.5, CAST(N'2018-06-01' AS Date), N'../Image/Poster/EmGaiMua.jpg', N'AAA', N'Viễn Đông', 2018, 3)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Jura-1', N'Jurasic park 1', 128, 9, CAST(N'2008-12-02' AS Date), N'../Image/Poster/jurassicPark1.jpg', N'AAA', N'Fox century', 2008, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Jura-2', N'Jurassic park 2', 134, 8.3, CAST(N'2018-06-15' AS Date), N'../Image/Poster/jurassicPark2.jpg', N'AAA', N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-1', N'Star War', 180, 8.5, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_1.jpg', N'AAA', N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-2', N'Star War 2', 180, 8.7, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_2.jpg', N'AAA', N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'StaW-3', N'Star War 3', 180, 8.8, CAST(N'2018-07-31' AS Date), N'../Image/Poster/start_war_movie_3.jpg', N'AAA', N'Fox century', 2018, 11)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Termi-1', N'Terminator', 180, 9.5, CAST(N'2018-07-31' AS Date), N'../Image/Poster/terminator_1.jpg', N'AAA', N'Fox century', 2018, 3)
INSERT [dbo].[Movie] ([movieID], [movieTitle], [length], [rating], [startDate], [poster], [linkTrailer], [producer], [year], [genreID]) VALUES (N'Trans-1', N'Transformer', 180, 9, CAST(N'2018-07-31' AS Date), N'../Image/Poster/PosterNotAvailable(Default).jpg', N'AAA', N'Fox century', 2018, 2)
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([detailID], [orderID], [seat]) VALUES (1, N'order12345', N'A5')
INSERT [dbo].[OrderDetail] ([detailID], [orderID], [seat]) VALUES (2, N'order12345', N'A6')
INSERT [dbo].[OrderDetail] ([detailID], [orderID], [seat]) VALUES (3, N'order12345', N'A7')
INSERT [dbo].[OrderDetail] ([detailID], [orderID], [seat]) VALUES (4, N'order12346', N'A8')
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'order12345', N'Sche6', CAST(N'2018-01-07 00:00:00.000' AS DateTime), N'linhnt', N'01627962333', N'linh4740@gmail.com', 1)
INSERT [dbo].[Orders] ([orderID], [scheduleID], [orderDate], [username], [phone], [email], [isCheckOut]) VALUES (N'order12346', N'Sche6', CAST(N'2018-01-06 00:00:00.000' AS DateTime), N'linhnt', N'01627962333', N'linh4740@gmail.com', 1)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'linhnt', 123)
INSERT [dbo].[Point] ([username], [point]) VALUES (N'phuongnt', 0)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (1, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (2, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (3, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (4, 40, 1)
INSERT [dbo].[Room] ([roomID], [numberOfSear], [isAvailable]) VALUES (5, 40, 1)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche1', CAST(N'2018-07-02 07:30:00.000' AS DateTime), N'EGM', 1, 60)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche10', CAST(N'2018-08-08 21:00:00.000' AS DateTime), N'Staw-2', 1, 50)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche11', CAST(N'2018-08-08 23:00:00.000' AS DateTime), N'Staw-2', 1, 100)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche12', CAST(N'2018-08-09 07:00:00.000' AS DateTime), N'Staw-2', 1, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche13', CAST(N'2018-08-09 12:00:00.000' AS DateTime), N'Staw-2', 1, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche2', CAST(N'2018-02-02 04:00:00.000' AS DateTime), N'StaW-2', 2, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche3', CAST(N'2018-08-04 00:00:00.000' AS DateTime), N'StaW-2', 2, 25)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche4', CAST(N'2018-08-05 00:00:00.000' AS DateTime), N'StaW-2', 3, 30)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche5', CAST(N'2018-08-06 00:00:00.000' AS DateTime), N'StaW-2', 4, 35)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche6', CAST(N'2018-08-07 00:00:00.000' AS DateTime), N'StaW-3', 4, 30)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche7', CAST(N'2018-08-08 00:00:00.000' AS DateTime), N'Staw-2', 1, 30)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche8', CAST(N'2018-08-08 14:00:00.000' AS DateTime), N'Staw-2', 1, 20)
INSERT [dbo].[Schedule] ([scheduleID], [date], [movieID], [roomID], [priceOfTicket]) VALUES (N'Sche9', CAST(N'2018-08-08 16:00:00.000' AS DateTime), N'Staw-2', 1, 30)
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
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Schedule] FOREIGN KEY([scheduleID])
REFERENCES [dbo].[Schedule] ([scheduleID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Schedule]
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
