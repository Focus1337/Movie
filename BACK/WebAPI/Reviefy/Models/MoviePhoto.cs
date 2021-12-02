using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace Reviefy.Models
{
    [Table(Name = "MoviePhotos")]
    public class MoviePhoto
    {
        [Column("photos_id"), PrimaryKey, NotNull]
        public Guid PhotosId { get; set; }

        [Column("movie_id"), NotNull] public Guid MovieId { get; set; }

        [Column("background"), NotNull] public string Background { get; set; }

        [Column("photo1"), NotNull] public string Photo1 { get; set; }
        
        [Column("photo2"), NotNull] public string Photo2 { get; set; }
       
        [Column("photo3"), NotNull] public string Photo3 { get; set; }
        
        [Column("photo4"), NotNull] public string Photo4 { get; set; }
        
        [Column("photo5"), NotNull] public string Photo5 { get; set; }
        
        [Column("photo6"), NotNull] public string Photo6 { get; set; }
        
        [Column("photo7"), NotNull] public string Photo7 { get; set; }
        
        [Column("photo8"), NotNull] public string Photo8 { get; set; }
        
        [Column("photo9"), NotNull] public string Photo9 { get; set; }
    }
}