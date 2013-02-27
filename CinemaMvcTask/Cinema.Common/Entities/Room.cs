using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCommon.Entities
{
    public class Room : IValidatableObject
    {
        public int RoomId { get; set; }

        [DisplayName("Total seats")]
        public int MaxSeats { get; set; }

        [DisplayName("Seats taken")]
        public int ReservedSeats { get; set; }
        [DisplayName("Room")]
        public string Name { get; set; }

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int? MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [NotMapped]
        public virtual bool HasMovie
        {
            get { return Movie != null; }
        }

        [NotMapped, DisplayName("Seats available")]
        public virtual bool HasFreeSeats
        {
            get { return (MaxSeats - ReservedSeats) > 0; }
        }

        [NotMapped]
        public virtual double Income
        {
            get
            {
                if (HasMovie)
                {
                    return ReservedSeats * Movie.Price;
                }
                return 0;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReservedSeats > MaxSeats)
            {
                yield return new ValidationResult("Cannot give more seats than room has max seats",
                                                  new[] {"ReservedSeats"});
            }
            if (ReservedSeats < 0)
            {
                yield return new ValidationResult("Cannot remove more seats than room has reserved seats",
                                                  new[] { "ReservedSeats" });
            }
        }
    }
}
