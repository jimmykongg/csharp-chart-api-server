using Microsoft.EntityFrameworkCore;

namespace ChartServer;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<ChartData> ChartData { get; set; }
}

public class ChartData
{
    public int Id { get; set; }
    public string Label { get; set; }
    public int Value { get; set; }
}