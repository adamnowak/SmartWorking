--Create user [smartworker] with password 'Belchatow12'
CREATE LOGIN [smartworker] WITH PASSWORD=N'Belchatow12', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

--add rolemember dbcreateor
EXEC sys.sp_addsrvrolemember @loginame = N'smartworker', @rolename = N'dbcreator'
GO

USE [master]
GO

--Create database
CREATE DATABASE [SmartWorking]
GO

ALTER DATABASE [SmartWorking] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartWorking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SmartWorking] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SmartWorking] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SmartWorking] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SmartWorking] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SmartWorking] SET ARITHABORT OFF 
GO

ALTER DATABASE [SmartWorking] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SmartWorking] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [SmartWorking] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SmartWorking] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SmartWorking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SmartWorking] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SmartWorking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SmartWorking] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SmartWorking] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SmartWorking] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SmartWorking] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SmartWorking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SmartWorking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SmartWorking] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SmartWorking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SmartWorking] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SmartWorking] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SmartWorking] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SmartWorking] SET  READ_WRITE 
GO

ALTER DATABASE [SmartWorking] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SmartWorking] SET  MULTI_USER 
GO

ALTER DATABASE [SmartWorking] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SmartWorking] SET DB_CHAINING OFF 
GO

--set SmartWorking as default database for test user
alter login [smartworker] with default_database = [SmartWorking]
GO

--switch to SmartWorking
USE [SmartWorking]
GO

--set owner for SmartWorking to smartworker user
EXEC sp_changedbowner 'smartworker'
GO