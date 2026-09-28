using System.ComponentModel.DataAnnotations;

namespace PowerZoneGym.Models
{
    public class BloodGroup
    {
        [Key]
        public int BloodGroupID { get; set; }
        public string BloodGroupName { get; set; }

        public virtual ICollection<GymTrainee> GymTrainees { get; set; }

    }
}
