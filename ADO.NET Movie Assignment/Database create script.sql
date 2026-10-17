


CREATE DATABASE AdoMovies;

USE AdoMovies;


CREATE TABLE [Genres] (
  [Id] integer PRIMARY KEY IDENTITY(1,1),
  [GenreName] varchar(100) NOT NULL
)
GO

CREATE TABLE [Movies] (
  [Id] integer PRIMARY KEY IDENTITY(1,1),
  [GenreId] integer NOT NULL,
  [MovieTitle] varchar(250) NOT NULL
)
GO

ALTER TABLE [Movies] ADD CONSTRAINT [MovieGenre] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id])
GO


INSERT INTO [Genres] (Id, GenreName)
VALUES (1, 'Action');
INSERT INTO [Genres] (Id, GenreName)
VALUES (2, 'Sci-Fi');
INSERT INTO [Genres] (Id, GenreName)
VALUES (3, 'Romance');
INSERT INTO [Genres] (Id, GenreName)
VALUES (4, 'Horror');
INSERT INTO [Genres] (Id, GenreName)
VALUES (5, 'Fantasy');


INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (1, 1 ,'Mad Max');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (2, 1 ,'Die Hard');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (3, 2,'Avatar');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (4, 2,'2001: A Space Odyssey');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (5, 3,'Titanic');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (6, 4,'The Shining');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (7, 5,'Spirited Away');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (8, 5,'The Lord of the Rings: The Fellowship of the Ring');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (9, 5,'The Lord of the Rings: The Two Towers');
INSERT INTO [Movies] (Id, GenreId, MovieTitle)
VALUES (10, 5,'The Lord of the Rings: The Return of the King');