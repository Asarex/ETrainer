﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models
{
	public class Exercise
	{
		[Required]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public IEnumerable<int> UseMuscles { get; set; }
	}
}
