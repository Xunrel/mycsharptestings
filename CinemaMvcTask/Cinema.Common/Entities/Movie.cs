using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCommon.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        [DisplayName("Movie")]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
