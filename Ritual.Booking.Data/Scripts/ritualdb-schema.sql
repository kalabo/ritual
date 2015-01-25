USE [RitualDB]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](10) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[TimeZoneOffset] [smallint] NOT NULL,
	[Coordinates] [geography] NULL,
	[Currency] [nchar](10) NULL,
	[AvailableSlots] [smallint] NOT NULL CONSTRAINT [DF_Location_AvailableSlots]  DEFAULT ((0)),
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [nvarchar](50) NOT NULL,
	[Salutation] [nchar](10) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IdentificationNumber] [nvarchar](50) NOT NULL,
	[EmailOptOut] [bit] NULL,
	[Birthday] [date] NULL,
	[HomePhone] [nvarchar](50) NULL,
	[MobilePhone] [nvarchar](50) NULL,
	[HomeLocationId] [int] NOT NULL,
	[AspNetUserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Membership]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[PackageId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Trial] [bit] NOT NULL,
	[MembershipStateId] [int] NOT NULL,
	[CancellationDate] [date] NULL,
	[Paid] [bit] NOT NULL,
	[MonthlyPrice] [decimal](19, 4) NULL,
	[TotalPrice] [decimal](19, 4) NULL,
	[DiscountPercentage] [decimal](5, 2) NULL,
	[DiscountPrice] [decimal](19, 4) NULL,
	[DiscountReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MembershipState]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MembershipState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MembershipSuspensions]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipSuspensions](
	[Id] [int] NOT NULL,
	[MembershipId] [int] NOT NULL,
	[SuspensionStartDate] [date] NOT NULL,
	[SuspensionEndDate] [date] NOT NULL,
	[SuspensionReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_MembershipSuspensions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpeningHour]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningHour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfWeek] [tinyint] NOT NULL,
	[OpenTime] [time](7) NULL,
	[CloseTime] [time](7) NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_OpeningHour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpeningHourOverride]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningHourOverride](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OverrideStartDate] [date] NOT NULL,
	[OverrideEndDate] [date] NOT NULL,
	[DayOfWeek] [tinyint] NULL,
	[AltOpenTime] [time](7) NULL,
	[AltCloseTme] [time](7) NULL,
	[Closed] [bit] NULL,
	[OverrideReason] [nvarchar](max) NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_OpeningHourOverride] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PackageType] [nvarchar](50) NULL,
	[PackagePeriodMonths] [int] NULL,
	[PackageSuspensionLimit] [int] NULL,
	[PackageVisitLimit] [int] NULL,
	[PackageIsActive] [bit] NULL,
	[PackageIsReoccuring] [bit] NULL,
	[PackagePayInFull] [bit] NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PackageLocationPrices]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageLocationPrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[MonthlyPrice] [decimal](19, 4) NOT NULL,
	[TotalPrice] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_PackageLocationPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuarterlyAssessment]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuarterlyAssessment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[QAQuarter] [int] NOT NULL,
	[QAYear] [int] NULL,
	[QADateTime] [datetime] NULL,
	[QAClientRPE] [int] NULL,
	[QATestOneTitle] [nvarchar](max) NULL,
	[QATestOneType] [nvarchar](max) NULL,
	[QATestOneTimeReps] [nvarchar](max) NULL,
	[QATestOneNotes] [nvarchar](max) NULL,
	[QATestTwoTitle] [nvarchar](max) NULL,
	[QATestTwoType] [nvarchar](max) NULL,
	[QATestTwoTimeReps] [nvarchar](max) NULL,
	[QATestTwoNotes] [nvarchar](max) NULL,
	[QATestThreeTitle] [nvarchar](max) NULL,
	[QATestThreeType] [nvarchar](max) NULL,
	[QATestThreeTimeReps] [nvarchar](max) NULL,
	[QATestThreeNotes] [nvarchar](max) NULL,
	[QATestFourTitle] [nvarchar](max) NULL,
	[QATestFourType] [nvarchar](max) NULL,
	[QATestFourTimeReps] [nvarchar](max) NULL,
	[QATestFourNotes] [nvarchar](max) NULL,
	[QATestFiveTitle] [nvarchar](max) NULL,
	[QATestFiveType] [nvarchar](max) NULL,
	[QATestFiveTimeReps] [nvarchar](max) NULL,
	[QATestFiveNotes] [nvarchar](max) NULL,
	[QATestFiveRoundOneReps] [int] NULL,
	[QATestFiveRoundTwoReps] [int] NULL,
	[QATestFiveRoundThreeReps] [int] NULL,
	[QATestFiveRoundFourReps] [int] NULL,
	[QATestFiveRoundFiveReps] [int] NULL,
	[QATestFiveRoundSixReps] [int] NULL,
	[QATestFiveRoundSevenReps] [int] NULL,
	[QATestFiveRoundEightReps] [int] NULL,
	[QATestFiveTotalReps] [int] NULL,
 CONSTRAINT [PK_QuarterlyAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SessionBooking]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[BookingStateId] [int] NOT NULL,
	[RPEFeeling] [int] NOT NULL,
	[RPEPush] [int] NOT NULL,
	[TrainerNotes] [nvarchar](max) NULL,
	[TrainerId] [int] NOT NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SessionBookingState]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionBookingState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BookingState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 1/25/2015 12:38:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AspNetUserId] [nvarchar](128) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_AspNetUsers]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Location] FOREIGN KEY([HomeLocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Location]
GO
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_Member]
GO
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_MembershipState] FOREIGN KEY([MembershipStateId])
REFERENCES [dbo].[MembershipState] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_MembershipState]
GO
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_Package] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Package] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_Package]
GO
ALTER TABLE [dbo].[MembershipSuspensions]  WITH CHECK ADD  CONSTRAINT [FK_MembershipSuspensions_Membership] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Membership] ([Id])
GO
ALTER TABLE [dbo].[MembershipSuspensions] CHECK CONSTRAINT [FK_MembershipSuspensions_Membership]
GO
ALTER TABLE [dbo].[OpeningHour]  WITH CHECK ADD  CONSTRAINT [FK_OpeningHour_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[OpeningHour] CHECK CONSTRAINT [FK_OpeningHour_Location]
GO
ALTER TABLE [dbo].[OpeningHourOverride]  WITH CHECK ADD  CONSTRAINT [FK_OpeningHourOverride_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[OpeningHourOverride] CHECK CONSTRAINT [FK_OpeningHourOverride_Location]
GO
ALTER TABLE [dbo].[PackageLocationPrices]  WITH CHECK ADD  CONSTRAINT [FK_PackageLocationPrices_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[PackageLocationPrices] CHECK CONSTRAINT [FK_PackageLocationPrices_Location]
GO
ALTER TABLE [dbo].[PackageLocationPrices]  WITH CHECK ADD  CONSTRAINT [FK_PackageLocationPrices_Package] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Package] ([Id])
GO
ALTER TABLE [dbo].[PackageLocationPrices] CHECK CONSTRAINT [FK_PackageLocationPrices_Package]
GO
ALTER TABLE [dbo].[QuarterlyAssessment]  WITH CHECK ADD  CONSTRAINT [FK_QuarterlyAssessment_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[QuarterlyAssessment] CHECK CONSTRAINT [FK_QuarterlyAssessment_Member]
GO
ALTER TABLE [dbo].[QuarterlyAssessment]  WITH CHECK ADD  CONSTRAINT [FK_QuarterlyAssessment_Trainer] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainer] ([Id])
GO
ALTER TABLE [dbo].[QuarterlyAssessment] CHECK CONSTRAINT [FK_QuarterlyAssessment_Trainer]
GO
ALTER TABLE [dbo].[SessionBooking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_BookingState] FOREIGN KEY([BookingStateId])
REFERENCES [dbo].[SessionBookingState] ([Id])
GO
ALTER TABLE [dbo].[SessionBooking] CHECK CONSTRAINT [FK_Booking_BookingState]
GO
ALTER TABLE [dbo].[SessionBooking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[SessionBooking] CHECK CONSTRAINT [FK_Booking_Location]
GO
ALTER TABLE [dbo].[SessionBooking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[SessionBooking] CHECK CONSTRAINT [FK_Booking_Member]
GO
ALTER TABLE [dbo].[SessionBooking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_TimeSlot] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([Id])
GO
ALTER TABLE [dbo].[SessionBooking] CHECK CONSTRAINT [FK_Booking_TimeSlot]
GO
ALTER TABLE [dbo].[Trainer]  WITH CHECK ADD  CONSTRAINT [FK_Trainer_AspNetUsers1] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Trainer] CHECK CONSTRAINT [FK_Trainer_AspNetUsers1]
GO
ALTER TABLE [dbo].[Trainer]  WITH CHECK ADD  CONSTRAINT [FK_Trainer_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Trainer] CHECK CONSTRAINT [FK_Trainer_Location]
GO
ALTER TABLE [dbo].[Trainer]  WITH CHECK ADD  CONSTRAINT [FK_Trainer_Location1] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Trainer] CHECK CONSTRAINT [FK_Trainer_Location1]
GO
