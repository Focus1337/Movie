use reviefydb;

GO
CREATE TABLE Users
(
	user_id INT NOT NULL IDENTITY,
	password NVARCHAR(max) NOT NULL,
	email NVARCHAR(max) NOT NULL,
	first_name NVARCHAR(max) NOT NULL,
	second_name NVARCHAR(max) NOT NULL,
	register_date DATE NOT NULL,
	avatar_url NVARCHAR(max), -- url to avatar img 
	CONSTRAINT pk_user PRIMARY KEY(user_id)
)
GO

GO
CREATE TABLE Movies
(
	movie_id INT NOT NULL IDENTITY,
	title NVARCHAR(max) NOT NULL, 
	[length] INT NOT NULL check([length] >= 0),
	genre NVARCHAR(max) NOT NULL,
	realese_date DATE NOT NULL,
	rating FLOAT NOT NULL default(0),
	storyline TEXT NOT NULL,
	director NVARCHAR(max) NOT NULL default('unknown'),
	budget INT NOT NULL check(budget >= 0),
	country NVARCHAR(max) NOT NULL,
	[language] NVARCHAR(max) NOT NULL,
	company NVARCHAR(max) NOT NULL default('unknown'),
	poster_url NVARCHAR(max), -- url to poster img 


	CONSTRAINT pk_movie PRIMARY KEY(movie_id),
)
GO

GO
CREATE TABLE Reviews
(
	review_id INT NOT NULL IDENTITY,
	user_id INT NOT NULL, --FK (poka xz kak imenno)
	movie_id INT NOT NULL, --FK (poka xz kak imenno)
	[text] TEXT NOT NULL,
	review_date DATE NOT NULL, 
	rating INT NOT NULL DEFAULT(0),

	CONSTRAINT pk_review PRIMARY KEY(review_id),
	CONSTRAINT fk_review_user FOREIGN KEY(user_id)
		REFERENCES Users(user_id)
		on delete cascade on update cascade,
	CONSTRAINT fk_review_movie FOREIGN KEY(movie_id)
		REFERENCES Movies(movie_id)
		on delete cascade on update cascade
)
GO

GO
CREATE TABLE News
(
	news_id INT NOT NULL IDENTITY,
	poster_url NVARCHAR(max), -- url to poster img 
	title NVARCHAR(max) NOT NULL, 
	news_date DATE NOT NULL,
	[text] TEXT NOT NULL

	CONSTRAINT pk_news PRIMARY KEY(news_id)
)
GO