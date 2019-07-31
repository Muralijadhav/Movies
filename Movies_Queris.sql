USE [Movies]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 31-Jul-19 12:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [nvarchar](max) NOT NULL,
	[Sex] [nvarchar](max) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Bio] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Actors] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MovieActors]    Script Date: 31-Jul-19 12:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActors](
	[Movie_MovieId] [int] NOT NULL,
	[Actor_ActorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MovieActors] PRIMARY KEY CLUSTERED 
(
	[Movie_MovieId] ASC,
	[Actor_ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movies]    Script Date: 31-Jul-19 12:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [nvarchar](max) NOT NULL,
	[YearOfRelease] [datetime] NOT NULL,
	[Plot] [nvarchar](max) NOT NULL,
	[PosterImage] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovieActors_dbo.Actors_Actor_ActorId] FOREIGN KEY([Actor_ActorId])
REFERENCES [dbo].[Actors] ([ActorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_dbo.MovieActors_dbo.Actors_Actor_ActorId]
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MovieActors_dbo.Movies_Movie_MovieId] FOREIGN KEY([Movie_MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_dbo.MovieActors_dbo.Movies_Movie_MovieId]
GO
