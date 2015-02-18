USE [RitualDB]
GO
SET IDENTITY_INSERT [dbo].[PackageType] ON 

GO
INSERT [dbo].[PackageType] ([Id], [Name]) VALUES (1, N'Trial')
GO
INSERT [dbo].[PackageType] ([Id], [Name]) VALUES (2, N'Standard')
GO
INSERT [dbo].[PackageType] ([Id], [Name]) VALUES (3, N'Off Peak')
GO
SET IDENTITY_INSERT [dbo].[PackageType] OFF
GO
SET IDENTITY_INSERT [dbo].[Package] ON 

GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (1, N'1 Month Off Peak Membership - Paid In Full', 3, 1, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (2, N'1 Month Standard Membership - Paid In Full', 2, 1, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (3, N'3 Months Off Peak Membership - Paid In Full', 3, 3, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (4, N'3 Months Off Peak Membership - Monthly Recurring', 3, 3, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (5, N'3 Months Standard Membership - Paid In Full', 2, 3, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (6, N'3 Months Standard Membership - Monthly Recurring', 2, 3, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (7, N'6 Months Off Peak Membership - Monthly Recurring', 3, 6, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (8, N'6 Months Off Peak Membership - Paid In Full', 3, 6, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (9, N'6 Months Standard Membership - Monthly Recurring', 2, 6, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (10, N'6 Months Standard Membership - Paid In Full', 2, 6, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (11, N'12 Months Off Peak Membership - Monthly Recurring', 3, 12, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (12, N'12 Months Off Peak Membership - Paid In Full', 3, 12, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (13, N'12 Months Standard Membership - Monthly Recurring', 2, 12, 2, NULL, 1, 1, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (14, N'12 Months Standard Membership - Paid In Full', 2, 12, 2, NULL, 1, 0, 1)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (15, N'10 Sessions Standard Membership - Paid In Full', 2, 12, 0, 10, 1, 0, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (16, N'20 Sessions Standard Membership - Paid In Full', 2, 12, 0, 20, 1, 0, 0)
GO
INSERT [dbo].[Package] ([Id], [Name], [PackageTypeId], [PackagePeriodMonths], [PackageSuspensionLimit], [PackageVisitLimit], [PackageIsActive], [PackageIsReoccuring], [PackagePayInFull]) VALUES (17, N'1 Week Trial Membership - Paid In Full', 1, NULL, 0, NULL, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Package] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0702FA47-C6F6-4C93-ABA1-49400959ACBC', N'Administrator')
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
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Salutation], [FirstName], [LastName], [Pin], [HomePhone], [MobilePhone]) VALUES (N'43dd3cc0-9d7f-418b-8abe-1d4ff27afb59', N'trial@user.com', 0, N'ALnG3JjpbFCpyJe7VFb+7KEWvlDrtvNjGTWO8TdmyUsr1O9h+yJP0tNVPgtAXP/DMg==', N'e8db9f6f-83ed-42c3-bcb3-a77275079055', NULL, 0, 0, NULL, 1, 0, N'trial@user.com', N'Mr        ', N'Trial', N'User', 12345, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Salutation], [FirstName], [LastName], [Pin], [HomePhone], [MobilePhone]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'cpettigrew@gmail.com', 0, N'APuabRRcdn8/PCXx0II8896ihBkN2OkKxi4fm2rPAy25hx+dlLu/6Xh2kOmKNYqFkg==', N'4d61b680-e9f0-4002-a3a2-f2aba3d5c4c5', NULL, 0, 0, NULL, 1, 0, N'cpettigrew@gmail.com', N'Mr        ', N'Christopher', N'Pettigrew', 123456, NULL, NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43dd3cc0-9d7f-418b-8abe-1d4ff27afb59', N'f62987d0-ca94-4931-8c6d-8f46722a982d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'0702FA47-C6F6-4C93-ABA1-49400959ACBC')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'f3cc4a6d-4fd4-46fc-a891-58541d428a15')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'f62987d0-ca94-4931-8c6d-8f46722a982d')
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
SET IDENTITY_INSERT [dbo].[Location] ON 

GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Currency], [AvailableSlots], [Longitude], [Latitude]) VALUES (1, N'London - Oxford Street', N'270 Oxford Street, London', N'0208 789 7890', N'W1C 1DT', N'UK', 0, N'GBP       ', 12, CAST(-0.144119 AS Decimal(9, 6)), CAST(51.515293 AS Decimal(9, 6)))
GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Currency], [AvailableSlots], [Longitude], [Latitude]) VALUES (2, N'Singapore', N'11 North Canal Road, Singapore', N'0065 6536 7291', N'048824', N'Singapore', 8, N'SGD       ', 10, CAST(103.848740 AS Decimal(9, 6)), CAST(1.286026 AS Decimal(9, 6)))
GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Currency], [AvailableSlots], [Longitude], [Latitude]) VALUES (3, N'San Fransisco', N'1000 Van Ness, 1000 Van Ness Avenue', N'+1 415-926-6790', N'94109', N'USA', -8, N'USD       ', 12, CAST(-122.470683 AS Decimal(9, 6)), CAST(37.775043 AS Decimal(9, 6)))
GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Currency], [AvailableSlots], [Longitude], [Latitude]) VALUES (4, N'Los Angeles', N'1123 Vine Street #14', N'323-461-4170', N'90038', N'USA', -8, N'USD       ', 10, CAST(-118.327037 AS Decimal(9, 6)), CAST(34.091627 AS Decimal(9, 6)))
GO
INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Currency], [AvailableSlots], [Longitude], [Latitude]) VALUES (5, N'Hong Kong', N'Hysan Place 500 Hennessy Road, East Point', N'852 2886 7222', N'n/a', N'Hong Kong', 7, N'HKD       ', 14, CAST(114.183755 AS Decimal(9, 6)), CAST(22.279825 AS Decimal(9, 6)))
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

