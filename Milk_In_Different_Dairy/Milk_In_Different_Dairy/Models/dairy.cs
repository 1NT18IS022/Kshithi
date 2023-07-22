using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Milk_In_Different_Dairy.Models
{
    public class dairy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dairy_id { get; set; }


        [Required(ErrorMessage ="enter dairy name")]
        public string  Dairy_Name { get; set; }    
    }
}
