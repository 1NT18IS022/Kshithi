using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace milk_in_liters_api.model
{
    public class member
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int member_Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string member_Name { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int age { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public genderLevel gender { get; set; }

        [Required(ErrorMessage = "Please enter aadhar_number")]
        public string aadhar_number { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [DataType(DataType.PhoneNumber)]
        public string phone_number { get; set; }



    }
    public enum genderLevel
    {
        male = 1,
        female = 2
    }

}
