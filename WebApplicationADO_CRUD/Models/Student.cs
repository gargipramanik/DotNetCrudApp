using System.ComponentModel.DataAnnotations;

namespace WebApplicationADO_CRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Fname { get; set; }
        [MaxLength(50)]
        public string Lname { get; set; }
        //[MaxLength(10)] because we will insert this by radio button
        public string Gender { get; set; }
        //[DataType(DataType.Date)]
        public DateOnly DOB { get; set; }
        [MaxLength(50)]
        public string Department { get; set; }
    }
}
