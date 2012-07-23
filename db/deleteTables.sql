USE [SmartWorking]
GO
/****** Object:  ForeignKey [FK_Cars_Drivers]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Drivers]
GO
/****** Object:  ForeignKey [FK_ClientBuildings_Buildings]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Buildings]
GO
/****** Object:  ForeignKey [FK_ClientBuildings_Clients]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Clients]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Orders]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
/****** Object:  ForeignKey [FK_MaterialsDeliverer_Contractors]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialsProducer_Contractors]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_Orders_ClientBuildings]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_ClientBuildings]
GO
/****** Object:  ForeignKey [FK_Orders_Recipes]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Materials]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Recipes]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Orders]
GO
DROP TABLE [dbo].[DeliveryNotes]
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
DROP TABLE [dbo].[MaterialStocks]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_ClientBuildings]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Recipes]
GO
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
DROP TABLE [dbo].[RecipeComponents]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 07/22/2012 21:49:32 ******/
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsDeliverer_Contractors]
GO
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [FK_MaterialsProducer_Contractors]
GO
DROP TABLE [dbo].[Materials]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Drivers]
GO
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[ClientBuildings]    Script Date: 07/22/2012 21:49:31 ******/
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Buildings]
GO
ALTER TABLE [dbo].[ClientBuildings] DROP CONSTRAINT [FK_ClientBuildings_Clients]
GO
DROP TABLE [dbo].[ClientBuildings]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 07/22/2012 21:49:31 ******/
DROP TABLE [dbo].[Clients]
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 07/22/2012 21:49:31 ******/
DROP TABLE [dbo].[Contractors]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 07/22/2012 21:49:31 ******/
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 07/22/2012 21:49:32 ******/
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 07/22/2012 21:49:32 ******/
DROP TABLE [dbo].[Recipes]
GO
