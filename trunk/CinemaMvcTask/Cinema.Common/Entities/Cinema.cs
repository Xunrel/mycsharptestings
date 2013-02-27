using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CinemaCommon.Entities
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        [DisplayName("Cinema")]
        public string Name { get; set; }

        public virtual List<Room> Rooms { get; set; }
        
        [NotMapped]
        public virtual bool HasRooms
        {
            get
            {
                if (Rooms != null)
                {
                    return Rooms.Count > 0;
                }
                return false;
            }
        }

        [NotMapped, DisplayName("Total income")]
        public double TotalIncome
        {
            get
            {
                double total = 0;
                if (HasRooms)
                {
                    total += Rooms.Sum(room => room.Income);
                }
                return total;
            }
        }
    }
}
