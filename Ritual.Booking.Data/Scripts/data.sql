SET IDENTITY_INSERT [dbo].[Location] ON 

GO

INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Coordinates]) 
VALUES (1, N'London', N'Trafalgar Square', N'0208 789 7890', N'SE1 1AA', N'UK', 0, NULL)

INSERT [dbo].[Location] ([Id], [Name], [Address], [PhoneNumber], [PostCode], [Country], [TimeZoneOffset], [Coordinates]) 
VALUES (2, N'Ritual Singapore', N'11 North Canal Road', N'0065 6536 7291', N'048824', N'Singapore', 0, NULL)

GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO