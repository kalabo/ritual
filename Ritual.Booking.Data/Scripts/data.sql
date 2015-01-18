USE [RitualDB]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a7411bb5-74a9-473a-bde5-9877feb21ebe', N'Visitor')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f3cc4a6d-4fd4-46fc-a891-58541d428a15', N'Head Office')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f62987d0-ca94-4931-8c6d-8f46722a982d', N'Member')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f7494fe1-f5a7-40e0-aad5-8b319be66dc7', N'Trainer')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fbb32647-ba6c-4cce-9ddb-1dcc99ec8754', N'Franchise Owner')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2efa61fc-5922-47c4-ae38-ddb2fc864fe1', N'john.smith@hotmail.com', 0, N'AFllAVCCXsrUyzMN9VVVw1+pM4E8B/2jwx4M77NZXInoc3k3+J9n9sNsypdvePRpLg==', N'302bd25d-c74a-4052-aec1-64ae39b0eae4', NULL, 0, 0, NULL, 1, 0, N'john.smith@hotmail.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'cpettigrew@gmail.com', 0, N'APuabRRcdn8/PCXx0II8896ihBkN2OkKxi4fm2rPAy25hx+dlLu/6Xh2kOmKNYqFkg==', N'4d61b680-e9f0-4002-a3a2-f2aba3d5c4c5', NULL, 0, 0, NULL, 1, 0, N'cpettigrew@gmail.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf999c9b-d6f1-4600-a9aa-26a1f764d059', N'jane.doe@hotmail.com', 0, N'AHy95Q3PIs0Nrz9esMkdsbsvdQpnxpQCBm2DURLc6rTM7w7Nx0VnmbmV4RCVYy1eLg==', N'e5c202a1-bc2d-4ac9-abfc-04b5076fc8fe', NULL, 0, 0, NULL, 1, 0, N'jane.doe@hotmail.com')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'f3cc4a6d-4fd4-46fc-a891-58541d428a15')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'f62987d0-ca94-4931-8c6d-8f46722a982d')
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Coordinates]) VALUES (1, N'London', N'Trafalgar Square', N'0208 789 7890', N'SE1 1AA', N'UK', 0, NULL)
GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Coordinates]) VALUES (2, N'Ritual Singapore', N'11 North Canal Road', N'0065 6536 7291', N'048824', N'Singapore', 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainer] ON 

GO
INSERT [dbo].[Trainer] ([Id], [FirstName], [LastName], [AspNetUserId], [LocationId]) VALUES (1, N'Brad', N'Robinson', N'a6ce8231-8631-4494-9adb-bcb534321ab9', 1)
GO
SET IDENTITY_INSERT [dbo].[Trainer] OFF
GO
INSERT [dbo].[Member] ([Id], [Salutation], [FirstName], [LastName], [IdentificationNumber], [EmailOptOut], [Birthday], [HomePhone], [MobilePhone], [HomeLocationId], [AspNetUserId]) VALUES (N'1', N'Mr        ', N'Christopher', N'Pettigrew', N'member635568776623286683', 0, NULL, N'01256 841012', N'07812638995', 1, N'a6ce8231-8631-4494-9adb-bcb534321ab9')
GO
INSERT [dbo].[Member] ([Id], [Salutation], [FirstName], [LastName], [IdentificationNumber], [EmailOptOut], [Birthday], [HomePhone], [MobilePhone], [HomeLocationId], [AspNetUserId]) VALUES (N'2', N'Mr        ', N'John', N'Smith', N'member635572123147777882', NULL, NULL, NULL, NULL, 2, N'2efa61fc-5922-47c4-ae38-ddb2fc864fe1')
GO
INSERT [dbo].[Member] ([Id], [Salutation], [FirstName], [LastName], [IdentificationNumber], [EmailOptOut], [Birthday], [HomePhone], [MobilePhone], [HomeLocationId], [AspNetUserId]) VALUES (N'3', N'Miss      ', N'Jane', N'Doe', N'member635572123354126494', NULL, NULL, NULL, NULL, 1, N'cf999c9b-d6f1-4600-a9aa-26a1f764d059')
GO
SET IDENTITY_INSERT [dbo].[SessionBookingState] ON 

