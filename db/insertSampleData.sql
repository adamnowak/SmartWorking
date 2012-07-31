USE [Smartworking]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Recipes] ON
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (1, N'20445116', N'15', NULL, N'0-16', N'K4', N'B-20      ', NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (2, N'10344110', N'5', NULL, N'0-16', N'K3', N'B-10      ', NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (3, N'Beton na ogradzenia', N'2', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (4, N'B-20', N'B-20', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (5, N'20445116', N'15', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (6, N'25446116', N'17', NULL, N'0-16', N'K 4', N'B 25      ', CAST(0x0000A099008EAE07 AS DateTime), NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (7, N'25446116', N'17', NULL, N'0-16', N'K 4', N'B 25      ', CAST(0x0000A099008EBEB0 AS DateTime), NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (8, N'25446116', N'17', NULL, N'0-16', N'K 4', N'B 25      ', NULL, NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (9, N'30446115', N'12', NULL, N'0-16', N'K4', N'B-30      ', CAST(0x0000A09B00B5A743 AS DateTime), NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (10, N'30446115', N'12', NULL, N'0-16', N'K4', N'B-30      ', CAST(0x0000A09B00B5BB1D AS DateTime), NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (11, N'30446115', N'12', NULL, N'0-16', N'K4', N'B-30      ', CAST(0x0000A09B00B6025D AS DateTime), NULL)
INSERT [dbo].[Recipes] ([Id], [Name], [InternalName], [Number], [Granulation], [Consistency], [ConcreteClass], [Deleted], [Deactivated]) VALUES (12, N'30446115', N'12', NULL, N'0-16', N'K4', N'B-30      ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Drivers] ON
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (1, N'Bogdan', N'Kula', N'603 157 559', N'Bogdan', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (2, N'Paweł', N'Motyliński', N'607 724 232', N'Paweł', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (3, N'Błażej', N'Frant', N'693 491 790', N'Błażej', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (4, N'Waldek', N'Nowak', N'783 991 152', N'VEKA Waldek', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (5, N'Karol', N'Binka', N'665 169 910', N'VEKA Karol', NULL, NULL)
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (6, N'Jan', N'Kowalski', N'', N'Kowalski', NULL, CAST(0x0000A09B00B26AEA AS DateTime))
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (7, N'Maciek', N'Nyszak', N'43 655 66 66', N'Test', NULL, CAST(0x0000A09B00B26182 AS DateTime))
INSERT [dbo].[Drivers] ([Id], [Name], [Surname], [Phone], [InternalName], [Deleted], [Deactivated]) VALUES (8, N'Maciek', N'Nyszak', N'222222', N'Test', NULL, CAST(0x0000A09B00B25A75 AS DateTime))
SET IDENTITY_INSERT [dbo].[Drivers] OFF
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Buildings] ON
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (1, NULL, NULL, N'Somee', N'Com', NULL, NULL, NULL, N'12', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (2, NULL, NULL, N'Zieleniec', N'Narty', NULL, NULL, NULL, N'12', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (3, NULL, NULL, N'm', N'u', NULL, NULL, NULL, N'k', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (4, NULL, NULL, N'Góra', N'Polna', NULL, NULL, NULL, N'234', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (5, NULL, NULL, N'Elektrownia', N'Blysku', NULL, NULL, NULL, N'7', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (6, N'Kielchinów', N'97-400', N'Kielchinów', N'Kielchinów', N'601065848', N'Sylwester Wypych', NULL, N'10', NULL, NULL)
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (7, N'Jan Kolwalski', N'97-400', N'Bełchatów', N'Wyszyńskiego ', N'646466464', NULL, NULL, N'13', NULL, CAST(0x0000A09B00BF6CBA AS DateTime))
INSERT [dbo].[Buildings] ([Id], [InternalName], [ZIPCode], [City], [Street], [Phone], [ContactPerson], [ContactPersonPhone], [HouseNo], [Deleted], [Deactivated]) VALUES (8, N'Bawełnianka', N'97-400', N'Bełchatów', N'Mickiewicza', NULL, NULL, NULL, N'1', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Contractors] ON
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (1, N'Cemex', N'Cemex Polska Sp. z o.o', N'02-444', N'Warszawa', N'Aleje Jerozolimskie', N'212', NULL, N'22 99999', NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (2, N'Kubus', N'Kubus', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (3, N'Pacak', N'Pacak', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (4, N'Górażdże', N'Gorazdze ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contractors] ([Id], [InternalName], [Name], [ZIPCode], [City], [Street], [HouseNo], [Deleted], [Phone], [Deactivated]) VALUES (5, N'Utex', N'Utex', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contractors] OFF
/****** Object:  Table [dbo].[Clients]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (1, N'BWB', N'827-177-92-06', N'BWB Sylwester Wypych', N'Bełchatów', N'Przemysłowa', N'97-400', N'4', N'601065848', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (2, N'Binz', N'8676766868', N'BinZ S.A.', N'Belchatów', N'Olsztynska', N'97-400', N'3', N'44 633 55 55', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (3, N'BGR', N'833-675-12-23', N'BGR Polska', N'Poznań', N'Wesoła', N'65-330', N'8', N'565 555 555', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (4, NULL, NULL, N'Inkom, Darek, Jaros', NULL, NULL, NULL, NULL, N'843048013', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (5, NULL, NULL, N'Inkom, asdfkj, sakdfja', NULL, NULL, NULL, NULL, N'888999', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (6, N'Begier', N'098329048', N'Begier dklafj', N'adsfk', N'adskfj', N'97-400', N'12', N'55555', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (7, N'Jan Kowalski', N'Kowalski', N'Jan', N'Bełchatów', N'Słoneczna', N'97-400', N'12', N'44 633 33 33', NULL, NULL)
INSERT [dbo].[Clients] ([Id], [InternalName], [NIP], [Name], [City], [Street], [ZIPCode], [HouseNo], [Phone], [Deleted], [Deactivated]) VALUES (8, N'Mirbud', N'777-234-23-32', N'Mirbud S.A.', N'Skierniewice', N' Olechów', N'97-432', N'1', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[ClientBuildings]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[ClientBuildings] ON
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (3, 2, 3, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (5, 4, 5, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (11, 3, 5, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (12, 3, 4, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (18, 1, 5, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (19, 1, 4, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (20, 1, 1, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (21, 1, 2, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (22, 7, 6, NULL, NULL)
INSERT [dbo].[ClientBuildings] ([Id], [Client_Id], [Building_Id], [Deleted], [Deactivated]) VALUES (23, 8, 8, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ClientBuildings] OFF
/****** Object:  Table [dbo].[Cars]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (1, N'SK 3354 W', N'Pompogruszka', N'Bogdan', 2, NULL, 10, 1, 1, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (2, N'EBE 4EA1', N'Skoda', N'Błażej', 1, NULL, 10, 1, 3, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (3, N'EBE 3HE8', N'Fiat', N'Paweł', 1, NULL, 10, 1, 2, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (4, N'PL', N'Ford', N'Karol', 1, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (5, N'EBE 1234', N'DAF', N'Waldek', 2, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (6, N'EBE 12345', NULL, N'Kukula', 3, NULL, 7, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (7, N'....ab', NULL, N'Odbiór wlasnl', 3, NULL, 18, 3, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (8, N'PZ', NULL, N'Akfa', 1, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (9, N'ttt', NULL, N'Daf', 2, NULL, 10, 2, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (10, N'SK 3354 W', N'Pompogruszka', N'AstraTestowa', 3, NULL, 10, 1, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (11, NULL, NULL, N'testowa', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (12, N'ebe 12345', NULL, N'test dwa', 1, NULL, 10, 1, NULL, NULL)
INSERT [dbo].[Cars] ([Id], [RegistrationNumber], [Name], [InternalName], [CarType], [Deleted], [Capacity], [TransportType], [Driver_Id], [Deactivated]) VALUES (13, N'Pl 12346', N'DAF', N'Michal', 1, NULL, 10, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cars] OFF
/****** Object:  Table [dbo].[Materials]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Materials] ON
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (1, N'Piasek 0-2 mm', NULL, 4, 2, N'Piasek Górażdże', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (2, N'Cement Cem II BS-32,5 R', NULL, 1, 1, N'Cement Cem II BS-32,5 R', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (3, N'Woda Wodociagi', NULL, NULL, NULL, N'Woda', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (4, N'Piasek 0-2', NULL, 3, 3, N'Piasek Pacak', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (5, N'Zwir 2-8', NULL, NULL, NULL, N'Zwir 2-8', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (6, N'test', NULL, 1, 1, N'test', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (7, N'Popiół lotny', NULL, NULL, NULL, N'Popiół', NULL, NULL)
INSERT [dbo].[Materials] ([Id], [Name], [MaterialType], [Producer_Id], [Deliverer_Id], [InternalName], [Deleted], [Deactivated]) VALUES (8, N'Cement Cem III 32,5', NULL, 4, 4, N'Cement Cem III 32,5', CAST(0x0000A09300CEC9A2 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Materials] OFF
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/30/2012 23:38:32 ******/
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
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (19, 1, 7, 125, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (20, 2, 7, 134, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (21, 5, 7, 345, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (22, 3, 7, 110, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (23, 1, 8, 126, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (24, 2, 8, 134, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (25, 5, 8, 345, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (26, 3, 8, 110, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (27, 2, 10, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (28, 3, 10, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (29, 4, 10, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (30, 7, 10, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (31, 5, 10, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (32, 2, 11, 230, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (33, 3, 11, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (34, 4, 11, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (35, 7, 11, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (36, 5, 11, NULL, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (37, 2, 12, 230, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (38, 3, 12, 120, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (39, 4, 12, 180, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (40, 7, 12, 76, NULL, NULL)
INSERT [dbo].[RecipeComponents] ([Id], [Material_Id], [Recipe_Id], [Amount], [Deleted], [Deactivated]) VALUES (41, 5, 12, 126, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF
/****** Object:  Table [dbo].[Orders]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([Id], [Recipe_Id], [ClientBuilding_Id], [Amount], [DateOfOrder], [PlannedDeliveryTime], [Deleted], [Deactivated], [Canceled], [Pump], [Notice]) VALUES (1, 8, 18, 36, NULL, NULL, NULL, NULL, NULL, 1, N'Pompa do betonu')
INSERT [dbo].[Orders] ([Id], [Recipe_Id], [ClientBuilding_Id], [Amount], [DateOfOrder], [PlannedDeliveryTime], [Deleted], [Deactivated], [Canceled], [Pump], [Notice]) VALUES (2, 5, 22, 50, NULL, NULL, NULL, NULL, NULL, 1, N'wolny rozładunek')
INSERT [dbo].[Orders] ([Id], [Recipe_Id], [ClientBuilding_Id], [Amount], [DateOfOrder], [PlannedDeliveryTime], [Deleted], [Deactivated], [Canceled], [Pump], [Notice]) VALUES (3, 12, 23, 10, NULL, NULL, NULL, NULL, NULL, 1, N'Notatka')
SET IDENTITY_INSERT [dbo].[Orders] OFF
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/30/2012 23:38:32 ******/
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/30/2012 23:38:32 ******/
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (1, 1, CAST(0x0000A089003F0C8E AS DateTime), CAST(0x0000A089003F0C8E AS DateTime), NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (2, 2, CAST(0x0000A09D00F870C2 AS DateTime), NULL, NULL, NULL, 7, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (3, 1, CAST(0x0000A09E00932A41 AS DateTime), NULL, NULL, NULL, 1, 2, 3, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (4, 1, CAST(0x0000A09E0093ACBC AS DateTime), NULL, NULL, NULL, 1, 3, 3, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (5, 1, CAST(0x0000A09E009583CC AS DateTime), NULL, NULL, NULL, 1, 1, 3, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (6, 3, CAST(0x0000A09E00B59514 AS DateTime), NULL, NULL, NULL, 1, 10, 1, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (7, 1, CAST(0x0000A09E0096A27F AS DateTime), NULL, NULL, NULL, 1, 2, 2, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (8, 1, CAST(0x0000A09E0096BCBE AS DateTime), NULL, NULL, NULL, 1, 3, 2, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (9, 2, CAST(0x0000A09E00AC2E23 AS DateTime), NULL, NULL, NULL, 5, 10, 1, NULL, NULL, NULL)
INSERT [dbo].[DeliveryNotes] ([Id], [Driver_Id], [DateDrawing], [DateOfArrival], [Canceled], [Drawer], [Car_Id], [Amount], [Order_Id], [Deleted], [Deactivated], [Number]) VALUES (10, 1, CAST(0x0000A09E00AC6760 AS DateTime), NULL, NULL, NULL, 1, 9, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
