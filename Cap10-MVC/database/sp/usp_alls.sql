USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetArtist]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetArtist]
(
	@pNombre NVARCHAR(100)
)
AS
BEGIN

	SELECT ArtistId,Name 
	FROM Artist
	WHERE Name like @pNombre

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GeTracks]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GeTracks]
(
@TrackName NVARCHAR(200)
)
AS
BEGIN
SELECT  C.TrackId, C.Name AS TrackName, 
		C.AlbumId, A.Title, 
		C.MediaTypeId, E.Name AS MediaTypeName, 
		C.GenreId, D.Name AS GenreName, C.Composer, B.ArtistId, 
        B.Name AS ArtistName, C.Milliseconds, C.Bytes, C.UnitPrice
FROM    dbo.Album AS A INNER JOIN
        dbo.Artist AS B ON A.ArtistId = B.ArtistId INNER JOIN
        dbo.Track AS C ON A.AlbumId = C.AlbumId INNER JOIN
        dbo.Genre AS D ON C.GenreId = D.GenreId INNER JOIN
        dbo.MediaType AS E ON C.MediaTypeId = E.MediaTypeId
WHERE	C.Name LIKE @TrackName

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTrack]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetTrack]
(
@name NVARCHAR(200)
)
AS
BEGIN
SELECT      A.TrackId, A.Name as TrackName,
	A.AlbumId, B.Title, A.MediaTypeId,
	 F.Name AS MediaTypeName, A.GenreId, D.Name AS GenreName, B.ArtistId, 
            C.Name AS ArtistName
FROM        dbo.Track AS A INNER JOIN
    dbo.Album AS B ON A.AlbumId =  B.AlbumId INNER JOIN
    dbo.Artist AS C ON B.ArtistId = C.ArtistId INNER JOIN
    dbo.Genre AS D ON A.GenreId = D.GenreId INNER JOIN
    dbo.MediaType AS F ON A.MediaTypeId = F.MediaTypeId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertArtist]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertArtist]
(
@Name NVARCHAR(120)
)
AS
BEGIN
	
	INSERT INTO Artist(Name)
	VALUES(@Name)

	SELECT SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertArtistWithOutput]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertArtistWithOutput]
(
@Name NVARCHAR(120),
@ID INT OUTPUT
)
AS
BEGIN
	
	INSERT INTO Artist(Name)
	VALUES(@Name)

	SET @ID = SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateArtist]    Script Date: 12/03/2019 10:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateArtist]
(
@Name NVARCHAR(120),
@ID INT
)
AS
BEGIN
	
	UPDATE Artist
	SET [Name] = @Name
	WHERE ArtistId = @ID


END
GO
