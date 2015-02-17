USE [RitualDB]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/17/2015 12:05:29 AM ******/
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
	[Salutation] [nchar](10) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Pin] [int] NOT NULL,
	[HomePhone] [nvarchar](50) NULL,
	[MobilePhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUserId] [nvarchar](128) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InitialAssessment]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InitialAssessment](
	[Id] [int] NOT NULL,
	[AssessmentDateTime] [datetime] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ClientCheckDetails] [nvarchar](max) NULL,
	[ClientHearAboutRitual] [nvarchar](255) NOT NULL,
	[ClientTrainingHistory] [nvarchar](max) NOT NULL,
	[ClientInjuriesMedicalIssues] [nvarchar](max) NOT NULL,
	[ClientPosturalArea] [nvarchar](255) NOT NULL,
	[ClientPosturalAreaDetails] [nvarchar](max) NOT NULL,
	[MovementAnteriorTrunk] [nchar](10) NOT NULL,
	[MovementPosteriorTrunk] [nchar](10) NOT NULL,
	[MovementHorizontalPush] [nchar](10) NOT NULL,
	[MovementVerticalPush] [nchar](10) NOT NULL,
	[MovementHorizontalPull] [nchar](10) NOT NULL,
	[MovementVerticalPull] [nchar](10) NOT NULL,
	[MovementHipPush] [nchar](10) NOT NULL,
	[MovementHipPull] [nchar](10) NOT NULL,
	[MovementSingleLeg] [nchar](10) NOT NULL,
	[MovementLocomotion1] [nchar](10) NOT NULL,
	[MovementLocamotion2] [nchar](10) NOT NULL,
	[MovementDetails] [nvarchar](max) NOT NULL,
	[Recommendation] [nvarchar](max) NOT NULL,
	[WorkoutExplained] [bit] NOT NULL,
	[WarmupExplained] [bit] NOT NULL,
	[ClientEmployeeReminder] [bit] NOT NULL,
	[AdditionalClientProgress] [nvarchar](max) NOT NULL,
	[AdditionalClientTips] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 2/17/2015 12:05:29 AM ******/
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
	[Currency] [nchar](10) NOT NULL,
	[AvailableSlots] [smallint] NOT NULL CONSTRAINT [DF_Location_AvailableSlots]  DEFAULT ((0)),
	[Longitude] [decimal](9, 6) NOT NULL,
	[Latitude] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentificationNumber] [nvarchar](50) NOT NULL,
	[EmailOptOut] [bit] NULL,
	[HomeLocationId] [int] NOT NULL,
	[AspNetUserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Membership]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Trial] [bit] NOT NULL,
	[MembershipStateId] [int] NOT NULL,
	[CancellationDate] [date] NULL,
	[Paid] [bit] NOT NULL,
	[InitialPaymentDate] [date] NULL,
	[InitialPayment] [decimal](19, 4) NULL,
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
/****** Object:  Table [dbo].[MembershipState]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[MembershipSuspensions]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipSuspensions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[News]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Body] [nvarchar](max) NULL,
	[NewsCategoryId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[ModifiedBy] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsCategories]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NewsCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpeningHour]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningHour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfWeek] [tinyint] NOT NULL,
	[OpenTime] [time](7) NOT NULL,
	[CloseTime] [time](7) NOT NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_OpeningHour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpeningHourOverride]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpeningHourOverride](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OverrideStartDate] [date] NOT NULL,
	[OverrideEndDate] [date] NOT NULL,
	[DayOfWeek] [tinyint] NOT NULL,
	[AltOpenTime] [time](7) NOT NULL,
	[AltCloseTme] [time](7) NOT NULL,
	[OverrideReason] [nvarchar](max) NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_OpeningHourOverride] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PackageTypeId] [int] NOT NULL,
	[PackagePeriodMonths] [int] NULL,
	[PackageSuspensionLimit] [int] NULL,
	[PackageVisitLimit] [int] NULL,
	[PackageIsActive] [bit] NOT NULL,
	[PackageIsReoccuring] [bit] NOT NULL,
	[PackagePayInFull] [bit] NOT NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PackageLocationPrices]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[PackageType]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PackageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuarterlyAssessment]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuarterlyAssessment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[SessionBooking]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[BookingStateId] [int] NOT NULL,
	[RPEFeeling] [int] NOT NULL,
	[RPEPush] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SessionBookingState]    Script Date: 2/17/2015 12:05:29 AM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 2/17/2015 12:05:29 AM ******/
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
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_AspNetUsers]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Location]
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
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_Member1] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_Member1]
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
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_AspNetUsersCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_AspNetUsersCreatedBy]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_AspNetUsersModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_AspNetUsersModifiedBy]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Location]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_NewsCategories] FOREIGN KEY([NewsCategoryId])
REFERENCES [dbo].[NewsCategories] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_NewsCategories]
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
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_PackageType] FOREIGN KEY([PackageTypeId])
REFERENCES [dbo].[PackageType] ([Id])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_PackageType]
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
ALTER TABLE [dbo].[QuarterlyAssessment]  WITH CHECK ADD  CONSTRAINT [FK_QuarterlyAssessment_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[QuarterlyAssessment] CHECK CONSTRAINT [FK_QuarterlyAssessment_Employee]
GO
ALTER TABLE [dbo].[QuarterlyAssessment]  WITH CHECK ADD  CONSTRAINT [FK_QuarterlyAssessment_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[QuarterlyAssessment] CHECK CONSTRAINT [FK_QuarterlyAssessment_Member]
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
/****** Object:  StoredProcedure [dbo].[GetImminentSessionBookings]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetImminentSessionBookings]

	@LocationId int, 
	@CurrentDateTime datetime

AS
BEGIN

	Declare @availableSlots int

	select @availableSlots = AvailableSlots from Location where Id = @LocationId;

	with Numbers_cte as (
    select 1 as Number
    union all
    select Number + 1
    from Numbers_cte
    where Number < @availableSlots)
,
 Session_CTE as (

	select 
		ROW_NUMBER() over (order by SessionBooking.id ) as RowNr,
		TimeSlot.Id as TimeSlotId,
		SessionBooking.id as SessionBookingId,
		SessionBookingState.Name as SessionBookingState,
		MemberId,
		Member.FirstName,
		Member.LastName
	from 
		SessionBooking
	join 
		TimeSlot
	on 
		SessionBooking.TimeSlotId = TimeSlot.Id
	join 
		Member 
	on 
		SessionBooking.MemberId = Member.Id
	join
		SessionBookingState
	on		
		SessionBookingState.Id = SessionBooking.BookingStateId
	where 
		SessionBooking.Date = CONVERT(date, @CurrentDateTime) and 
		TimeSlot.StartTime between CONVERT(time, @CurrentDateTime) and DATEADD(ss, 1799, CONVERT(time, @CurrentDateTime)) and	
		SessionBooking.LocationId = @LocationId and 
		(SessionBooking.BookingStateId = 1 or SessionBooking.BookingStateId = 3)
		)

	select * from Session_CTE right join Numbers_cte on Numbers_cte.Number = Session_CTE.RowNr
END


GO
/****** Object:  StoredProcedure [dbo].[GetNextBookingSlotsWindow]    Script Date: 2/17/2015 12:05:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Hirst
-- Create date: 30 Jan 2015
-- Description:	Get the booking slots over a period of days that are within opening hours
-- =============================================
CREATE PROCEDURE [dbo].[GetNextBookingSlotsWindow] 

	@LocationId int, 
	@CurrentDateTime datetime
AS
BEGIN

	declare @DayOne Date
	declare @DayTwo Date
	declare @DayThree Date
	set datefirst 1
	select @DayOne = CONVERT(date, @CurrentDateTime)
	select @DayTwo = DATEADD(DAY, 1, @DayOne)
	select @DayThree = DATEADD(DAY, 2, @DayOne)

	select 
		TimeSlot.Id as TimeSlotId,
		@LocationId as LocationId,
		BookingDays.BookingDay,
		datename(dw,BookingDays.WeekDay) as DayOfWeek,
		TimeSlot.StartTime, 
		TimeSlot.EndTime,
		(select count(id) from SessionBooking where LocationId = @LocationId and TimeSlotId = TimeSlot.Id and [Date] = BookingDays.BookingDay) as BookingCount,
		(select AvailableSlots from Location where Id = @LocationId) as AvailableSlots, Status = 
		CASE   
			WHEN OpeningHourOverride.LocationId is not null and 
			TimeSlot.StartTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme and 
			TimeSlot.EndTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme THEN 'Closed'
			ELSE 'Available'
		END ,ClosureReason = 
	   CASE   
			WHEN OpeningHourOverride.LocationId is not null and 
			TimeSlot.StartTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme and 
			TimeSlot.EndTime between OpeningHourOverride.AltOpenTime and OpeningHourOverride.AltCloseTme THEN OpeningHourOverride.OverrideReason
			ELSE ''
		END 
	from 
		TimeSlot, 
		(select @DayOne as BookingDay, DATEPART(dw, @DayOne) as WeekDay UNION ALL SELECT @DayTwo as BookingDay, DATEPART(dw, @DayTwo) as WeekDay UNION ALL SELECT @DayThree as BookingDay, DATEPART(dw, @DayThree) as WeekDay) as BookingDays

	join 
		OpeningHour 
	on 
		OpeningHour.[DateOfWeek] = BookingDays.WeekDay and
		OpeningHour.LocationId = @LocationId   
	left join 
		OpeningHourOverride 
	on 
		OpeningHourOverride.LocationId = @LocationId and
		BookingDays.BookingDay between OpeningHourOverride.OverrideStartDate and OpeningHourOverride.OverrideEndDate  
	where 
		TimeSlot.StartTime between OpeningHour.OpenTime and OpeningHour.CloseTime and 
		TimeSlot.EndTime between OpeningHour.OpenTime and OpeningHour.CloseTime 
	order by 
		BookingDays.BookingDay,
		TimeSlot.StartTime

END


GO
