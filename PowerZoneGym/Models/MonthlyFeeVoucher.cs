using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerZoneGym.Models
{
    public class MonthlyFeeVoucher
    {
        [Key]
        public int MonthlyFeeID { get; set;  }
        //timestamp

        [DataType(DataType.Date)]
        public DateTime FeeDate { get; set; } = DateTime.Now;

        public string Remarks { get; set;  }
        public string Status {  get; set; }

        [ForeignKey("GymTrainee")]
        public int TraineeId { get; set; }
        public GymTrainee GymTrainee { get; set;  }



    }
}
