USE [aspnet-Húsüzem-6E56DABA-2692-454B-B6ED-7E03231CAF21]
GO

/****** Object: Table [dbo].[Husika] Script Date: 2022. 02. 24. 2:39:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Husika] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Terméknév]    NVARCHAR (MAX) NOT NULL,
    [Ár]           NVARCHAR (MAX) NOT NULL,
    [Alapanyag]    NVARCHAR (MAX) NOT NULL,
    [GyártásIdeje] NVARCHAR (MAX) NOT NULL
);


