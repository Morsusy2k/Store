USE [master]
GO
/****** Object:  Database [DBStore]    Script Date: 1/7/2018 9:08:19 PM ******/
CREATE DATABASE [DBStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBStore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBStore] SET RECOVERY FULL 
GO
ALTER DATABASE [DBStore] SET  MULTI_USER 
GO
ALTER DATABASE [DBStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBStore', N'ON'
GO
ALTER DATABASE [DBStore] SET QUERY_STORE = OFF
GO
USE [DBStore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DBStore]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 1/7/2018 9:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Storage] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Message] [nvarchar](255) NOT NULL,
	[Ip] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Picture] [image] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Mark] [float] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Mark] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewAnswer]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReviewId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_ReviewAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Picture] [image] NULL,
	[Password] [nvarchar](254) NOT NULL,
	[LastLogin] [date] NOT NULL,
	[Activated] [bit] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHasRole]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHasRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserHasRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verification]    Script Date: 1/7/2018 9:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verification](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Verification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [Address], [Picture], [Password], [LastLogin], [Activated]) VALUES (1, N'Dragan', N'Ilic', N'morsy2k@gmail.com', N'061/300-1733', N'Josifa Pancica 33', NULL, N'sifra', CAST(N'2018-01-07' AS Date), 0)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [Address], [Picture], [Password], [LastLogin], [Activated]) VALUES (2, N'Milenko', N'Kosticko', N'milena@gmail.com', N'0615486445', N'PK', NULL, N'sifra', CAST(N'2018-01-07' AS Date), 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Activated]  DEFAULT ((0)) FOR [Activated]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_User]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_Article]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_User]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Mark_Article]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Mark_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Mark_User]
GO
ALTER TABLE [dbo].[ReviewAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ReviewAnswer_Review] FOREIGN KEY([ReviewId])
REFERENCES [dbo].[Review] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReviewAnswer] CHECK CONSTRAINT [FK_ReviewAnswer_Review]
GO
ALTER TABLE [dbo].[ReviewAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ReviewAnswer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ReviewAnswer] CHECK CONSTRAINT [FK_ReviewAnswer_User]
GO
ALTER TABLE [dbo].[UserHasRole]  WITH CHECK ADD  CONSTRAINT [FK_UserHasRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRole] CHECK CONSTRAINT [FK_UserHasRole_Role]
GO
ALTER TABLE [dbo].[UserHasRole]  WITH CHECK ADD  CONSTRAINT [FK_UserHasRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserHasRole] CHECK CONSTRAINT [FK_UserHasRole_User]
GO
ALTER TABLE [dbo].[Verification]  WITH CHECK ADD  CONSTRAINT [FK_Verification_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Verification] CHECK CONSTRAINT [FK_Verification_User]
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDelete]
@Id int
AS
DELETE FROM Role WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAll]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetAll]
AS
SELECT * FROM Role
GO
/****** Object:  StoredProcedure [dbo].[RoleGetById]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetById]
@Id int
AS
SELECT * FROM Role WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RoleInsert]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleInsert]
@Id int OUTPUT,
@Name nvarchar(20)
AS
INSERT INTO Role (Name) VALUES (@Name)
SET @Id = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdate]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleUpdate]
@Id int,
@Name nvarchar(20)
AS
UPDATE Role SET Name = @Name
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete]
@Id int,
@Version timestamp
AS
DELETE FROM dbo.[User] WHERE Id = @Id AND [Version] = @Version
GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetAll]
AS
SELECT * FROM dbo.[User]
GO
/****** Object:  StoredProcedure [dbo].[UserGetById]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetById]
@Id int
AS
SELECT * FROM dbo.[User] WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInsert]
@Id int OUTPUT,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@EmailAddress nvarchar(100),
@PhoneNumber nvarchar(15),
@Address nvarchar(100),
@Picture image = null,
@Password nvarchar(254),
@LastLogin date,
@Activated bit,
@Version timestamp OUTPUT
AS
BEGIN
INSERT INTO dbo.[User] (FirstName, LastName, EmailAddress, PhoneNumber, Address, Picture, Password, LastLogin, Activated)
VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @Address, @Picture, @Password, @LastLogin, @Activated)
SET @Id = SCOPE_IDENTITY()
SELECT @Version = [Version] FROM dbo.[User] WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 1/7/2018 9:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserUpdate]
@Id int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@EmailAddress nvarchar(100),
@PhoneNumber nvarchar(15),
@Address nvarchar(100),
@Picture image = null,
@Password nvarchar(254),
@LastLogin date,
@Activated bit,
@Version timestamp OUTPUT
AS
BEGIN
UPDATE dbo.[User] SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber,
Address = @Address, Picture = @Picture, Password = @Password, LastLogin = @LastLogin, Activated = @Activated
WHERE Id = @Id AND [Version] = @Version
SELECT @Version = [Version] FROM dbo.[User] WHERE Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [DBStore] SET  READ_WRITE 
GO
