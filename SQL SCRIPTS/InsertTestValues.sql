use ReviefyDB

-- USERS
SELECT * FROM Users
INSERT INTO Users (user_id ,password, email, nickname, register_date, avatar_path)
VALUES(NEWID(), '123yuk456', 'maniaclord@bk.ru', 'Focus', '2021-12-01', 'google.com')

-- MOVIES
SELECT * FROM Movies
INSERT INTO Movies
VALUES	(NEWID(), 'Wrath of Man', 118, 'Action, Crime, Thriller', '2021-05-07', 8.8, 'Mysterious and wild-eyed, a new security guard for a cash truck surprises his co-workers when he unleashes precision skills during a heist. The crew is left wondering who he is and where he came from. Soon, the marksmans ultimate motive becomes clear as he takes dramatic and irrevocable steps to settle a score.', 'Guy Ritchie', 40, 'USA', 'English', 'Metro-Goldwyn-Mayer', 'https://m.media-amazon.com/images/M/MV5BYTA3MTdiOGMtY2EwNC00OTljLTg1YWItNmNkNDNlOThkOTFmXkEyXkFqcGdeQXVyMTA3MDk2NDg2._V1_.jpg'),
		(NEWID(), 'Red Notice', 117, 'Action, Comedies, Crime', '2021-11-04', 6.6, 'An FBI profiler pursuing the worlds most wanted art thief becomes his reluctant partner in crime to catch an elusive crook whos always one step ahead.', 'Rawson Marshall Thurber', 160, 'USA', 'English', 'Netflix', 'https://m.media-amazon.com/images/M/MV5BZmRjODgyMzEtMzIxYS00OWY2LTk4YjUtMGMzZjMzMTZiN2Q0XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg'),
		(NEWID(), 'Free Guy', 115, 'Action, Adventure, Comedies', '2021-08-13', 7.2, 'A bank teller discovers that hes actually an NPC inside a brutal, open world video game.', 'Shawn Levy', 120, 'USA', 'English', 'Maximum Effort', 'https://m.media-amazon.com/images/M/MV5BOTY2NzFjODctOWUzMC00MGZhLTlhNjMtM2Y2ODBiNGY1ZWRiXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_.jpg')


-- REVIEWS
SELECT * FROM Reviews



-- NEWS
SELECT * FROM News

INSERT INTO News
VALUES	(NEWID(), 'https://www.taylordailypress.net/wp-content/uploads/2021/08/Its-official-The-Expendables-4-has-been-announced-with-Megan.jpg', 'Papich in The Expendables', '2021-11-21', 'The incredibly great, strong and adequate Vitaliy Tsal will star in the upcoming blockbuster "The Expendables 5." The Expendables 5 is an upcoming American action movie that is the fifth in the Expendables series. Scott Waugh was hired to direct, and the script was written by Spencer Cohen with revisions by Max Adams, John Joseph Connolly and Sylvester Stallone.'),
		(NEWID(), 'https://blog.pdainternational.net/en-UK/wp-content/uploads/sites/8/2018/08/Blog-entrada-3-1.jpg', 'Reviefy is released', '2021-10-23', 'After 3 months of work we finally start our project. On our site you can leave various reviews for films, also you can do smth that you want. Im out of ideas to write smth here...'),
		(NEWID(), 'https://techtoday.in.ua/wp-content/uploads/2020/10/programmer-working-on-computers.jpg', 'Beginning of work', '2021-09-03', 'Hello everyone! We started working on our project - Reviefy. The point of this site is that you can leave your opinion on different films, as well as communicate with different people. Thanks to your...')
