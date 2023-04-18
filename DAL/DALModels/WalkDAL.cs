using System.ComponentModel.DataAnnotations.Schema;

namespace ViberWalkTracker.DAL.DALModels
{
    [Table("Walk")]
    public class WalkDAL
    {
        public int Id { get; set; }
        public string IMEI { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public decimal Distance { get; set; }
    }
}
