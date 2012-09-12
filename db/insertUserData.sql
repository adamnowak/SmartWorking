USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/11/2012 21:07:45 ******/
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Password], [PasswordSalz], [Phone], [Deleted], [Deactivated]) VALUES (1, N'Administrator', N'Administrator', N'l2QgcsY1HzXhMsy3uoIrcW0/lPk=', N'X80clJal8Qi96F34H6siQw==', N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 09/11/2012 21:07:45 ******/
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([Id], [Name], [Deleted], [Deactivated]) VALUES (1, N'Administrator', NULL, NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Deleted], [Deactivated]) VALUES (2, N'WOS', NULL, NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Deleted], [Deactivated]) VALUES (3, N'Operator', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 09/11/2012 21:07:45 ******/
INSERT [dbo].[UsersInRoles] ([User_Id], [Role_Id]) VALUES (1, 1)
