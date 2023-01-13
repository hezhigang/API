using System;
using System.Text.Json.Serialization;

namespace API.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public string CoverImageUrl { get; set;} = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Sku { get; set; } = string.Empty;
		public bool IsAvailable { get; set; }
		public int CategoryId { get; set; }
		[JsonIgnore]
		public virtual Category Category { get; set; }
	}
}

