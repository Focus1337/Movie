using System;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
	[Table(Name = "Movies")]
	public class Movie
	{
		[Column("movie_id"), PrimaryKey, Identity]
		public Guid MovieId { get; set; }

		[Column("title"), NotNull] public string Title { get; set; }

		[Column("duration"), NotNull] public int Duration { get; set; }

		[Column("genre"), NotNull] public string Genre { get; set; }

		[Column("release_date"), NotNull] public DateTime ReleaseDate { get; set; }

		[Column("rating"), NotNull] public double Rating { get; set; }

		[Column("storyline"), NotNull] public string Storyline { get; set; }

		[Column("director"), NotNull] public string Director { get; set; }

		[Column("budget"), NotNull] public int Budget { get; set; }

		[Column("country"), NotNull] public string Country { get; set; }

		[Column("language"), NotNull] public string Language { get; set; }

		[Column("company"), NotNull] public string Company { get; set; }

		[Column("poster_path"), Nullable] public string PosterPath { get; set; }
		
		[Column("trailer_path"), Nullable] public string TrailerPath { get; set; }

	}
}