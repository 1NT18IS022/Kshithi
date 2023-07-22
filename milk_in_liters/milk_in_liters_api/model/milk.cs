using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace milk_in_liters_api.model
{
    public class milk
    {
        public int id{ get; set; }


        [Required(ErrorMessage = "enter 1 for morning or 2 for evening")]
        public shifttype shift { get; set; }


        [Required(ErrorMessage = "enter date")]
        public DateTime? date{ get; set; }


        [Required(ErrorMessage = "enter milk in liters")]
        public float liters { get; set; }

      
        public float total_liters { get; set; }

        [Required(ErrorMessage ="enter member id")]
        [ForeignKey("member_Id")]
        public int member_Id { get; set; }  


    }
   public  enum shifttype
    {
        morning=1,
        evening=2
    }
}
