USE [master]
GO
/****** Object:  Database [SnMes_KEY_SERVER]    Script Date: 2/18/2021 11:53:55 AM ******/
CREATE DATABASE [SnMes_KEY_SERVER]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SnMes_KEY_SERVER', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SnMes_KEY_SERVER.mdf' , SIZE = 1253376KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SnMes_KEY_SERVER_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SnMes_KEY_SERVER_log.ldf' , SIZE = 63184896KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SnMes_KEY_SERVER].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ARITHABORT OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET RECOVERY FULL 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET  MULTI_USER 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SnMes_KEY_SERVER', N'ON'
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET QUERY_STORE = OFF
GO
USE [SnMes_KEY_SERVER]
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
USE [SnMes_KEY_SERVER]
GO
/****** Object:  Table [dbo].[AttestationKeyDetails]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttestationKeyDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AttestationKeyRangeId] [int] NOT NULL,
	[StoreLocation] [nvarchar](100) NOT NULL,
	[AttestationKey] [nvarchar](50) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[WorkOrderId] [int] NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ProductId] [int] NULL,
	[isReserve] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttestationKeyRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttestationKeyRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RootPath] [nvarchar](max) NOT NULL,
	[Preffix] [nvarchar](50) NOT NULL,
	[AttestationKeyStart] [nvarchar](20) NOT NULL,
	[AttestationKeyEnd] [nvarchar](20) NOT NULL,
	[FileExtension] [nvarchar](max) NOT NULL,
	[FileQtyPerDirectory] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NULL,
	[UpdatedOn] [datetime] NULL,
	[PartNo] [varchar](30) NULL,
	[isGenerated] [smallint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMEIDetails]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMEIDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IMEIRangeId] [int] NOT NULL,
	[IMEI] [nvarchar](15) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[WorkOrderId] [int] NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ProductId] [int] NULL,
	[isReserve] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMEIRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMEIRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TacFac] [nvarchar](8) NOT NULL,
	[IMEIStart] [nvarchar](12) NOT NULL,
	[IMEIEnd] [nvarchar](12) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NULL,
	[UpdatedOn] [datetime] NULL,
	[PartNo] [nvarchar](30) NULL,
	[isGenerated] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyboxDetails]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyboxDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KeyboxRangeId] [int] NOT NULL,
	[StoreLocation] [nvarchar](100) NOT NULL,
	[Keybox] [nvarchar](50) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[WorkOrderId] [int] NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ProductId] [int] NULL,
	[isReserve] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyboxRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyboxRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RootPath] [nvarchar](max) NOT NULL,
	[Preffix] [nvarchar](50) NOT NULL,
	[KeyboxStart] [nvarchar](20) NOT NULL,
	[KeyboxEnd] [nvarchar](20) NOT NULL,
	[FileExtension] [nvarchar](max) NOT NULL,
	[FileQtyPerDirectory] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NULL,
	[UpdatedOn] [datetime] NULL,
	[PartNo] [varchar](30) NULL,
	[isGenerated] [smallint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyHistory]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISN] [varchar](50) NULL,
	[KEY_SERVER] [varchar](50) NULL,
	[VALUE] [varchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MACDetails]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MACDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MACRangeId] [int] NOT NULL,
	[MAC] [nvarchar](15) NOT NULL,
	[ProductId] [int] NULL,
	[IsUsed] [bit] NOT NULL,
	[WorkOrderId] [int] NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[isReserve] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MACRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MACRanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MACStart] [nvarchar](12) NOT NULL,
	[MACEnd] [nvarchar](12) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedBy] [nvarchar](32) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](32) NULL,
	[UpdatedOn] [datetime] NULL,
	[Remarks] [nvarchar](50) NULL,
	[PartNo] [nvarchar](30) NOT NULL,
	[isGenerated] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KeyHistory] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[sp_AttestationKeyRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure AttestationKey Ranges
-- =============================================
CREATE PROCEDURE [dbo].[sp_AttestationKeyRanges]

@action varchar(50)=null, @rootpath varchar(50)=null ,@preffix varchar(50)=null, @from varchar (50)=null,@end varchar (50)=null, @ext varchar(50)=null, @qtyperdir int=null, @qty int=null, @partno varchar (50)=null , @badge varchar (50)=null, @id int= null
AS 	
IF @action ='INSERT' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE TacFac = @tacfac)
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Alreaady exists !!!' as Error_Message	
		--END
		--ELSE
		--BEGIN
			insert into AttestationKeyRanges values(@rootpath,@preffix, @from,@end,@ext,@qtyperdir,@qty,@badge,GETDATE(),null,null,@partno,0)
			--insert into AttestationKeyRanges values('dummy','dummy', 'dummy','dummy','dummy',1,1,'dummy',GETDATE(),null,null,'dummy',0)
		--	select 'Success Insert Imei Ranges' as MESSAGE	
		--END   
	END
	
IF @action ='UPDATE' 
	BEGIN
		--IF EXISTS(SELECT Id FROM IMEIRanges  WHERE Id = @id and isGenerated=0)
		--BEGIN
			update AttestationKeyRanges set RootPath=@rootpath, Preffix=@preffix, AttestationKeyStart=@from,AttestationKeyEnd=@end,FileExtension=@ext,FileQtyPerDirectory=@qtyperdir, Quantity=@qty,UpdatedBy=@badge,UpdatedOn=GETDATE(),PartNo=@partno where Id=@id
		--	select 'Success Update Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Cannot Edit !!!' as Error_Message
		--END   
	END

IF @action ='DELETE' 
	BEGIN
		--IF EXISTS(SELECT TacFac FROM IMEIRanges  WHERE TacFac = @tacfac and isGenerated=0)
		--BEGIN
			delete from AttestationKeyRanges where Id=@id
		--	select 'Success Delete Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+ ' Cannot Delete or Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getById' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM AttestationKeyRanges  WHERE Id=@id
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getAll' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM AttestationKeyRanges
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_GenerateKeys]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Release
-- =============================================
CREATE PROCEDURE [dbo].[sp_GenerateKeys]

@action varchar(50)=null, @RangeId varchar(50)=null, @keyValue varchar(50)=null,@badge varchar(20)=null,@path varchar(max)=null,@storelocation varchar (max)=null,@Id int=0
AS 	
IF @action ='IMEI' 
	BEGIN
		insert into IMEIDetails values (@RangeId,@keyValue,0,null,@badge,GETDATE(),null,null)
	END

IF @action ='MAC' 
	BEGIN
		insert into MACDetails values (@RangeId,@keyValue,null,0,null,@badge,GETDATE(),null)
	END
	
IF @action ='KEYBOX' 
	BEGIN
		insert into KeyboxDetails values (@RangeId,@path,@keyValue,0,null,@badge,GETDATE(),null,null)
	END

IF @action ='AttestationKey' 
	BEGIN
		insert into AttestationKeyDetails values (@RangeId,@path,@keyValue,0,null,@badge,GETDATE(),null,null)
	END

IF @action ='UpdateImei' 
	BEGIN
		update IMEIRanges set isGenerated=1 where Id = @Id
	END

IF @action ='UpdateMac' 
	BEGIN
		update MACRanges set isGenerated=1 where Id = @Id
	END

IF @action ='UpdateKeybox' 
	BEGIN
		update KeyboxRanges set isGenerated=1 where Id = @Id
	END

IF @action ='UpdateAttestationKey' 
	BEGIN
		update AttestationKeyRanges set isGenerated=1 where Id = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttestationKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAttestationKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 
IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID and  IsUsed=1)    
		BEGIN   
			select top (@requiredQty) AttestationKey from AttestationKeyDetails a 
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))			
		END
ELSE
IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
	IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1)    
		BEGIN   
			select top (@requiredQty) AttestationKey from AttestationKeyDetails a 
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
			BEGIN
				WITH KeyAttestationKey as (
				select top (@requiredQty) AttestationKey ,ProductID,WorkOrderId,IsUsed  from AttestationKeyDetails a 
				inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
				where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
				)
				update KeyAttestationKey set ProductID =@ProductID 
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetImeiKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetImeiKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 	
IF EXISTS(SELECT * FROM IMEIDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID  and IsUsed=1)    
		BEGIN   
			select top (@requiredQty) IMEI from IMEIDetails a --WITH(NOLOCK)
			inner join IMEIRanges b on a.IMEIRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))			
		END
ELSE
IF EXISTS(SELECT * FROM IMEIDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
	IF EXISTS(SELECT * FROM IMEIDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1)    
		BEGIN 
		--BEGIN TRANSACTION  
			select top (@requiredQty) IMEI from IMEIDetails a WITH(NOLOCK)
			inner join IMEIRanges b on a.IMEIRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
			--OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			BEGIN
				WITH KeyImei as (
				select top (@requiredQty) IMEI ,ProductID,WorkOrderId,IsUsed  from IMEIDetails a --WITH(NOLOCK)
				inner join IMEIRanges b on a.IMEIRangeId=b.Id
				where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
				)
				update KeyImei set ProductID =@ProductID 
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		--COMMIT
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetKeyboxKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetKeyboxKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 
IF EXISTS(SELECT * FROM KEYBOXDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID and  IsUsed=1)    
		BEGIN   
			select top (@requiredQty) KEYBOX from KEYBOXDetails a 
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END
ELSE
IF EXISTS(SELECT * FROM KeyboxDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
	IF EXISTS(SELECT * FROM KEYBOXDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1)    
		BEGIN   
			select top (@requiredQty) KEYBOX from KEYBOXDetails a 
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
			BEGIN
				WITH KeyKeyBox as (
				select top (@requiredQty) KEYBOX ,ProductID,WorkOrderId,IsUsed  from KEYBOXDetails a 
				inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
				where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
				)
				update KeyKeyBox set ProductID =@ProductID 
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMacKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMacKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 
IF EXISTS(SELECT * FROM MACDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID and  IsUsed=1)    
		BEGIN   
			select top (@requiredQty) MAC from MACDetails a 
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END
ELSE
IF EXISTS(SELECT * FROM MACDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
	IF EXISTS(SELECT * FROM MACDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1)    
		BEGIN   
			select top (@requiredQty) MAC from MACDetails a 
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
			BEGIN
				WITH KeyMac as (
				select top (@requiredQty) MAC ,ProductID,WorkOrderId,IsUsed  from MACDetails a 
				inner join MACRanges b on a.MACRangeId=b.Id
				where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId is null and IsUsed=1
				)
				update KeyMac set ProductID =@ProductID 
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSingleAttestationKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSingleAttestationKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 	
IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select top (@requiredQty) AttestationKey from AttestationKeyDetails a --WITH(NOLOCK)
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END 
ELSE
IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
		BEGIN
			select top (@requiredQty) AttestationKey from AttestationKeyDetails a
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
		BEGIN
			WITH AttestationKey as (
			select top (@requiredQty) AttestationKey ,ProductID,WorkOrderId,IsUsed,isReserve ,a.CreatedOn from AttestationKeyDetails a --WITH(NOLOCK)
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0)
			update AttestationKey set ProductID =@ProductID ,WorkOrderId=@WorkOrderID , IsUsed =1,isReserve=0
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL')) 
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSingleImeiKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSingleImeiKey]    Script Date: 1/25/2021 2:52:00 PM ******/

