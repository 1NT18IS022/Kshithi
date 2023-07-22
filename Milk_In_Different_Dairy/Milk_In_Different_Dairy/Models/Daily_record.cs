using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Milk_In_Different_Dairy.Models
{
    public class Daily_record
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="enter liters")]
        public float liters { get; set; }



 



        [Required(ErrorMessage = "enter date")]
        public DateTime date{ get;set; }



        [Required(ErrorMessage = "enter dairy id")]
        [ForeignKey("dairy")]
        public int Dairy_Id { get; set; } 
    
       

    }
}
