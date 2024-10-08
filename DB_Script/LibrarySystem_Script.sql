USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 27.09.2024 22:11:29 ******/
CREATE DATABASE [LibrarySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibrarySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LibrarySystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibrarySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LibrarySystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibrarySystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibrarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibrarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibrarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibrarySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibrarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibrarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibrarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibrarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibrarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibrarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibrarySystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibrarySystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibrarySystem] SET QUERY_STORE = OFF
GO
USE [LibrarySystem]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](128) NOT NULL,
	[author_surname] [nvarchar](128) NOT NULL,
	[log_create_user_id] [int] NOT NULL,
	[log_create_date] [datetime] NOT NULL,
	[log_update_user_id] [int] NULL,
	[log_update_date] [datetime] NULL,
	[log_delete_user_id] [int] NULL,
	[log_delete_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [nvarchar](256) NOT NULL,
	[book_price] [money] NOT NULL,
	[book_page] [int] NULL,
	[publishing_house_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
	[log_create_user_id] [int] NOT NULL,
	[log_create_date] [datetime] NOT NULL,
	[log_update_user_id] [int] NULL,
	[log_update_date] [datetime] NULL,
	[log_delete_user_id] [int] NULL,
	[log_delete_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublishingHouse]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishingHouse](
	[publishing_house_id] [int] IDENTITY(1,1) NOT NULL,
	[publishing_house_name] [nchar](256) NOT NULL,
	[publishing_house_address] [nchar](256) NULL,
	[log_create_user_id] [int] NOT NULL,
	[log_create_date] [datetime] NOT NULL,
	[log_update_user_id] [int] NULL,
	[log_update_date] [datetime] NULL,
	[log_delete_user_id] [int] NULL,
	[log_delete_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_PublishingHouse] PRIMARY KEY CLUSTERED 
(
	[publishing_house_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_GetBookInfo]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_GetBookInfo] AS
SELECT a.author_name + ' '+ a.author_surname As AuthorName, b.book_name as BookName, ph.publishing_house_name As PublishingHouseName, b.book_price As BookPrice, b.book_id As BookId 
	FROM Book b
		INNER JOIN Author a on a.author_id = b.author_id
		INNER JOIN PublishingHouse ph on ph.publishing_house_id = b.publishing_house_id
	WHERE b.log_delete_date is null AND b.log_delete_user_id is null  
		AND a.log_delete_date is null AND a.log_delete_user_id is null 
		AND ph.log_delete_date is null AND ph.log_delete_user_id is null 
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](128) NOT NULL,
	[surname] [nchar](128) NOT NULL,
	[email] [nvarchar](256) NOT NULL,
	[phone_number] [nvarchar](11) NULL,
	[password] [nvarchar](128) NOT NULL,
	[user_role_id] [int] NOT NULL,
	[log_create_user_id] [int] NOT NULL,
	[log_create_date] [datetime] NOT NULL,
	[log_update_user_id] [int] NULL,
	[log_update_date] [datetime] NULL,
	[log_delete_user_id] [int] NULL,
	[log_delete_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[user_role_id] [int] IDENTITY(1,1) NOT NULL,
	[user_role_name] [nvarchar](64) NOT NULL,
	[full_authority] [bit] NOT NULL,
	[log_create_user_id] [int] NOT NULL,
	[log_create_date] [datetime] NOT NULL,
	[log_update_user_id] [int] NULL,
	[log_update_date] [datetime] NULL,
	[log_delete_user_id] [int] NULL,
	[log_delete_date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[user_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([author_id], [author_name], [author_surname], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (1, N'Ahmet', N' Ümit', 0, CAST(N'2024-09-26T11:25:26.623' AS DateTime), 0, CAST(N'2024-09-26T12:25:56.563' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Author] ([author_id], [author_name], [author_surname], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (2, N'Elif', N'Şafak', 0, CAST(N'2024-09-26T12:07:48.000' AS DateTime), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([book_id], [book_name], [book_price], [book_page], [publishing_house_id], [author_id], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (2, N'Beyoğlu Rapsodisi', 285.0000, NULL, 1, 1, 0, CAST(N'2024-09-26T15:11:52.850' AS DateTime), 0, CAST(N'2024-09-27T21:34:19.723' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Book] ([book_id], [book_name], [book_price], [book_page], [publishing_house_id], [author_id], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (3, N'Deneme', 125.0000, NULL, 2, 2, 0, CAST(N'2024-09-26T15:39:05.510' AS DateTime), 0, CAST(N'2024-09-27T18:36:03.743' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[PublishingHouse] ON 

INSERT [dbo].[PublishingHouse] ([publishing_house_id], [publishing_house_name], [publishing_house_address], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (1, N'Türkiye İş Bankası Kültür Yayınları                                                                                                                                                                                                                             ', N'İstanbul                                                                                                                                                                                                                                                        ', 0, CAST(N'2024-09-26T11:16:42.543' AS DateTime), 0, CAST(N'2024-09-26T11:21:55.917' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[PublishingHouse] ([publishing_house_id], [publishing_house_name], [publishing_house_address], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (2, N'YapıKredi Yayınları                                                                                                                                                                                                                                             ', NULL, 0, CAST(N'2024-09-26T12:55:22.347' AS DateTime), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[PublishingHouse] ([publishing_house_id], [publishing_house_name], [publishing_house_address], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (3, N'Test Yayınları                                                                                                                                                                                                                                                  ', NULL, 0, CAST(N'2024-09-26T12:56:37.127' AS DateTime), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[PublishingHouse] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([user_id], [name], [surname], [email], [phone_number], [password], [user_role_id], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (3, N'Admin                                                                                                                           ', N'Admin Soyad                                                                                                                     ', N'admin@admin.com', NULL, N'Admin123*', 1, 0, CAST(N'2024-09-24T20:30:00.000' AS DateTime), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([user_role_id], [user_role_name], [full_authority], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (1, N'Admin', 1, 0, CAST(N'2024-09-23T20:30:00.000' AS DateTime), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserRole] ([user_role_id], [user_role_name], [full_authority], [log_create_user_id], [log_create_date], [log_update_user_id], [log_update_date], [log_delete_user_id], [log_delete_date], [active]) VALUES (2, N'Kullanıcı', 0, 0, CAST(N'2024-09-27T16:14:05.513' AS DateTime), NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_PublishingHouse] FOREIGN KEY([publishing_house_id])
REFERENCES [dbo].[PublishingHouse] ([publishing_house_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_PublishingHouse]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserInfo] FOREIGN KEY([user_role_id])
REFERENCES [dbo].[UserRole] ([user_role_id])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserInfo]
GO
/****** Object:  StoredProcedure [dbo].[P_GetFullBookInfo]    Script Date: 27.09.2024 22:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[P_GetFullBookInfo] 
AS
BEGIN

	SET NOCOUNT ON;
	SELECT a.author_name + ' '+ a.author_surname As AuthorName, b.book_name as BookName, ph.publishing_house_name As PublishingHouseName, b.book_price As BookPrice, b.book_id As BookId 
	FROM Book b
		INNER JOIN Author a on a.author_id = b.author_id
		INNER JOIN PublishingHouse ph on ph.publishing_house_id = b.publishing_house_id
	WHERE b.log_delete_date is null AND b.log_delete_user_id is null  
		AND a.log_delete_date is null AND a.log_delete_user_id is null 
		AND ph.log_delete_date is null AND ph.log_delete_user_id is null 
    ORDER BY a.author_name
END
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
