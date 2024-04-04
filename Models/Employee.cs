using System.ComponentModel.DataAnnotations;

namespace ProConcept.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Department { get; set; }
    }
}
