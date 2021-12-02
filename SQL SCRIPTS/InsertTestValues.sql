use ReviefyDB

-- ALL SELECTS
SELECT * FROM Users
SELECT * FROM Movies
SELECT * FROM MoviePhotos
SELECT * FROM Reviews
SELECT * FROM News

-- USERS
INSERT INTO Users (user_id ,password, email, nickname, register_date, avatar_path)
VALUES	(NEWID(), 'focus', 'maniaclord@bk.ru', 'Focus', '2021-12-01', 'https://i.imgur.com/3n0g5q0.png'),
		(NEWID(), 'arthas', 'arthas@gmail.com', 'Arthas', '2021-12-01', 'https://i.imgur.com/3n0g5q0.png')
		

		
-- MOVIES
INSERT INTO Movies
VALUES	(NEWID(), 'Wrath of Man', 118, 'Action, Crime, Thriller', '2021-05-07', 8.8, 'Mysterious and wild-eyed, a new security guard for a cash truck surprises his co-workers when he unleashes precision skills during a heist. The crew is left wondering who he is and where he came from. Soon, the marksmans ultimate motive becomes clear as he takes dramatic and irrevocable steps to settle a score.', 'Guy Ritchie', 40, 'USA', 'English', 'Metro-Goldwyn-Mayer', 'https://m.media-amazon.com/images/M/MV5BYTA3MTdiOGMtY2EwNC00OTljLTg1YWItNmNkNDNlOThkOTFmXkEyXkFqcGdeQXVyMTA3MDk2NDg2._V1_.jpg', 'https://www.youtube.com/watch?v=EFYEni2gsK0'),
		(NEWID(), 'Red Notice', 117, 'Action, Comedies, Crime', '2021-11-04', 6.6, 'An FBI profiler pursuing the worlds most wanted art thief becomes his reluctant partner in crime to catch an elusive crook whos always one step ahead.', 'Rawson Marshall Thurber', 160, 'USA', 'English', 'Netflix', 'https://m.media-amazon.com/images/M/MV5BZmRjODgyMzEtMzIxYS00OWY2LTk4YjUtMGMzZjMzMTZiN2Q0XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg', 'https://www.youtube.com/watch?v=Pj0wz7zu3Ms'),
		(NEWID(), 'Free Guy', 115, 'Action, Adventure, Comedies', '2021-08-13', 7.2, 'A bank teller discovers that hes actually an NPC inside a brutal, open world video game.', 'Shawn Levy', 120, 'USA', 'English', 'Maximum Effort', 'https://m.media-amazon.com/images/M/MV5BOTY2NzFjODctOWUzMC00MGZhLTlhNjMtM2Y2ODBiNGY1ZWRiXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_.jpg', 'https://www.youtube.com/watch?v=X2m-08cOAbc')

INSERT INTO Movies
VALUES	(NEWID(), 'Zalupka', 165, 'Action, Adventure, Comedies', '2021-12-02', 9.2, 'test test test', 'Test Test', 200, 'USA', 'English', 'Test', 'test', 'test')



