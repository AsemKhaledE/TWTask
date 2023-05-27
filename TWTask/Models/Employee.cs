using System.ComponentModel.DataAnnotations;

namespace TWTask.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed.")]
        public string? Name { get; set; }

        [Range(20, int.MaxValue, ErrorMessage = "You must be 20 years or older.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "addresses list shouldn't be empty.")]
        public List<Address>? Addresses { get; set; }
    }
}
