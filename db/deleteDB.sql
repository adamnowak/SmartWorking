USE [SmartWorking]
GO
/****** Object:  ForeignKey [FK_Buildings_Contractors]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Contractors]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Buildings]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Buildings]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Cars]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Drivers]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
/****** Object:  ForeignKey [FK_DeliveryNotes_Recipes]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Recipes]
GO
/****** Object:  ForeignKey [FK_MaterialStocks_Materails]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Materials]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
/****** Object:  ForeignKey [FK_RecipeComponents_Recipes]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Buildings]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Buildings]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Cars]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Drivers]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Drivers]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryNotes_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]'))
ALTER TABLE [dbo].[DeliveryNotes] DROP CONSTRAINT [FK_DeliveryNotes_Recipes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNotes]') AND type in (N'U'))
DROP TABLE [dbo].[DeliveryNotes]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Contractors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Contractors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[MaterialStocks]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaterialStocks_Materails]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaterialStocks]'))
ALTER TABLE [dbo].[MaterialStocks] DROP CONSTRAINT [FK_MaterialStocks_Materails]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaterialStocks]') AND type in (N'U'))
DROP TABLE [dbo].[MaterialStocks]
GO
/****** Object:  Table [dbo].[RecipeComponents]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Materials]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Materials]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RecipeComponents_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RecipeComponents]'))
ALTER TABLE [dbo].[RecipeComponents] DROP CONSTRAINT [FK_RecipeComponents_Recipes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeComponents]') AND type in (N'U'))
DROP TABLE [dbo].[RecipeComponents]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recipes]') AND type in (N'U'))
DROP TABLE [dbo].[Recipes]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[Contractors]    Script Date: 06/12/2012 22:12:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contractors]') AND type in (N'U'))
DROP TABLE [dbo].[Contractors]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drivers]') AND type in (N'U'))
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/12/2012 22:12:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
DROP TABLE [dbo].[Materials]
GO
