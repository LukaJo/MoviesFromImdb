USE [Movies]
GO
/****** Object:  Table [dbo].[Imdb]    Script Date: 25.12.2018 14:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Imdb](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[imdbRating] [varchar](50) NULL,
	[Runtime] [varchar](50) NULL,
	[Genre] [varchar](50) NULL,
	[Actors] [varchar](100) NULL,
	[Plot] [varchar](500) NULL,
	[Metascore] [varchar](50) NULL,
	[Poster] [varchar](150) NULL,
	[Watched] [varchar](1) NULL,
        [Trailer] [varchar](100) NULL,
        [Image] [image] NULL,
 CONSTRAINT [PK_Imdb] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AddNewMovie]    Script Date: 25.12.2018 14:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewMovie]  
(  
   @Title varchar (50),  
   @Year varchar (50),  
   @imdbRating varchar (50),
   @Runtime varchar (50),  
   @Genre varchar (50),  
   @Actors varchar (100),
   @Plot varchar (500),  
   @Metascore varchar (50),  
   @Poster varchar (150),
   @Image image,
   @Trailer varchar (100)     
)  
AS  
IF NOT EXISTS(SELECT Title FROM Imdb WHERE Title = @Title and Year = @Year)
BEGIN  

   INSERT INTO [dbo].[Imdb]
           ([Title]
           ,[Year]
           ,[imdbRating]
           ,[Runtime]
           ,[Genre]
           ,[Actors]
           ,[Plot]
           ,[Metascore]
           ,[Poster]
           ,[Watched]
		   ,[Image]
		   ,[Trailer]
		   )
     VALUES
           (@Title,@Year,@imdbRating,@Runtime,@Genre,@Actors,@Plot,@Metascore,@Poster,'N',@Image,@Trailer)

END  









GO
/****** Object:  StoredProcedure [dbo].[ChangeWatchedStatus]    Script Date: 25.12.2018 14:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeWatchedStatus]  
(  
   @MovieId int  
  
)  
AS  

BEGIN  

UPDATE [dbo].[Imdb]
   SET Watched = 'Y'
 WHERE MovieId = @MovieId;

END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteMovie]    Script Date: 25.12.2018 14:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMovie]  
(  
   @MovieId int  
  
)  
AS  

BEGIN  

DELETE FROM [dbo].[Imdb]
      WHERE MovieId = @MovieId;

END  
GO
/****** Object:  StoredProcedure [dbo].[GetAllMovies]    Script Date: 25.12.2018 14:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMovies]  

AS  

BEGIN  

SELECT * FROM Imdb order by Title;

END  
GO
