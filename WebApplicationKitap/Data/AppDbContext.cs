using Microsoft.EntityFrameworkCore;
using WebApplicationKitap.Models;

namespace WebApplicationKitap.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
		{

		}
		public DbSet<Kitap> Kitaps { get; set; }
		public DbSet<Yazar> Yazars { get; set; }
	}
}