-- MOVIEPHOTOS
INSERT INTO MoviePhotos
VALUES	(NEWID(), 'ECD826E4-0526-4020-9121-8DCCE47C110A', 
					'https://www.hollywoodreporter.com/wp-content/uploads/2021/05/058_WOM_FP_00022-copy.jpg', 
					'https://www.denofgeek.com/wp-content/uploads/2021/05/Jason-Statham-and-Josh-Harnett-in-Wrath-of-Man.jpeg',
					'https://www.hollywoodreporter.com/wp-content/uploads/2021/05/058_WOM_FP_00022-copy.jpg',
					'https://storage.googleapis.com/orchestra-cafe-7jp1kqsp/uploads/2021/03/4d7411be-jason-statham-wrath-of-man.jpg',
					'https://media-cldnry.s-nbcnews.com/image/upload/t_fit-760w,f_auto,q_auto:best/newscms/2021_18/3470256/210504-jason-statham-wrath-of-man-ac-818p.jpg',
					'https://lh3.googleusercontent.com/proxy/HgZ0jrrzRvlxdT-_be3qmZlMqikKVZDRv77ftfuVr-KnqyTIKQdGBwnxUgLcoRYA8K86l8Fml-AbStHh5byw2YBtsTyYhS8pmCGc2zim4ONQLN4Ypg',
					'https://www.slashfilm.com/img/gallery/wrath-of-man-trailer/intro-import.jpg',
					'https://itc.ua/wp-content/uploads/2021/05/1-9-770x513.jpg',
					'https://glamadelaide.com.au/wp-content/uploads/2021/05/Wrath-of-Man.jpeg',
					'https://www.rollingstone.com/wp-content/uploads/2021/03/163_WOM_FP_00076_rgbc.jpg'),	
		(NEWID(), '3F213609-99E1-4929-9F8E-CCBC807CB828', 
					'', 
					'',
					'',
					'',
					'',
					'',
					'',
					'',
					'',
					'')
INSERT INTO MoviePhotos
VALUES(NEWID(), 'E68AE4EB-0BB6-4D7C-AA9B-4B346CBE95DB', default, default,default,default,default,default,default,default,default,default)



-- REVIEWS
INSERT INTO Reviews
VALUES (NEWID(), 'E0FE7A6E-B6EB-4338-9EF9-E2B4B6DDD44F', 'E89416F9-7860-48F8-8BD8-782A6666BD9D', 'This is definitely not your average Guy Ritchie film. It is not light-hearted, albeit there is some slick dialogues. It has no comic appeal, albeit there is a bit of dry humor. Think of shortened edition of Michel Manns "Heat" rather than "Snatch" or "Lock, Stock And Two Smoking Barrels", and youll got some understanding of what its all about.

Jason Statham is perfectly fitting for the role of mysterious H., a character with dark past and blurred present. Again, its not Statham typical B-movie action performance, since here thriller for the most part prevails over action. Its not entirely original work: Ritchies film based on French Le Convoyeur (2004), but its more of re-imagning than a direct copy or a straitforward remake.

Starts like action-comedy, but then getting more and more dark, as new elements of the story introduced. At some moments plot is a bit hard to follow due to non-linear structure, but the basic points are always intact. Some subplots seems lost by the third act, and its preventing film from being great. However, for the most part its a very soild, if unusual, effort from Ritchie entetring to a more mature ground. In the end, its a suspenseful heist movie involving betrayal, family tragedy and a huge, long, mercialess gunfight in the final act.', '2021-12-02', 8, 14340)



-- NEWS
INSERT INTO News
VALUES	(NEWID(), 'https://www.taylordailypress.net/wp-content/uploads/2021/08/Its-official-The-Expendables-4-has-been-announced-with-Megan.jpg', 'Papich in The Expendables', '2021-11-21', 'The incredibly great, strong and adequate Vitaliy Tsal will star in the upcoming blockbuster "The Expendables 5." The Expendables 5 is an upcoming American action movie that is the fifth in the Expendables series. Scott Waugh was hired to direct, and the script was written by Spencer Cohen with revisions by Max Adams, John Joseph Connolly and Sylvester Stallone.'),
		(NEWID(), 'https://blog.pdainternational.net/en-UK/wp-content/uploads/sites/8/2018/08/Blog-entrada-3-1.jpg', 'Reviefy is released', '2021-10-23', 'After 3 months of work we finally start our project. On our site you can leave various reviews for films, also you can do smth that you want. Im out of ideas to write smth here...'),
		(NEWID(), 'https://techtoday.in.ua/wp-content/uploads/2020/10/programmer-working-on-computers.jpg', 'Beginning of work', '2021-09-03', 'Hello everyone! We started working on our project - Reviefy. The point of this site is that you can leave your opinion on different films, as well as communicate with different people. Thanks to your...')
