using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Models
{
    public class CreatePersonViewModel
    {
		[DataType(DataType.Text)]
		[Display(Name = "Name: ")]
		[Required(ErrorMessage = "Name is required!"), MaxLength(80), MinLength(4)]
		public string Name { get; set; }

		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone number: ")]
		public string PhoneNr { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "City: ")]
		public string City { get; set; }


		public int Id { get; set; }

		public CreatePersonViewModel()
		{
		}
	}
}
