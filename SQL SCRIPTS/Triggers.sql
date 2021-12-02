GO
CREATE TRIGGER Movies_INSERT
ON Movies
INSTEAD OF INSERT
AS 
INSERT INTO Movies
VALUES(
		(SELECT movie_id FROM inserted), 
		(SELECT title FROM inserted),
		(SELECT duration FROM inserted),
		(SELECT genre FROM inserted),
		(SELECT release_date FROM inserted),
		(SELECT rating FROM inserted),
		(SELECT storyline FROM inserted),
		(SELECT director FROM inserted),
		(SELECT budget FROM inserted),
		(SELECT country FROM inserted),
		(SELECT [language] FROM inserted),
		(SELECT company FROM inserted),
		(SELECT poster_path FROM inserted),
		(SELECT trailer_path FROM inserted));

INSERT INTO MoviePhotos
VALUES(NEWID(), (SELECT movie_id FROM inserted), default, default,default,default,default,default,default,default,default,default);
GO
