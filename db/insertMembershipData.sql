USE [SmartWorking]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 07/14/2012 21:50:57 ******/
INSERT [dbo].[aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (N'/', N'/', N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', NULL)
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 07/14/2012 21:50:57 ******/
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 07/14/2012 21:50:57 ******/
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'common', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'health monitoring', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'membership', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'personalization', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'profile', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'role manager', N'1', 1)
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 07/14/2012 21:50:57 ******/
INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'8807e66b-2d29-4b4b-b33d-3dd9fb4af0eb', N'basia.wos', N'basia.wos', NULL, 0, CAST(0x0000A08E011AE32B AS DateTime))
INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'e45b13c9-7dd6-42d1-81d2-6254fde24868', N'operator', N'operator', NULL, 0, CAST(0x0000A08E011B0997 AS DateTime))
INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'aed3ab89-10e2-4393-b19a-336674c586ea', N'sylwester.wypych', N'sylwester.wypych', NULL, 0, CAST(0x0000A08E011D9C4F AS DateTime))
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 07/14/2012 21:50:57 ******/
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 07/14/2012 21:50:57 ******/
INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'c9c175d1-18a8-42eb-a18b-cd66848a7642', N'Administrator', N'administrator', NULL)
INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'667af872-c22d-4ee9-a19d-8cdc0fdf55b3', N'Operator', N'operator', NULL)
INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'00a3daa2-0b9e-4b97-aa48-bef66806fb6d', N'WOS', N'wos', NULL)
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 07/14/2012 21:50:57 ******/
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 07/14/2012 21:50:57 ******/
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 07/14/2012 21:50:57 ******/
INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'8807e66b-2d29-4b4b-b33d-3dd9fb4af0eb', N'Mmg9vgH6stPzIGyi2lLl8mPlE+4=', 1, N'QX0MrXHcgxfWb+YkRnnAXA==', NULL, N'basia.wos@gmail.com', N'basia.wos@gmail.com', N'co to wos', N'DSKbvY2FBlQXZCrraeg6NbnpwXw=', 1, 0, CAST(0x0000A08E011AE25C AS DateTime), CAST(0x0000A08E011AE32B AS DateTime), CAST(0x0000A08E011AE25C AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'e45b13c9-7dd6-42d1-81d2-6254fde24868', N'PxNjlNrGRh3+MgQRgWDcN8i6ecI=', 1, N'XwWlQ7TmfK0n7iFbwmtxUQ==', NULL, N'operator@gmail.com', N'operator@gmail.com', N'gdzie', N'Pnkhk1JkP1CidYABN8WJE2u7I4w=', 1, 0, CAST(0x0000A08E011B0908 AS DateTime), CAST(0x0000A08E011B0997 AS DateTime), CAST(0x0000A08E011B0908 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'1246f2e0-e2e6-487d-bf3a-3c105f42ee38', N'aed3ab89-10e2-4393-b19a-336674c586ea', N'1awCxSw6VFv+JEK4L2E1Ww+flR8=', 1, N'/QRGs67ACDn0i7vifCqFlA==', NULL, N'sylwester.wypych@gmail.com', N'sylwester.wypych@gmail.com', N'Numer bloku gdzie mieszkalismy razem', N'wAIZeWGNL7GGkdKmGU9eQUD72gg=', 1, 0, CAST(0x0000A08E011A6E58 AS DateTime), CAST(0x0000A08E011D9C4F AS DateTime), CAST(0x0000A08E011A6E58 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 07/14/2012 21:50:57 ******/
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 07/14/2012 21:50:57 ******/
