﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWeb.Models
{
	public class Muscle
	{
		[Required]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }
	}
}
