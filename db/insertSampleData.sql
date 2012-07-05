USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted]) VALUES (1, N'Beton na stropy', N'B1', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted]) VALUES (2, N'Beton na fundament', N'b2', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted]) VALUES (3, N'Beton na ogradzenia', N'og', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
/****** Object:  Table [dbo].[Cars]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType_Id], [Deleted]) VALUES (1, N'Ert 3456', N'Łada Samara', N'lad', NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType_Id], [Deleted]) VALUES (2, N'UUU 987657', N'Skoda', N'Sk', NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType_Id], [Deleted]) VALUES (3, N'543', N'Fiat', N'Fi', NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType_Id], [Deleted]) VALUES (4, N'PO 608ju', N'Ford', N'Mk4', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cars] OFF
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/27/2012 20:01:07 ******/
/****** Object:  Table [dbo].[Clients]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted]) VALUES (1, NULL, NULL, N'Somee', NULL, NULL, NULL, N'Hostings', N'423456987', NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted]) VALUES (2, NULL, NULL, N'Kontrahent', NULL, NULL, NULL, N'Nazwisko', N'543', NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[CarTypes]    Script Date: 06/27/2012 20:01:07 ******/
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [Client_Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted]) VALUES (1, 1, NULL, NULL, N'Somee', N'Com', NULL, NULL, NULL, N'12', NULL)
INSERT [dbo].[Buildings] ([Id], [Client_Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted]) VALUES (2, 1, NULL, NULL, N'Zieleniec', N'Narty', NULL, NULL, NULL, N'12', NULL)
INSERT [dbo].[Buildings] ([Id], [Client_Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted]) VALUES (3, 2, NULL, NULL, N'm', N'u', NULL, NULL, NULL, N'k', NULL)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
/****** Object:  Table [dbo].[Materials]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted]) VALUES (1, N'Piasek', NULL, NULL, N'pia', NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted]) VALUES (2, N'Cement', NULL, NULL, N'ce', NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted]) VALUES (3, N'Woda', NULL, NULL, N'wo', NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted]) VALUES (4, N'Żółty piasek', NULL, NULL, N'zp', NULL)
SET IDENTITY_INSERT [dbo].[Materials] OFF
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Car_Id], [Deleted]) VALUES (1, N'Elvis', N'Kierownicaa', N'123456', NULL, NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Car_Id], [Deleted]) VALUES (2, N'Marek2', N'Samochodzik', N'987654', NULL, NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Car_Id], [Deleted]) VALUES (3, N'Urszula', N'Łóźbłężźća', N'33456', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Drivers] OFF
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[RecipeComponents] ON
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (1, 1, 1, 3, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (2, 2, 1, 1, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (3, 3, 1, 1, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (4, 1, 2, 14, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (5, 3, 2, 3, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (6, 2, 3, 2, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted]) VALUES (7, 4, 3, 4, NULL)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[Orders]    Script Date: 06/27/2012 20:01:07 ******/
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/27/2012 20:01:07 ******/
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/27/2012 20:01:07 ******/
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (1, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (2, 1, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (3, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (4, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (5, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (6, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (7, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (8, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (9, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (10, 1, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (11, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (12, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (13, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (14, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (15, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (16, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id]) VALUES (17, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
