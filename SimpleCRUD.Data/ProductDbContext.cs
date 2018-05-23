using System.Data.Entity;

namespace SimpleCRUD.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("ProductContextDB") { }
        public virtual DbSet<TrainingProduct> TrainingProduct { get; set; }
    }
}