GO
INSERT [dbo].[Member] ([Id], [IdentificationNumber], [EmailOptOut], [HomeLocationId], [AspNetUserId]) VALUES (1, N'member635568776623286683', 0, 2, N'a6ce8231-8631-4494-9adb-bcb534321ab9')
GO
INSERT [dbo].[Member] ([Id], [IdentificationNumber], [EmailOptOut], [HomeLocationId], [AspNetUserId]) VALUES (7, N'member635592969018760237', NULL, 1, N'43dd3cc0-9d7f-418b-8abe-1d4ff27afb59')
GO
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[Membership] ON 

GO
INSERT [dbo].[Membership] ([Id], [MemberId], [PackageId], [StartDate], [EndDate], [Trial], [MembershipStateId], [CancellationDate], [Paid], [InitialPaymentDate], [InitialPayment], [MonthlyPrice], [TotalPrice], [DiscountPercentage], [DiscountPrice], [DiscountReason]) VALUES (3, 1, 17, CAST(N'2015-01-02' AS Date), CAST(N'2015-01-08' AS Date), 1, 3, NULL, 1, CAST(N'2015-01-02' AS Date), CAST(50.0000 AS Decimal(19, 4)), NULL, CAST(50.0000 AS Decimal(19, 4)), NULL, NULL, NULL)
GO
INSERT [dbo].[Membership] ([Id], [MemberId], [PackageId], [StartDate], [EndDate], [Trial], [MembershipStateId], [CancellationDate], [Paid], [InitialPaymentDate], [InitialPayment], [MonthlyPrice], [TotalPrice], [DiscountPercentage], [DiscountPrice], [DiscountReason]) VALUES (4, 1, 14, CAST(N'2015-01-09' AS Date), CAST(N'2016-01-09' AS Date), 0, 1, NULL, 1, CAST(N'2015-01-09' AS Date), CAST(3229.2000 AS Decimal(19, 4)), CAST(269.1000 AS Decimal(19, 4)), CAST(3229.2000 AS Decimal(19, 4)), CAST(10.00 AS Decimal(5, 2)), CAST(322.9200 AS Decimal(19, 4)), N'Paid In Full')
GO
SET IDENTITY_INSERT [dbo].[Membership] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageLocationPrices] ON 

GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (1, 2, 1, CAST(349.0000 AS Decimal(19, 4)), CAST(349.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (2, 2, 2, CAST(449.0000 AS Decimal(19, 4)), CAST(449.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (3, 2, 3, CAST(299.0000 AS Decimal(19, 4)), CAST(897.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (5, 2, 4, CAST(299.0000 AS Decimal(19, 4)), CAST(897.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (6, 2, 5, CAST(399.0000 AS Decimal(19, 4)), CAST(1197.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (7, 2, 6, CAST(399.0000 AS Decimal(19, 4)), CAST(1197.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (8, 2, 7, CAST(239.0000 AS Decimal(19, 4)), CAST(1434.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (9, 2, 8, CAST(215.1000 AS Decimal(19, 4)), CAST(1290.6000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (11, 2, 9, CAST(339.0000 AS Decimal(19, 4)), CAST(2034.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (12, 2, 10, CAST(305.1000 AS Decimal(19, 4)), CAST(1830.6000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (13, 2, 11, CAST(199.0000 AS Decimal(19, 4)), CAST(2388.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (14, 2, 12, CAST(179.1000 AS Decimal(19, 4)), CAST(2149.2000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (15, 2, 13, CAST(299.0000 AS Decimal(19, 4)), CAST(3588.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (16, 2, 14, CAST(269.1000 AS Decimal(19, 4)), CAST(3229.2000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (18, 2, 15, CAST(0.0000 AS Decimal(19, 4)), CAST(600.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[PackageLocationPrices] ([Id], [LocationId], [PackageId], [MonthlyPrice], [TotalPrice]) VALUES (19, 2, 16, CAST(0.0000 AS Decimal(19, 4)), CAST(1000.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[PackageLocationPrices] OFF
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
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (2, CAST(N'00:00:00' AS Time), CAST(N'00:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (3, CAST(N'00:30:00' AS Time), CAST(N'00:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (4, CAST(N'01:00:00' AS Time), CAST(N'01:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (5, CAST(N'01:30:00' AS Time), CAST(N'01:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (6, CAST(N'02:00:00' AS Time), CAST(N'02:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (7, CAST(N'02:30:00' AS Time), CAST(N'02:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (8, CAST(N'03:00:00' AS Time), CAST(N'03:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (9, CAST(N'03:30:00' AS Time), CAST(N'03:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (10, CAST(N'04:00:00' AS Time), CAST(N'04:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (11, CAST(N'04:30:00' AS Time), CAST(N'04:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (12, CAST(N'05:00:00' AS Time), CAST(N'05:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (13, CAST(N'05:30:00' AS Time), CAST(N'05:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (14, CAST(N'06:00:00' AS Time), CAST(N'06:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (15, CAST(N'06:30:00' AS Time), CAST(N'06:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (16, CAST(N'07:00:00' AS Time), CAST(N'07:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (17, CAST(N'07:30:00' AS Time), CAST(N'07:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (18, CAST(N'08:00:00' AS Time), CAST(N'08:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (19, CAST(N'08:30:00' AS Time), CAST(N'08:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (20, CAST(N'09:00:00' AS Time), CAST(N'09:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (21, CAST(N'09:30:00' AS Time), CAST(N'09:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (22, CAST(N'10:00:00' AS Time), CAST(N'10:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (23, CAST(N'10:30:00' AS Time), CAST(N'10:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (24, CAST(N'11:00:00' AS Time), CAST(N'11:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (25, CAST(N'11:30:00' AS Time), CAST(N'11:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (26, CAST(N'12:00:00' AS Time), CAST(N'12:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (27, CAST(N'12:30:00' AS Time), CAST(N'12:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (28, CAST(N'13:00:00' AS Time), CAST(N'13:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (29, CAST(N'13:30:00' AS Time), CAST(N'13:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (30, CAST(N'14:00:00' AS Time), CAST(N'14:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (31, CAST(N'14:30:00' AS Time), CAST(N'14:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (32, CAST(N'15:00:00' AS Time), CAST(N'15:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (33, CAST(N'15:30:00' AS Time), CAST(N'15:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (34, CAST(N'16:00:00' AS Time), CAST(N'16:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (35, CAST(N'16:30:00' AS Time), CAST(N'16:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (36, CAST(N'17:00:00' AS Time), CAST(N'17:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (37, CAST(N'17:30:00' AS Time), CAST(N'17:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (38, CAST(N'18:00:00' AS Time), CAST(N'18:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (39, CAST(N'18:30:00' AS Time), CAST(N'18:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (40, CAST(N'19:00:00' AS Time), CAST(N'19:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (41, CAST(N'19:30:00' AS Time), CAST(N'19:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (42, CAST(N'20:00:00' AS Time), CAST(N'20:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (43, CAST(N'20:30:00' AS Time), CAST(N'20:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (44, CAST(N'21:00:00' AS Time), CAST(N'21:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (45, CAST(N'21:30:00' AS Time), CAST(N'21:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (46, CAST(N'22:00:00' AS Time), CAST(N'22:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (47, CAST(N'22:30:00' AS Time), CAST(N'22:59:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (48, CAST(N'23:00:00' AS Time), CAST(N'23:29:59' AS Time))
GO
INSERT [dbo].[TimeSlot] ([Id], [StartTime], [EndTime]) VALUES (49, CAST(N'23:30:00' AS Time), CAST(N'23:59:59' AS Time))
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
SET IDENTITY_INSERT [dbo].[SessionBooking] ON 

GO
INSERT [dbo].[SessionBooking] ([Id], [MemberId], [LocationId], [Date], [BookingStateId], [RPEFeeling], [RPEPush], [Notes], [TimeSlotId]) VALUES (1, 1, 2, CAST(N'2015-02-04' AS Date), 3, 7, 8, NULL, 49)
GO
INSERT [dbo].[SessionBooking] ([Id], [MemberId], [LocationId], [Date], [BookingStateId], [RPEFeeling], [RPEPush], [Notes], [TimeSlotId]) VALUES (13, 1, 2, CAST(N'2015-02-05' AS Date), 1, 0, 0, NULL, 2)
GO
INSERT [dbo].[SessionBooking] ([Id], [MemberId], [LocationId], [Date], [BookingStateId], [RPEFeeling], [RPEPush], [Notes], [TimeSlotId]) VALUES (14, 1, 2, CAST(N'2015-02-06' AS Date), 1, 0, 0, NULL, 31)
GO
INSERT [dbo].[SessionBooking] ([Id], [MemberId], [LocationId], [Date], [BookingStateId], [RPEFeeling], [RPEPush], [Notes], [TimeSlotId]) VALUES (15, 1, 2, CAST(N'2015-02-06' AS Date), 1, 0, 0, NULL, 36)
GO
INSERT [dbo].[SessionBooking] ([Id], [MemberId], [LocationId], [Date], [BookingStateId], [RPEFeeling], [RPEPush], [Notes], [TimeSlotId]) VALUES (16, 1, 2, CAST(N'2015-02-07' AS Date), 1, 0, 0, NULL, 25)
GO
SET IDENTITY_INSERT [dbo].[SessionBooking] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([Id], [AspNetUserId], [LocationId]) VALUES (1, N'a6ce8231-8631-4494-9adb-bcb534321ab9', 1)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[QuarterlyAssessment] ON 

GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [EmployeeId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (2, 1, 1, 2, 2014, CAST(N'2014-01-30 06:00:00.000' AS DateTime), 10, NULL, N'3', N'14', N'Sounds Great! Don''t you think?', NULL, N'2', N'10', N'Not Bad form, good effort.', NULL, N'3', N'4', N'Needs to increase strength', NULL, N'4', N'3min 40', N'Fantastic effort', NULL, N'2', N'12', N'Amazing', 4, 3, 6, 5, 4, 7, 6, 5, 40)
GO
INSERT [dbo].[QuarterlyAssessment] ([Id], [MemberId], [EmployeeId], [QAQuarter], [QAYear], [QADateTime], [QAClientRPE], [QATestOneTitle], [QATestOneType], [QATestOneTimeReps], [QATestOneNotes], [QATestTwoTitle], [QATestTwoType], [QATestTwoTimeReps], [QATestTwoNotes], [QATestThreeTitle], [QATestThreeType], [QATestThreeTimeReps], [QATestThreeNotes], [QATestFourTitle], [QATestFourType], [QATestFourTimeReps], [QATestFourNotes], [QATestFiveTitle], [QATestFiveType], [QATestFiveTimeReps], [QATestFiveNotes], [QATestFiveRoundOneReps], [QATestFiveRoundTwoReps], [QATestFiveRoundThreeReps], [QATestFiveRoundFourReps], [QATestFiveRoundFiveReps], [QATestFiveRoundSixReps], [QATestFiveRoundSevenReps], [QATestFiveRoundEightReps], [QATestFiveTotalReps]) VALUES (3, 1, 1, 1, 2015, CAST(N'2015-01-21 00:00:00.000' AS DateTime), 4, NULL, N'2', N'60 seconds', N'Fantastic Form!', NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, N'-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[QuarterlyAssessment] OFF
GO
SET IDENTITY_INSERT [dbo].[MembershipSuspensions] ON 

GO
INSERT [dbo].[MembershipSuspensions] ([Id], [MembershipId], [SuspensionStartDate], [SuspensionEndDate], [SuspensionReason]) VALUES (1, 4, CAST(N'2015-02-04' AS Date), CAST(N'2015-03-11' AS Date), N'fun')
GO
SET IDENTITY_INSERT [dbo].[MembershipSuspensions] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsCategories] ON 

GO
INSERT [dbo].[NewsCategories] ([Id], [Title]) VALUES (1, N'Announcement')
GO
INSERT [dbo].[NewsCategories] ([Id], [Title]) VALUES (2, N'Gym Update')
GO
SET IDENTITY_INSERT [dbo].[NewsCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

GO
INSERT [dbo].[News] ([Id], [LocationId], [Title], [Body], [NewsCategoryId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, 2, N'Welcome to Ritual Singapore Dude!', N'<p>This is the body<strong> text for Ritual Singapore. </strong>What do you think of this?</p>', 1, CAST(N'2015-02-16 22:11:29.000' AS DateTime), CAST(N'2015-02-16 23:28:04.407' AS DateTime), N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'a6ce8231-8631-4494-9adb-bcb534321ab9')
GO
INSERT [dbo].[News] ([Id], [LocationId], [Title], [Body], [NewsCategoryId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, 2, N'We now have a brand new Receptionist!', N'<p>Welcome to the crew of Ritual is the new Receptionist Jaimee</p>', 2, CAST(N'2015-02-16 23:43:36.407' AS DateTime), CAST(N'2015-02-16 23:43:36.407' AS DateTime), N'a6ce8231-8631-4494-9adb-bcb534321ab9', N'a6ce8231-8631-4494-9adb-bcb534321ab9')
GO
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[OpeningHourOverride] ON 

GO
INSERT [dbo].[OpeningHourOverride] ([Id], [OverrideStartDate], [OverrideEndDate], [DayOfWeek], [AltOpenTime], [AltCloseTme], [OverrideReason], [LocationId]) VALUES (1, CAST(N'2015-01-30' AS Date), CAST(N'2015-01-30' AS Date), 5, CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), N'Employee Training', 2)
GO
INSERT [dbo].[OpeningHourOverride] ([Id], [OverrideStartDate], [OverrideEndDate], [DayOfWeek], [AltOpenTime], [AltCloseTme], [OverrideReason], [LocationId]) VALUES (2, CAST(N'2015-01-31' AS Date), CAST(N'2015-01-31' AS Date), 6, CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'Lunch Training', 2)
GO
INSERT [dbo].[OpeningHourOverride] ([Id], [OverrideStartDate], [OverrideEndDate], [DayOfWeek], [AltOpenTime], [AltCloseTme], [OverrideReason], [LocationId]) VALUES (3, CAST(N'2015-01-31' AS Date), CAST(N'2015-01-31' AS Date), 6, CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'Lunch Meeting', 1)
GO
SET IDENTITY_INSERT [dbo].[OpeningHourOverride] OFF
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
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (13, 1, CAST(N'09:00:00' AS Time), CAST(N'15:00:00' AS Time), 3)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (14, 2, CAST(N'08:30:00' AS Time), CAST(N'16:00:00' AS Time), 3)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (15, 3, CAST(N'07:30:00' AS Time), CAST(N'18:00:00' AS Time), 3)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (16, 1, CAST(N'12:00:00' AS Time), CAST(N'06:00:00' AS Time), 5)
GO
INSERT [dbo].[OpeningHour] ([Id], [DateOfWeek], [OpenTime], [CloseTime], [LocationId]) VALUES (17, 1, CAST(N'12:04:00' AS Time), CAST(N'03:00:00' AS Time), 5)
GO
SET IDENTITY_INSERT [dbo].[OpeningHour] OFF
GO