-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSingleImeiKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 	
IF EXISTS(SELECT * FROM IMEIDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select top (@requiredQty) IMEI from IMEIDetails a 
			inner join IMEIRanges b on a.IMEIRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	order by IMEI
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END 
ELSE
IF EXISTS(SELECT * FROM IMEIDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
BEGIN
			--BEGIN TRANSACTION 
			--BEGIN
			select top (@requiredQty) IMEI from IMEIDetails a  --WITH (TABLOCK, HOLDLOCK)
			inner join IMEIRanges b on a.IMEIRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0 order by IMEI
			--OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))			
			BEGIN
				
				WITH KeyImei as (
				select top (@requiredQty) IMEI ,ProductID,WorkOrderId,IsUsed,isReserve ,a.CreatedOn from IMEIDetails a --WITH(NOLOCK)
				inner join IMEIRanges b on a.IMEIRangeId=b.Id
				where PartNo=@PartNo and IsUsed=0 order by IMEI)
				update KeyImei set ProductID =@ProductID ,WorkOrderId=@WorkOrderID , IsUsed =1 ,isReserve=0
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
			--END
		--COMMIT
  END 
  
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSingleKeybox]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSingleKeybox]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 	
IF EXISTS(SELECT * FROM KEYBOXDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select top (@requiredQty) KEYBOX from KEYBOXDetails a --WITH(NOLOCK)
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END 
ELSE
IF EXISTS(SELECT * FROM KeyboxDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
		BEGIN
			select top (@requiredQty) KEYBOX from KEYBOXDetails a
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
		BEGIN
			WITH Keybox as (
			select top (@requiredQty) KEYBOX ,ProductID,WorkOrderId,IsUsed,isReserve ,a.CreatedOn from KEYBOXDetails a --WITH(NOLOCK)
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0)
			update Keybox set ProductID =@ProductID ,WorkOrderId=@WorkOrderID , IsUsed =1 ,isReserve=0
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSingleMacKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--SET QUOTED_IDENTIFIER ON
--GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSingleMacKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50),@ProductID int
AS 	
--
IF EXISTS(SELECT * FROM MACDetails  WHERE WorkOrderId = @WorkOrderID and ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select top (@requiredQty) MAC from MACDetails a --WITH(NOLOCK)
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and WorkOrderId = @WorkOrderID and ProductId = @ProductID and IsUsed=1	
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))		
		END 
