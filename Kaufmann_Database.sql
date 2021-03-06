USE [Kaufmann_FinalDB]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 5/12/2022 8:11:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverLicenseNumber] [varchar](13) NOT NULL,
	[FirstName] [varchar](10) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[SocialSecurity] [varchar](11) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverLicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infractions]    Script Date: 5/12/2022 8:11:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infractions](
	[InfractionID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleOwnerID] [int] NOT NULL,
	[Offence] [varchar](50) NOT NULL,
	[InfractionDate] [date] NOT NULL,
	[FineAmount] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Infractions] PRIMARY KEY CLUSTERED 
(
	[InfractionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/12/2022 8:11:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](10) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[FirstName] [varchar](10) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleOwner]    Script Date: 5/12/2022 8:11:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleOwner](
	[VehicleOwnerID] [int] IDENTITY(1,1) NOT NULL,
	[LicensePlateNumber] [varchar](6) NOT NULL,
	[DriverLicenseNumber] [varchar](13) NOT NULL,
	[TitleDateIssued] [date] NOT NULL,
 CONSTRAINT [PK_VehicleOwner] PRIMARY KEY CLUSTERED 
(
	[VehicleOwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 5/12/2022 8:11:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[LicensePlateNumber] [varchar](6) NOT NULL,
	[Model] [varchar](30) NOT NULL,
	[Make] [varchar](30) NOT NULL,
	[Year] [varchar](4) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[LicensePlateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M034485627313', N'Lily', N'Kunz', N'786-35-4395', CAST(N'2000-05-05' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M112233445566', N'John', N'Doe', N'123-45-6789', CAST(N'1996-05-25' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M114455667711', N'Jane', N'Doe', N'122-45-6789', CAST(N'1995-05-25' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M114485468543', N'Jan', N'Smith', N'343-23-2579', CAST(N'1989-02-20' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M160425677214', N'Jeffery', N'Anderson', N'658-98-3256', CAST(N'1979-03-05' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M213445657610', N'Joe', N'Rogan', N'358-78-7423', CAST(N'1980-12-14' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M213960487503', N'Mary', N'Rogan', N'913-78-3644', CAST(N'1980-12-14' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M379675224456', N'Din', N'Djarin', N'634-85-9456', CAST(N'1990-01-04' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M836463657617', N'May', N'Clark', N'894-36-8541', CAST(N'2000-05-05' AS Date))
INSERT [dbo].[Drivers] ([DriverLicenseNumber], [FirstName], [LastName], [SocialSecurity], [DateOfBirth]) VALUES (N'M876665627416', N'Billy', N'Mays', N'894-36-8541', CAST(N'1986-05-04' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Infractions] ON 

INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (1, 1, N'Speeding', CAST(N'2019-01-21' AS Date), CAST(200.50 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (2, 1, N'Ran through stop sign', CAST(N'2020-05-03' AS Date), CAST(300.50 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (3, 1, N'Speeding', CAST(N'2022-04-01' AS Date), CAST(300.50 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (4, 9, N'Speeding', CAST(N'2018-09-25' AS Date), CAST(300.50 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (5, 13, N'Ran stoplight', CAST(N'2022-03-30' AS Date), CAST(599.00 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (6, 4, N'Ran stoplight', CAST(N'2022-01-01' AS Date), CAST(599.00 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (7, 7, N'Using phone while driving', CAST(N'2021-08-07' AS Date), CAST(700.00 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (8, 2, N'Distracted driving', CAST(N'2022-03-15' AS Date), CAST(700.00 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (9, 8, N'Speeding', CAST(N'2022-03-15' AS Date), CAST(300.00 AS Decimal(8, 2)))
INSERT [dbo].[Infractions] ([InfractionID], [VehicleOwnerID], [Offence], [InfractionDate], [FineAmount]) VALUES (10, 8, N'Ran stoplight', CAST(N'2022-03-15' AS Date), CAST(500.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Infractions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (1, N'TSmith', N'Password123', N'Tim', N'Smith', N'Law Enforcement')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (2, N'JSmith', N'Password123', N'Jane', N'Smith', N'DMV Staff')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (3, N'CAnderson', N'Password123', N'Connor', N'Anderson', N'DMV Staff')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (4, N'MJane', N'Password123', N'Mary', N'Jane', N'Law Enforcement')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (5, N'JClark', N'Password123', N'Joe', N'Clark', N'Law Enforcement')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (6, N'PJackson', N'Password123', N'Percy', N'Jackson', N'DMV Staff')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (7, N'TStark', N'Password123', N'Tony', N'Stark', N'Law Enforcement')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (8, N'JGoldbloom', N'Password123', N'Jeff', N'Goldbloom', N'DMV Staff')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (9, N'BWayne', N'Password123', N'Bruce', N'Wayne', N'DMV Staff')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FirstName], [LastName], [Role]) VALUES (10, N'CKent', N'Password123', N'Clark', N'Kent', N'Law Enforcement')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleOwner] ON 

INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (1, N'ABC123', N'M112233445566', CAST(N'2022-05-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (2, N'DEF387', N'M112233445566', CAST(N'2012-05-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (3, N'DEF387', N'M114455667711', CAST(N'2012-05-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (4, N'JOP047', N'M114485468543', CAST(N'2016-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (5, N'ILF196', N'M160425677214', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (6, N'OLG156', N'M213445657610', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (7, N'OLG156', N'M213960487503', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (8, N'DMV036', N'M213445657610', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (9, N'DMV036', N'M213960487503', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (10, N'MLE731', N'M379675224456', CAST(N'2020-01-12' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (11, N'MEA015', N'M836463657617', CAST(N'2019-01-25' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (12, N'MES375', N'M836463657617', CAST(N'2019-01-25' AS Date))
INSERT [dbo].[VehicleOwner] ([VehicleOwnerID], [LicensePlateNumber], [DriverLicenseNumber], [TitleDateIssued]) VALUES (13, N'MWD638', N'M876665627416', CAST(N'2022-01-25' AS Date))
SET IDENTITY_INSERT [dbo].[VehicleOwner] OFF
GO
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'ABC123', N'Impala', N'Chevrolet', N'2013')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'DEF387', N'Silverado', N'Chevrolet', N'2010')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'DMV036', N'Mustang', N'Ford', N'2014')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'ILF196', N'Corolla', N'Toyota', N'2019')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'JOP047', N'Corolla', N'Toyota', N'2015')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'MEA015', N'Mustang', N'Ford', N'2019')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'MES375', N'Pacifica', N'Chevrolet', N'2019')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'MLE731', N'Mustang', N'Ford', N'2014')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'MWD638', N'Aventador', N'Lamborghini', N'2022')
INSERT [dbo].[Vehicles] ([LicensePlateNumber], [Model], [Make], [Year]) VALUES (N'OLG156', N'Malibu', N'Chevrolet', N'2014')
GO
ALTER TABLE [dbo].[Infractions]  WITH CHECK ADD  CONSTRAINT [FK_Infractions_Vehicles] FOREIGN KEY([VehicleOwnerID])
REFERENCES [dbo].[VehicleOwner] ([VehicleOwnerID])
GO
ALTER TABLE [dbo].[Infractions] CHECK CONSTRAINT [FK_Infractions_Vehicles]
GO
ALTER TABLE [dbo].[VehicleOwner]  WITH CHECK ADD  CONSTRAINT [FK_VehicleOwner_Drivers] FOREIGN KEY([DriverLicenseNumber])
REFERENCES [dbo].[Drivers] ([DriverLicenseNumber])
GO
ALTER TABLE [dbo].[VehicleOwner] CHECK CONSTRAINT [FK_VehicleOwner_Drivers]
GO
ALTER TABLE [dbo].[VehicleOwner]  WITH CHECK ADD  CONSTRAINT [FK_VehicleOwner_Vehicles] FOREIGN KEY([LicensePlateNumber])
REFERENCES [dbo].[Vehicles] ([LicensePlateNumber])
GO
ALTER TABLE [dbo].[VehicleOwner] CHECK CONSTRAINT [FK_VehicleOwner_Vehicles]
GO
