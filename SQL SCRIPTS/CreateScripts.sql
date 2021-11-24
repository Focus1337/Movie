use reviefydb;

GO
CREATE TABLE Users
(
	user_id INT NOT NULL IDENTITY,
	password NVARCHAR(30) NOT NULL,
	email NVARCHAR(30) NOT NULL,
	name NVARCHAR(15) NOT NULL,
	second_name NVARCHAR(15) NOT NULL,
	register_date DATE NOT NULL,
	avatar NVARCHAR(30), -- url to avatar img 
	CONSTRAINT pk_user PRIMARY KEY(user_id)
)
GO

GO
CREATE TABLE Movies
(
	movie_id INT NOT NULL IDENTITY,
	title NVARCHAR(30) NOT NULL, 
	[length] INT NOT NULL check([length] >= 0),
	realese_date DATE NOT NULL,
	rating FLOAT NOT NULL default(0),
	storyline TEXT NOT NULL,
	director NVARCHAR(30) NOT NULL default('unknown'),
	budget INT NOT NULL check(budget >= 0),
	country NVARCHAR(30) NOT NULL,
	[language] NVARCHAR(30) NOT NULL,
	company NVARCHAR(30) NOT NULL default('unknown'),
	cover NVARCHAR(30), -- url to cover img 


	CONSTRAINT pk_movie PRIMARY KEY(movie_id),
)
GO

GO
CREATE TABLE Reviews
(
	review_id INT NOT NULL IDENTITY,
	user_id INT NOT NULL, --FK (poka xz kak imenno)
	movie_id INT NOT NULL, --FK (poka xz kak imenno)
	text TEXT NOT NULL,
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