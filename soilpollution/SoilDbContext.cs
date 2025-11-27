namespace soilpollution;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Point
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public required string Name { get; set; } // e.g., "P-1"

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public required ICollection<DepthLayer> DepthLayers { get; set; }
}

public class DepthLayer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public required string DepthRange { get; set; } // e.g., "0-5", "5-20"

    public int PointId { get; set; }
    [ForeignKey("PointId")]
    public required Point Point { get; set; }

    public required ICollection<Measurement> Measurements { get; set; }
}

public class Measurement
{
    [Key]
    public int Id { get; set; }

    public double Zn { get; set; } // Zn, 23 mg/kg
    public double Cu { get; set; } // Cu, 3.0 mg/kg
    public double Cd { get; set; } // Cd, 0.5 mg/kg
    public double Pb { get; set; } // Pb, 32 mg/kg

    public int DepthLayerId { get; set; }
    [ForeignKey("DepthLayerId")]
    public required DepthLayer DepthLayer { get; set; }
}

public class SoilDbContext : DbContext
{
    public SoilDbContext(DbContextOptions<SoilDbContext> options)
        : base(options)
    {
    }

    public DbSet<Point> Points { get; set; } = null!;
    public DbSet<DepthLayer> DepthLayers { get; set; } = null!;
    public DbSet<Measurement> Measurements { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure relationships and constraints
        modelBuilder.Entity<Point>()
            .HasMany(p => p.DepthLayers)
            .WithOne(d => d.Point)
            .HasForeignKey(d => d.PointId);

        modelBuilder.Entity<DepthLayer>()
            .HasMany(d => d.Measurements)
            .WithOne(m => m.DepthLayer)
            .HasForeignKey(m => m.DepthLayerId);
    }
}
