USE [SmartWorking]
GO
/****** Object:  ForeignKey [FK_Cars_Drivers]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Drivers]
GO
/****** Object:  ForeignKey [FK_ClientBuildings_Buildings]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientBuildings_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientBuildings]'))
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Buildings]
GO
/****** Object:  ForeignKey [FK_ClientBuildings_Clients]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientBuildings_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientBuildings]'))
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Clients]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Orders]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
/****** Object:  ForeignKey [FK_MaterialsDeliverer_Contractors]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsDeliverer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialsProducer_Contractors]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsProducer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_Orders_ClientBuildings]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_ClientBuildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_ClientBuildings]
GO
/****** Object:  ForeignKey [FK_Orders_Recipes]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Materials]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Recipes]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]') AND type in (N'U'))
DROP TABLE [dbo].[DeliveryNotes]
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaterialStocks]') AND type in (N'U'))
DROP TABLE [dbo].[MaterialStocks]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_ClientBuildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_ClientBuildings]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeComponents]') AND type in (N'U'))
DROP TABLE [dbo].[RecipeComponents]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsDeliverer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialsProducer_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Materials]'))
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
DROP TABLE [dbo].[Materials]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Drivers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[ClientBuildings]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientBuildings_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientBuildings]'))
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Buildings]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientBuildings_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientBuildings]'))
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Clients]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientBuildings]') AND type in (N'U'))
DROP TABLE [dbo].[ClientBuildings]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
DROP TABLE [dbo].[Clients]
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contractors]') AND type in (N'U'))
DROP TABLE [dbo].[Contractors]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/24/2012 21:53:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drivers]') AND type in (N'U'))
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/24/2012 21:53:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recipes]') AND type in (N'U'))
DROP TABLE [dbo].[Recipes]
GO