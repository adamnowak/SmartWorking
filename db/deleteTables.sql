USE [SmartWorking]
GO
/****** Object:  ForeignKey [FK_Buildings_Clients]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Clients]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Orders]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
/****** Object:  ForeignKey [FK_Drivers_Cars]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Drivers] DROP CONSTRAINT [FK_Drivers_Cars]
GO
/****** Object:  ForeignKey [FK_MaterialsDeliverer_Contractors]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialsProducer_Contractors]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_Orders_Buildings]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Buildings]
GO
/****** Object:  ForeignKey [FK_Orders_Recipes]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Materials]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Recipes]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
DROP TABLE [dbo].[DeliveryNotes]
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
DROP TABLE [dbo].[MaterialStocks]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Buildings]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
DROP TABLE [dbo].[RecipeComponents]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Drivers] DROP CONSTRAINT [FK_Drivers_Cars]
GO
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
DROP TABLE [dbo].[Materials]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Clients]
GO
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[CarTypes]    Script Date: 06/27/2012 20:05:23 ******/
ALTER TABLE [dbo].[CarTypes] DROP CONSTRAINT [FK_CarTypes_Cars]
GO
DROP TABLE [dbo].[CarTypes]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 06/27/2012 20:05:23 ******/
DROP TABLE [dbo].[Clients]
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/27/2012 20:05:23 ******/
DROP TABLE [dbo].[Contractors]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 06/27/2012 20:05:23 ******/
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/27/2012 20:05:23 ******/
DROP TABLE [dbo].[Recipes]
GO
