using System.ComponentModel.DataAnnotations.Schema;

namespace ViberWalkTracker.DAL.DALModels
{
    [Table("BotUser")]
    public class UserDAL
    {
        public string Id { get; set; }
        public string IMEI { get; set; }
    }
}
