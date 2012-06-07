USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[InternalName] [varchar](50) NULL,
 CONSTRAINT [PK_Materialy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drivers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Drivers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[Phone] [nchar](10) NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contractors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contractors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[Phone] [nchar](9) NULL,
 CONSTRAINT [PK_Contractors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [nchar](10) NULL,
	[Name] [varchar](50) NULL,
	[InternalName] [varchar](10) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Cars', N'COLUMN',N'RegistrationNumber'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numer rejestracyjny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cars', @level2type=N'COLUMN',@level2name=N'RegistrationNumber'
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recipes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[InternalName] [varchar](50) NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecipeSpecifications]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeSpecifications]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RecipeSpecifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Material_Id] [int] NULL,
	[Recipe_Id] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_FormulaRecepty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaterialStocks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MaterialStocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Material_Id] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_ZapasyMaterialow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contractor_Id] [int] NOT NULL,
	[City] [varchar](50) NULL,
	[Street] [varchar](50) NULL,
	[HouseNo] [varchar](50) NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/07/2012 21:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Building_Id] [int] NULL,
	[Recipe_Id] [int] NULL,
	[Amount] [float] NULL,
	[Driver_Id] [int] NULL,
	[DateDrawing] [datetime] NULL,
	[DateOfArrival] [datetime] NULL,
	[Canceled] [datetime] NULL,
	[Drawer] [varchar](50) NULL,
	[Car_Id] [int] NULL,
 CONSTRAINT [PK_DeliveryNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DeliveryNotes', N'COLUMN',N'DateDrawing'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data wystawienia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryNotes', @level2type=N'COLUMN',@level2name=N'DateDrawing'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DeliveryNotes', N'COLUMN',N'DateOfArrival'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data otrzymania' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryNotes', @level2type=N'COLUMN',@level2name=N'DateOfArrival'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DeliveryNotes', N'COLUMN',N'Drawer'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wystawiajacy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryNotes', @level2type=N'COLUMN',@level2name=N'Drawer'
GO
/****** Object:  ForeignKey [FK_Buildings_Contractors]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Contractors] FOREIGN KEY([Contractor_Id])
REFERENCES [dbo].[Contractors] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Contractors]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Buildings]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Buildings] FOREIGN KEY([Building_Id])
REFERENCES [dbo].[Buildings] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Buildings]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Cars] FOREIGN KEY([Car_Id])
REFERENCES [dbo].[Cars] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Drivers] FOREIGN KEY([Driver_Id])
REFERENCES [dbo].[Drivers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Recipes]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Recipes] FOREIGN KEY([Recipe_Id])
REFERENCES [dbo].[Recipes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Recipes]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks]  WITH CHECK ADD  CONSTRAINT [FK_MaterialStocks_Materails] FOREIGN KEY([Material_Id])
REFERENCES [dbo].[Materials] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] CHECK CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_RecipeSpecifications_Materials]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeSpecifications_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeSpecifications]'))
ALTER TABLE [dbo].[RecipeSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_RecipeSpecifications_Materials] FOREIGN KEY([Material_Id])
REFERENCES [dbo].[Materials] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeSpecifications_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeSpecifications]'))
ALTER TABLE [dbo].[RecipeSpecifications] CHECK CONSTRAINT [FK_RecipeSpecifications_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeSpecifications_Recipes]    Script Date: 06/07/2012 21:20:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeSpecifications_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeSpecifications]'))
ALTER TABLE [dbo].[RecipeSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_RecipeSpecifications_Recipes] FOREIGN KEY([Recipe_Id])
REFERENCES [dbo].[Recipes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeSpecifications_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeSpecifications]'))
ALTER TABLE [dbo].[RecipeSpecifications] CHECK CONSTRAINT [FK_RecipeSpecifications_Recipes]
GO
