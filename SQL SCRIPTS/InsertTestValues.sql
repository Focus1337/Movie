use ReviefyDB

-- USERS
SELECT * FROM Users
INSERT INTO Users (user_id ,password, email, nickname, register_date, avatar_path)
VALUES(NEWID(), '123yuk456', 'maniaclord@bk.ru', 'Focus', '2021-12-01', 'google.com')

-- MOVIES
SELECT * FROM Movies

-- REVIEWS
SELECT * FROM Reviews



-- NEWS
SELECT * FROM News

INSERT INTO News
VALUES(NEWID(), 'https://www.taylordailypress.net/wp-content/uploads/2021/08/Its-official-The-Expendables-4-has-been-announced-with-Megan.jpg', 'Papich in The Expendables', '2021-11-21', 'The incredibly great, strong and adequate Vitaliy Tsal will star in the upcoming blockbuster "The Expendables 5." The Expendables 5 is an upcoming American action movie that is the fifth in the Expendables series. Scott Waugh was hired to direct, and the script was written by Spencer Cohen with revisions by Max Adams, John Joseph Connolly and Sylvester Stallone.')

INSERT INTO News
VALUES(NEWID(), 'https://blog.pdainternational.net/en-UK/wp-content/uploads/sites/8/2018/08/Blog-entrada-3-1.jpg', 'Reviefy is released', '2021-10-23', 'After 3 months of work we finally start our project. On our site you can leave various reviews for films, also you can do smth that you want. Im out of ideas to write smth here...')

INSERT INTO News
VALUES(NEWID(), 'https://techtoday.in.ua/wp-content/uploads/2020/10/programmer-working-on-computers.jpg', 'Beginning of work', '2021-09-03', 'Hello everyone! We started working on our project - Reviefy. The point of this site is that you can leave your opinion on different films, as well as communicate with different people. Thanks to your...')
