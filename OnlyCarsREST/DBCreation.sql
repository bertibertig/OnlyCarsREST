CREATE DATABASE OnlyCars;

USE [OnlyCars]
GO

/****** Object: Table [dbo].[Car] Script Date: 19.06.2022 20:37:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Car] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [LicensePlate] VARCHAR (50) NULL
);
USE [OnlyCars]
GO

/****** Object: Table [dbo].[ParkingPlace] Script Date: 19.06.2022 20:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParkingPlace] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ParkingNumber] VARCHAR (50) NOT NULL,
    [Level]         INT          NOT NULL,
    [Ldx]           INT          NULL,
    [Ldy]           INT          NULL,
    [CarId]         INT          NULL,
    [Occupied]      INT          NOT NULL,
    [Urx]           INT          NULL,
    [Ury]           INT          NULL
);
