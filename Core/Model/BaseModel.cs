﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
   public class BaseModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
		public bool Deleted { get; set; }
	}
}
