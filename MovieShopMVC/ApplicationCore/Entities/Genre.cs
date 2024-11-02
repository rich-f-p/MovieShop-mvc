﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class Genre
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[Column(TypeName = "nvarchar(24)")]
		public string Name { get; set; }

		public ICollection<MovieGenre> MovieGenres { get; set; }
	}
}
