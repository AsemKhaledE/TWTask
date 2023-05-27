using System.ComponentModel.DataAnnotations;
using TWTask.Models;
using X.PagedList;

namespace TWTask.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed.")]
        public string? Name { get; set; }

        [Range(20, int.MaxValue, ErrorMessage = "You must be 20 years or older.")]
        public int Age { get; set; }

        public List<AddressDto> Addresses { get; set; } = new();
        [Required(ErrorMessage = "addresses list shouldn't be empty.")]

        public string? Description { get; set; }

    }
}
