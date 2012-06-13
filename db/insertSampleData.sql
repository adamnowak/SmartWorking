USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (1, N'Material1', N'M1')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (2, N'Material2', N'M2')
SET IDENTITY_INSERT [dbo].[Materials] OFF

/****** Object:  Table [dbo].[Drivers]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (1, N'Sławek', N'Kierowcowy', N'1234567')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (2, N'Władek', N'Ładow', N'1234567987')
SET IDENTITY_INSERT [dbo].[Drivers] OFF

/****** Object:  Table [dbo].[Contractors]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Contractors] ON
INSERT [dbo].[Contractors] ([Id], [FullName], [Name], [Surname], [Phone]) VALUES (1, N'Łukasz Sp. o.o. ół', N'Nieźrebie', N'Adam', N'987654uytfvc i')
INSERT [dbo].[Contractors] ([Id], [FullName], [Name], [Surname], [Phone]) VALUES (2, N'Źrebię L', N'Łaja', N'Żabę', N'87654')
SET IDENTITY_INSERT [dbo].[Contractors] OFF

/****** Object:  Table [dbo].[Cars]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (1, N'12345678', N'Skoda', N'sk')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (2, N'123456', N'Łada', N'Ła')
SET IDENTITY_INSERT [dbo].[Cars] OFF

/****** Object:  Table [dbo].[Recipes]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (1, N'Recepta1łóaa', N'R1aa')
SET IDENTITY_INSERT [dbo].[Recipes] OFF

/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[RecipeComponents] ON
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (1, 2, 1, 3)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/13/2012 10:17:40 ******/

/****** Object:  Table [dbo].[Buildings]    Script Date: 06/13/2012 10:17:40 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [Contractor_Id], [City], [Street], [HouseNo]) VALUES (1, 1, N'ŁÓdz', N'ŁódzkaŻŚĆŃĆĘĄŚŁÓ', N'987654')
SET IDENTITY_INSERT [dbo].[Buildings] OFF
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/13/2012 10:17:40 ******/

