using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

/// <summary>
/// It is important that the namespace of 
/// the buddy class and the real class are the same
/// </summary>
namespace HelperMethods.Models
{
	/// <summary>
	/// The buddy class only needs to contain properties that we want to apply metadata to—we do not have
	/// to replicate all of the properties of the Person class, for example.
	/// </summary>
	[DisplayName("New Person")]
	public partial class PersonMetaData
	{
		[HiddenInput(DisplayValue = false)]
		public int PersonId { get; set; }

		[Display(Name = "First")]
		[UIHint("MultilineText")]
		public string FirstName { get; set; }

		[Display(Name = "Last")]
		public string LastName { get; set; }

		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }

		public Address HomeAddress { get; set; }

		[Display(Name = "Approved")]
		public bool IsApproved { get; set; }
		public Role Role { get; set; }
	}
}