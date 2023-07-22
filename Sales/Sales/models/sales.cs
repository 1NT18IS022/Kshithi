using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.models
{
    public class sales
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="please enter item name")]
        public string name { get; set; }

        [Required(ErrorMessage = "please enter item price")]
        public float price { get; set; }

        [Required(ErrorMessage = "please enter number of items")]
        public int quantity { get; set; }

        [Required(ErrorMessage ="enter date")]
        public DateTime date { get; set; }

        public int sold { get; set; }

        public int data { get;set; }
        public int type { get; set; }


    }
}
