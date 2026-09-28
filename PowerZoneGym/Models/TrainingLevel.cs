using System.ComponentModel.DataAnnotations;

namespace PowerZoneGym.Models
{
    public class TrainingLevel
    {
        [Key]
        public int TrainingLevelID { get; set; }
        public string TrainingLevelName { get; set; }
        public virtual ICollection<GymTrainee> GymTrainees { get; set; }
    }
}
