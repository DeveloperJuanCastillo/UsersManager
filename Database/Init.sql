USE [master]
GO
/****** Object:  Database [UserManagement]    Script Date: 7/07/2025 6:40:55 a. m. ******/
CREATE DATABASE [UserManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\UserManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\UserManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [UserManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [UserManagement] SET  MULTI_USER 
GO
ALTER DATABASE [UserManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserManagement', N'ON'
GO
ALTER DATABASE [UserManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [UserManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UserManagement]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/07/2025 6:40:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Birthdate] [datetime] NOT NULL,
	[Gender] [nchar](1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Users_CRUD]    Script Date: 7/07/2025 6:40:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Users_CRUD]
    @Action     VARCHAR(10),
    @Id         INT = NULL,
    @Name       VARCHAR(100) = NULL,
    @Birthdate  DATETIME = NULL,
    @Gender     NCHAR(1) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
        IF @Name IS NULL OR @Birthdate IS NULL OR @Gender IS NULL
        BEGIN
            RAISERROR('Parámetros requeridos: @Name, @Birthdate, @Gender', 16, 1);
            RETURN;
        END

        INSERT INTO [dbo].[Users] ([Name], [Birthdate], [Gender])
        VALUES (@Name, @Birthdate, @Gender);

        SELECT SCOPE_IDENTITY() AS NewUserId;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @Id IS NULL
        BEGIN
            SELECT * FROM [dbo].[Users];
        END
        ELSE
        BEGIN
            SELECT * FROM [dbo].[Users] WHERE [Id] = @Id;
        END
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        IF @Id IS NULL OR @Name IS NULL OR @Birthdate IS NULL OR @Gender IS NULL
        BEGIN
            RAISERROR('Parámetros requeridos: @Id, @Name, @Birthdate, @Gender', 16, 1);
            RETURN;
        END

        UPDATE [dbo].[Users]
        SET [Name] = @Name,
            [Birthdate] = @Birthdate,
            [Gender] = @Gender
        WHERE [Id] = @Id;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No se encontró un usuario con el Id proporcionado.', 16, 1);
        END
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        IF @Id IS NULL
        BEGIN
            RAISERROR('Parámetro requerido: @Id', 16, 1);
            RETURN;
        END

        DELETE FROM [dbo].[Users] WHERE [Id] = @Id;

        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('No se encontró un usuario con el Id proporcionado.', 16, 1);
        END
    END

    ELSE
    BEGIN
        RAISERROR('Acción no válida. Use CREATE, READ, UPDATE o DELETE.', 16, 1);
    END
END



GO
USE [master]
GO
ALTER DATABASE [UserManagement] SET  READ_WRITE 
GO
