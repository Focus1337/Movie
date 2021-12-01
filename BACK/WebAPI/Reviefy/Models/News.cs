using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
    [Table(Name = "News")]
    public class News
    {
        [Column("news_id"), PrimaryKey, NotNull]
        public Guid NewsId { get; set; }// = Guid.NewGuid();

        [Column("poster_path"), NotNull]
        public string PosterPath { get; set; }
        
        [Column("title"), NotNull]
        public string Title { get; set; }
        
        [Column("news_date"), NotNull] 
        public DateTime NewsDate { get; set; }
        
        [Column("text"), NotNull]
        public string Text { get; set; }
    }
}