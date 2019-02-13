CREATE PROCEDURE usp_GetArtist
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
CREATE PROCEDURE usp_InsertArtits
(
@Name NVARCHAR(120)
)
AS
BEGIN
	
	INSERT INTO Artist(Name)
	VALUES(@Name)

	SELECT SCOPE_IDENTITY()

END

