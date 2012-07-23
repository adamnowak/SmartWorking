USE [Smartworking]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (1, N'20445116', N'15', NULL, N'0-16', N'K4', N'B-20      ', NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (2, N'10344110', N'5', NULL, N'0-16', N'K3', N'B-10      ', NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (3, N'Beton na ogradzenia', N'2', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (4, N'B-20', N'B-20', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (5, N'20445116', N'15', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (6, N'25446116', N'17', NULL, N'0-16', N'K 4', N'B 25      ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (1, N'Bogdan', N'Kula', N'603157559', N'Bogdan', CAST(0x0000A09300F97901 AS DateTime), NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (2, N'Paweljj', N'Motylinski', N'601602603', N'Pawel', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (3, N'Blazej', N'Frant', N'601601603', N'Blazej', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (4, N'Jarek', N'Skwareksd', N'555', NULL, NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (5, N'Karol', N'Binka', N'601000000', NULL, NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (6, N'Jan', N'Kowalski', N'', N'Kowalski', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (7, N'Maciek', N'Nyszak', N'7324329048023894', N'Test', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (8, N'Maciek', N'Nyszak', N'222222', N'Test', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Drivers] OFF
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (1, NULL, NULL, N'Somee', N'Com', NULL, NULL, NULL, N'12', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (2, NULL, NULL, N'Zieleniec', N'Narty', NULL, NULL, NULL, N'12', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (3, NULL, NULL, N'm', N'u', NULL, NULL, NULL, N'k', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (4, NULL, NULL, N'Góra', N'Polna', NULL, NULL, NULL, N'234', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (5, NULL, NULL, N'Elektrownia', N'Blysku', NULL, NULL, NULL, N'7', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (6, N'Kielchinów', N'97-400', N'Kielchinów', N'Kielchinów', N'601065848', N'Sylwester Wypych', NULL, N'10', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Contractors] ON
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (1, N'Cemex', N'Cemex Polska Sp. z o.o', N'02-444', N'Warszawa', N'Aleje Jerozolimskie', N'212', NULL, N'22 99999', NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (2, N'Kubus', N'Kubus', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (3, N'Pacak', N'Pacak', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (4, N'Górazdze', N'Gorazdze ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contractors] OFF
/****** Object:  Table [dbo].[Clients]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (1, N'BWB', N'827-177-92-06', N'BWB Sylwester Wypych', N'Belchatów', N'Przemsylowa', N'97-400', N'4', N'601065848', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (2, N'Binz', N'8676766868', N'BinZ S.A.', N'Belchatów', N'Olsztynska', N'97-400', N'3', N'44 633 55 55', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (3, NULL, NULL, N'Kulopolo, Wijciech, Poklak', NULL, NULL, NULL, NULL, N'1119994442123412', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (4, NULL, NULL, N'Inkom, Darek, Jaros', NULL, NULL, NULL, NULL, N'843048013', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (5, NULL, NULL, N'Inkom, asdfkj, sakdfja', NULL, NULL, NULL, NULL, N'888999', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (6, N'Begier', N'098329048', N'Begier dklafj', N'adsfk', N'adskfj', N'97-400', N'12', N'55555', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[ClientBuildings]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[ClientBuildings] ON
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (1, 1, 1, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (2, 1, 2, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (3, 2, 3, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (4, 3, 4, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (5, 4, 5, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (6, 1, 6, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ClientBuildings] OFF
/****** Object:  Table [dbo].[Cars]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (1, N'SK 3354 W', N'Pompogruszka', N'Bogdan', 2, NULL, 10, 1, 1, CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (2, N'EBE 4EA1', N'Skoda', N'Blazej', 1, NULL, 10, 1, 7, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (3, N'EBE 3HE8', N'Fiat', N'Pawel', 1, NULL, 10, 1, 6, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (4, N'PL', N'Ford', N'Karol', 1, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (5, N'Pl 12345', N'DAF', N'Waldek', 1, NULL, 10, 2, 1, CAST(0x0000000100000000 AS DateTime))
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (6, N'EBE 12345', NULL, N'Kukula', 3, NULL, 7, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (7, N'....ab', NULL, N'Odbiór wlasnl', 3, NULL, 18, 3, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (8, N'PZ', NULL, N'Akfa', 1, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (9, N'ttt', NULL, N'Daf', 2, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (10, N'SK 3354 W', N'Pompogruszka', N'AstraTestowa', 3, NULL, 10, 1, NULL, CAST(0x0000000000000000 AS DateTime))
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (11, NULL, NULL, N'testowa', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (12, N'ebe 12345', NULL, N'test dwa', 1, NULL, 10, 1, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (13, N'Pl 12346', N'DAF', N'Michal', 1, CAST(0x0000A09300C4BCE9 AS DateTime), 10, 2, 1, CAST(0x0000000100000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Cars] OFF
/****** Object:  Table [dbo].[Materials]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (1, N'Piasek 0-2 mm', 4, 2, N'Piasek Górazdzed', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (2, N'Cement Cem II BS-32,5 R', 1, 1, N'Cement Cem II BS-32,5 R', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (3, N'Woda Wodociagi', NULL, NULL, N'Woda', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (4, N'Piasek 0-2', 3, 3, N'Piasek Pacak', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (5, N'Zwir 2-8', NULL, NULL, N'Zwir 2-8', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (6, N'test', 1, 1, N'test', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (7, N'Popiól lotny', 4, 3, N'Popiól', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (8, N'Cement Cem III 32,5', 4, 4, N'Cement Cem III 32,5', CAST(0x0000A09300CEC9A2 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Materials] OFF
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[RecipeComponents] ON
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (1, 1, 1, 760, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (2, 2, 1, 1, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (3, 3, 1, 110, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (4, 1, 2, 14, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (5, 3, 2, 3, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (6, 2, 3, 2, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (7, 4, 3, 4, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (8, 3, 4, 127, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (9, 2, 1, 8.1, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (10, 1, 6, 126, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (11, 2, 6, 134, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (12, 4, 1, 145, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (13, 5, 6, 345, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (14, 3, 6, 110, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (15, 2, 2, 200, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (16, 5, 2, 280, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (17, 2, 4, 200, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (18, 2, 5, 230, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[Orders]    Script Date: 07/23/2012 22:15:02 ******/
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/23/2012 22:15:02 ******/
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/23/2012 22:15:02 ******/
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated]) VALUES (1, 1, CAST(0x0000A089003F0C8E AS DateTime), CAST(0x0000A089003F0C8E AS DateTime), NULL, NULL, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
