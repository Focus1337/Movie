using System;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
	[Table(Name = "Reviews")]
	public class Review
	{
		[Column("review_id"), PrimaryKey, NotNull]
		public Guid ReviewId { get; set; }// = Guid.NewGuid();

		[Column("user_id"), NotNull] public Guid UserId { get; set; }

		[Column("movie_id"), NotNull] public Guid MovieId { get; set; }

		[Column("text"), NotNull] public string Text { get; set; }

		[Column("review_date"), NotNull] public DateTime ReviewDate { get; set; }

		[Column("rating"), NotNull] public int Rating { get; set; }

		[Column("helpfulness"), NotNull] public int Helpfulness { get; set; }
	}
}