/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[Author]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[DocumentTypeID]
      ,[Edition]
      ,[Issue]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[Title]
      ,[URL]
      ,[Volume]
      ,[Year]
      ,[Publisher]
      ,[PublisherLocation]
      ,[ChapterTitle]
      ,[BookEditor]
      ,[DOI]
      ,[DHFNumber]
  FROM [Claims_Prod].[dbo].[Documents]
  order by CreatedBy, CreatedDate desc;
 


--select * from [audit].[Documents]
--  order by CreatedBy, CreatedDate desc