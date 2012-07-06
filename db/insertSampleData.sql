USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (1, N'Piasek', N'pia')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (2, N'Cement', N'ce')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (3, N'Woda', N'wo')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (4, N'Żółty piasek', N'zp')
INSERT [dbo].[Materials] ([Id], [Name], [InternalName]) VALUES (5, N'Żwir 2-8', N'Żwir 2-8')
SET IDENTITY_INSERT [dbo].[Materials] OFF
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (1, N'Bogdan', N'Kula', N'603157559')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (2, N'Paweł', N'Motyliński', N'601601601')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (3, N'Błażej', N'Frant', N'601601601')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (4, N'Jarek', N'Skwareksd', N'555')
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone]) VALUES (5, N'Karol', N'Binka', N'601000000')
SET IDENTITY_INSERT [dbo].[Drivers] OFF
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [Name], [Phone]) VALUES (1, N'Kontrahent Somee.com, Somee, Hostings', N'423456987')
INSERT [dbo].[Clients] ([Id], [Name], [Phone]) VALUES (2, N'Drugia, Kontrahent, Nazwisko', N'543')
INSERT [dbo].[Clients] ([Id], [Name], [Phone]) VALUES (3, N'Kulopolo, Wijciech, Poklak', N'1119994442123412')
INSERT [dbo].[Clients] ([Id], [Name], [Phone]) VALUES (4, N'Inkom, Darek, Jaros', N'843048013')
INSERT [dbo].[Clients] ([Id], [Name], [Phone]) VALUES (5, N'Inkom, asdfkj, sakdfja', N'888999')
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[Cars]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (1, N'Ert 3456', N'Pompogruszka', N'Astra')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (2, N'UUU 987657', N'Skoda', N'Sk')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (3, N'543', N'Fiat', N'Fi')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (4, N'PO 608ju', N'Ford', N'Mk4')
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName]) VALUES (5, N'EBE 0428', N'DAF', N'DAF')
SET IDENTITY_INSERT [dbo].[Cars] OFF
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (1, N'Beton na stropy', N'B1')
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (2, N'Beton na fundament', N'b2')
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (3, N'Beton na ogradzenia', N'og')
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName]) VALUES (4, N'B-20', N'B-20')
SET IDENTITY_INSERT [dbo].[Recipes] OFF
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[RecipeComponents] ON
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (1, 1, 1, 3)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (2, 2, 1, 1)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (3, 3, 1, 1)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (4, 1, 2, 14)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (5, 3, 2, 3)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (6, 2, 3, 2)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (7, 4, 3, 4)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount]) VALUES (8, 3, 4, 127)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/06/2012 21:17:11 ******/
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [Client_Id], [City], [Street], [HouseNo]) VALUES (1, 1, N'Somee', N'Com', N'12')
INSERT [dbo].[Buildings] ([Id], [Client_Id], [City], [Street], [HouseNo]) VALUES (2, 1, N'Zieleniec', N'Narty', N'12')
INSERT [dbo].[Buildings] ([Id], [Client_Id], [City], [Street], [HouseNo]) VALUES (3, 2, N'm', N'u', N'k')
INSERT [dbo].[Buildings] ([Id], [Client_Id], [City], [Street], [HouseNo]) VALUES (4, 3, N'Góra', N'Polna', N'234')
INSERT [dbo].[Buildings] ([Id], [Client_Id], [City], [Street], [HouseNo]) VALUES (5, 4, N'Elektrownia', N'Błysku', N'7')
SET IDENTITY_INSERT [dbo].[Buildings] OFF


SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (1, 1, 2, 3,     CAST(0x0000A03D00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (2, 1, 1, 4.5,   CAST(0x0000A03D00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (3, 1, 2, 4,     CAST(0x0000A03D00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (4, 2, 3, 5,     CAST(0x0000A05E00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (5, 1, 1, 7,     CAST(0x0000A05E00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (6, 3, 3, 8,     CAST(0x0000A05E00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (7, 2, 3, 34,    CAST(0x0000A05E00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (8, 2, 3, 3,     CAST(0x0000A05E00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (9, 2, 3, 5,     CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (10, 2, 3, 2,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (11, 2, 3, 9,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (12, 2, 3, 1,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (13, 2, 3, 3.3,  CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (14, 2, 3, 2,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (15, 3, 3, 4,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (16, 2, 3, 2,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (17, 2, 2, 4,    CAST(0x0000A07A00F55D20 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (18, 3, 3, NULL, CAST(0x0000A07B00C28410 AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (19, 4, 2, NULL, CAST(0x0000A07B00C300BD AS DateTime))
INSERT [dbo].[Orders] ([Id], [Building_Id], [Recipe_Id], [Amount], [DateOfOrder]) VALUES (20, 5, 2, NULL, CAST(0x0000A07B00EF8B4E AS DateTime))
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF


/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/06/2012 21:17:11 ******/
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (1, 1, 3, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (2, 2, 4.5, 1, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (3, 3, 4, 2, CAST(0x0000A03D00F55D20 AS DateTime), CAST(0x0000A03D00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (4, 4, 5, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A07B00C31789 AS DateTime), NULL, 1)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (5, 5, 7, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (6, 6, 8, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (7, 7, 34, 2, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (8, 8, 3, 3, CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A05E00F55D20 AS DateTime), CAST(0x0000A07C004C0356 AS DateTime), NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (9, 9, 5, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07B00C29A62 AS DateTime), NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (10, 10,2, 1, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (11, 11, 9, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (12, 12, 1, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (13, 13, 3.3, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (14, 14, 2, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (15, 15, 4, 2, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07B00FFB878 AS DateTime), NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (16, 16, 2, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (17, 17, 4, 3, CAST(0x0000A07A00F55D20 AS DateTime), CAST(0x0000A07A00F55D20 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (18, 18, NULL, 2, CAST(0x0000A07B00C28410 AS DateTime), CAST(0x0000A07B00C28410 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (19, 19, NULL, 4, CAST(0x0000A07B00C300BD AS DateTime), CAST(0x0000A06A00000000 AS DateTime), NULL, NULL, 4)
INSERT [dbo].[DeliveryNotes] ([Id], [Order_Id], [Amount], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id]) VALUES (20, 20, NULL, 3, CAST(0x0000A07B00EF8B4E AS DateTime), CAST(0x0000A07B00EF8B4E AS DateTime), NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
