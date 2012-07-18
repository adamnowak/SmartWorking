USE [SmartWorking]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drivers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Drivers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NULL,
	[Surname] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[InternalName] [nvarchar](50) NULL,
	[Deleted] [datetime] NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recipes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NULL,
	[InternalName] [nvarchar](50) NULL,
	[Number] [nvarchar](10) NULL,
	[Granulation] [nvarchar](10) NULL,
	[Consistency] [nvarchar](10) NULL,
	[ConcreteClass] [nchar](10) NULL,
	[Deleted] [datetime] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Recipes', N'COLUMN',N'Granulation'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ziarnistosc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Recipes', @level2type=N'COLUMN',@level2name=N'Granulation'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Recipes', N'COLUMN',N'Consistency'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konsystencja' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Recipes', @level2type=N'COLUMN',@level2name=N'Consistency'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Recipes', N'COLUMN',N'ConcreteClass'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Klasa betonu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Recipes', @level2type=N'COLUMN',@level2name=N'ConcreteClass'
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contractors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contractors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InternalName] [nvarchar](50) NULL,
	[Name] [nvarchar](150) NULL,
	[ZIPCode] [nvarchar](10) NULL,
	[City] [nvarchar](70) NULL,
	[Street] [nvarchar](70) NULL,
	[HouseNo] [nvarchar](50) NULL,
	[Deleted] [datetime] NULL,
	[Phone] [nvarchar](10) NULL,
 CONSTRAINT [PK_Contractors_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InternalName] [nvarchar](50) NULL,
	[NIP] [nvarchar](20) NULL,
	[Name] [nvarchar](70) NULL,
	[City] [nvarchar](70) NULL,
	[Street] [nvarchar](70) NULL,
	[ZIPCode] [nvarchar](10) NULL,
	[HouseNo] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Deleted] [datetime] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Contractors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Producer_Id] [int] NULL,
	[Deliverer_Id] [int] NULL,
	[InternalName] [nvarchar](50) NULL,
	[Deleted] [datetime] NULL,
 CONSTRAINT [PK_Materialy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [nvarchar](20) NULL,
	[Name] [nvarchar](50) NULL,
	[InternalName] [nvarchar](50) NULL,
	[CarType] [int] NULL,
	[Deleted] [datetime] NULL,
	[Capacity] [float] NULL,
	[TransportType] [int] NULL,
	[Driver_Id] [int] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Cars', N'COLUMN',N'RegistrationNumber'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numer rejestracyjny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cars', @level2type=N'COLUMN',@level2name=N'RegistrationNumber'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Cars', N'COLUMN',N'CarType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 - Betonomieszarka; 2 - Pompogruszka; 3 - Wywrotka; 4 - inna' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cars', @level2type=N'COLUMN',@level2name=N'CarType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Cars', N'COLUMN',N'TransportType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 - firmowy; 2 - wynajety; 3 - odbiur wlasny' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cars', @level2type=N'COLUMN',@level2name=N'TransportType'
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Client_Id] [int] NULL,
	[InternalName] [nvarchar](50) NULL,
	[ZIPCode] [nvarchar](10) NULL,
	[City] [nvarchar](70) NULL,
	[Street] [nvarchar](70) NULL,
	[Phone] [nvarchar](20) NULL,
	[ContactPerson] [nvarchar](70) NULL,
	[ContactPersonPhone] [nvarchar](20) NULL,
	[HouseNo] [nvarchar](50) NULL,
	[Deleted] [datetime] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeComponents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RecipeComponents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Material_Id] [int] NULL,
	[Recipe_Id] [int] NULL,
	[Amount] [float] NULL,
	[Deleted] [datetime] NULL,
 CONSTRAINT [PK_RecipeComponents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[Recipe_Id] [int] NULL,
	[Building_Id] [int] NULL,
	[Amount] [float] NULL,
	[DateOfOrder] [datetime] NULL,
	[Canceled] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Orders', N'COLUMN',N'Amount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ilosc zamówienia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'Amount'
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/18/2012 16:41:50 ******/
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
	[Deleted] [datetime] NULL,
 CONSTRAINT [PK_ZapasyMaterialow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/18/2012 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Driver_Id] [int] NULL,
	[DateDrawing] [datetime] NULL,
	[DateOfArrival] [datetime] NULL,
	[Canceled] [datetime] NULL,
	[Drawer] [nvarchar](50) NULL,
	[Car_Id] [int] NULL,
	[Amount] [float] NULL,
	[Order_Id] [int] NULL,
 CONSTRAINT [PK_DeliveryNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
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
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DeliveryNotes', N'COLUMN',N'Amount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ilosc wydana przy tej wz''tce' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DeliveryNotes', @level2type=N'COLUMN',@level2name=N'Amount'
GO
/****** Object:  ForeignKey [FK_Buildings_Clients]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Clients] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Clients]
GO
/****** Object:  ForeignKey [FK_Cars_Drivers]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Drivers] FOREIGN KEY([Driver_Id])
REFERENCES [dbo].[Drivers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Cars] FOREIGN KEY([Car_Id])
REFERENCES [dbo].[Cars] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Drivers] FOREIGN KEY([Driver_Id])
REFERENCES [dbo].[Drivers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Orders]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Orders] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Orders] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Orders]
GO
/****** Object:  ForeignKey [FK_MaterialsDeliverer_Contractors]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsDeliverer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_MaterialsDeliverer_Contractors] FOREIGN KEY([Deliverer_Id])
REFERENCES [dbo].[Contractors] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsDeliverer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialsProducer_Contractors]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsProducer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_MaterialsProducer_Contractors] FOREIGN KEY([Producer_Id])
REFERENCES [dbo].[Contractors] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsProducer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks]  WITH CHECK ADD  CONSTRAINT [FK_MaterialStocks_Materails] FOREIGN KEY([Material_Id])
REFERENCES [dbo].[Materials] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] CHECK CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_Orders_Buildings]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Buildings] FOREIGN KEY([Building_Id])
REFERENCES [dbo].[Buildings] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Buildings]
GO
/****** Object:  ForeignKey [FK_Orders_Recipes]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Recipes] FOREIGN KEY([Recipe_Id])
REFERENCES [dbo].[Recipes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Recipes]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Materials]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents]  WITH CHECK ADD  CONSTRAINT [FK_RecipeComponents_Materials] FOREIGN KEY([Material_Id])
REFERENCES [dbo].[Materials] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] CHECK CONSTRAINT [FK_RecipeComponents_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Recipes]    Script Date: 07/18/2012 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents]  WITH CHECK ADD  CONSTRAINT [FK_RecipeComponents_Recipes] FOREIGN KEY([Recipe_Id])
REFERENCES [dbo].[Recipes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] CHECK CONSTRAINT [FK_RecipeComponents_Recipes]
GO