ELSE
IF EXISTS(SELECT * FROM MACDetails  WHERE ProductId=@ProductID  and IsUsed=1)    
		BEGIN 
			select 'this Product ID Alreaady Linked !' as Error_Message	
		END 
ELSE
		BEGIN
			--BEGIN TRANSACTION
			select top (@requiredQty) MAC from MACDetails a
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
			--OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		BEGIN
			WITH KeyMac as (
			select top (@requiredQty) MAC ,ProductID,WorkOrderId,IsUsed,isReserve ,a.CreatedOn from MACDetails a --WITH(NOLOCK)
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0)
			update KeyMac set ProductID =@ProductID ,WorkOrderId=@WorkOrderID , IsUsed =1,isReserve=0
			OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
		--COMMIT TRANSACTION
	END
	--
GO
/****** Object:  StoredProcedure [dbo].[sp_ImeiRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Imei Ranges
-- =============================================
CREATE PROCEDURE [dbo].[sp_ImeiRanges]

@action varchar(50)=null, @tacfac varchar(50)=null ,@from varchar (50)=null,@end varchar (50)=null, @qty int=null, @partno varchar (50)=null , @badge varchar (50)=null, @id int= null
AS 	
IF @action ='INSERT' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE TacFac = @tacfac)
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Alreaady exists !!!' as Error_Message	
		--END
		--ELSE
		--BEGIN
			insert into IMEIRanges values(@tacfac,@from,@end,@qty,@badge,GETDATE(),null,null,@partno,0)
		--	select 'Success Insert Imei Ranges' as MESSAGE	
		--END   
	END

IF @action ='UPDATE' 
	BEGIN
		--IF EXISTS(SELECT Id FROM IMEIRanges  WHERE Id = @id and isGenerated=0)
		--BEGIN
			update IMEIRanges set TacFac=@tacfac,IMEIStart=@from,IMEIEnd=@end,Quantity=@qty,UpdatedBy=@badge,UpdatedOn=GETDATE(),PartNo=@partno where Id=@id
		--	select 'Success Update Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Cannot Edit !!!' as Error_Message
		--END   
	END

IF @action ='DELETE' 
	BEGIN
		--IF EXISTS(SELECT TacFac FROM IMEIRanges  WHERE TacFac = @tacfac and isGenerated=0)
		--BEGIN
			delete from IMEIRanges where Id=@id
		--	select 'Success Delete Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+ ' Cannot Delete or Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getById' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM IMEIRanges  WHERE Id=@id
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getAll' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM IMEIRanges
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='VALIDATION'
	BEGIN
		select TacFac,IMEIStart,IMEIEnd from IMEIRanges where TacFac=@tacfac
	END

IF @action ='getByTacfac'
	BEGIN
		select TacFac,IMEIStart,IMEIEnd from IMEIRanges where TacFac=@tacfac
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_KeyboxRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Mac Ranges
-- =============================================
CREATE PROCEDURE [dbo].[sp_KeyboxRanges]

@action varchar(50)=null, @rootpath varchar(max)=null ,@preffix varchar(max)=null, @from varchar (50)=null,@end varchar (50)=null, @ext varchar(max)=null, @qtyperdir int=null, @qty int=null, @partno varchar (50)=null , @badge varchar (50)=null, @id int= null
AS 	
IF @action ='INSERT' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE TacFac = @tacfac)
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Alreaady exists !!!' as Error_Message	
		--END
		--ELSE
		--BEGIN
			insert into KeyboxRanges values(@rootpath,@preffix, @from,@end,@ext,@qtyperdir,@qty,@badge,GETDATE(),null,null,@partno,0)
		--	select 'Success Insert Imei Ranges' as MESSAGE	
		--END   
	END
	
IF @action ='UPDATE' 
	BEGIN
		--IF EXISTS(SELECT Id FROM IMEIRanges  WHERE Id = @id and isGenerated=0)
		--BEGIN
			update KeyboxRanges set RootPath=@rootpath, Preffix=@preffix, KeyboxStart=@from,KeyboxEnd=@end,FileExtension=@ext,FileQtyPerDirectory=@qtyperdir, Quantity=@qty,UpdatedBy=@badge,UpdatedOn=GETDATE(),PartNo=@partno where Id=@id
		--	select 'Success Update Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Cannot Edit !!!' as Error_Message
		--END   
	END

IF @action ='DELETE' 
	BEGIN
		--IF EXISTS(SELECT TacFac FROM IMEIRanges  WHERE TacFac = @tacfac and isGenerated=0)
		--BEGIN
			delete from KeyboxRanges where Id=@id
		--	select 'Success Delete Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+ ' Cannot Delete or Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getById' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM KeyboxRanges  WHERE Id=@id
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getAll' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM KeyboxRanges
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_MacRanges]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Mac Ranges
-- =============================================
CREATE PROCEDURE [dbo].[sp_MacRanges]

@action varchar(50)=null, @tacfac varchar(50)=null ,@from varchar (50)=null,@end varchar (50)=null, @qty int=null, @partno varchar (50)=null , @badge varchar (50)=null, @id int= null, @remarks varchar (100)=null
AS 	
IF @action ='INSERT' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE TacFac = @tacfac)
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Alreaady exists !!!' as Error_Message	
		--END
		--ELSE
		--BEGIN
			insert into MACRanges values(@from,@end,@qty,@badge,GETDATE(),null,null,@remarks,@partno,0)
		--	select 'Success Insert Imei Ranges' as MESSAGE	
		--END   
	END
	
IF @action ='UPDATE' 
	BEGIN
		--IF EXISTS(SELECT Id FROM IMEIRanges  WHERE Id = @id and isGenerated=0)
		--BEGIN
			update MACRanges set MACStart=@from,MACEnd=@end,Quantity=@qty,UpdatedBy=@badge,UpdatedOn=GETDATE(),remarks=@remarks,PartNo=@partno where Id=@id
		--	select 'Success Update Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+' Cannot Edit !!!' as Error_Message
		--END   
	END

IF @action ='DELETE' 
	BEGIN
		--IF EXISTS(SELECT TacFac FROM IMEIRanges  WHERE TacFac = @tacfac and isGenerated=0)
		--BEGIN
			delete from MACRanges where Id=@id
		--	select 'Success Delete Imei Ranges' as MESSAGE	
		--END
		--ELSE
		--BEGIN
		--	select 'this TACFAC : '+@tacfac+ ' Cannot Delete or Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getById' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM MACRanges  WHERE Id=@id
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='getAll' 
	BEGIN
		--IF EXISTS(SELECT * FROM IMEIRanges  WHERE Id=@id)
		--BEGIN
			SELECT * FROM MACRanges
		--END
		--ELSE
		--BEGIN
		--	select 'this ID : '+@id+ '  Not Found !!!' as Error_Message
		--END 
	END

IF @action ='VALIDATION'
	BEGIN
		select TacFac,IMEIStart,IMEIEnd from IMEIRanges where TacFac=@tacfac
	END

IF @action ='getByTacfac'
	BEGIN
		select TacFac,IMEIStart,IMEIEnd from IMEIRanges where TacFac=@tacfac
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_ReCompileIndex]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Recompile Index
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReCompileIndex]

AS 	
IF EXISTS (SELECT 1
            FROM sys.indexes I
                INNER JOIN sys.tables T
                    ON I.object_id = T.object_id
                INNER JOIN sys.schemas S
                    ON S.schema_id = T.schema_id
            WHERE I.Name = 'IX_ImeiDetails__Lookup '
                AND T.Name = 'ImeiDetails' 
                AND S.Name = 'dbo')
	BEGIN
		DROP INDEX IX_ImeiDetails__Lookup   
		ON imeidetails
		CREATE clustered INDEX IX_ImeiDetails__Lookup on IMEIDetails (productID, WorkOrderId, isused)
	END
IF EXISTS (SELECT 1
            FROM sys.indexes I
                INNER JOIN sys.tables T
                    ON I.object_id = T.object_id
                INNER JOIN sys.schemas S
                    ON S.schema_id = T.schema_id
            WHERE I.Name = 'IX_MacDetails__Lookup '
                AND T.Name = 'Macdetails'
                AND S.Name = 'dbo')
	BEGIN
		DROP INDEX IX_MacDetails__Lookup   
		ON Macdetails
		CREATE clustered INDEX IX_MacDetails__Lookup on Macdetails (productID, WorkOrderId, isused)
	END
IF EXISTS (SELECT 1
            FROM sys.indexes I
                INNER JOIN sys.tables T
                    ON I.object_id = T.object_id
                INNER JOIN sys.schemas S
                    ON S.schema_id = T.schema_id
            WHERE I.Name = 'IX_KeyboxDetails__Lookup '
                AND T.Name = 'KeyboxDetails'
                AND S.Name = 'dbo')
	BEGIN
		DROP INDEX IX_KeyboxDetails__Lookup   
		ON KeyboxDetails
		CREATE clustered INDEX IX_KeyboxDetails__Lookup on KeyboxDetails (productID, WorkOrderId, isused)
	END
IF EXISTS (SELECT 1
            FROM sys.indexes I
                INNER JOIN sys.tables T
                    ON I.object_id = T.object_id
                INNER JOIN sys.schemas S
                    ON S.schema_id = T.schema_id
            WHERE I.Name = 'IX_AttestationKeyDetails__Lookup '
                AND T.Name = 'AttestationKeyDetails'
                AND S.Name = 'dbo')
	BEGIN
		DROP INDEX IX_AttestationKeyDetails__Lookup   
		ON AttestationKeyDetails
		CREATE clustered INDEX IX_AttestationKeyDetails__Lookup on AttestationKeyDetails (productID, WorkOrderId, isused)
	END
BEGIN
	select 'Success Recompile INDEX to be Fastest... !!!' as MESSAGE
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Release]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure Release
-- =============================================
CREATE PROCEDURE [dbo].[sp_Release]

@action varchar(50)=null, @productId varchar(50)
AS 	
IF @action ='IMEI' 
	BEGIN
		IF EXISTS(SELECT * FROM IMEIDetails where ProductId=@productId and isReserve=1)
		BEGIN
		WITH KeyServer as (
				select * from IMEIDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	ELSE
		BEGIN
		WITH KeyServer as (
				select * from IMEIDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null , WorkOrderId=null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	END

IF @action ='MAC' 
	BEGIN
		IF EXISTS(SELECT * FROM MACDetails where ProductId=@productId and isReserve=1)
		BEGIN
		WITH KeyServer as (
				select * from MACDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	ELSE
		BEGIN
		WITH KeyServer as (
				select * from MACDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null , WorkOrderId=null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	END

IF @action ='KEYBOX' 
	BEGIN
		IF EXISTS(SELECT * FROM KeyboxDetails where ProductId=@productId and isReserve=1)
		BEGIN
		WITH KeyServer as (
				select * from KeyboxDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	ELSE
		BEGIN
		WITH KeyServer as (
				select * from KeyboxDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null , WorkOrderId=null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	END

IF @action ='AttestationKey' 
	BEGIN
		IF EXISTS(SELECT * FROM AttestationKeyDetails where ProductId=@productId and isReserve=1)
		BEGIN
		WITH KeyServer as (
				select * from AttestationKeyDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	ELSE
		BEGIN
		WITH KeyServer as (
				select * from AttestationKeyDetails where ProductId=@productId
				)
				update KeyServer set ProductID =null , WorkOrderId=null
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
		END
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_ReserveATTKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReserveATTKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50)
AS 
IF EXISTS(SELECT * FROM AttestationKeyDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and  IsUsed=1)  
			BEGIN
			select 'This Work Order ID is already Reserve Key' as ERROR_MESSAGE
			END
ELSE
		BEGIN
			select top (@requiredQty) AttestationKey from AttestationKeyDetails a --WITH(NOLOCK)
			inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
			BEGIN
				WITH AttestationKey as (
				select top (@requiredQty) AttestationKey ,ProductID,WorkOrderId,IsUsed,isReserve from AttestationKeyDetails a --WITH(NOLOCK)
				inner join AttestationKeyRanges b on a.AttestationKeyRangeId=b.Id
				where PartNo=@PartNo and IsUsed=0
				)
				update AttestationKey set WorkOrderId=@WorkOrderID , IsUsed =1 , isReserve=1
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReserveImeiKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReserveImeiKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50)
AS 
IF EXISTS(SELECT * FROM IMEIDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and  IsUsed=1)  
			BEGIN
			select 'This WoID is already Reserve Key' as ERROR_MESSAGE
			END
ELSE
		BEGIN
		--BEGIN TRANSACTION 
			select top (@requiredQty) IMEI from IMEIDetails a --WITH(NOLOCK)
			inner join IMEIRanges b on a.IMEIRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
			--OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			BEGIN
				WITH KeyImei as (
				select top (@requiredQty) IMEI ,ProductID,WorkOrderId,IsUsed,isReserve from IMEIDetails a-- WITH(NOLOCK)
				inner join IMEIRanges b on a.IMEIRangeId=b.Id
				where PartNo=@PartNo and IsUsed=0
				)
				update KeyImei set WorkOrderId=@WorkOrderID , IsUsed =1 , isReserve=1
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL')) 
			END
		--COMMIT
		END

GO
/****** Object:  StoredProcedure [dbo].[sp_ReserveKeybox]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReserveKeybox]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50)
AS 
IF EXISTS(SELECT * FROM KEYBOXDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and  IsUsed=1)  
			BEGIN
			select 'This Work Order ID is already Reserve Key' as ERROR_MESSAGE
			END
ELSE
		BEGIN
			select top (@requiredQty) KEYBOX from KEYBOXDetails a --WITH(NOLOCK)
			inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
			BEGIN
				WITH Keybox as (
				select top (@requiredQty) KEYBOX ,ProductID,WorkOrderId,IsUsed,isReserve from KEYBOXDetails a --WITH(NOLOCK)
				inner join KEYBOXRanges b on a.KEYBOXRangeId=b.Id
				where PartNo=@PartNo and IsUsed=0
				)
				update Keybox set WorkOrderId=@WorkOrderID , IsUsed =1 , isReserve=1
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReserveMacKey]    Script Date: 2/18/2021 11:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- strore procedure get key
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReserveMacKey]
@PartNo varchar(50), @requiredQty int ,@WorkOrderID varchar (50)
AS 
IF EXISTS(SELECT * FROM MACDetails  WHERE WorkOrderId = @WorkOrderID and ProductId is null and  IsUsed=1)  
			BEGIN
			select 'This Work Order ID is already Reserve Key' as ERROR_MESSAGE
			END
ELSE
		BEGIN
			select top (@requiredQty) MAC from MACDetails a WITH(NOLOCK)
			inner join MACRanges b on a.MACRangeId=b.Id
			where PartNo=@PartNo and IsUsed=0
			BEGIN
				WITH KeyMac as (
				select top (@requiredQty) MAC ,ProductID,WorkOrderId,IsUsed,isReserve from MACDetails a --WITH(NOLOCK)
				inner join MACRanges b on a.MACRangeId=b.Id
				where PartNo=@PartNo and IsUsed=0
				)
				update KeyMac set WorkOrderId=@WorkOrderID , IsUsed =1 , isReserve=1
				OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))
			END
		END

GO
USE [master]
GO
ALTER DATABASE [SnMes_KEY_SERVER] SET  READ_WRITE 
GO