GO
INSERT [dbo].[SessionBookingState] ([Id], [Name]) VALUES (1, N'Pending')
GO
INSERT [dbo].[SessionBookingState] ([Id], [Name]) VALUES (2, N'Cancelled')
GO
INSERT [dbo].[SessionBookingState] ([Id], [Name]) VALUES (3, N'Checked-in')
GO
INSERT [dbo].[SessionBookingState] ([Id], [Name]) VALUES (4, N'Missed')
GO
SET IDENTITY_INSERT [dbo].[SessionBookingState] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (2, CAST(N'00:00:00' AS Time), CAST(N'00:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (3, CAST(N'00:30:00' AS Time), CAST(N'01:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (4, CAST(N'01:00:00' AS Time), CAST(N'01:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (5, CAST(N'01:30:00' AS Time), CAST(N'02:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (6, CAST(N'02:00:00' AS Time), CAST(N'02:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (7, CAST(N'02:30:00' AS Time), CAST(N'03:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (8, CAST(N'03:00:00' AS Time), CAST(N'03:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (9, CAST(N'03:30:00' AS Time), CAST(N'04:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (10, CAST(N'04:00:00' AS Time), CAST(N'04:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (11, CAST(N'04:30:00' AS Time), CAST(N'05:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (12, CAST(N'05:00:00' AS Time), CAST(N'05:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (13, CAST(N'05:30:00' AS Time), CAST(N'06:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (14, CAST(N'06:00:00' AS Time), CAST(N'06:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (15, CAST(N'06:30:00' AS Time), CAST(N'07:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (16, CAST(N'07:00:00' AS Time), CAST(N'07:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (17, CAST(N'07:30:00' AS Time), CAST(N'08:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (18, CAST(N'08:00:00' AS Time), CAST(N'08:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (19, CAST(N'08:30:00' AS Time), CAST(N'09:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (20, CAST(N'09:00:00' AS Time), CAST(N'09:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (21, CAST(N'09:30:00' AS Time), CAST(N'10:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (22, CAST(N'10:00:00' AS Time), CAST(N'10:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (23, CAST(N'10:30:00' AS Time), CAST(N'11:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (24, CAST(N'11:00:00' AS Time), CAST(N'11:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (25, CAST(N'11:30:00' AS Time), CAST(N'12:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (26, CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (27, CAST(N'12:30:00' AS Time), CAST(N'13:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (28, CAST(N'13:00:00' AS Time), CAST(N'13:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (29, CAST(N'13:30:00' AS Time), CAST(N'14:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (30, CAST(N'14:00:00' AS Time), CAST(N'14:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (31, CAST(N'14:30:00' AS Time), CAST(N'15:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (32, CAST(N'15:00:00' AS Time), CAST(N'15:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (33, CAST(N'15:30:00' AS Time), CAST(N'16:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (34, CAST(N'16:00:00' AS Time), CAST(N'16:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (35, CAST(N'16:30:00' AS Time), CAST(N'17:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (36, CAST(N'17:00:00' AS Time), CAST(N'17:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (37, CAST(N'17:30:00' AS Time), CAST(N'18:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (38, CAST(N'18:00:00' AS Time), CAST(N'18:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (39, CAST(N'18:30:00' AS Time), CAST(N'19:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (40, CAST(N'19:00:00' AS Time), CAST(N'19:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (41, CAST(N'19:30:00' AS Time), CAST(N'20:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (42, CAST(N'20:00:00' AS Time), CAST(N'20:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (43, CAST(N'20:30:00' AS Time), CAST(N'21:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (44, CAST(N'21:00:00' AS Time), CAST(N'21:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (45, CAST(N'21:30:00' AS Time), CAST(N'22:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (46, CAST(N'22:00:00' AS Time), CAST(N'22:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (47, CAST(N'22:30:00' AS Time), CAST(N'23:00:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (48, CAST(N'23:00:00' AS Time), CAST(N'23:30:00' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (49, CAST(N'23:30:00' AS Time), CAST(N'00:00:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
SET IDENTITY_INSERT [dbo].[OpeningHour] ON 

GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (1, 1, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (2, 2, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (3, 3, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (4, 4, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (5, 5, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (6, 6, CAST(N'09:00:00' AS Time), CAST(N'15:00:00' AS Time), 2)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (7, 1, CAST(N'07:00:00' AS Time), CAST(N'20:00:00' AS Time), 1)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (8, 2, CAST(N'07:00:00' AS Time), CAST(N'20:00:00' AS Time), 1)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (9, 3, CAST(N'07:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (10, 4, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (11, 5, CAST(N'06:30:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (12, 6, CAST(N'09:30:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
SET IDENTITY_INSERT [dbo].[OpeningHour] OFF
GO
SET IDENTITY_INSERT [dbo].[MembershipState] ON 

GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (1, N'Active')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (2, N'Closed')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (3, N'Expired')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (4, N'Free')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (5, N'Inactive')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (6, N'Suspend')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (7, N'Cancelled')
GO
INSERT [dbo].[MembershipState] ([Id], [Name]) VALUES (8, N'Void')
GO
SET IDENTITY_INSERT [dbo].[MembershipState] OFF
GO
SET IDENTITY_INSERT [dbo].[Package] ON 

GO
INSERT [dbo].[Package] ([Id], [Name], [PackageType], [PackagePeriodMonths], [PackagePricePerMonth], [PackageDiscountPercentage], [PackageDiscountAmmount], [PackagePriceAfterDiscount], [PackageTotalPrice], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive]) VALUES (1, N'Regular', N'Full Term', 12, 369.0000, NULL, NULL, NULL, 4428.0000, 2, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Package] OFF
GO
SET IDENTITY_INSERT [dbo].[QuarterlyAssessment] ON 

GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (2, N'1', 1, 2, 2014, CAST(N'2014-01-30 06:00:00.000' AS DateTime), 10, NULL, N'3', N'14', N'Sounds Great! Don''t you think?', NULL, N'2', N'10', N'Not Bad form, good effort.', NULL, N'3', N'4', N'Needs to increase strength', NULL, N'4', N'3min 40', N'Fantastic effort', NULL, N'2', N'12', N'Amazing', 4, 3, 6, 5, 4, 7, 6, 5, 40)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (3, N'1', 1, 1, 2015, CAST(N'2015-01-21 00:00:00.000' AS DateTime), 4, NULL, N'2', N'60 seconds', N'Fantastic Form!', NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (4, N'2', 1, 3, 2015, CAST(N'2015-01-18 21:12:00.000' AS DateTime), 4, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (5, N'3', 1, 1, 2014, CAST(N'2014-12-16 04:00:00.000' AS DateTime), 6, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (6, N'2', 1, 4, 2014, CAST(N'2014-10-14 07:22:00.000' AS DateTime), 8, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [TrainerId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (7, N'2', 1, 3, 2014, CAST(N'2014-07-15 09:00:00.000' AS DateTime), 7, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[QuarterlyAssessment] OFF
GO
