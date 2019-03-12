CREATE PROCEDURE usp_GetArtist
(@pNombre NVARCHAR(100)
)
AS
BEGIN

	SELECT ArtistId, Name
	FROM Artist
	WHERE Name like @pNombre
END
GO
CREATE PROCEDURE usp_InsertArtist
(
@Name NVARCHAR(120)
)
AS
BEGIN
	INSERT INTO Artist (Name)
	VALUES(@Name)

	SELECT SCOPE_IDENTITY()	

END
GO

CREATE PROCEDURE usp_UpdateArtist
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

CREATE PROCEDURE usp_DeleteArtist
(
@Name NVARCHAR
)
AS
BEGIN
	DELETE
	FROM Artist 
	WHERE Name =@Name
END
GO
CREATE PROCEDURE usp_InsertArtistWithOutput
(
@Name NVARCHAR(120),
@ID INT OUTPUT
)
AS
BEGIN
	INSERT INTO Artist (Name)
	VALUES(@Name)

	set @ID = SCOPE_IDENTITY()	

END
GO


CREATE PROCEDURE USP_GetGenre
(@pNombre NVARCHAR(100)
)
AS
BEGIN

	SELECT GenreId, Name
	FROM Genre
	WHERE Name like @pNombre
END
GO

CREATE PROCEDURE usp_InsertGenre
(
@Name NVARCHAR(120)
)
AS
BEGIN
	INSERT INTO Genre (Name)
	VALUES(@Name)

	SELECT SCOPE_IDENTITY()	

END
GO

CREATE PROCEDURE usp_UpdateGenre
(
@Name NVARCHAR(120),
@GenreId INT 
)
AS
BEGIN
	UPDATE Genre
	SET Name = @Name
	where GenreId = @GenreId
	
END
GO

CREATE PROCEDURE usp_DeleteGenre
@Name NVARCHAR
AS
BEGIN
	DELETE
	FROM Genre
	WHERE Name = @Name
END
GO
SELECT TOP 10 * FROM Artist WITH (NOLOCK)
ORDER BY ArtistId DESC
GO
SELECT TOP 10 * FROM Artist
ORDER BY ArtistId DESC
GO

CREATE PROCEDURE usp_GetAlbum
(@pTitle NVARCHAR(160)
)
AS
BEGIN

	SELECT AlbumId, Title
	FROM Album
	WHERE Title like @pTitle
END
GO
/**/
CREATE PROCEDURE usp_InsertAlbum
(
@Title NVARCHAR(160),
@ArtistId INT
)
AS
BEGIN
	INSERT INTO Album (Title, ArtistId)
				VALUES(@Title, @ArtistId)
	SELECT SCOPE_IDENTITY()	
END
GO

CREATE PROCEDURE usp_UpdateAlbum
(
@AlbumId INT,
@Title NVARCHAR(160),
@ArtistId INT 
)
AS
BEGIN
	UPDATE Album
	SET Title = @Title, ArtistId= @ArtistId 
	where AlbumId = @AlbumId
	
END
GO

CREATE PROCEDURE usp_DeleteAlbum
@Title NVARCHAR(160)
AS
BEGIN
	DELETE
	FROM Album
	WHERE Title = @Title
END
GO

CREATE PROCEDURE usp_InsertCustomer
(
@FirstName NVARCHAR(40),
@LastName NVARCHAR(20),
@Company NVARCHAR(80),
@Address NVARCHAR(70),
@City NVARCHAR(40),
@State NVARCHAR(40),
@Country NVARCHAR(40),
@PostalCode NVARCHAR(10),
@Phone NVARCHAR(24),
@Fax NVARCHAR(24),
@Email NVARCHAR(60),
@SupportRepId INT
)
AS
BEGIN
	INSERT INTO Customer (FirstName, LastName, Company, Address, City, State, Country, PostalCode, Phone, Fax, Email, SupportRepId)
					VALUES(@FirstName, @LastName, @Company, @Address, @City, @State, @Country, @PostalCode,@Phone, @Fax, @Email, @SupportRepId )
	SELECT SCOPE_IDENTITY()	
END
GO
CREATE PROCEDURE usp_UpdateCustomer
(
@CustomerId INT,
@FirstName NVARCHAR(40),
@LastName NVARCHAR(20),
@Company NVARCHAR(80),
@Address NVARCHAR(70),
@City NVARCHAR(40),
@State NVARCHAR(40),
@Country NVARCHAR(40),
@PostalCode NVARCHAR(10),
@Phone NVARCHAR(24),
@Fax NVARCHAR(24),
@Email NVARCHAR(60),
@SupportRepId INT
)
AS
BEGIN
	UPDATE Customer
	SET FirstName = @FirstName, LastName=@LastName, Company=@Company, Address=@Address, City=@City, State=@State,
	 Country=@Country, PostalCode=@PostalCode, Phone=@Phone, Fax=@Fax, Email=@Email, SupportRepId=@SupportRepId 
	where CustomerId = @CustomerId
	
END
GO
CREATE PROCEDURE usp_DeleteCustomer
@Firstname NVARCHAR(40)
AS
BEGIN
	DELETE
	FROM Customer
	WHERE FirstName = @Firstname
END
GO
CREATE PROCEDURE usp_GetTrack
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
 exec usp_GetTrack '%'


CREATE PROCEDURE usp_GeTracks
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




















