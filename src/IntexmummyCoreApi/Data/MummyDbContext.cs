using System;
using Microsoft.EntityFrameworkCore;

namespace IntexmummyCoreApi.Data
{
	public class MummyDbContext : DbContext
	{
		public MummyDbContext() { }

		public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options) { }

		public virtual DbSet<Mummy> Joined_main { get; set; }

		public virtual DbSet<Burial> burialmain { get; set; }
	}
}

