using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMatLibrary
{
	public class MannazRestAppDbContext : DbContext
	{
		public MannazRestAppDbContext(DbContextOptions<MannazRestAppDbContext> options) : base(options)
		{
			
		}

		public DbSet<MouseMat> MouseMats { get; set; }
	}
}
