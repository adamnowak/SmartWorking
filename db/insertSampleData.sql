USE [Smartworking]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (1, N'Piasek', N'pia')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (2, N'Cement', N'ce')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (3, N'Woda', N'wo')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (4, N'Żółty piasek', N'zp')
SET IDENTITY_INSERT [dbo].[Materials] OFF
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (1, N'Elvis', N'Kierownicaa', N'123456')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (2, N'Marek2', N'Samochodzik', N'987654')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (3, N'Urszula', N'Łóźbłężźća', N'33456')
SET IDENTITY_INSERT [dbo].[Drivers] OFF
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Contractors] ON
INSERT [dbo].[Contractors] ([Id], [FullName], [Name], [Surname], [Phone]) VALUES (1, N'Kontrahent Somee.com', N'Somee', N'Hostings', N'423456987')
INSERT [dbo].[Contractors] ([Id], [FullName], [Name], [Surname], [Phone]) VALUES (2, N'Drugia', N'Kontrahent', N'Nazwisko', N'543')
SET IDENTITY_INSERT [dbo].[Contractors] OFF
/****** Object:  Table [dbo].[Cars]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (1, N'Ert 3456', N'Łada Samara', N'lad')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (2, N'UUU 987657', N'Skoda', N'Sk')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (3, N'543', N'Fiat', N'Fi')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (4, N'PO 608ju', N'Ford', N'Mk4')
SET IDENTITY_INSERT [dbo].[Cars] OFF
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (1, N'Beton na stropy', N'B1')
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (2, N'Beton na fundament', N'b2')
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (3, N'Beton na ogradzenia', N'og')
SET IDENTITY_INSERT [dbo].[Recipes] OFF
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[RecipeComponents] ON
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (1, 1, 1, 3)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (2, 2, 1, 1)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (3, 3, 1, 1)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (4, 1, 2, 14)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (5, 3, 2, 3)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (6, 2, 3, 2)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (7, 4, 3, 4)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/25/2012 00:02:13 ******/
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [Contractor_Id], [City], [Street], [HouseNo]) VALUES (1, 1, N'Somee', N'Com', N'12')
INSERT [dbo].[Buildings] ([Id], [Contractor_Id], [City], [Street], [HouseNo]) VALUES (2, 1, N'Zieleniec', N'Narty', N'12')
INSERT [dbo].[Buildings] ([Id], [Contractor_Id], [City], [Street], [HouseNo]) VALUES (3, 2, N'm', N'u', N'k')
SET IDENTITY_INSERT [dbo].[Buildings] OFF
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/25/2012 00:02:13 ******/
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (1, 1, 2, 3, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (2, 1, 1, 4.5, 1, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (3, 1, 2, 4, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (4, 2, 3, 5, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (5, 1, 1, 7, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (6, 3, 3, 8, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (7, 2, 3, 34, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (8, 2, 3, 3, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (9, 2, 3, 5, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (10, 2, 3, 2, 1, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (11, 2, 3, 9, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (12, 2, 3, 1, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (13, 2, 3, 3.3, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (14, 2, 3, 2, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (15, 3, 3, 4, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (16, 2, 3, 2, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Building_Id], [Recipe_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (17, 2, 2, 4, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
