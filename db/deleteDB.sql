USE [SmartWorking]
GO
/****** Object:  ForeignKey [FK_Buildings_Contractors]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Contractors]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Buildings]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Buildings]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Recipes]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Recipes]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 06/07/2012 23:38:59 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_RecipeSpecifications_Materials]    Script Date: 06/07/2012 23:38:59 ******/
ALTER TABLE [dbo].[RecipeSpecifications] DROP CONSTRAINT [FK_RecipeSpecifications_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeSpecifications_Recipes]    Script Date: 06/07/2012 23:38:59 ******/
ALTER TABLE [dbo].[RecipeSpecifications] DROP CONSTRAINT [FK_RecipeSpecifications_Recipes]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Buildings]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Recipes]
GO
DROP TABLE [dbo].[DeliveryNotes]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/07/2012 23:38:58 ******/
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Contractors]
GO
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/07/2012 23:38:59 ******/
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
DROP TABLE [dbo].[MaterialStocks]
GO
/****** Object:  Table [dbo].[RecipeSpecifications]    Script Date: 06/07/2012 23:38:59 ******/
ALTER TABLE [dbo].[RecipeSpecifications] DROP CONSTRAINT [FK_RecipeSpecifications_Materials]
GO
ALTER TABLE [dbo].[RecipeSpecifications] DROP CONSTRAINT [FK_RecipeSpecifications_Recipes]
GO
DROP TABLE [dbo].[RecipeSpecifications]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/07/2012 23:38:59 ******/
DROP TABLE [dbo].[Recipes]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 06/07/2012 23:38:58 ******/
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/07/2012 23:38:58 ******/
DROP TABLE [dbo].[Contractors]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/07/2012 23:38:59 ******/
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/07/2012 23:38:59 ******/
DROP TABLE [dbo].[Materials]
GO
