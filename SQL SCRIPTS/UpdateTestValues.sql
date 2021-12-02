use ReviefyDB

-- ALL SELECTS
SELECT * FROM Users
SELECT * FROM Movies
SELECT * FROM MoviePhotos
SELECT * FROM Reviews
SELECT * FROM News

-- MOVIEPHOTOS
UPDATE MoviePhotos
   SET
      background = '',
      photo1 = '',
      photo2 = '',
      photo3 = '',
      photo4 = '',
      photo5 = '',
      photo6 = '',
      photo7 = '',
      photo8 = '',
      photo9 = ''
WHERE movie_id = 'E68AE4EB-0BB6-4D7C-AA9B-4B346CBE95DB'
