﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	[PrimaryKey(nameof(RoleId), nameof(UserId))]
	public class UserRole
	{
		[Required]
		public int RoleId { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
